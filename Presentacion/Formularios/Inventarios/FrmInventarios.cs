using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace SistemaPublicidad.Formularios
{
    // Apartado "Inventarios": formulario y definición (columnas, resúmenes, filtros, campos y datos de EJEMPLO)
    public class FrmInventarios : FrmModulo
    {
        public FrmInventarios() : base(Modulos.Obtener("Inventarios", "\U0001F4E6", 0)) { }
    }

    public static partial class Modulos
    {
        static ModuloCfg DatosInventarios(string nombre, string icono)
        {
            ModuloCfg c;
            c = Def(nombre, icono, new[] { "Total de ítems", "Disponibles", "Stock bajo", "Agotados" }, new[] { "5", "3", "1", "1" }, new[] { "\U0001F4E6", "\U0001F6E1", "\U0001F552", "\U0001F5C4" },
                        "ID:44:id:o;Material:190:texto:o;Sucursal:140:texto:o;Existencia:90:num:o;Mínimo:80:num;Ubicación:120:texto;Estado:100:estado:o",
                        @"001|Vinil adhesivo|Sucursal Central|45|10|Estante A1|Disponible
002|Lona 13 oz|Sucursal Norte|30|10|Estante B2|Disponible
003|Acrílico 3 mm|Sucursal Sur|8|10|Estante C1|Stock bajo
004|Tinta solvente|Sucursal Central|12|5|Bodega 2|Disponible
005|Tubo metálico|Sucursal Occidente|0|6|Patio|Agotado",
                        new[] { "Estado=Disponible,Stock bajo,Agotado", "Sucursal=" + SUC, "Orden=" }, "Material:c=Vinil adhesivo,Lona 13 oz,Acrílico 3 mm,Tinta solvente,Tubo metálico;Sucursal:c=" + SUC + ";Existencia:n;Mínimo:n;Ubicación:t;Estado:c=Disponible,Stock bajo,Agotado");
            return c;
        }
    }
}
