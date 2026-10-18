using System;
using System.Collections.Generic;
using System.Linq;
using Datos;
using Entidad;

namespace Negocio
{
    /// <summary>Reglas basicas y coordinacion de operaciones de Cotizaciones.</summary>
    public class CotizacionNegocio
    {
        private readonly CotizacionDatos datos = new CotizacionDatos();

        public List<Cotizacion> Listar()
        {
            return datos.Listar();
        }

        public List<Cotizacion> Buscar(string texto, string estado)
        {
            return datos.Buscar((texto ?? string.Empty).Trim(), estado);
        }

        public List<Cliente> ListarClientes() { return datos.ListarClientes(); }
        public List<Sucursal> ListarSucursales() { return datos.ListarSucursales(); }
        public List<TipoServicio> ListarTiposServicio() { return datos.ListarTiposServicio(); }

        public int Insertar(Cotizacion cotizacion)
        {
            Validar(cotizacion);
            return datos.Insertar(cotizacion);
        }

        public int Actualizar(Cotizacion cotizacion)
        {
            Validar(cotizacion);
            if (cotizacion.CodigoCotizacion <= 0)
                throw new ArgumentException("Selecciona una cotizacion valida para editar.");
            return datos.Actualizar(cotizacion);
        }

        public int Eliminar(int codigo)
        {
            if (codigo <= 0)
                throw new ArgumentException("Selecciona una cotizacion valida para eliminar.");
            return datos.Eliminar(codigo);
        }

        private void Validar(Cotizacion cotizacion)
        {
            if (cotizacion == null)
                throw new ArgumentException("No se recibieron los datos de la cotizacion.");
            if (cotizacion.CodigoTipoServicio <= 0 || cotizacion.CodigoSucursal <= 0 ||
                cotizacion.CodigoCliente <= 0)
                throw new ArgumentException("Selecciona cliente, sucursal y tipo de servicio.");
            if (string.IsNullOrWhiteSpace(cotizacion.NombreCotizador) ||
                cotizacion.NombreCotizador.Length > 45)
                throw new ArgumentException("El nombre del cotizador es obligatorio y admite hasta 45 caracteres.");
            if (string.IsNullOrWhiteSpace(cotizacion.DireccionCotizador) ||
                cotizacion.DireccionCotizador.Length > 150)
                throw new ArgumentException("La direccion es obligatoria y admite hasta 150 caracteres.");
            if (string.IsNullOrWhiteSpace(cotizacion.Descripcion) ||
                cotizacion.Descripcion.Length > 150)
                throw new ArgumentException("La descripcion es obligatoria y admite hasta 150 caracteres.");
            if (cotizacion.Cantidad <= 0)
                throw new ArgumentException("La cantidad debe ser mayor que cero.");
            if (cotizacion.Precio < 0 || cotizacion.Subtotal < 0 || cotizacion.Total < 0)
                throw new ArgumentException("Precio, subtotal y total no pueden ser negativos.");
        }

        /// <summary>El resumen se calcula sobre toda la tabla, sin paginacion.</summary>
        public ResumenModulo ObtenerResumen()
        {
            List<Cotizacion> lista = datos.Listar() ?? new List<Cotizacion>();
            ResumenModulo resumen = new ResumenModulo();
            resumen.Total = lista.Count;
            resumen.TituloEstado = "Registros por estado";
            resumen.PorEstado = ResumenHelper.Contar(
                lista.Select(x => x.Estado ? "Activo" : "Inactivo"),
                new string[] { "Activo", "Inactivo" }, 0);
            resumen.TituloCategoria = "Cotizaciones por cotizador";
            resumen.PorCategoria = ResumenHelper.Contar(
                lista.Select(x => x.NombreCotizador), new string[] { }, 6);
            resumen.TieneMonto = true;
            resumen.EtiquetaMonto = "Monto cotizado";
            resumen.MontoEsMoneda = true;
            resumen.MontoTotal = lista.Sum(x => x.Total);
            return resumen;
        }
    }
}
