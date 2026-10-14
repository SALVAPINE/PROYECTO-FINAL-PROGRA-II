using System.Drawing;

namespace Presentacion
{
    /// <summary>Un dato de los gráficos propios (etiqueta, valor y color).</summary>
    public class PuntoGrafico
    {
        public string Etiqueta { get; set; }
        public decimal Valor { get; set; }
        public Color Color { get; set; }

        public PuntoGrafico(string etiqueta, decimal valor, Color color)
        {
            Etiqueta = etiqueta;
            Valor = valor;
            Color = color;
        }
    }
}
