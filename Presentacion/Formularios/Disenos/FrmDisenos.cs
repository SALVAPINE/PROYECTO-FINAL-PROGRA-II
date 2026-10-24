using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace SistemaPublicidad.Formularios
{
    // Apartado "Diseños": formulario y definición (columnas, resúmenes, filtros, campos y datos de EJEMPLO)
    public class FrmDisenos : FrmModulo
    {
        public FrmDisenos() : base(Modulos.Obtener("Diseños", "\U0001F3A8", 0)) { }
    }

    public static partial class Modulos
    {
        static ModuloCfg DatosDisenos(string nombre, string icono)
        {
            ModuloCfg c;
            c = Def(nombre, icono, new[] { "Total de diseños", "Aprobados", "En revisión", "Pendientes" }, new[] { "5", "3", "1", "1" }, new[] { "\U0001F3A8", "\U0001F6E1", "\U0001F4CB", "\U0001F552" },
                        "ID:44:id:o;Diseño:190:texto:o;Cliente:160:texto;Diseñador:150:texto;Entrega:90:texto:o;Estado:110:estado:o",
                        @"001|Logotipo Cliente Demo|Cliente Demo|María López|20/10/2026|Aprobado
002|Valla Distribuidora El Sol|Distribuidora El Sol|Luisa Ramírez|22/10/2026|En revisión
003|Rótulo Comercial Maya|Comercial Maya|Jorge Herrera|23/10/2026|Aprobado
004|Banner Ana Torres|Ana Torres|María López|24/10/2026|Pendiente
005|Flyer Valeria Castillo|Valeria Castillo|Luisa Ramírez|25/10/2026|Aprobado",
                        new[] { "Estado=Aprobado,En revisión,Pendiente", "Diseñador=María López,Luisa Ramírez,Jorge Herrera", "Cliente=" }, "Nombre del diseño:t;Cliente:c=Cliente Demo,Distribuidora El Sol,Comercial Maya;Diseñador:c=María López,Luisa Ramírez,Jorge Herrera;Fecha de entrega:f;Estado:c=Pendiente,En revisión,Aprobado;Notas:t");
            return c;
        }
    }
}
