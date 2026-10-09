using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Presentacion
{
    /// <summary>Colores y utilidades compartidas del diseño CAPAZ.</summary>
    public static class Tema
    {
        public static readonly Color Fondo = Color.FromArgb(14, 18, 52);
        public static readonly Color PanelOscuro = Color.FromArgb(22, 28, 76);
        public static readonly Color Tarjeta = Color.FromArgb(26, 32, 84);
        public static readonly Color Campo = Color.FromArgb(30, 37, 92);
        public static readonly Color Acento = Color.FromArgb(61, 63, 206);
        public static readonly Color TextoSuave = Color.FromArgb(160, 170, 220);
        public static readonly Color Verde = Color.FromArgb(46, 212, 122);
        public static readonly Color Rojo = Color.FromArgb(255, 59, 59);
        public static readonly Color Ambar = Color.FromArgb(255, 193, 7);
        public static readonly Color[] Paleta =
        {
            Color.FromArgb(61, 63, 206), Color.FromArgb(32, 201, 170), Color.FromArgb(140, 120, 240),
            Color.FromArgb(255, 193, 7), Color.FromArgb(255, 99, 132), Color.FromArgb(100, 130, 255)
        };

        public static Color ColorEstado(string estado)
        {
            switch (estado)
            {
                case "Activo":
                case "Aprobada":
                case "Aprobado":
                case "Pagada":
                case "Terminada":
                case "Entregada":
                case "Entregado":
                case "Recibida":
                    return Verde;
                case "Pendiente":
                case "En proceso":
                case "Emitida":
                    return Ambar;
                default:
                    return Rojo;
            }
        }

        public static void EstilizarGrid(DataGridView g)
        {
            g.AutoGenerateColumns = false;
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
            g.DefaultCellStyle.SelectionBackColor = Acento;
            g.DefaultCellStyle.SelectionForeColor = Color.White;
            g.DefaultCellStyle.Font = new Font("Segoe UI", 9F);
        }

        public static void Info(string mensaje)
        {
            MessageBox.Show(mensaje, "CAPAZ", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void Aviso(string mensaje)
        {
            MessageBox.Show(mensaje, "CAPAZ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public static bool Confirmar(string mensaje)
        {
            return MessageBox.Show(mensaje, "CAPAZ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
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
            var p = new GraphicsPath();
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
