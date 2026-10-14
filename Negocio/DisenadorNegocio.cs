using System.Collections.Generic;
using System.Linq;
using Datos;
using Entidad;

namespace Negocio
{
    /// <summary>
    /// Capa de negocio de diseñadores: validaciones y reglas; llama a la capa de datos.
    /// </summary>
    public class DisenadorNegocio
    {
        private readonly DisenadorDatos datos = new DisenadorDatos();

        public List<Disenador> Listar()
        {
            return datos.Listar();
        }

        public List<Disenador> Buscar(string texto, string estado)
        {
            return datos.Buscar(texto, estado);
        }

        public int Insertar(Disenador disenador)
        {
            // TODO: validar los datos antes de guardar.
            return datos.Insertar(disenador);
        }

        public int Actualizar(Disenador disenador)
        {
            // TODO: validar los datos antes de guardar.
            return datos.Actualizar(disenador);
        }

        public int Eliminar(int codigo)
        {
            // TODO: validar reglas antes de eliminar.
            return datos.Eliminar(codigo);
        }

        /// <summary>Resumen del módulo (se muestra en la pestaña Resumen).</summary>
        public ResumenModulo ObtenerResumen()
        {
            List<Disenador> lista = datos.Listar() ?? new List<Disenador>();
            ResumenModulo r = new ResumenModulo();
            r.Total = lista.Count;
            r.TituloEstado = "Registros por estado";
            r.PorEstado = ResumenHelper.Contar(lista.Select(x => x.Estado ? "Activo" : "Inactivo"), new string[] { "Activo", "Inactivo" }, 0);
            r.TituloCategoria = "Diseñadores por especialidad";
            r.PorCategoria = ResumenHelper.Contar(lista.Select(x => x.Especialidad), new string[] {  }, 6);
            return r;
        }
    }
}
