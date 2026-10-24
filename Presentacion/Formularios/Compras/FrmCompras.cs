using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace SistemaPublicidad.Formularios
{
    // Apartado "Compras": formulario y definición (columnas, resúmenes, filtros, campos y datos de EJEMPLO)
    public class FrmCompras : FrmModulo
    {
        public FrmCompras() : base(Modulos.Obtener("Compras", "\U0001F6D2", 0)) { }
    }

    public static partial class Modulos
    {
        static ModuloCfg DatosCompras(string nombre, string icono)
        {
            ModuloCfg c;
            c = Def(nombre, icono, new[] { "Total de compras", "Monto comprado", "Recibidas", "Pendientes" }, new[] { "4", "Q7,100", "2", "1" }, new[] { "\U0001F6D2", "\U0001FA99", "\U0001F6E1", "\U0001F552" },
                        "No.:80:texto:o;Proveedor:190:texto;Fecha:90:texto:o;Sucursal:130:texto:o;Pago:110:badge;Total:100:num:o;Estado:100:estado:o",
                        @"COM-001|Papelería y Rótulos S.A.|05/10/2026|Sucursal Central|Transferencia|Q 2,400.00|Recibida
COM-002|Impresos del Norte|08/10/2026|Sucursal Norte|Efectivo|Q 1,500.00|Recibida
COM-003|Metales y Estructuras|12/10/2026|Sucursal Sur|Transferencia|Q 3,200.00|Pendiente
COM-004|Papelería y Rótulos S.A.|15/10/2026|Sucursal Occidente|Tarjeta|Q 800.00|Cancelada",
                        new[] { "Estado=Recibida,Pendiente,Cancelada", "Pago=Efectivo,Tarjeta,Transferencia", "Sucursal=" + SUC },
                        "No. de compra:t;Proveedor:c=Papelería y Rótulos S.A.,Impresos del Norte,Metales y Estructuras;Fecha:f;Sucursal:c=" + SUC + ";Forma de pago:c=Efectivo,Tarjeta,Transferencia;Estado:c=Pendiente,Recibida,Cancelada;Observaciones:t");
                    c.Tabs = new[] { "Consultar", "Gestionar" }; c.TituloDet = "Detalle de la compra"; c.ColsDet = Cols("#:36:id;Material:260:texto;Cantidad:80:num;Costo unit.:110:num;Subtotal:110:num", false);
                    c.Detalle = new Dictionary<string, string[][]> {
                        { "COM-001", FilasDet("1|Vinil adhesivo|10|Q 120.00|Q 1,200.00\n2|Lona 13 oz|4|Q 300.00|Q 1,200.00") },
                        { "COM-002", FilasDet("1|Tinta solvente|5|Q 200.00|Q 1,000.00\n2|Acrílico 3 mm|5|Q 100.00|Q 500.00") },
                        { "COM-003", FilasDet("1|Tubo metálico|16|Q 200.00|Q 3,200.00") },
                        { "COM-004", FilasDet("1|Vinil adhesivo|4|Q 200.00|Q 800.00") } };
            return c;
        }
    }
}
