using System.Collections.Generic;
using System.Linq;
using Datos;
using Entidad;

namespace Negocio
{
    /// <summary>
    /// Capa de negocio de usuarios: validaciones y reglas; llama a la capa de datos.
    /// </summary>
    public class UsuarioNegocio
    {
        private readonly UsuarioDatos datos = new UsuarioDatos();

        public List<Usuario> Listar()
        {
            return datos.Listar();
        }

        public List<Usuario> Buscar(string texto, string tipo, string estado)
        {
            return datos.Buscar(texto, tipo, estado);
        }

        public int Insertar(Usuario usuario)
        {
            // TODO: validar los datos antes de guardar.
            return datos.Insertar(usuario);
        }

        public int Actualizar(Usuario usuario)
        {
            // TODO: validar los datos antes de guardar.
            return datos.Actualizar(usuario);
        }

        public int Eliminar(int codigo)
        {
            // TODO: validar reglas antes de eliminar.
            return datos.Eliminar(codigo);
        }

        /// <summary>Resumen del módulo (se muestra en la pestaña Resumen).</summary>
        public ResumenModulo ObtenerResumen()
        {
            List<Usuario> lista = datos.Listar() ?? new List<Usuario>();
            ResumenModulo r = new ResumenModulo();
            r.Total = lista.Count;
            r.TituloEstado = "Registros por estado";
            r.PorEstado = ResumenHelper.Contar(lista.Select(x => x.Estado ? "Activo" : "Inactivo"), new string[] { "Activo", "Inactivo" }, 0);
            r.TituloCategoria = "Usuarios por rol";
            r.PorCategoria = ResumenHelper.Contar(lista.Select(x => x.TipoUsuario), new string[] { "Administrador", "Supervisor", "Usuario" }, 0);
            return r;
        }
    }
}
