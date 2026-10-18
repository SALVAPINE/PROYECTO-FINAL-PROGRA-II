using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;

namespace CAPAZ.Presentacion.Controles
{
    /// <summary>Utilidades de dibujo compartidas por los controles personalizados.</summary>
    internal static class GraficosUi
    {
        public static GraphicsPath RectanguloRedondeado(RectangleF r, float radio)
        {
            var path = new GraphicsPath();
            if (radio <= 0.5f || r.Width <= 1 || r.Height <= 1)
            {
                path.AddRectangle(r);
                return path;
            }
            float d = radio * 2f;
            if (d > r.Width) { d = r.Width; }
            if (d > r.Height) { d = r.Height; }
            path.AddArc(r.X, r.Y, d, d, 180, 90);
            path.AddArc(r.Right - d, r.Y, d, d, 270, 90);
            path.AddArc(r.Right - d, r.Bottom - d, d, d, 0, 90);
            path.AddArc(r.X, r.Bottom - d, d, d, 90, 90);
            path.CloseFigure();
            return path;
        }

        /// <summary>
        /// Convierte "E710" (4 dígitos hex) en el carácter de Segoe MDL2 Assets.
        /// Si el texto no es un código de 4 dígitos, se usa tal cual (por ejemplo un emoji o un símbolo).
        /// </summary>
        public static string GlifoDesdeCodigo(string codigo)
        {
            if (string.IsNullOrWhiteSpace(codigo)) { return string.Empty; }
            codigo = codigo.Trim();
            int valor;
            if (codigo.Length == 4 &&
                int.TryParse(codigo, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out valor))
            {
                return char.ConvertFromUtf32(valor);
            }
            return codigo;
        }
    
        /// <summary>Separa las letras con espacios finísimos (efecto de texto con tracking amplio).</summary>
        public static string Espaciar(string texto)
        {
            if (string.IsNullOrEmpty(texto)) { return string.Empty; }
            var sb = new System.Text.StringBuilder();
            for (int i = 0; i < texto.Length; i++)
            {
                sb.Append(texto[i]);
                if (i < texto.Length - 1) { sb.Append('\u200a'); }
            }
            return sb.ToString();
        }
    }
}
