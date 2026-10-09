using System.Collections.Generic;
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

        public string SiguienteCodigo()
        {
            return datos.SiguienteCodigo();
        }

        public int Insertar(OrdenTrabajo ordenTrabajo)
        {
            // TODO: validar los datos antes de guardar.
            return datos.Insertar(ordenTrabajo);
        }

        public int Actualizar(OrdenTrabajo ordenTrabajo)
        {
            // TODO: validar los datos antes de guardar.
            return datos.Actualizar(ordenTrabajo);
        }

        public int Eliminar(string codigo)
        {
            // TODO: validar reglas antes de eliminar.
            return datos.Eliminar(codigo);
        }
    }
}
