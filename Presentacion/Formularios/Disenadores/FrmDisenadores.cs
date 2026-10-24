using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace SistemaPublicidad.Formularios
{
    // Apartado "Diseñadores": formulario y definición (columnas, resúmenes, filtros, campos y datos de EJEMPLO)
    public class FrmDisenadores : FrmModulo
    {
        public FrmDisenadores() : base(Modulos.Obtener("Diseñadores", "\u270F", 0)) { }
    }

    public static partial class Modulos
    {
        static ModuloCfg DatosDisenadores(string nombre, string icono)
        {
            ModuloCfg c;
            c = Def(nombre, icono, new[] { "Total de diseñadores", "Activos", "Inactivos", "Diseños asignados" }, new[] { "3", "3", "0", "5" }, new[] { "\u270F", "\U0001F464", "\U0001F552", "\U0001F3A8" },
                        "ID:44:id:o;Diseñador:200:nombre;Especialidad:140:texto:o;Sucursal:140:texto:o;Teléfono:110:texto;Diseños:80:num;Estado:90:estado:o",
                        @"001|María López~mlopez@publicidad.com|Branding|Sucursal Central|5555-2001|2|Activo
002|Luisa Ramírez~lramirez@publicidad.com|Gran formato|Sucursal Occidente|5555-2002|2|Activo
003|Jorge Herrera~jherrera@publicidad.com|Digital|Sucursal Occidente|5555-2003|1|Activo",
                        new[] { "Estado=Activo,Inactivo", "Especialidad=Branding,Gran formato,Digital", "Sucursal=" + SUC }, "Nombre completo:t;Correo electrónico:t;Teléfono:t;Especialidad:c=Branding,Gran formato,Digital;Sucursal:c=" + SUC + ";Estado:c=Activo,Inactivo");
            return c;
        }
    }
}
