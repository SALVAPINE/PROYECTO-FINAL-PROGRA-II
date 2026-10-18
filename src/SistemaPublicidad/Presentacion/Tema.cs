using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Presentacion
{
    /// <summary>Colores y utilidades compartidas del diseño de Publicidad Multisucursal.</summary>
    public static class Tema
    {
        public static readonly Color Fondo = Color.FromArgb(14, 18, 52);
        public static readonly Color PanelOscuro = Color.FromArgb(22, 28, 76);
        public static readonly Color Tarjeta = Color.FromArgb(26, 32, 84);
        public static readonly Color Campo = Color.FromArgb(30, 37, 92);
        public static readonly Color Acento = Color.FromArgb(61, 63, 206);
        public static readonly Color TextoSuave = Color.FromArgb(160, 170, 220);
        public static readonly Color Verde = Color.FromArgb(34, 197, 130);
        public static readonly Color Azul = Color.FromArgb(59, 130, 246);
        public static readonly Color Ambar = Color.FromArgb(251, 176, 52);
        public static readonly Color Rosa = Color.FromArgb(244, 63, 94);
        public static readonly Color[] Paleta =
        {
            Color.FromArgb(139, 92, 246), Color.FromArgb(59, 130, 246), Color.FromArgb(251, 176, 52),
            Color.FromArgb(34, 197, 130), Color.FromArgb(244, 63, 94), Color.FromArgb(20, 184, 166)
        };

        public static bool EsEstadoConocido(string estado)
        {
            switch (estado)
            {
                case "Activo": case "Aprobada": case "Aprobado": case "Pagada": case "Terminada":
                case "Entregada": case "Entregado": case "Recibida":
                case "En proceso":
                case "Pendiente": case "Emitida":
                case "Inactivo": case "Rechazada": case "Anulada":
                    return true;
                default:
                    return false;
            }
        }

        public static Color ColorEstado(string estado)
        {
            switch (estado)
            {
                case "Activo": case "Aprobada": case "Aprobado": case "Pagada": case "Terminada":
                case "Entregada": case "Entregado": case "Recibida":
                    return Verde;
                case "En proceso":
                    return Azul;
                case "Pendiente": case "Emitida":
                    return Ambar;
                default:
                    return Rosa;
            }
        }

        public static Color ColorEstadoOPaleta(string etiqueta, int indice)
        {
            return EsEstadoConocido(etiqueta) ? ColorEstado(etiqueta) : Paleta[indice % Paleta.Length];
        }

        /// <summary>Estilo oscuro de las tablas. Sin columnas definidas: se generan al enlazar los datos.</summary>
        public static void EstilizarGrid(DataGridView g)
        {
            g.AutoGenerateColumns = true;
            g.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            g.AllowUserToAddRows = false;
            g.AllowUserToDeleteRows = false;
            g.AllowUserToResizeRows = false;
            g.ReadOnly = true;
            g.MultiSelect = false;
            g.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            g.RowHeadersVisible = false;
            g.BorderStyle = BorderStyle.None;
            g.BackgroundColor = PanelOscuro;
            g.GridColor = Color.FromArgb(38, 46, 108);
            g.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            g.EnableHeadersVisualStyles = false;
            g.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            g.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            g.ColumnHeadersHeight = 32;
            g.RowTemplate.Height = 26;

            g.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 26, 72);
            g.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            g.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(20, 26, 72);
            g.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.White;
            g.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);

            g.DefaultCellStyle.BackColor = PanelOscuro;
            g.DefaultCellStyle.ForeColor = Color.White;
            // Simula una selección translúcida mezclando el acento con el fondo marino.
            g.DefaultCellStyle.SelectionBackColor = Dibujo.Mezclar(PanelOscuro, Acento, 0.30F);
            g.DefaultCellStyle.SelectionForeColor = Color.White;
            g.DefaultCellStyle.Font = new Font("Segoe UI", 9F);

            // Evita duplicar el dibujo si el tema se aplica nuevamente a la cuadrícula.
            g.CellPainting -= PintarEstadoComoEtiqueta;
            g.CellPainting += PintarEstadoComoEtiqueta;
        }

        /// <summary>Dibuja los estados como etiquetas compactas dentro de las cuadrículas.</summary>
        private static void PintarEstadoComoEtiqueta(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex < 0) return;

            DataGridView grid = sender as DataGridView;
            if (grid == null) return;

            DataGridViewColumn columna = grid.Columns[e.ColumnIndex];
            if (!string.Equals(columna.Name, "Estado", System.StringComparison.OrdinalIgnoreCase)
                && !string.Equals(columna.HeaderText, "Estado", System.StringComparison.OrdinalIgnoreCase)) return;

            // El encabezado y las etiquetas usan el mismo margen, evitando el padding automático distinto.
            if (e.RowIndex < 0)
            {
                e.PaintBackground(e.ClipBounds, false);
                e.Paint(e.ClipBounds, DataGridViewPaintParts.Border);

                string titulo = e.FormattedValue == null ? columna.HeaderText : e.FormattedValue.ToString();
                Font fuenteTitulo = e.CellStyle.Font ?? grid.ColumnHeadersDefaultCellStyle.Font;
                Color colorTitulo = e.CellStyle.ForeColor;
                TextRenderer.DrawText(e.Graphics, titulo, fuenteTitulo,
                    new Rectangle(e.CellBounds.X + 12, e.CellBounds.Y, e.CellBounds.Width - 16, e.CellBounds.Height),
                    colorTitulo,
                    TextFormatFlags.VerticalCenter | TextFormatFlags.Left | TextFormatFlags.EndEllipsis);
                e.Handled = true;
                return;
            }

            object valor = e.Value;
            if (valor == null || valor == System.DBNull.Value) return;

            string estado;
            if (valor is bool)
                estado = (bool)valor ? "Activo" : "Inactivo";
            else
            {
                estado = valor.ToString();
                if (string.Equals(estado, "true", System.StringComparison.OrdinalIgnoreCase)) estado = "Activo";
                else if (string.Equals(estado, "false", System.StringComparison.OrdinalIgnoreCase)) estado = "Inactivo";
            }

            Color color = ColorEstado(estado);
            Color colorTexto = color;
            Color bordeEtiqueta;
            Color fondoEtiqueta;
            if (string.Equals(estado, "Activo", System.StringComparison.OrdinalIgnoreCase))
            {
                // Verde profundo y borde suave para integrarse con la paleta azul marino.
                colorTexto = Color.FromArgb(102, 218, 177);
                fondoEtiqueta = Color.FromArgb(13, 57, 54);
                bordeEtiqueta = Color.FromArgb(36, 105, 87);
            }
            else if (string.Equals(estado, "Inactivo", System.StringComparison.OrdinalIgnoreCase))
            {
                colorTexto = Color.FromArgb(235, 157, 173);
                fondoEtiqueta = Color.FromArgb(65, 37, 55);
                bordeEtiqueta = Color.FromArgb(111, 63, 81);
            }
            else
            {
                // Conserva un distintivo equivalente para los otros estados del sistema.
                fondoEtiqueta = Dibujo.Mezclar(PanelOscuro, color, 0.38F);
                bordeEtiqueta = Dibujo.Mezclar(PanelOscuro, color, 0.58F);
                colorTexto = Dibujo.Mezclar(Color.White, color, 0.28F);
            }

            e.PaintBackground(e.ClipBounds, true);
            e.Paint(e.ClipBounds, DataGridViewPaintParts.Border);

            using (Font fuente = new Font("Segoe UI", 9F, FontStyle.Bold))
            {
                Size texto = TextRenderer.MeasureText(estado, fuente);
                int alto = 22;
                int ancho = texto.Width + 26;
                // Alinea el inicio de la etiqueta con el margen izquierdo del encabezado "Estado".
                int x = e.CellBounds.X + 12;
                int y = e.CellBounds.Y + (e.CellBounds.Height - alto) / 2;
                Rectangle etiqueta = new Rectangle(x, y, ancho, alto);

                // Radio ligeramente menor que la mitad evita el caso límite que dibuja esquinas rectas.
                using (GraphicsPath fondo = Dibujo.Redondeado(etiqueta, (alto - 2) / 2))
                using (SolidBrush pincelFondo = new SolidBrush(fondoEtiqueta))
                using (Pen lapizBorde = new Pen(bordeEtiqueta, 1F))
                {
                    System.Drawing.Drawing2D.GraphicsState estadoGrafico = e.Graphics.Save();
                    e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    e.Graphics.FillPath(pincelFondo, fondo);
                    e.Graphics.DrawPath(lapizBorde, fondo);
                    TextRenderer.DrawText(e.Graphics, estado, fuente,
                        new Rectangle(etiqueta.X + 1, etiqueta.Y + 1, etiqueta.Width - 2, etiqueta.Height - 2), colorTexto,
                        TextFormatFlags.VerticalCenter | TextFormatFlags.HorizontalCenter | TextFormatFlags.EndEllipsis);
                    e.Graphics.Restore(estadoGrafico);
                }
            }

            e.Handled = true;
        }

        public static void Info(string mensaje)
        {
            MessageBox.Show(mensaje, "Publicidad Multisucursal", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void Aviso(string mensaje)
        {
            MessageBox.Show(mensaje, "Publicidad Multisucursal", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public static bool Confirmar(string mensaje)
        {
            return MessageBox.Show(mensaje, "Publicidad Multisucursal", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
        }
    }

    public static class Dibujo
    {
        /// <summary>Color de fondo opaco del contenedor (sube por los padres hasta encontrar uno sin transparencia).</summary>
        public static Color FondoPadre(Control c)
        {
            Control p = c.Parent;
            while (p != null)
            {
                if (p.BackColor.A == 255) return p.BackColor;
                p = p.Parent;
            }
            return SystemColors.Control;
        }

        public static GraphicsPath Redondeado(Rectangle r, int radio)
        {
            GraphicsPath p = new GraphicsPath();
            int d = radio * 2;
            if (d <= 0 || r.Width <= d || r.Height <= d)
            {
                p.AddRectangle(r);
                return p;
            }
            p.AddArc(r.X, r.Y, d, d, 180, 90);
            p.AddArc(r.Right - d, r.Y, d, d, 270, 90);
            p.AddArc(r.Right - d, r.Bottom - d, d, d, 0, 90);
            p.AddArc(r.X, r.Bottom - d, d, d, 90, 90);
            p.CloseFigure();
            return p;
        }

        public static Color Mezclar(Color a, Color b, float t)
        {
            return Color.FromArgb(
                (int)(a.R + (b.R - a.R) * t),
                (int)(a.G + (b.G - a.G) * t),
                (int)(a.B + (b.B - a.B) * t));
        }
    }
}
