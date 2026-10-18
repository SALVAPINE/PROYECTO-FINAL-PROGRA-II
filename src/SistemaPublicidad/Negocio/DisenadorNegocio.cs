using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
            if (string.IsNullOrWhiteSpace(estado)) estado = "Todos";
            if (estado != "Todos" && estado != "Activo" && estado != "Inactivo")
                throw new ArgumentException("Selecciona un filtro de estado válido.");
            return datos.Buscar((texto ?? string.Empty).Trim(), estado);
        }

        public int Insertar(Disenador disenador)
        {
            Validar(disenador, false);
            return datos.Insertar(disenador);
        }

        public int Actualizar(Disenador disenador)
        {
            Validar(disenador, true);
            return datos.Actualizar(disenador);
        }

        public int Eliminar(int codigo)
        {
            if (codigo <= 0) throw new ArgumentException("Selecciona un diseñador válido.");
            try
            {
                return datos.Eliminar(codigo);
            }
            catch (SqlException ex)
            {
                if (ex.Number == 547)
                    throw new InvalidOperationException(
                        "No se puede eliminar: el diseñador tiene diseños u órdenes de trabajo relacionados.", ex);
                throw;
            }
        }

        // Reglas básicas; no se cambian tipos, longitudes ni relaciones de SQL Server.
        private static void Validar(Disenador disenador, bool requiereCodigo)
        {
            if (disenador == null) throw new ArgumentNullException("disenador");
            if (requiereCodigo && disenador.CodigoDiseñador <= 0)
                throw new ArgumentException("Selecciona un diseñador válido para editar.");
            if (string.IsNullOrWhiteSpace(disenador.NombreDiseñador) || disenador.NombreDiseñador.Length > 45)
                throw new ArgumentException("El nombre es obligatorio y admite hasta 45 caracteres.");
            if (disenador.Edad <= 0)
                throw new ArgumentException("La edad debe ser mayor que cero.");
            if (string.IsNullOrWhiteSpace(disenador.Especialidad) || disenador.Especialidad.Length > 45)
                throw new ArgumentException("La especialidad es obligatoria y admite hasta 45 caracteres.");
            if (disenador.Telefono <= 0)
                throw new ArgumentException("El teléfono debe ser un entero positivo.");
            if (string.IsNullOrWhiteSpace(disenador.Correo) || disenador.Correo.Length > 150)
                throw new ArgumentException("El correo es obligatorio y admite hasta 150 caracteres.");
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
