using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Entidad;

namespace Presentacion
{
    /// <summary>Convierte los resúmenes de la capa de negocio en valores de tarjetas y gráficos (los textos fijos se editan en el diseñador).</summary>
    internal static class Resumenes
    {
        public static List<PuntoGrafico> PuntosEstado(IEnumerable<ItemGrafico> items)
        {
            List<PuntoGrafico> lista = new List<PuntoGrafico>();
            if (items == null) return lista;
            int i = 0;
            foreach (ItemGrafico it in items)
            {
                lista.Add(new PuntoGrafico(it.Etiqueta, it.Valor, Tema.ColorEstadoOPaleta(it.Etiqueta, i)));
                i++;
            }
            return lista;
        }

        public static List<PuntoGrafico> PuntosPaleta(IEnumerable<ItemGrafico> items)
        {
            List<PuntoGrafico> lista = new List<PuntoGrafico>();
            if (items == null) return lista;
            int i = 0;
            foreach (ItemGrafico it in items)
            {
                lista.Add(new PuntoGrafico(it.Etiqueta, it.Valor, Tema.Paleta[i % Tema.Paleta.Length]));
                i++;
            }
            return lista;
        }

        public static void Aplicar(ResumenModulo r, StatCard total, StatCard estado1, StatCard estado2, StatCard extra,
                                   GraficoDona dona, GraficoBarras barras)
        {
            total.Valor = r.Total.ToString();
            total.Subtitulo = "Registros";

            Poner(estado1, r.PorEstado != null && r.PorEstado.Count > 0 ? r.PorEstado[0] : null, r.Total);
            Poner(estado2, r.PorEstado != null && r.PorEstado.Count > 1 ? r.PorEstado[1] : null, r.Total);

            if (r.TieneMonto)
            {
                extra.Valor = r.MontoEsMoneda ? r.MontoTotal.ToString("C2") : r.MontoTotal.ToString("0.##");
                extra.Subtitulo = "Acumulado";
            }
            else
            {
                extra.Valor = (r.PorCategoria == null ? 0 : r.PorCategoria.Count(i => i.Valor > 0)).ToString();
                extra.Subtitulo = "con registros";
            }

            dona.SetDatos(PuntosEstado(r.PorEstado));
            barras.SetDatos(PuntosPaleta(r.PorCategoria));
        }

        private static void Poner(StatCard tarjeta, ItemGrafico item, int total)
        {
            if (item == null)
            {
                tarjeta.Valor = "0";
                tarjeta.Subtitulo = "";
                return;
            }
            tarjeta.Valor = item.Valor.ToString("0.##");
            tarjeta.Subtitulo = (total > 0 ? Math.Round(item.Valor / total * 100) : 0) + "% del total";
        }
    }
}
