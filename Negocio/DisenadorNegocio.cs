using System;
using System.Collections.Generic;
using System.Linq;
using Datos;
using Entidad;

namespace Negocio
{
    /// <summary>
    /// Capa de negocio de diseñadores: validaciones y reglas; llama a la capa de datos.
    /// </summary>
    public class DisenadorNegocio
    {
        private readonly DisenadorDatos datos = new DisenadorDatos();

        public List<Disenador> Listar()
        {
            return datos.Listar();
        }

        public List<Disenador> Buscar(string texto, string estado)
        {
            return datos.Buscar(texto, estado);
        }

        public int Insertar(Disenador disenador)
        {
            Validar(disenador);
            return datos.Insertar(disenador);
        }

        public int Actualizar(Disenador disenador)
        {
            Validar(disenador);
            if (disenador.CodigoDiseñador <= 0)
                throw new ArgumentException("Selecciona un diseñador válido para editar.");
            return datos.Actualizar(disenador);
        }

        public int Eliminar(int codigo)
        {
            if (codigo <= 0)
                throw new ArgumentException("Selecciona un diseñador válido para eliminar.");
            return datos.Eliminar(codigo);
        }

        private static void Validar(Disenador disenador)
        {
            if (disenador == null)
                throw new ArgumentException("No se recibieron los datos del diseñador.");
            if (string.IsNullOrWhiteSpace(disenador.NombreDiseñador) || disenador.NombreDiseñador.Length > 45)
                throw new ArgumentException("El nombre del diseñador es obligatorio y admite hasta 45 caracteres.");
            if (disenador.Edad < 1 || disenador.Edad > 120)
                throw new ArgumentException("La edad debe estar entre 1 y 120 años.");
            if (string.IsNullOrWhiteSpace(disenador.Especialidad) || disenador.Especialidad.Length > 45)
                throw new ArgumentException("La especialidad es obligatoria y admite hasta 45 caracteres.");
            if (disenador.Telefono <= 0)
                throw new ArgumentException("El teléfono debe ser un número mayor que cero.");
            if (string.IsNullOrWhiteSpace(disenador.Correo) || disenador.Correo.Length > 150)
                throw new ArgumentException("El correo es obligatorio y admite hasta 150 caracteres.");
            if (disenador.Correo.IndexOf('@') <= 0)
                throw new ArgumentException("Escribe un correo electrónico válido.");
        }

        /// <summary>Resumen del módulo (se muestra en la pestaña Resumen).</summary>
        public ResumenModulo ObtenerResumen()
        {
            List<Disenador> lista = datos.Listar() ?? new List<Disenador>();
            ResumenModulo r = new ResumenModulo();
            r.Total = lista.Count;
            r.TituloEstado = "Registros por estado";
            r.PorEstado = ResumenHelper.Contar(lista.Select(x => x.Estado ? "Activo" : "Inactivo"), new string[] { "Activo", "Inactivo" }, 0);
            r.TituloCategoria = "Diseñadores por especialidad";
            r.PorCategoria = ResumenHelper.Contar(lista.Select(x => x.Especialidad), new string[] {  }, 6);
            return r;
        }
    }
}
