using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace SistemaPublicidad.Formularios
{
    // Apartado "Sucursales": formulario y definición (columnas, resúmenes, filtros, campos y datos de EJEMPLO)
    public class FrmSucursales : FrmModulo
    {
        public FrmSucursales() : base(Modulos.Obtener("Sucursales", "\U0001F4CD", 0)) { }
    }

    public static partial class Modulos
    {
        static ModuloCfg DatosSucursales(string nombre, string icono)
        {
            ModuloCfg c;
            c = Def(nombre, icono, new[] { "Total de sucursales", "Activas", "Inactivas", "Empleados" }, new[] { "4", "4", "0", "12" }, new[] { "\U0001F4CD", "\U0001F6E1", "\U0001F552", "\U0001F465" },
                        "ID:44:id:o;Sucursal:170:texto:o;Dirección:260:texto;Teléfono:110:texto;Encargado:150:texto;Estado:90:estado:o",
                        @"001|Sucursal Central|6a. Avenida 10-20, Zona 1|2222-1001|Pedro Salazar|Activo
002|Sucursal Norte|3a. Calle 5-12, Zona 4|2222-1002|Rosa Gómez|Activo
003|Sucursal Sur|Calzada Sur 8-45, Zona 12|2222-1003|Luis Barrios|Activo
004|Sucursal Occidente|1a. Avenida 7-30, Zona 3|2222-1004|Marta Cifuentes|Activo",
                        new[] { "Estado=Activo,Inactivo", "Encargado=", "Orden=" }, "Nombre de la sucursal:t;Dirección:t;Teléfono:t;Encargado:t;Estado:c=Activo,Inactivo");
            return c;
        }
    }
}
