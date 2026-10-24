using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace SistemaPublicidad.Formularios
{
    // Apartado "Facturaciones": formulario y definición (columnas, resúmenes, filtros, campos y datos de EJEMPLO)
    public class FrmFacturaciones : FrmModulo
    {
        public FrmFacturaciones() : base(Modulos.Obtener("Facturaciones", "\U0001F9FE", 0)) { }
    }

    public static partial class Modulos
    {
        static ModuloCfg DatosFacturaciones(string nombre, string icono)
        {
            ModuloCfg c;
            c = Def(nombre, icono, new[] { "Total de facturas", "Monto facturado", "Pagadas", "Pendientes" }, new[] { "5", "Q7,780", "3", "1" }, new[] { "\U0001F9FE", "\U0001FA99", "\U0001F6E1", "\U0001F552" },
                        "No.:80:texto:o;Cliente:160:texto;Fecha:90:texto:o;Sucursal:130:texto:o;Pago:110:badge;Total:100:num:o;Estado:100:estado:o",
                        @"FAC-0004|Cliente Demo|12/10/2026|Sucursal Central|Efectivo|Q 2,150.00|Pagada
FAC-0005|Carlos Pérez|14/10/2026|Sucursal Norte|Tarjeta|Q 1,200.00|Pagada
FAC-0006|Ana Torres|15/10/2026|Sucursal Sur|Transferencia|Q 980.00|Pendiente
FAC-0007|María López|16/10/2026|Sucursal Central|Efectivo|Q 1,750.00|Anulada
FAC-0008|Cliente Demo|17/10/2026|Sucursal Central|Tarjeta|Q 3,450.00|Pagada",
                        new[] { "Estado=Pagada,Pendiente,Anulada", "Pago=Efectivo,Tarjeta,Transferencia", "Sucursal=" + SUC },
                        "No. de factura:t;Cliente:c=Cliente Demo,Carlos Pérez,Ana Torres;Fecha:f;Sucursal:c=" + SUC + ";Forma de pago:c=Efectivo,Tarjeta,Transferencia;Estado:c=Pagada,Pendiente,Anulada;Observaciones:t");
                    c.Tabs = new[] { "Consultar", "Gestionar" }; c.TituloDet = "Detalle de la factura"; c.ColsDet = Cols("#:36:id;Descripción:260:texto;Cantidad:80:num;Precio unit.:110:num;Subtotal:110:num", false);
                    c.Detalle = new Dictionary<string, string[][]> {
                        { "FAC-0004", FilasDet("1|Rótulo luminoso|1|Q 1,500.00|Q 1,500.00\n2|Instalación en sitio|1|Q 650.00|Q 650.00") },
                        { "FAC-0005", FilasDet("1|Lona publicitaria|2|Q 300.00|Q 600.00\n2|Impresión de vinil|3|Q 200.00|Q 600.00") },
                        { "FAC-0006", FilasDet("1|Diseño de logotipo|1|Q 680.00|Q 680.00\n2|Tarjetas de presentación|1|Q 300.00|Q 300.00") },
                        { "FAC-0007", FilasDet("1|Valla vial|1|Q 1,750.00|Q 1,750.00") },
                        { "FAC-0008", FilasDet("1|Impresión gran formato|5|Q 300.00|Q 1,500.00\n2|Rótulo acrílico|2|Q 450.00|Q 900.00\n3|Instalación en sitio|1|Q 1,050.00|Q 1,050.00") } };
            return c;
        }
    }
}
