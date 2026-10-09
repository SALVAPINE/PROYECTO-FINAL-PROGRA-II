using System.Collections.Generic;
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

        public string SiguienteCodigo()
        {
            return datos.SiguienteCodigo();
        }

        public int Insertar(Compra compra)
        {
            // TODO: validar los datos antes de guardar.
            return datos.Insertar(compra);
        }

        public int Actualizar(Compra compra)
        {
            // TODO: validar los datos antes de guardar.
            return datos.Actualizar(compra);
        }

        public int Eliminar(string codigo)
        {
            // TODO: validar reglas antes de eliminar.
            return datos.Eliminar(codigo);
        }
    }
}
