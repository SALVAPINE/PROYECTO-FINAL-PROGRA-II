using System;

namespace Entidad
{
    public class Sucursal
    {
        public int CodigoSucursal { get; set; }
        public string NombreSucursal { get; set; }
        public string Direccion { get; set; }
        public string Municipio { get; set; }
        public string Departamento { get; set; }
        public int Telefono { get; set; }
        public TimeSpan HorarioDeAtencion { get; set; }
        public bool Estado { get; set; }
    }
}
