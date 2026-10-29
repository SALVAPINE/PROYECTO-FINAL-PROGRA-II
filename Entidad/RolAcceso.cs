using System;

namespace Entidad
{
    /// <summary>
    /// Representa un permiso de acceso por tipo de usuario a un módulo.
    /// Mapea la tabla dbo.Tbl_RolAccesos en SQL Server.
    /// </summary>
    public class RolAcceso
    {
        public int CodigoRolAcceso { get; set; }
        public string TipoUsuario { get; set; }
        public string NombreModulo { get; set; }
        public bool Estado { get; set; }
    }
}

