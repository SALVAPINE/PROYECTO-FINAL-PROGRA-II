using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace SistemaPublicidad.Formularios
{
    // Imágenes incrustadas (carpeta Recursos): logo, íconos e ilustraciones
    public static class Recursos
    {
        static readonly Dictionary<string, Bitmap> cache = new Dictionary<string, Bitmap>();
        public static Bitmap Img(string n)
        {
            Bitmap b; if (cache.TryGetValue(n, out b)) return b;
            try { using (var s = typeof(Recursos).Assembly.GetManifestResourceStream("SistemaPublicidad.Recursos." + n + ".png")) { if (s == null) b = null; else using (var t = new Bitmap(s)) b = new Bitmap(t); } }
            catch (Exception) { b = null; }
            cache[n] = b; return b;
        }
        public static void Dibujar(Graphics g, Bitmap b, RectangleF r)
        {
            if (b == null) return;
            var im = g.InterpolationMode; var po = g.PixelOffsetMode; g.InterpolationMode = InterpolationMode.HighQualityBicubic; g.PixelOffsetMode = PixelOffsetMode.HighQuality;
            using (var ia = new System.Drawing.Imaging.ImageAttributes()) { ia.SetWrapMode(WrapMode.TileFlipXY); g.DrawImage(b, Rectangle.Round(r), 0, 0, b.Width, b.Height, GraphicsUnit.Pixel, ia); }
            g.InterpolationMode = im; g.PixelOffsetMode = po;
        }
        public static bool Tile(Graphics g, string n, Rectangle r) { var b = Img(n); if (b == null) return false; Dibujar(g, b, r); return true; }
    }

    public class ImgBox : Control
    {
        public Bitmap Imagen { get; set; }
        public ImgBox() { SetStyle(ControlStyles.SupportsTransparentBackColor | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true); BackColor = Color.Transparent; }
        protected override void OnPaint(PaintEventArgs e) { Recursos.Dibujar(e.Graphics, Imagen, new RectangleF(0, 0, Width, Height)); }
    }
}
