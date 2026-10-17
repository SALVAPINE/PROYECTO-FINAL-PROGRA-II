using System;
using Entidad;
using Negocio;

namespace CAPAZ.Presentacion
{
    /// <summary>Valida el acceso temporal y las cuentas con rol almacenadas en la base.</summary>
    public static class ServicioLogin
    {
        private const string UsuarioTemporal = "sa";
        private const string ClaveTemporal = "UMG2027";
        private static readonly UsuarioNegocio negocio = new UsuarioNegocio();

        public static Usuario Autenticar(string usuario, string clave)
        {
            if (string.Equals((usuario ?? string.Empty).Trim(), UsuarioTemporal, StringComparison.OrdinalIgnoreCase) &&
                string.Equals(clave, ClaveTemporal, StringComparison.Ordinal))
            {
                return new Usuario
                {
                    NombreUsuario = UsuarioTemporal,
                    TipoUsuario = "Administrador",
                    Estado = true
                };
            }

            return negocio.Autenticar(usuario, clave);
        }
    }
}
