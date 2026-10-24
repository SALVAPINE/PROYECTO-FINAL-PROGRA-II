using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace SistemaPublicidad.Formularios
{
    // Apartado "Tipo de Servicio": formulario y definición (columnas, resúmenes, filtros, campos y datos de EJEMPLO)
    public class FrmTipoServicio : FrmModulo
    {
        public FrmTipoServicio() : base(Modulos.Obtener("Tipo de Servicio", "\U0001F6E0", 0)) { }
    }

    public static partial class Modulos
    {
        static ModuloCfg DatosTipoServicio(string nombre, string icono)
        {
            ModuloCfg c;
            c = Def(nombre, icono, new[] { "Total de servicios", "Activos", "Inactivos", "Precio promedio" }, new[] { "5", "5", "0", "Q1,246" }, new[] { "\U0001F6E0", "\U0001F6E1", "\U0001F552", "\U0001FA99" },
                        "ID:44:id:o;Servicio:200:texto:o;Descripción:280:texto;Precio base:100:num:o;Estado:90:estado:o",
                        @"001|Rótulos luminosos|Rótulos con iluminación LED para fachadas|Q 1,500.00|Activo
002|Impresión gran formato|Lonas, vinil y banners|Q 300.00|Activo
003|Vallas publicitarias|Diseño, impresión e instalación|Q 3,100.00|Activo
004|Diseño gráfico|Logotipos, flyers y piezas digitales|Q 680.00|Activo
005|Instalación|Montaje en sitio de rótulos y vallas|Q 650.00|Activo",
                        new[] { "Estado=Activo,Inactivo", "Categoría=", "Orden=" }, "Nombre del servicio:t;Descripción:t;Precio base (Q):n;Estado:c=Activo,Inactivo");
            return c;
        }
    }
}
