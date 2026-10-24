using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace SistemaPublicidad.Formularios
{
    // Apartado "Clientes": formulario y definición (columnas, resúmenes, filtros, campos y datos de EJEMPLO)
    public class FrmClientes : FrmModulo
    {
        public FrmClientes() : base(Modulos.Obtener("Clientes", "\U0001F465", 0)) { }
    }

    public static partial class Modulos
    {
        static ModuloCfg DatosClientes(string nombre, string icono)
        {
            ModuloCfg c;
            c = Def(nombre, icono, new[] { "Total de clientes", "Empresas", "Individuales", "Nuevos este mes" }, new[] { "6", "3", "3", "1" }, Ic,
                        "ID:44:id:o;Cliente:190:nombre;Teléfono:110:texto;NIT:100:texto;Tipo:100:badge;Sucursal:140:texto:o;Estado:80:estado:o;Registro:100:texto:o",
                        @"001|Cliente Demo~demo@cliente.com|5555-1001|1234567-8|Empresa|Sucursal Central|Activo|02/09/2026
002|Carlos Pérez~carlos@correo.com|5555-1002|2345678-9|Individual|Sucursal Norte|Activo|10/09/2026
003|Ana Torres~ana@correo.com|5555-1003|3456789-0|Individual|Sucursal Sur|Activo|15/09/2026
004|Distribuidora El Sol~ventas@elsol.com|5555-1004|4567890-1|Empresa|Sucursal Central|Activo|21/09/2026
005|Valeria Castillo~vcastillo@correo.com|5555-1005|5678901-2|Individual|Sucursal Occidente|Activo|28/09/2026
006|Comercial Maya~info@maya.com|5555-1006|6789012-3|Empresa|Sucursal Norte|Activo|05/10/2026",
                        new[] { "Tipo=Empresa,Individual", "Estado=Activo,Inactivo", "Sucursal=" + SUC },
                        "Nombre o razón social:t;NIT:t;Teléfono:t;Correo electrónico:t;Tipo:c=Empresa,Individual;Sucursal:c=" + SUC + ";Dirección:t;Estado:c=Activo,Inactivo");
            return c;
        }
    }
}
