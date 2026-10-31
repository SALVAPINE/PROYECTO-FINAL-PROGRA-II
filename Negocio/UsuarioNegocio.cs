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
            SesionActual.Cerrar();
            if (string.IsNullOrWhiteSpace(nombreUsuario) || string.IsNullOrEmpty(clave)) return null;
            Usuario cuenta = datos.Autenticar(nombreUsuario.Trim(), clave);
            if (cuenta != null) SesionActual.Iniciar(cuenta.TipoUsuario);
            return cuenta;
        }

        public List<Usuario> Listar() { return datos.Listar(); }

        public List<Usuario> Buscar(string texto, string tipo, string estado)
        {
            return datos.Buscar((texto ?? string.Empty).Trim(), tipo, estado);
        }

        public List<Sucursal> ListarSucursales() { return datos.ListarSucursales(); }

        public int Insertar(Usuario usuario)
        {
            Validar(usuario, false);
            return datos.Insertar(usuario);
        }

        public int Actualizar(Usuario usuario)
        {
            Validar(usuario, true);
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

        private void Validar(Usuario usuario, bool editar)
        {
            if (usuario == null)
                throw new ArgumentException("No se recibieron los datos del usuario.");
            if (usuario.CodigoSucursal <= 0)
                throw new ArgumentException("Selecciona una sucursal.");
            if (string.IsNullOrWhiteSpace(usuario.NombreUsuario) || usuario.NombreUsuario.Length > 45)
                throw new ArgumentException("El nombre de usuario es obligatorio y admite hasta 45 caracteres.");
            if ((!editar || !string.IsNullOrEmpty(usuario.Clave)) &&
                (string.IsNullOrWhiteSpace(usuario.Clave) || usuario.Clave.Length < 8 || usuario.Clave.Length > 255))
                throw new ArgumentException("Escribe una contraseña de 8 a 255 caracteres. Al editar, déjala vacía para conservarla.");
            if (!RolNegocio.TiposUsuario.Contains(usuario.TipoUsuario))
                throw new ArgumentException("Selecciona un tipo de usuario valido.");
            if (datos.Listar().Any(x => x.CodigoUsuario != usuario.CodigoUsuario &&
                string.Equals(x.NombreUsuario, usuario.NombreUsuario.Trim(), StringComparison.OrdinalIgnoreCase)))
                throw new ArgumentException("Ya existe una cuenta con ese nombre de usuario.");
            usuario.NombreUsuario = usuario.NombreUsuario.Trim();
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
