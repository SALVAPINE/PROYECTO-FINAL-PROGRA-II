using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace SistemaPublicidad.Formularios
{
    // Íconos vectoriales (línea) dibujados con GDI+; nítidos a cualquier tamaño.
    public static class Iconos
    {
        public static void Dibujar(Graphics g, string key, RectangleF r, Color col, float grosor = 0)
        {
            key = (key ?? "").Replace("\uFE0F", "");
            float w = grosor > 0 ? grosor : Math.Max(1.6f, r.Width / 11f);
            var sm = g.SmoothingMode; g.SmoothingMode = SmoothingMode.AntiAlias;
            using (var pen = new Pen(col, w) { StartCap = LineCap.Round, EndCap = LineCap.Round, LineJoin = LineJoin.Round })
            using (var br = new SolidBrush(col))
            {
                Func<float, float> X = v => r.X + v * r.Width;
                Func<float, float> Y = v => r.Y + v * r.Height;
                Func<float, float, PointF> Pt = (a, b) => new PointF(X(a), Y(b));
                Func<float, float, float, float, RectangleF> Rc = (a, b, cw, ch) => new RectangleF(X(a), Y(b), cw * r.Width, ch * r.Height);
                Func<float[], PointF[]> Pts = v => { var q = new PointF[v.Length / 2]; for (int i = 0; i < q.Length; i++) q[i] = Pt(v[2 * i], v[2 * i + 1]); return q; };
                Action<float[]> Poly = v => g.DrawLines(pen, Pts(v));
                Action<float[]> Cerr = v => g.DrawPolygon(pen, Pts(v));
                Action<float, float, float, float, float> Rr = (a, b, cw, ch, rad) => { using (var p = Tema.Ruta(Rc(a, b, cw, ch), rad * r.Width)) g.DrawPath(pen, p); };
                Action<float, float, float, float, float> Fr = (a, b, cw, ch, rad) => { using (var p = Tema.Ruta(Rc(a, b, cw, ch), rad * r.Width)) g.FillPath(br, p); };
                Action<float, float, float, float> El = (a, b, cw, ch) => g.DrawEllipse(pen, Rc(a, b, cw, ch));
                Action<float, float, float, float> Fe = (a, b, cw, ch) => g.FillEllipse(br, Rc(a, b, cw, ch));
                Action<float, float, float, float, float, float> Ar = (a, b, cw, ch, st, sw) => g.DrawArc(pen, Rc(a, b, cw, ch), st, sw);
                Action<float, float, float, float> Ln = (a, b, c2, d) => g.DrawLine(pen, Pt(a, b), Pt(c2, d));
                switch (key)
                {
                    case "\U0001F3E0": Poly(new[] { .1f, .5f, .5f, .12f, .9f, .5f }); Poly(new[] { .2f, .44f, .2f, .88f, .8f, .88f, .8f, .44f }); Poly(new[] { .42f, .88f, .42f, .64f, .58f, .64f, .58f, .88f }); break;
                    case "\U0001F464": El(.3f, .1f, .4f, .4f); Ar(.14f, .58f, .72f, .8f, 180, 180); break;
                    case "\U0001F465": El(.16f, .14f, .3f, .3f); Ar(.04f, .56f, .54f, .7f, 180, 180); El(.56f, .2f, .26f, .26f); Ar(.5f, .6f, .46f, .6f, 180, 180); break;
                    case "\U0001F4C4":
                    case "\U0001F4DD": Rr(.2f, .08f, .6f, .84f, .08f); Ln(.32f, .35f, .68f, .35f); Ln(.32f, .5f, .68f, .5f); Ln(.32f, .65f, .54f, .65f); break;
                    case "\U0001F6E0": Fe(.08f, .18f, .1f, .1f); Fe(.08f, .45f, .1f, .1f); Fe(.08f, .72f, .1f, .1f); Ln(.32f, .23f, .92f, .23f); Ln(.32f, .5f, .92f, .5f); Ln(.32f, .77f, .92f, .77f); break;
                    case "\U0001F69A": Rr(.05f, .28f, .52f, .42f, .05f); Cerr(new[] { .57f, .4f, .78f, .4f, .93f, .56f, .93f, .7f, .57f, .7f }); El(.16f, .64f, .17f, .17f); El(.66f, .64f, .17f, .17f); break;
                    case "\U0001F5BC": Rr(.1f, .15f, .8f, .7f, .08f); El(.26f, .3f, .14f, .14f); Poly(new[] { .1f, .78f, .4f, .52f, .6f, .7f, .72f, .6f, .9f, .78f }); break;
                    case "\U0001F3A8": El(.08f, .12f, .84f, .76f); Fe(.26f, .32f, .1f, .1f); Fe(.46f, .22f, .1f, .1f); Fe(.66f, .32f, .1f, .1f); Fe(.28f, .55f, .1f, .1f); break;
                    case "\u270F": Cerr(new[] { .18f, .82f, .2f, .6f, .62f, .18f, .82f, .38f, .4f, .8f }); Ln(.52f, .28f, .72f, .48f); break;
                    case "\U0001F4CB": Rr(.18f, .15f, .64f, .75f, .08f); Rr(.36f, .06f, .28f, .16f, .05f); Poly(new[] { .33f, .55f, .46f, .68f, .68f, .42f }); break;
                    case "\U0001F9FE": Cerr(new[] { .2f, .08f, .2f, .92f, .3f, .84f, .4f, .92f, .5f, .84f, .6f, .92f, .7f, .84f, .8f, .92f, .8f, .08f }); Ln(.34f, .32f, .66f, .32f); Ln(.34f, .5f, .66f, .5f); break;
                    case "\U0001F4CD":
                        using (var p = new GraphicsPath()) { p.AddArc(Rc(.22f, .08f, .56f, .56f), 140, 260); p.AddLine(p.GetLastPoint(), Pt(.5f, .95f)); p.CloseFigure(); g.DrawPath(pen, p); }
                        El(.4f, .26f, .2f, .2f); break;
                    case "\U0001F4E6": Cerr(new[] { .5f, .08f, .88f, .28f, .88f, .72f, .5f, .92f, .12f, .72f, .12f, .28f }); Poly(new[] { .12f, .28f, .5f, .48f, .88f, .28f }); Ln(.5f, .48f, .5f, .92f); break;
                    case "\U0001F5C4": El(.15f, .1f, .7f, .22f); Ln(.15f, .21f, .15f, .79f); Ln(.85f, .21f, .85f, .79f); Ar(.15f, .68f, .7f, .22f, 0, 180); Ar(.15f, .39f, .7f, .22f, 0, 180); break;
                    case "\U0001F6D2": Poly(new[] { .06f, .14f, .22f, .14f, .34f, .62f, .8f, .62f, .9f, .28f, .26f, .28f }); El(.36f, .76f, .12f, .12f); El(.68f, .76f, .12f, .12f); break;
                    case "\u2699":
                        El(.34f, .34f, .32f, .32f); El(.2f, .2f, .6f, .6f);
                        for (int k = 0; k < 8; k++) { double an = k * Math.PI / 4; Ln(.5f + .3f * (float)Math.Cos(an), .5f + .3f * (float)Math.Sin(an), .5f + .44f * (float)Math.Cos(an), .5f + .44f * (float)Math.Sin(an)); }
                        break;
                    case "\u23FB": Ar(.2f, .2f, .6f, .6f, -50, 280); Ln(.5f, .08f, .5f, .48f); break;
                    case "\U0001F50D": El(.12f, .12f, .5f, .5f); Ln(.56f, .56f, .88f, .88f); break;
                    case "\U0001F514": Ar(.22f, .12f, .56f, .56f, 180, 180); Poly(new[] { .22f, .4f, .22f, .66f, .12f, .78f, .88f, .78f, .78f, .66f, .78f, .4f }); Ar(.4f, .8f, .2f, .14f, 0, 180); break;
                    case "\U0001F4C5": Rr(.1f, .18f, .8f, .72f, .08f); Ln(.1f, .42f, .9f, .42f); Ln(.3f, .08f, .3f, .28f); Ln(.7f, .08f, .7f, .28f); break;
                    case "\U0001F4CA": Fr(.15f, .5f, .18f, .4f, .04f); Fr(.41f, .25f, .18f, .65f, .04f); Fr(.67f, .08f, .18f, .82f, .04f); break;
                    case "\U0001FA99": El(.1f, .1f, .8f, .8f); El(.28f, .28f, .44f, .44f); break;
                    case "\U0001F552": El(.1f, .1f, .8f, .8f); Poly(new[] { .5f, .28f, .5f, .5f, .68f, .6f }); break;
                    case "\U0001F6E1": Cerr(new[] { .5f, .06f, .86f, .2f, .86f, .52f, .5f, .94f, .14f, .52f, .14f, .2f }); Poly(new[] { .56f, .3f, .42f, .54f, .58f, .54f, .44f, .78f }); break;
                    case "\U0001F4E2":
                        g.FillPolygon(br, Pts(new[] { .14f, .38f, .4f, .38f, .8f, .14f, .8f, .86f, .4f, .62f, .14f, .62f })); Ln(.28f, .64f, .34f, .88f); Ar(.76f, .28f, .2f, .44f, -60, 120); break;
                    case "\U0001F5D1": Rr(.25f, .32f, .5f, .58f, .06f); Ln(.14f, .25f, .86f, .25f); Poly(new[] { .4f, .25f, .4f, .12f, .6f, .12f, .6f, .25f }); Ln(.4f, .46f, .4f, .76f); Ln(.6f, .46f, .6f, .76f); break;
                    case "\u2795": Ln(.5f, .15f, .5f, .85f); Ln(.15f, .5f, .85f, .5f); break;
                    default:
                        using (var f = new Font("Segoe UI Emoji", Math.Max(6f, r.Width * 0.5f)))
                        using (var sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center }) g.DrawString(key, f, br, r, sf);
                        break;
                }
            }
            g.SmoothingMode = sm;
        }
    }

    public class IconoLinea : Control
    {
        public string Key { get; set; } = ""; public Color Color { get; set; } = Color.White; public Bitmap Imagen { get; set; }
        public IconoLinea() { SetStyle(ControlStyles.SupportsTransparentBackColor | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true); BackColor = Color.Transparent; }
        protected override void OnPaint(PaintEventArgs e)
        { if (Imagen != null) Recursos.Dibujar(e.Graphics, Imagen, new RectangleF(0, 0, Width, Height)); else Iconos.Dibujar(e.Graphics, Key, new RectangleF(1, 1, Width - 2, Height - 2), Color, 1.8f); }
    }
}
