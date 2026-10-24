using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace SistemaPublicidad.Formularios
{
    // Apartado "Cotizaciones": formulario y definición (columnas, resúmenes, filtros, campos y datos de EJEMPLO)
    public class FrmCotizaciones : FrmModulo
    {
        public FrmCotizaciones() : base(Modulos.Obtener("Cotizaciones", "\U0001F4C4", 0)) { }
    }

    public static partial class Modulos
    {
        static ModuloCfg DatosCotizaciones(string nombre, string icono)
        {
            ModuloCfg c;
            c = Def(nombre, icono, new[] { "Total cotizaciones", "Monto cotizado", "Aprobadas", "Pendientes" }, new[] { "6", "Q10,900", "3", "2" }, new[] { "\U0001F4C4", "\U0001FA99", "\U0001F6E1", "\U0001F552" },
                        "No.:80:texto:o;Cliente:170:texto;Tipo de servicio:150:texto;Sucursal:130:texto:o;Fecha:90:texto:o;Total:100:num:o;Estado:100:estado:o",
                        @"COT-001|Cliente Demo|Rótulo luminoso|Sucursal Central|12/10/2026|Q 1,500.00|Aprobada
COT-002|Carlos Pérez|Lona publicitaria|Sucursal Norte|13/10/2026|Q 2,200.00|Aprobada
COT-003|Ana Torres|Diseño de logotipo|Sucursal Sur|14/10/2026|Q 900.00|Pendiente
COT-004|Distribuidora El Sol|Valla vial|Sucursal Central|15/10/2026|Q 3,100.00|Aprobada
COT-005|Valeria Castillo|Impresión vinil|Sucursal Occidente|16/10/2026|Q 1,450.00|Pendiente
COT-006|Comercial Maya|Rótulo acrílico|Sucursal Norte|17/10/2026|Q 1,750.00|Rechazada",
                        new[] { "Estado=Aprobada,Pendiente,Rechazada", "Sucursal=" + SUC, "Servicio=Rótulo luminoso,Lona publicitaria,Valla vial" },
                        "Cliente:c=Cliente Demo,Carlos Pérez,Ana Torres;Tipo de servicio:c=Rótulo luminoso,Lona publicitaria,Diseño de logotipo,Valla vial;Sucursal:c=" + SUC + ";Fecha:f;Validez (días):n;Total (Q):n;Estado:c=Pendiente,Aprobada,Rechazada;Descripción:t");
            return c;
        }
    }
}
