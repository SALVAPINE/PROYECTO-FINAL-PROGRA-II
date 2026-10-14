using System;

namespace Entidad
{
    public class Usuario
    {
        public int CodigoUsuario { get; set; }
        public int CodigoSucursal { get; set; }
        public string NombreUsuario { get; set; }
        public string Clave { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string TipoUsuario { get; set; }
        public bool Estado { get; set; }
    }
}
