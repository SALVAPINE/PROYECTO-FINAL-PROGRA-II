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
            g.DefaultCellStyle.SelectionBackColor = Acento;
            g.DefaultCellStyle.SelectionForeColor = Color.White;
            g.DefaultCellStyle.Font = new Font("Segoe UI", 9F);
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
