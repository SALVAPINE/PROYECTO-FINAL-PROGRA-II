using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace SistemaPublicidad.Formularios
{
    // Apartado "Usuarios": formulario y definición (columnas, resúmenes, filtros, campos y datos de EJEMPLO)
    public class FrmUsuarios : FrmModulo
    {
        public FrmUsuarios() : base(Modulos.Obtener("Usuarios", "\U0001F464", 0)) { }
    }

    public static partial class Modulos
    {
        static ModuloCfg DatosUsuarios(string nombre, string icono)
        {
            ModuloCfg c;
            c = Def(nombre, icono, new[] { "Total de usuarios", "Administradores", "Clientes", "Diseñadores" }, new[] { "8", "2", "2", "2" }, new[] { "\U0001F465", "\U0001F464", "\U0001F4C4", "\u270F" },
                        "ID:40:id:o;Nombre completo:190:nombre;Usuario:80:link:o;Correo electrónico:175:texto;Rol:115:badge:o;Sucursal:140:texto:o;Estado:80:estado:o;Último acceso:140:texto:o",
                        @"001|Administrador~admin@publicidad.com|admin|admin@publicidad.com|Administrador|Todas|Activo|18/10/2026 08:24
002|María López~mlopez@publicidad.com|mlopez|mlopez@publicidad.com|Diseñador|Sucursal Central|Activo|12/10/2026 16:32
003|Carlos Pérez~cperez@publicidad.com|cperez|cperez@publicidad.com|Cliente|Sucursal Norte|Activo|12/10/2026 14:20
004|Ana Torres~atorres@publicidad.com|atorres|atorres@publicidad.com|Vendedor|Sucursal Sur|Activo|16/10/2026 11:45
005|Luisa Ramírez~lramirez@publicidad.com|lramirez|lramirez@publicidad.com|Diseñador|Sucursal Occidente|Activo|16/10/2026 10:12
006|Sofía González~sgonzalez@publicidad.com|sgonzalez|sgonzalez@publicidad.com|Administrador|Sucursal Central|Inactivo|12/10/2026 09:33
007|Diego Morales~dmorales@publicidad.com|dmorales|dmorales@publicidad.com|Vendedor|Sucursal Norte|Activo|11/10/2026 15:20
008|Valeria Castillo~vcastillo@publicidad.com|vcastillo|vcastillo@publicidad.com|Cliente|Sucursal Sur|Activo|10/10/2026 12:05
009|Jorge Herrera~jherrera@publicidad.com|jherrera|jherrera@publicidad.com|Diseñador|Sucursal Occidente|Activo|08/10/2026 13:15
010|Camila Rivas~crivas@publicidad.com|crivas|crivas@publicidad.com|Vendedor|Sucursal Sur|Activo|08/10/2026 10:42",
                        new[] { "Rol=Administrador,Diseñador,Vendedor,Cliente", "Estado=Activo,Inactivo", "Sucursal=" + SUC },
                        "Nombre completo:t;Usuario:t;Correo electrónico:t;Contraseña:t;Rol:c=Administrador,Diseñador,Vendedor,Cliente;Sucursal:c=" + SUC + ";Estado:c=Activo,Inactivo");
                    c.Total = 48; c.StatTend = new[] { "+ 82 %", "+ 00 %", "+ 02 %", "+ 82 %" }; c.StatImg = new[] { "st2_total", "st2_admin", "st2_clientes", "st2_dis" }; c.TileImg = "tile_usuarios";
            return c;
        }
    }
}
