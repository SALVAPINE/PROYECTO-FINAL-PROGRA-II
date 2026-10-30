using System;
using System.Collections.Generic;
using System.Linq;
using Datos;
using Entidad;

namespace Negocio
{
    /// <summary>
    /// Capa de negocio de facturas: validaciones y reglas; llama a la capa de datos.
    /// </summary>
    public class FacturaNegocio
    {
        private readonly FacturaDatos datos = new FacturaDatos();
        private readonly DetalleFacturaDatos detalles = new DetalleFacturaDatos();

        public List<Factura> Listar()
        {
            return datos.Listar();
        }

        public FacturaDocumento ObtenerDocumento(int codigoFacturacion)
        {
            if (codigoFacturacion <= 0)
                throw new ArgumentException("Selecciona una factura válida para generar el documento.");
            return datos.ObtenerDocumento(codigoFacturacion);
        }

        public List<Factura> Buscar(string texto, string estado)
        {
            return datos.Buscar(texto, estado);
        }

        public int Insertar(Factura factura)
        {
            Validar(factura);
            return datos.Insertar(factura);
        }

        /// <summary>Inserta y devuelve el código generado para enlazar los conceptos.</summary>
        public int InsertarYObtenerCodigo(Factura factura)
        {
            Validar(factura);
            return datos.InsertarYObtenerCodigo(factura);
        }

        /// <summary>Valida e inserta la factura con su primer concepto.</summary>
        public int InsertarConDetalle(Factura factura, DetalleFactura detalle)
        {
            if (factura == null)
                throw new ArgumentException("No se recibieron los datos de la factura.");
            ValidarDetalle(detalle);
            factura.Subtotal = CalcularSubtotalDetalle(detalle);
            Validar(factura);
            return datos.InsertarConDetalle(factura, detalle);
        }

        public int Actualizar(Factura factura)
        {
            Validar(factura);
            if (factura.CodigoFacturacion <= 0)
                throw new ArgumentException("Selecciona una factura válida para editar.");
            return datos.Actualizar(factura);
        }

        /// <summary>Actualiza la factura y un concepto relacionado juntos.</summary>
        public int ActualizarConDetalle(Factura factura, DetalleFactura detalle)
        {
            if (factura == null)
                throw new ArgumentException("No se recibieron los datos de la factura.");
            ValidarDetalle(detalle);
            if (factura.CodigoFacturacion <= 0 || detalle.CodigoDetalleFactura <= 0)
                throw new ArgumentException("Selecciona una factura y un concepto válidos para editar.");
            if (detalle.CodigoFacturacion != factura.CodigoFacturacion)
                throw new ArgumentException("El concepto seleccionado no pertenece a esta factura.");
            factura.Subtotal = CalcularSubtotalFactura(factura.CodigoFacturacion, detalle);
            Validar(factura);
            return datos.ActualizarConDetalle(factura, detalle);
        }

        /// <summary>Valida y actualiza la factura junto con un concepto nuevo.</summary>
        public int ActualizarConNuevoDetalle(Factura factura, DetalleFactura detalle)
        {
            if (factura == null)
                throw new ArgumentException("No se recibieron los datos de la factura.");
            ValidarDetalle(detalle);
            if (factura.CodigoFacturacion <= 0)
                throw new ArgumentException("Selecciona una factura válida para agregar el concepto.");
            factura.Subtotal = CalcularSubtotalFactura(factura.CodigoFacturacion, detalle);
            Validar(factura);
            return datos.ActualizarConNuevoDetalle(factura, detalle);
        }

        public int Eliminar(int codigo)
        {
            if (codigo <= 0)
                throw new ArgumentException("Selecciona una factura válida para eliminar.");
            return datos.Eliminar(codigo);
        }

        public void RecalcularTotalesDesdeDetalles(int codigoFacturacion)
        {
            if (codigoFacturacion <= 0)
                throw new ArgumentException("Selecciona una factura válida para recalcular.");

            Factura factura = datos.Listar()
                .FirstOrDefault(x => x.CodigoFacturacion == codigoFacturacion);
            if (factura == null)
                throw new InvalidOperationException("No se encontró la factura que se debe recalcular.");

            factura.Subtotal = (detalles.ListarPorFactura(codigoFacturacion) ?? new List<DetalleFactura>())
                .Sum(CalcularSubtotalDetalle);
            Validar(factura);
            datos.Actualizar(factura);
        }

        private static void Validar(Factura factura)
        {
            if (factura == null)
                throw new ArgumentException("No se recibieron los datos de la factura.");
            if (factura.CodigoOrdenTrabajo <= 0)
                throw new ArgumentException("Selecciona una orden de trabajo.");
            if (factura.NoFactura <= 0)
                throw new ArgumentException("El número de factura debe ser mayor que cero.");
            if (factura.Subtotal < 0 || factura.Subtotal > 99999999.99m ||
                decimal.Round(factura.Subtotal, 2) != factura.Subtotal)
                throw new ArgumentException("El subtotal debe tener hasta 8 enteros y 2 decimales.");

            factura.Impuesto = decimal.Round(factura.Subtotal * 0.12m, 2);
            factura.TotalPagar = factura.Subtotal + factura.Impuesto;
            if (factura.TotalPagar > 99999999.99m)
                throw new ArgumentException("El total de la factura supera el máximo permitido.");
        }

        private static void ValidarDetalle(DetalleFactura detalle)
        {
            if (detalle == null)
                throw new ArgumentException("Completa los datos del concepto de la factura.");
            if (string.IsNullOrWhiteSpace(detalle.Descripcion) || detalle.Descripcion.Trim().Length > 150)
                throw new ArgumentException("La descripción es obligatoria y admite hasta 150 caracteres.");
            if (detalle.Cantidad <= 0)
                throw new ArgumentException("La cantidad debe ser mayor que cero.");
            if (detalle.Precio < 0 || detalle.DescuentoAplicado < 0)
                throw new ArgumentException("Los montos del concepto no pueden ser negativos.");
            if (detalle.DescuentoAplicado > detalle.Precio * detalle.Cantidad)
                throw new ArgumentException("El descuento no puede superar el total del concepto.");
            detalle.Descripcion = detalle.Descripcion.Trim();
        }

        decimal CalcularSubtotalFactura(int codigoFactura, DetalleFactura detalle)
        {
            List<DetalleFactura> existentes = detalles.ListarPorFactura(codigoFactura) ?? new List<DetalleFactura>();
            decimal subtotalExistente = existentes
                .Where(x => x.CodigoDetalleFactura != detalle.CodigoDetalleFactura)
                .Sum(CalcularSubtotalDetalle);
            return subtotalExistente + CalcularSubtotalDetalle(detalle);
        }

        static decimal CalcularSubtotalDetalle(DetalleFactura detalle)
        {
            return Math.Max(0, decimal.Round(
                detalle.Cantidad * detalle.Precio - detalle.DescuentoAplicado, 2));
        }

        /// <summary>Resumen del módulo (se muestra en la pestaña Resumen).</summary>
        public ResumenModulo ObtenerResumen()
        {
            List<Factura> lista = datos.Listar() ?? new List<Factura>();
            ResumenModulo r = new ResumenModulo();
            r.Total = lista.Count;
            r.TituloEstado = "Registros por estado";
            r.PorEstado = ResumenHelper.Contar(lista.Select(x => x.Estado ? "Activo" : "Inactivo"), new string[] { "Activo", "Inactivo" }, 0);
            r.TituloCategoria = r.TituloEstado;
            r.PorCategoria = r.PorEstado;
            r.TieneMonto = true;
            r.EtiquetaMonto = "Total facturado";
            r.MontoEsMoneda = true;
            r.MontoTotal = lista.Sum(x => x.TotalPagar);
            return r;
        }
    }
}
