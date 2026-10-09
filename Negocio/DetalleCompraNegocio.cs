using System.Collections.Generic;
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

        public List<DetalleCompra> Buscar(string texto, string compra)
        {
            return datos.Buscar(texto, compra);
        }

        public string SiguienteCodigo()
        {
            return datos.SiguienteCodigo();
        }

        public int Insertar(DetalleCompra detalleCompra)
        {
            // TODO: validar los datos antes de guardar.
            return datos.Insertar(detalleCompra);
        }

        public int Actualizar(DetalleCompra detalleCompra)
        {
            // TODO: validar los datos antes de guardar.
            return datos.Actualizar(detalleCompra);
        }

        public int Eliminar(string codigo)
        {
            // TODO: validar reglas antes de eliminar.
            return datos.Eliminar(codigo);
        }
    }
}
