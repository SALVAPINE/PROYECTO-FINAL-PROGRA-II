using System.Collections.Generic;
using System.Linq;
using Entidad;

namespace Negocio
{
    internal static class ResumenHelper
    {
        /// <summary>Cuenta cuántas veces aparece cada valor. Las categorías base salen siempre (aunque estén en cero).</summary>
        /// <param name="maximo">Si es mayor que cero, devuelve solo los valores más frecuentes (hasta ese número).</param>
        public static List<ItemGrafico> Contar(IEnumerable<string> valores, string[] categorias, int maximo)
        {
            List<string> orden = new List<string>(categorias);
            Dictionary<string, int> conteo = new Dictionary<string, int>();
            foreach (string c in categorias) conteo[c] = 0;

            foreach (string v in valores)
            {
                if (string.IsNullOrWhiteSpace(v)) continue;
                if (!conteo.ContainsKey(v))
                {
                    conteo[v] = 0;
                    orden.Add(v);
                }
                conteo[v]++;
            }

            IEnumerable<string> claves = orden;
            if (maximo > 0)
                claves = orden.OrderByDescending(k => conteo[k]).Take(maximo);

            return claves.Select(k => new ItemGrafico { Etiqueta = k, Valor = conteo[k] }).ToList();
        }
    }
}
