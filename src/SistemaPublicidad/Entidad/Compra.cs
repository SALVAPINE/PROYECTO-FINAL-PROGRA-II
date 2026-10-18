using System;

namespace Entidad
{
    public class Compra
    {
        public int CodigoCompra { get; set; }
        public int CodigoProveedor { get; set; }
        public int CodigoMaterial { get; set; }
        public int CantidadComprada { get; set; }
        public decimal TotalCompra { get; set; }
        public DateTime FechaCompra { get; set; }
        public DateTime FechaEntrega { get; set; }
        public bool Estado { get; set; }
    }
}
