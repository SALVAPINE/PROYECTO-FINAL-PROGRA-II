using System;
using System.Collections.Generic;
using System.Linq;
using Datos;
using Entidad;

namespace Negocio
{
    /// <summary>
    /// Capa de negocio de detalles de compra: validaciones y reglas; llama a la capa de datos.
    /// </summary>
    public class DetalleCompraNegocio
    {
        private readonly DetalleCompraDatos datos = new DetalleCompraDatos();

        public List<DetalleCompra> Listar()
        {
            return datos.Listar();
        }

        public List<DetalleCompra> Buscar(string texto, string estado)
        {
            return datos.Buscar(texto, estado);
        }

        public int Insertar(DetalleCompra detalleCompra)
        {
            Validar(detalleCompra);
            return datos.Insertar(detalleCompra);
        }

        public int Actualizar(DetalleCompra detalleCompra)
        {
            Validar(detalleCompra);
            if (detalleCompra.CodigoDetalleCompra <= 0)
                throw new ArgumentException("Selecciona un detalle válido para editar.");
            return datos.Actualizar(detalleCompra);
        }

        public int Eliminar(int codigo)
        {
            if (codigo <= 0)
                throw new ArgumentException("Selecciona un detalle válido para eliminar.");
            return datos.Eliminar(codigo);
        }

        /// <summary>Consulta solo las líneas que pertenecen a una compra.</summary>
        public List<DetalleCompra> ListarPorCompra(int codigoCompra)
        {
            if (codigoCompra <= 0) return new List<DetalleCompra>();
            return datos.ListarPorCompra(codigoCompra);
        }

        public List<DetalleCompra> BuscarPorCompra(int codigoCompra, string texto)
        {
            if (codigoCompra <= 0) return new List<DetalleCompra>();
            return datos.BuscarPorCompra(codigoCompra, texto);
        }

        /// <summary>Actualiza el encabezado y su línea seleccionada dentro de una transacción.</summary>
        public int ActualizarCompraConDetalle(Compra compra, DetalleCompra detalle)
        {
            ValidarCompra(compra);
            if (detalle == null)
                throw new ArgumentException("No se recibieron los datos del detalle de compra.");
            detalle.Subtotal = CompraNegocio.CalcularSubtotalDetalle(
                compra.CantidadComprada, detalle.PrecioUnitario, detalle.DescuentoCompra);
            Validar(detalle);
            if (compra.CodigoCompra <= 0 || detalle.CodigoDetalleCompra <= 0)
                throw new ArgumentException("Selecciona una compra y un detalle válidos para editar.");
            if (detalle.CodigoCompra != compra.CodigoCompra)
                throw new ArgumentException("El detalle seleccionado no pertenece a esta compra.");

            List<DetalleCompra> existentes = datos.ListarPorCompra(compra.CodigoCompra) ?? new List<DetalleCompra>();
            compra.TotalCompra = existentes
                .Where(x => x.CodigoDetalleCompra != detalle.CodigoDetalleCompra)
                .Sum(x => x.Subtotal)
                + detalle.Subtotal;
            ValidarCompra(compra);
            return new CompraDatos().ActualizarConDetalle(compra, detalle);
        }

        public int Eliminar(int codigoDetalle, int codigoCompra)
        {
            if (codigoDetalle <= 0 || codigoCompra <= 0)
                throw new ArgumentException("Selecciona un detalle de compra válido para eliminar.");
            int filasAfectadas = datos.Eliminar(codigoDetalle, codigoCompra);
            if (filasAfectadas != 1)
                throw new InvalidOperationException("El detalle no existe o no pertenece a esta compra.");
            new CompraNegocio().RecalcularTotalDesdeDetalles(codigoCompra);
            return filasAfectadas;
        }

        private static void Validar(DetalleCompra detalleCompra)
        {
            if (detalleCompra == null)
                throw new ArgumentException("No se recibieron los datos del detalle.");
            if (detalleCompra.CodigoCompra <= 0)
                throw new ArgumentException("El detalle debe pertenecer a una compra guardada.");
            if (string.IsNullOrWhiteSpace(detalleCompra.TipoDeCompra) || detalleCompra.TipoDeCompra.Length > 45)
                throw new ArgumentException("El tipo de compra es obligatorio y admite hasta 45 caracteres.");
            if (string.IsNullOrWhiteSpace(detalleCompra.Descripcion) || detalleCompra.Descripcion.Length > 150)
                throw new ArgumentException("La descripción es obligatoria y admite hasta 150 caracteres.");
            if (detalleCompra.PrecioUnitario < 0 || detalleCompra.DescuentoCompra < 0 || detalleCompra.Subtotal < 0)
                throw new ArgumentException("Los montos del detalle no pueden ser negativos.");
        }

        private static void ValidarCompra(Compra compra)
        {
            if (compra == null) throw new ArgumentException("No se recibieron los datos de la compra.");
            if (compra.CodigoProveedor <= 0) throw new ArgumentException("Selecciona un proveedor.");
            if (compra.CodigoMaterial <= 0) throw new ArgumentException("Selecciona un material.");
            if (compra.CantidadComprada <= 0) throw new ArgumentException("La cantidad comprada debe ser mayor que cero.");
            if (compra.TotalCompra < 0) throw new ArgumentException("El total de la compra no puede ser negativo.");
            if (compra.FechaEntrega.Date < compra.FechaCompra.Date)
                throw new ArgumentException("La fecha de entrega no puede ser anterior a la fecha de compra.");
        }

    }
}
