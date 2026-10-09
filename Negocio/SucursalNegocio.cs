using System.Collections.Generic;
using Datos;
using Entidad;

namespace Negocio
{
    /// <summary>
    /// Capa de negocio de sucursales: validaciones y reglas; llama a la capa de datos.
    /// </summary>
    public class SucursalNegocio
    {
        private readonly SucursalDatos datos = new SucursalDatos();

        public List<Sucursal> Listar()
        {
            return datos.Listar();
        }

        public List<Sucursal> Buscar(string texto, string estado)
        {
            return datos.Buscar(texto, estado);
        }

        public string SiguienteCodigo()
        {
            return datos.SiguienteCodigo();
        }

        public int Insertar(Sucursal sucursal)
        {
            // TODO: validar los datos antes de guardar.
            return datos.Insertar(sucursal);
        }

        public int Actualizar(Sucursal sucursal)
        {
            // TODO: validar los datos antes de guardar.
            return datos.Actualizar(sucursal);
        }

        public int Eliminar(string codigo)
        {
            // TODO: validar reglas antes de eliminar.
            return datos.Eliminar(codigo);
        }
    }
}
