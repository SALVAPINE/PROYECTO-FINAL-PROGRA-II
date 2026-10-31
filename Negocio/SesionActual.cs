using System;

namespace Negocio
{
    public static class SesionActual
    {
        public static string Rol { get; private set; }
        internal static void Iniciar(string rol) { Rol = rol; }
        public static void Cerrar() { Rol = null; }
        public static void ExigirAdministrador()
        {
            if (!string.Equals(Rol, "Administrador", StringComparison.OrdinalIgnoreCase))
                throw new UnauthorizedAccessException("Solo un administrador puede gestionar los permisos.");
        }
    }
}
