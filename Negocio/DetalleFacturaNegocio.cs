using System;
using System.Collections.Generic;
using System.Linq;
using Datos;
using Entidad;

namespace Negocio
{
    /// <summary>
    /// Capa de negocio de detalles de factura: validaciones y reglas; llama a la capa de datos.
    /// </summary>
    public class DetalleFacturaNegocio
    {
        private readonly DetalleFacturaDatos datos = new DetalleFacturaDatos();

        public List<DetalleFactura> Listar()
        {
            return datos.Listar();
        }

        public List<DetalleFactura> Buscar(string texto, string estado)
        {
            return datos.Buscar(texto, estado);
        }

        /// <summary>Consulta solo los detalles cuyo encabezado es la factura indicada.</summary>
        public List<DetalleFactura> ListarPorFactura(int codigoFacturacion)
        {
            if (codigoFacturacion <= 0)
                return new List<DetalleFactura>();

            return datos.ListarPorFactura(codigoFacturacion);
        }

        public List<DetalleFactura> BuscarPorFactura(int codigoFacturacion, string texto)
        {
            if (codigoFacturacion <= 0)
                return new List<DetalleFactura>();
            return datos.BuscarPorFactura(codigoFacturacion, texto);
        }

        public int Insertar(DetalleFactura detalleFactura)
        {
            Validar(detalleFactura);
            return datos.Insertar(detalleFactura);
        }

        public int Actualizar(DetalleFactura detalleFactura)
        {
            Validar(detalleFactura);
            if (detalleFactura.CodigoDetalleFactura <= 0)
                throw new ArgumentException("Selecciona un concepto válido para editar.");
            return datos.Actualizar(detalleFactura);
        }

        public int Eliminar(int codigo)
        {
            if (codigo <= 0)
                throw new ArgumentException("Selecciona un concepto válido para eliminar.");
            return datos.Eliminar(codigo);
        }

        public int Eliminar(int codigoDetalle, int codigoFacturacion)
        {
            if (codigoDetalle <= 0 || codigoFacturacion <= 0)
                throw new ArgumentException("Selecciona un concepto de factura válido para eliminar.");
            int filasAfectadas = datos.Eliminar(codigoDetalle, codigoFacturacion);
            if (filasAfectadas != 1)
                throw new InvalidOperationException("El concepto no existe o no pertenece a esta factura.");
            new FacturaNegocio().RecalcularTotalesDesdeDetalles(codigoFacturacion);
            return filasAfectadas;
        }

        private static void Validar(DetalleFactura detalleFactura)
        {
            if (detalleFactura == null)
                throw new ArgumentException("No se recibieron los datos del concepto.");
            if (detalleFactura.CodigoFacturacion <= 0)
                throw new ArgumentException("El concepto debe pertenecer a una factura guardada.");
            if (string.IsNullOrWhiteSpace(detalleFactura.Descripcion) || detalleFactura.Descripcion.Length > 150)
                throw new ArgumentException("La descripción es obligatoria y admite hasta 150 caracteres.");
            if (detalleFactura.Cantidad <= 0)
                throw new ArgumentException("La cantidad debe ser mayor que cero.");
            if (detalleFactura.Precio < 0 || detalleFactura.DescuentoAplicado < 0)
                throw new ArgumentException("Los montos del concepto no pueden ser negativos.");
            if (detalleFactura.DescuentoAplicado > detalleFactura.Precio * detalleFactura.Cantidad)
                throw new ArgumentException("El descuento no puede superar el total del concepto.");
        }

    }
}
