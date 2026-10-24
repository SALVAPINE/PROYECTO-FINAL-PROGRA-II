using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace SistemaPublicidad.Formularios
{
    // Apartado "Órdenes de Trabajo": formulario y definición (columnas, resúmenes, filtros, campos y datos de EJEMPLO)
    public class FrmOrdenesTrabajo : FrmModulo
    {
        public FrmOrdenesTrabajo() : base(Modulos.Obtener("Órdenes de Trabajo", "\U0001F4CB", 0)) { }
    }

    public static partial class Modulos
    {
        static ModuloCfg DatosOrdenesTrabajo(string nombre, string icono)
        {
            ModuloCfg c;
            c = Def(nombre, icono, new[] { "Total de órdenes", "En proceso", "Completadas", "Pendientes" }, new[] { "5", "2", "2", "1" }, new[] { "\U0001F4CB", "\U0001F552", "\U0001F6E1", "\U0001F4C4" },
                        "No.:80:texto:o;Cliente:160:texto;Servicio:150:texto;Diseñador:140:texto;Entrega:90:texto:o;Prioridad:90:badge:o;Estado:110:estado:o",
                        @"OT-001|Cliente Demo|Rótulo luminoso|María López|20/10/2026|Alta|Completada
OT-002|Carlos Pérez|Lona publicitaria|Jorge Herrera|21/10/2026|Media|En proceso
OT-003|Distribuidora El Sol|Valla vial|Luisa Ramírez|25/10/2026|Alta|En proceso
OT-004|Ana Torres|Diseño de logotipo|María López|18/10/2026|Baja|Completada
OT-005|Comercial Maya|Rótulo acrílico|Jorge Herrera|28/10/2026|Media|Pendiente",
                        new[] { "Estado=Pendiente,En proceso,Completada", "Prioridad=Alta,Media,Baja", "Diseñador=María López,Luisa Ramírez,Jorge Herrera" },
                        "Cliente:c=Cliente Demo,Carlos Pérez,Comercial Maya;Servicio:c=Rótulo luminoso,Lona publicitaria,Valla vial;Diseñador:c=María López,Luisa Ramírez,Jorge Herrera;Sucursal:c=" + SUC + ";Fecha de entrega:f;Prioridad:c=Alta,Media,Baja;Estado:c=Pendiente,En proceso,Completada");
            return c;
        }
    }
}
