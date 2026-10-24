using System;
using System.Collections.Generic;
using System.Linq;
using Datos;
using Entidad;

namespace Negocio
{
    /// <summary>
    /// Capa de negocio de inventarios: validaciones y reglas; llama a la capa de datos.
    /// </summary>
    public class InventarioNegocio
    {
        private readonly InventarioDatos datos = new InventarioDatos();

        public List<Inventario> Listar()
        {
            return datos.Listar();
        }

        public List<Inventario> Buscar(string texto, string estado)
        {
            return datos.Buscar(texto, estado);
        }

        public int Insertar(Inventario inventario)
        {
            Validar(inventario);
            return datos.Insertar(inventario);
        }

        public int Actualizar(Inventario inventario)
        {
            Validar(inventario);
            if (inventario.CodigoInventario <= 0)
                throw new ArgumentException("Selecciona un registro de inventario válido para editar.");
            return datos.Actualizar(inventario);
        }

        public int Eliminar(int codigo)
        {
            if (codigo <= 0)
                throw new ArgumentException("Selecciona un registro de inventario válido para eliminar.");
            return datos.Eliminar(codigo);
        }

        private static void Validar(Inventario inventario)
        {
            if (inventario == null)
                throw new ArgumentException("No se recibieron los datos del inventario.");
            if (inventario.CodigoSucursal <= 0)
                throw new ArgumentException("Selecciona una sucursal.");
            if (inventario.CodigoMaterial <= 0)
                throw new ArgumentException("Selecciona un material.");
            if (string.IsNullOrWhiteSpace(inventario.NombreProducto) || inventario.NombreProducto.Length > 45)
                throw new ArgumentException("El nombre del producto es obligatorio y admite hasta 45 caracteres.");
            if (string.IsNullOrWhiteSpace(inventario.TipoProducto) || inventario.TipoProducto.Length > 45)
                throw new ArgumentException("El tipo de producto es obligatorio y admite hasta 45 caracteres.");
            if (inventario.Stock < 0)
                throw new ArgumentException("El stock no puede ser negativo.");
            if (inventario.PrecioCompra < 0)
                throw new ArgumentException("El precio de compra no puede ser negativo.");
        }

        /// <summary>Resumen del módulo (se muestra en la pestaña Resumen).</summary>
        public ResumenModulo ObtenerResumen()
        {
            List<Inventario> lista = datos.Listar() ?? new List<Inventario>();
            ResumenModulo r = new ResumenModulo();
            r.Total = lista.Count;
            r.TituloEstado = "Registros por estado";
            r.PorEstado = ResumenHelper.Contar(lista.Select(x => x.Estado ? "Activo" : "Inactivo"), new string[] { "Activo", "Inactivo" }, 0);
            r.TituloCategoria = "Inventario por tipo de producto";
            r.PorCategoria = ResumenHelper.Contar(lista.Select(x => x.TipoProducto), new string[] {  }, 6);
            r.TieneMonto = true;
            r.EtiquetaMonto = "Existencias";
            r.MontoEsMoneda = false;
            r.MontoTotal = lista.Sum(x => x.Stock);
            return r;
        }
    }
}
