using System;
using System.Collections.Generic;
using System.Linq;
using Datos;
using Entidad;

namespace Negocio
{
    /// <summary>
    /// Capa de negocio de órdenes de trabajo: validaciones y reglas; llama a la capa de datos.
    /// </summary>
    public class OrdenTrabajoNegocio
    {
        private readonly OrdenTrabajoDatos datos = new OrdenTrabajoDatos();

        public List<OrdenTrabajo> Listar()
        {
            return datos.Listar();
        }

        public List<OrdenTrabajo> Buscar(string texto, string estado)
        {
            return datos.Buscar(texto, estado);
        }

        public int Insertar(OrdenTrabajo ordenTrabajo)
        {
            Validar(ordenTrabajo);
            return datos.Insertar(ordenTrabajo);
        }

        public int Actualizar(OrdenTrabajo ordenTrabajo)
        {
            Validar(ordenTrabajo);
            if (ordenTrabajo.CodigoOrdenTrabajo <= 0)
                throw new ArgumentException("Selecciona una orden válida para editar.");
            return datos.Actualizar(ordenTrabajo);
        }

        public int Eliminar(int codigo)
        {
            if (codigo <= 0)
                throw new ArgumentException("Selecciona una orden válida para eliminar.");
            return datos.Eliminar(codigo);
        }

        private static void Validar(OrdenTrabajo ordenTrabajo)
        {
            if (ordenTrabajo == null)
                throw new ArgumentException("No se recibieron los datos de la orden.");
            if (ordenTrabajo.CodigoSucursal <= 0)
                throw new ArgumentException("Selecciona una sucursal.");
            if (ordenTrabajo.CodigoTipoServicio <= 0)
                throw new ArgumentException("Selecciona un tipo de servicio.");
            if (ordenTrabajo.CodigoCotizacion <= 0)
                throw new ArgumentException("Selecciona una cotización.");
            if (ordenTrabajo.CodigoDiseñador <= 0)
                throw new ArgumentException("Selecciona un diseñador.");
            if (string.IsNullOrWhiteSpace(ordenTrabajo.NombreOrdenTrabajo) || ordenTrabajo.NombreOrdenTrabajo.Length > 100)
                throw new ArgumentException("El nombre de la orden es obligatorio y admite hasta 100 caracteres.");
            if (string.IsNullOrWhiteSpace(ordenTrabajo.TipoDeOrden) || ordenTrabajo.TipoDeOrden.Length > 100)
                throw new ArgumentException("El tipo de orden es obligatorio y admite hasta 100 caracteres.");
            if (ordenTrabajo.Descripcion != null && ordenTrabajo.Descripcion.Length > 150)
                throw new ArgumentException("La descripción admite hasta 150 caracteres.");
            if (ordenTrabajo.FechaFinalizacion.Date < ordenTrabajo.FechaInicio.Date)
                throw new ArgumentException("La fecha de finalización no puede ser anterior a la fecha de inicio.");
        }

        /// <summary>Resumen del módulo (se muestra en la pestaña Resumen).</summary>
        public ResumenModulo ObtenerResumen()
        {
            List<OrdenTrabajo> lista = datos.Listar() ?? new List<OrdenTrabajo>();
            ResumenModulo r = new ResumenModulo();
            r.Total = lista.Count;
            r.TituloEstado = "Registros por estado";
            r.PorEstado = ResumenHelper.Contar(lista.Select(x => x.Estado ? "Activo" : "Inactivo"), new string[] { "Activo", "Inactivo" }, 0);
            r.TituloCategoria = "Órdenes por tipo";
            r.PorCategoria = ResumenHelper.Contar(lista.Select(x => x.TipoDeOrden), new string[] {  }, 6);
            return r;
        }
    }
}
