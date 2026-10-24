using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace SistemaPublicidad.Formularios
{
    // Apartado "Proveedores": formulario y definición (columnas, resúmenes, filtros, campos y datos de EJEMPLO)
    public class FrmProveedores : FrmModulo
    {
        public FrmProveedores() : base(Modulos.Obtener("Proveedores", "\U0001F69A", 0)) { }
    }

    public static partial class Modulos
    {
        static ModuloCfg DatosProveedores(string nombre, string icono)
        {
            ModuloCfg c;
            c = Def(nombre, icono, new[] { "Total de proveedores", "Activos", "Inactivos", "Categorías" }, new[] { "4", "3", "1", "3" }, new[] { "\U0001F69A", "\U0001F6E1", "\U0001F552", "\U0001F4E6" },
                        "ID:44:id:o;Proveedor:200:texto:o;Contacto:160:texto;Teléfono:110:texto;NIT:100:texto;Categoría:120:badge;Estado:90:estado:o",
                        @"001|Papelería y Rótulos S.A.|Juan Mejía|2333-3001|1100220-1|Insumos|Activo
002|Impresos del Norte|Karla Rivas|2333-3002|1100221-2|Impresión|Activo
003|Metales y Estructuras|Óscar Díaz|2333-3003|1100222-3|Estructuras|Activo
004|Tintas y Solventes GT|Elena Ruiz|2333-3004|1100223-4|Insumos|Inactivo",
                        new[] { "Categoría=Insumos,Impresión,Estructuras", "Estado=Activo,Inactivo", "Orden=" }, "Nombre del proveedor:t;Contacto:t;Teléfono:t;NIT:t;Categoría:c=Insumos,Impresión,Estructuras;Estado:c=Activo,Inactivo");
            return c;
        }
    }
}
