using System;
using System.Collections.Generic;
using System.Linq;
using Datos;
using Entidad;

namespace Negocio
{
    /// <summary>
    /// Capa de negocio de compras: validaciones y reglas; llama a la capa de datos.
    /// </summary>
    public class CompraNegocio
    {
        private readonly CompraDatos datos = new CompraDatos();

        public List<Compra> Listar()
        {
            return datos.Listar();
        }

        public List<Compra> Buscar(string texto, string estado)
        {
            return datos.Buscar(texto, estado);
        }

        public CompraDocumento ObtenerDocumento(int codigoCompra)
        {
            if (codigoCompra <= 0)
                throw new ArgumentException("Selecciona una compra válida para imprimir.");
            return datos.ObtenerDocumento(codigoCompra);
        }

        public int Insertar(Compra compra)
        {
            Validar(compra);
            return datos.Insertar(compra);
        }

        /// <summary>Inserta y devuelve el código generado para enlazar el detalle.</summary>
        public int InsertarYObtenerCodigo(Compra compra)
        {
            Validar(compra);
            return datos.InsertarYObtenerCodigo(compra);
        }

        /// <summary>Valida y guarda el encabezado con su detalle como una unidad.</summary>
        public int InsertarConDetalle(Compra compra, DetalleCompra detalle)
        {
            Validar(compra);
            if (detalle == null)
                throw new ArgumentException("Completa los datos del detalle de la compra.");
            if (string.IsNullOrWhiteSpace(detalle.TipoDeCompra) || detalle.TipoDeCompra.Trim().Length > 45)
                throw new ArgumentException("El tipo de compra es obligatorio y admite hasta 45 caracteres.");
            if (string.IsNullOrWhiteSpace(detalle.Descripcion) || detalle.Descripcion.Trim().Length > 150)
                throw new ArgumentException("La descripción del detalle es obligatoria y admite hasta 150 caracteres.");
            if (detalle.PrecioUnitario < 0 || detalle.Subtotal < 0 || detalle.DescuentoCompra < 0)
                throw new ArgumentException("Los montos del detalle no pueden ser negativos.");

            detalle.TipoDeCompra = detalle.TipoDeCompra.Trim();
            detalle.Descripcion = detalle.Descripcion.Trim();
            return datos.InsertarConDetalle(compra, detalle);
        }

        public int Actualizar(Compra compra)
        {
            Validar(compra);
            if (compra.CodigoCompra <= 0)
                throw new ArgumentException("Selecciona una compra válida para editar.");
            return datos.Actualizar(compra);
        }

        public int Eliminar(int codigo)
        {
            if (codigo <= 0)
                throw new ArgumentException("Selecciona una compra válida para eliminar.");
            return datos.Eliminar(codigo);
        }

        private static void Validar(Compra compra)
        {
            if (compra == null)
                throw new ArgumentException("No se recibieron los datos de la compra.");
            if (compra.CodigoProveedor <= 0)
                throw new ArgumentException("Selecciona un proveedor.");
            if (compra.CodigoMaterial <= 0)
                throw new ArgumentException("Selecciona un material.");
            if (compra.CantidadComprada <= 0)
                throw new ArgumentException("La cantidad comprada debe ser mayor que cero.");
            if (compra.TotalCompra < 0)
                throw new ArgumentException("El total de la compra no puede ser negativo.");
            if (compra.FechaEntrega.Date < compra.FechaCompra.Date)
                throw new ArgumentException("La fecha de entrega no puede ser anterior a la fecha de compra.");
        }

        /// <summary>Resumen del módulo (se muestra en la pestaña Resumen).</summary>
        public ResumenModulo ObtenerResumen()
        {
            List<Compra> lista = datos.Listar() ?? new List<Compra>();
            ResumenModulo r = new ResumenModulo();
            r.Total = lista.Count;
            r.TituloEstado = "Registros por estado";
            r.PorEstado = ResumenHelper.Contar(lista.Select(x => x.Estado ? "Activo" : "Inactivo"), new string[] { "Activo", "Inactivo" }, 0);
            r.TituloCategoria = r.TituloEstado;
            r.PorCategoria = r.PorEstado;
            r.TieneMonto = true;
            r.EtiquetaMonto = "Total comprado";
            r.MontoEsMoneda = true;
            r.MontoTotal = lista.Sum(x => x.TotalCompra);
            return r;
        }
    }
}
