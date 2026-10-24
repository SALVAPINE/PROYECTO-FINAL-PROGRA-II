using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace SistemaPublicidad.Formularios
{
    // Apartado "Materiales": formulario y definición (columnas, resúmenes, filtros, campos y datos de EJEMPLO)
    public class FrmMateriales : FrmModulo
    {
        public FrmMateriales() : base(Modulos.Obtener("Materiales", "\U0001F5BC", 0)) { }
    }

    public static partial class Modulos
    {
        static ModuloCfg DatosMateriales(string nombre, string icono)
        {
            ModuloCfg c;
            c = Def(nombre, icono, new[] { "Total de materiales", "Disponibles", "Stock bajo", "Agotados" }, new[] { "5", "3", "1", "1" }, new[] { "\U0001F5BC", "\U0001F6E1", "\U0001F552", "\U0001F4E6" },
                        "ID:44:id:o;Material:190:texto:o;Categoría:130:texto:o;Unidad:80:texto;Precio unit.:100:num:o;Stock:80:num:o;Estado:100:estado:o",
                        @"001|Vinil adhesivo|Impresión|Metro|Q 120.00|45|Disponible
002|Lona 13 oz|Impresión|Metro|Q 300.00|30|Disponible
003|Acrílico 3 mm|Rótulos|Plancha|Q 100.00|8|Stock bajo
004|Tinta solvente|Insumos|Litro|Q 200.00|12|Disponible
005|Tubo metálico|Estructuras|Unidad|Q 200.00|0|Agotado",
                        new[] { "Categoría=Impresión,Rótulos,Insumos,Estructuras", "Estado=Disponible,Stock bajo,Agotado", "Unidad=Metro,Plancha,Litro,Unidad" },
                        "Nombre del material:t;Categoría:c=Impresión,Rótulos,Insumos,Estructuras;Unidad:c=Metro,Plancha,Litro,Unidad;Precio unitario (Q):n;Stock inicial:n;Proveedor:c=Papelería y Rótulos S.A.,Impresos del Norte,Metales y Estructuras");
            return c;
        }
    }
}
