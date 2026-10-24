using System;
using System.Collections.Generic;
using System.Linq;
using Datos;
using Entidad;

namespace Negocio
{
    /// <summary>
    /// Capa de negocio de diseños: validaciones y reglas; llama a la capa de datos.
    /// </summary>
    public class DisenoNegocio
    {
        private readonly DisenoDatos datos = new DisenoDatos();

        public List<Diseno> Listar()
        {
            return datos.Listar();
        }

        public List<Diseno> Buscar(string texto, string estado)
        {
            return datos.Buscar(texto, estado);
        }

        public int Insertar(Diseno diseno)
        {
            Validar(diseno);
            return datos.Insertar(diseno);
        }

        public int Actualizar(Diseno diseno)
        {
            Validar(diseno);
            if (diseno.CodigoDiseño <= 0)
                throw new ArgumentException("Selecciona un diseño válido para editar.");
            return datos.Actualizar(diseno);
        }

        public int Eliminar(int codigo)
        {
            if (codigo <= 0)
                throw new ArgumentException("Selecciona un diseño válido para eliminar.");
            return datos.Eliminar(codigo);
        }

        private static void Validar(Diseno diseno)
        {
            if (diseno == null)
                throw new ArgumentException("No se recibieron los datos del diseño.");
            if (diseno.CodigoCliente <= 0)
                throw new ArgumentException("Selecciona un cliente.");
            if (diseno.CodigoDiseñador <= 0)
                throw new ArgumentException("Selecciona un diseñador.");
            if (string.IsNullOrWhiteSpace(diseno.NombreDiseño) || diseno.NombreDiseño.Length > 45)
                throw new ArgumentException("El nombre del diseño es obligatorio y admite hasta 45 caracteres.");
            if (string.IsNullOrWhiteSpace(diseno.TipoDiseño) || diseno.TipoDiseño.Length > 45)
                throw new ArgumentException("El tipo de diseño es obligatorio y admite hasta 45 caracteres.");
            if (diseno.Descripcion != null && diseno.Descripcion.Length > 150)
                throw new ArgumentException("La descripción admite hasta 150 caracteres.");
            if (diseno.RangoDiseño != null && diseno.RangoDiseño.Length > 45)
                throw new ArgumentException("El rango admite hasta 45 caracteres.");
        }

        /// <summary>Resumen del módulo (se muestra en la pestaña Resumen).</summary>
        public ResumenModulo ObtenerResumen()
        {
            List<Diseno> lista = datos.Listar() ?? new List<Diseno>();
            ResumenModulo r = new ResumenModulo();
            r.Total = lista.Count;
            r.TituloEstado = "Registros por estado";
            r.PorEstado = ResumenHelper.Contar(lista.Select(x => x.Estado ? "Activo" : "Inactivo"), new string[] { "Activo", "Inactivo" }, 0);
            r.TituloCategoria = "Diseños por tipo";
            r.PorCategoria = ResumenHelper.Contar(lista.Select(x => x.TipoDiseño), new string[] {  }, 6);
            return r;
        }
    }
}
