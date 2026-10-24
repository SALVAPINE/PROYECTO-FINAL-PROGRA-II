using System;
using System.Collections.Generic;
using System.Linq;
using Datos;
using Entidad;

namespace Negocio
{
    /// <summary>Validaciones sencillas para las operaciones de usuarios.</summary>
    public class UsuarioNegocio
    {
        private readonly UsuarioDatos datos = new UsuarioDatos();

        public Usuario Autenticar(string nombreUsuario, string clave)
        {
            if (string.IsNullOrWhiteSpace(nombreUsuario) || string.IsNullOrEmpty(clave)) return null;
            return datos.Autenticar(nombreUsuario.Trim(), clave);
        }

        public List<Usuario> Listar() { return datos.Listar(); }

        public List<Usuario> Buscar(string texto, string tipo, string estado)
        {
            return datos.Buscar((texto ?? string.Empty).Trim(), tipo, estado);
        }

        public List<Sucursal> ListarSucursales() { return datos.ListarSucursales(); }

        public int Insertar(Usuario usuario)
        {
            Validar(usuario);
            return datos.Insertar(usuario);
        }

        public int Actualizar(Usuario usuario)
        {
            Validar(usuario);
            if (usuario.CodigoUsuario <= 0)
                throw new ArgumentException("Selecciona un usuario valido para editar.");
            return datos.Actualizar(usuario);
        }

        public int Eliminar(int codigo)
        {
            if (codigo <= 0)
                throw new ArgumentException("Selecciona un usuario valido para eliminar.");
            return datos.Eliminar(codigo);
        }

        private void Validar(Usuario usuario)
        {
            if (usuario == null)
                throw new ArgumentException("No se recibieron los datos del usuario.");
            if (usuario.CodigoSucursal <= 0)
                throw new ArgumentException("Selecciona una sucursal.");
            if (string.IsNullOrWhiteSpace(usuario.NombreUsuario) || usuario.NombreUsuario.Length > 45)
                throw new ArgumentException("El nombre de usuario es obligatorio y admite hasta 45 caracteres.");
            if (string.IsNullOrWhiteSpace(usuario.Clave) || usuario.Clave.Length > 255)
                throw new ArgumentException("La clave es obligatoria y admite hasta 255 caracteres.");
            if (string.IsNullOrWhiteSpace(usuario.TipoUsuario) || usuario.TipoUsuario.Length > 45)
                throw new ArgumentException("Selecciona un tipo de usuario valido.");
        }

        /// <summary>El resumen usa todos los usuarios, no solo la pagina visible.</summary>
        public ResumenModulo ObtenerResumen()
        {
            List<Usuario> lista = datos.Listar() ?? new List<Usuario>();
            ResumenModulo resumen = new ResumenModulo();
            resumen.Total = lista.Count;
            resumen.TituloEstado = "Registros por estado";
            resumen.PorEstado = ResumenHelper.Contar(
                lista.Select(x => x.Estado ? "Activo" : "Inactivo"),
                new string[] { "Activo", "Inactivo" }, 0);
            resumen.TituloCategoria = "Usuarios por tipo";
            resumen.PorCategoria = ResumenHelper.Contar(
                lista.Select(x => x.TipoUsuario),
                new string[] { "Administrador", "Diseñador", "Operador" }, 0);
            return resumen;
        }
    }
}
