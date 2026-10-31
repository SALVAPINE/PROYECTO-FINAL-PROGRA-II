#if LOGIN_STANDALONE
extern alias SistemaPublicidadCompartida;
#endif

using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Entidad;
using Negocio;
using Login.Controles;
#if LOGIN_STANDALONE
using AppDialog = SistemaPublicidadCompartida::SistemaPublicidad.Formularios.AppDialog;
#else
using SistemaPublicidad.Formularios;
#endif

namespace Login.Formularios
{
    public class FrmLogin : Form
    {
        [DllImport("user32.dll")] static extern bool ReleaseCapture();
        [DllImport("user32.dll")] static extern IntPtr SendMessage(IntPtr h, int m, int w, int l);
        [DllImport("user32.dll", CharSet = CharSet.Unicode)] static extern IntPtr SendMessage(IntPtr h, int m, IntPtr w, string l);

        static readonly Color Campo = Color.FromArgb(13, 24, 76);
        TextBox txtUsuario, txtClave;
        Label lblOjo, lnkOlvido, phUsuario, phClave;
        NeonCheck chkRecordar;
        GradientButton btnIngresar;
        RoleCard[] roles;
        bool verClave;
        Bitmap bg;
        readonly Timer fade = new Timer { Interval = 15 };
        readonly Timer anim = new Timer { Interval = 33 };
        double t;
        int foco;
        const int N = 52;
        float[] px = new float[N], py = new float[N], pv = new float[N], pp = new float[N];
        readonly Rectangle artRect = U.R(630, 0, 342, 960);

        public string RolSeleccionado
        {
            get { foreach (var r in roles) if (r.Selected) return r.Title; return ""; }
        }

        // El formulario principal recibe estos valores solo cuando la cuenta es válida.
        public string UsuarioAutenticado { get; private set; }
        public string RolAutenticado { get; private set; }

        public FrmLogin()
        {
            AutoScaleMode = AutoScaleMode.None;
            FormBorderStyle = FormBorderStyle.None;
            StartPosition = FormStartPosition.CenterScreen;
            ClientSize = new Size(U.P(1640), U.P(960));
            BackColor = Color.FromArgb(3, 6, 30);
            DoubleBuffered = true;
            Text = "Publicidad Multisucursal - Iniciar sesión";

            var rnd = new Random(7);
            for (int i = 0; i < N; i++) { px[i] = 640 + rnd.Next(325); py[i] = rnd.Next(960); pv[i] = 6 + rnd.Next(16); pp[i] = rnd.Next(628) / 100f; }

            var min = new WinBtn { Kind = 0, Bounds = U.R(1456, 22, 44, 40) };
            var max = new WinBtn { Kind = 1, Bounds = U.R(1514, 22, 44, 40) };
            var cls = new WinBtn { Kind = 2, Bounds = U.R(1572, 22, 44, 40) };
            min.Click += (s, e) => WindowState = FormWindowState.Minimized;
            max.Click += (s, e) => WindowState = WindowState == FormWindowState.Maximized ? FormWindowState.Normal : FormWindowState.Maximized;
            cls.Click += (s, e) => Close();
            Controls.AddRange(new Control[] { min, max, cls });

            txtUsuario = MakeTb(U.R(1125, 393, 380, 30), false, "Ingrese su usuario");
            txtClave = MakeTb(U.R(1125, 486, 380, 30), true, "Ingrese su contraseña");
            phUsuario = Ph("Ingrese su usuario", txtUsuario);
            phClave = Ph("Ingrese su contraseña", txtClave);
            txtUsuario.Enter += (s, e) => Foco(1); txtUsuario.Leave += (s, e) => Foco(0);
            txtClave.Enter += (s, e) => Foco(2); txtClave.Leave += (s, e) => Foco(0);
            lblOjo = new Label
            {
                AutoSize = false, Bounds = U.R(1494, 462, 66, 52), Text = "\uED1A", Font = U.Ico(28),
                ForeColor = Color.FromArgb(165, 182, 225), BackColor = Color.Transparent,
                TextAlign = ContentAlignment.MiddleCenter, Cursor = Cursors.Hand
            };
            lblOjo.MouseEnter += (s, e) => lblOjo.ForeColor = Color.White;
            lblOjo.MouseLeave += (s, e) => lblOjo.ForeColor = Color.FromArgb(165, 182, 225);
            lblOjo.Click += (s, e) =>
            {
                verClave = !verClave;
                txtClave.UseSystemPasswordChar = !verClave;
                lblOjo.Text = verClave ? "\uE7B3" : "\uED1A";
            };

            chkRecordar = new NeonCheck { Text = "Recordar usuario", Checked = false, Bounds = U.R(1047, 538, 260, 34) };
            chkRecordar.Click += (s, e) =>
            {
                if (!chkRecordar.Checked && !PreferenciasLogin.Guardar(false, "", ""))
                    AppDialog.Warning(this, "Preferencias", "No se pudo borrar el usuario recordado en este equipo.");
            };
            lnkOlvido = new Label
            {
                AutoSize = false, Bounds = U.R(1320, 540, 247, 30), Text = "¿Olvidó su contraseña?", Font = U.F(17),
                ForeColor = Color.FromArgb(80, 180, 255), BackColor = Color.Transparent,
                TextAlign = ContentAlignment.MiddleRight, Cursor = Cursors.Hand
            };
            lnkOlvido.MouseEnter += (s, e) => lnkOlvido.ForeColor = Color.White;
            lnkOlvido.MouseLeave += (s, e) => lnkOlvido.ForeColor = Color.FromArgb(80, 180, 255);
            lnkOlvido.Click += (s, e) => AppDialog.Information(this, "Recuperar acceso",
                "Comunícate con el administrador del sistema para restablecer tu contraseña.");

            btnIngresar = new GradientButton { Text = "INICIAR SESIÓN" };
            btnIngresar.Bounds = Rectangle.Inflate(U.R(1047, 590, 520, 64), btnIngresar.Pad, btnIngresar.Pad);
            btnIngresar.Click += (s, e) => Ingresar();

            roles = new[]
            {
                new RoleCard { Title = "Administrador", Sub = "Acceso completo", Glyph = "\uE77B", Accent = Color.FromArgb(40, 150, 255), Selected = true },
                new RoleCard { Title = "Diseñador", Sub = "Diseño y creatividad", Glyph = "\uE70F", Accent = Color.FromArgb(235, 55, 205) },
                new RoleCard { Title = "Operador", Sub = "Gestión y soporte", Glyph = "\uE713", Accent = Color.FromArgb(255, 200, 30) },
                new RoleCard { Title = "Gerente", Sub = "Gestión general", Glyph = "\uE716", Accent = Color.FromArgb(0, 210, 180) },
                new RoleCard { Title = "Vendedor", Sub = "Ventas y clientes", Glyph = "\uE719", Accent = Color.FromArgb(120, 170, 255) }
            };
            var rb = new[] { U.R(1045, 710, 176, 100), U.R(1238, 710, 160, 100), U.R(1414, 710, 160, 100),
                U.R(1045, 825, 176, 100), U.R(1238, 825, 160, 100) };
            for (int i = 0; i < roles.Length; i++)
            {
                var rc = roles[i];
                rc.Bounds = Rectangle.Inflate(rb[i], rc.Pad, rc.Pad);
                rc.Click += (s, e) => { foreach (var o in roles) o.Selected = (o == rc); };
            }

            Controls.AddRange(new Control[] { txtUsuario, txtClave, phUsuario, phClave, lblOjo, chkRecordar, lnkOlvido, btnIngresar });
            Controls.AddRange(roles);
            txtUsuario.KeyDown += EnterKey;
            txtClave.KeyDown += EnterKey;
            string[] recordado = PreferenciasLogin.Leer();
            if (recordado.Length == 2)
            {
                txtUsuario.Text = recordado[0];
                chkRecordar.Checked = true;
                foreach (var tarjeta in roles) tarjeta.Selected = tarjeta.Title == recordado[1];
            }

            Opacity = 0;
            fade.Tick += (s, e) => { Opacity = Math.Min(1, Opacity + 0.08); if (Opacity >= 1) fade.Stop(); };
            anim.Tick += (s, e) =>
            {
                t += 0.033;
                Invalidate(artRect);
                btnIngresar.T = t; btnIngresar.Invalidate();
                foreach (var r in roles) { r.T = t; r.Step(); if (r.Selected) r.Invalidate(); }
            };
            Shown += (s, e) => { fade.Start(); anim.Start(); txtUsuario.Focus(); };
        }

        void Foco(int f)
        {
            foco = f;
            Invalidate(Rectangle.Inflate(U.R(1047, 358, 520, 161), U.P(14), U.P(14)));
        }

        void EnterKey(object s, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) { e.SuppressKeyPress = true; Ingresar(); }
        }

        TextBox MakeTb(Rectangle b, bool clave, string cue)
        {
            var tb = new TextBox { BorderStyle = BorderStyle.None, BackColor = Campo, ForeColor = Color.White, Font = U.F(20), Bounds = b };
            if (clave) tb.UseSystemPasswordChar = true;
            return tb;
        }

        // Placeholder propio (mismo color y tamaño que el mockup)
        Label Ph(string texto, TextBox tb)
        {
            var l = new Label
            {
                AutoSize = false, Text = texto, Font = U.F(20), ForeColor = Color.FromArgb(112, 140, 200),
                BackColor = Color.Transparent, TextAlign = ContentAlignment.MiddleLeft,
                Bounds = new Rectangle(tb.Left + 2, tb.Top, tb.Width, tb.Height)
            };
            l.Click += (s, e) => tb.Focus();
            tb.TextChanged += (s, e) => l.Visible = tb.Text.Length == 0;
            return l;
        }

        static void SetCue(TextBox tb, string cue)
        {
            if (tb.IsHandleCreated) SendMessage(tb.Handle, 0x1501, new IntPtr(1), cue);
        }

        void Ingresar()
        {
            if (string.IsNullOrWhiteSpace(txtUsuario.Text) || txtClave.Text.Length == 0)
            {
                AppDialog.Warning(this, "Completa tus datos",
                    "Escribe tu usuario y contraseña para iniciar sesión.");
                return;
            }

            string usuario = txtUsuario.Text.Trim();
            string clave = txtClave.Text;
            string rol = RolSeleccionado;

            try
            {
                var negocio = new UsuarioNegocio();
                Usuario cuenta = negocio.Autenticar(usuario, clave);

                if (cuenta == null)
                {
                    AppDialog.Error(this, "No se pudo iniciar sesión",
                        "El usuario o la contraseña son incorrectos, o la cuenta está inactiva.");
                    txtClave.Clear();
                    txtClave.Focus();
                    return;
                }

                string tipo = cuenta.TipoUsuario ?? string.Empty;
                bool rolCoincide = string.Equals(tipo, rol, StringComparison.OrdinalIgnoreCase) ||
                    (rol == "Diseñador" && tipo.Equals("Disenador", StringComparison.OrdinalIgnoreCase));

                if (!rolCoincide)
                {
                    SesionActual.Cerrar();
                    AppDialog.Warning(this, "Perfil no coincide",
                        "La cuenta '" + usuario + "' pertenece al perfil '" + cuenta.TipoUsuario + "'. Selecciona la tarjeta correspondiente.");
                    return;
                }

                UsuarioAutenticado = cuenta.NombreUsuario;
                RolAutenticado = cuenta.TipoUsuario;
                if (!PreferenciasLogin.Guardar(chkRecordar.Checked, cuenta.NombreUsuario, rol))
                    AppDialog.Warning(this, "Preferencias", "Tu acceso es válido, pero no se pudo guardar la preferencia de usuario en este equipo.");
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                AppDialog.Error(this, "Error de autenticación",
                    "No se pudo validar el usuario con la base de datos: " + ex.Message);
            }
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (e.Button == MouseButtons.Left) { ReleaseCapture(); SendMessage(Handle, 0xA1, 2, 0); }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                fade.Dispose();
                anim.Dispose();
                if (bg != null) { bg.Dispose(); bg = null; }
            }
            base.Dispose(disposing);
        }

        static void Calidad(Graphics g)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;
            g.TextRenderingHint = TextRenderingHint.AntiAlias;
        }

        // ============ ESCENA ESTÁTICA (se dibuja una sola vez en un bitmap) ============
        protected override void OnPaint(PaintEventArgs e)
        {
            if (bg == null || bg.Size != ClientSize)
            {
                if (bg != null) bg.Dispose();
                bg = new Bitmap(ClientSize.Width, ClientSize.Height);
                using (var gb = Graphics.FromImage(bg)) { Calidad(gb); Escena(gb); }
            }
            var g = e.Graphics;
            g.DrawImage(bg, e.ClipRectangle, e.ClipRectangle, GraphicsUnit.Pixel);
            Calidad(g);
            Dinamico(g);
        }

        void Escena(Graphics g)
        {
            var full = new Rectangle(0, 0, Width, Height);
            using (var b = new LinearGradientBrush(full, Color.FromArgb(2, 5, 28), Color.FromArgb(10, 8, 58), 30f)) g.FillRectangle(b, full);
            U.Glow(g, 700, 30, 440, Color.FromArgb(130, 40, 70, 255));
            U.Glow(g, 40, 960, 560, Color.FromArgb(160, 230, 40, 220));
            U.Glow(g, 960, 900, 420, Color.FromArgb(160, 255, 110, 30));
            U.Glow(g, 330, 470, 380, Color.FromArgb(55, 60, 60, 220));

            Curvas(g);
            Arte(g);

            using (var b = new SolidBrush(Color.FromArgb(4, 8, 34))) g.FillRectangle(b, U.P(972), 0, Width - U.P(972), Height);
            U.Glow(g, 1320, 520, 540, Color.FromArgb(55, 40, 70, 255));
            U.Glow(g, 1560, 60, 260, Color.FromArgb(40, 120, 60, 255));

            Izquierda(g);
            Tarjeta(g);
        }

        void Curvas(Graphics g)
        {
            // Banda curva superior izquierda
            var q = U.Pt(560, 0, 520, 150, 300, 300, 0, 335);
            using (var gp = new GraphicsPath())
            {
                gp.AddBezier(q[0], q[1], q[2], q[3]);
                gp.AddLine(q[3], new PointF(0, 0));
                gp.CloseFigure();
                using (var b = new LinearGradientBrush(gp.GetBounds(), Color.FromArgb(110, 50, 80, 255), Color.FromArgb(0, 120, 60, 255), 40f)) g.FillPath(b, gp);
            }
            using (var gp = new GraphicsPath())
            {
                gp.AddBezier(q[0], q[1], q[2], q[3]);
                U.GlowPath(g, gp, Color.FromArgb(90, 120, 255), 1f, 16, 10, 5);
                using (var p = new Pen(Color.FromArgb(200, 120, 160, 255), 2f)) g.DrawPath(p, gp);
            }
            var q2 = U.Pt(630, 0, 600, 190, 340, 340, 0, 395);
            using (var gp = new GraphicsPath())
            {
                gp.AddBezier(q2[0], q2[1], q2[2], q2[3]);
                using (var p = new Pen(Color.FromArgb(120, 200, 80, 255), 2f)) g.DrawPath(p, gp);
            }
            // Ondas inferior izquierda
            var w1 = U.Pt(0, 770, 270, 735, 470, 830, 575, 960);
            using (var gp = new GraphicsPath())
            {
                gp.AddBezier(w1[0], w1[1], w1[2], w1[3]);
                gp.AddLine(w1[3], new PointF(0, Height));
                gp.CloseFigure();
                using (var b = new LinearGradientBrush(gp.GetBounds(), Color.FromArgb(170, 150, 40, 255), Color.FromArgb(200, 255, 90, 90), 20f)) g.FillPath(b, gp);
            }
            using (var gp = new GraphicsPath())
            {
                gp.AddBezier(w1[0], w1[1], w1[2], w1[3]);
                U.GlowPath(g, gp, Color.FromArgb(255, 90, 220), 1f, 14, 8, 4);
                using (var p = new Pen(Color.FromArgb(230, 255, 190, 255), 2f)) g.DrawPath(p, gp);
            }
            var w2 = U.Pt(0, 850, 210, 825, 400, 905, 470, 960);
            using (var gp = new GraphicsPath())
            {
                gp.AddBezier(w2[0], w2[1], w2[2], w2[3]);
                gp.AddLine(w2[3], new PointF(0, Height));
                gp.CloseFigure();
                using (var b = new LinearGradientBrush(gp.GetBounds(), Color.FromArgb(170, 110, 30, 220), Color.FromArgb(210, 255, 120, 60), 20f)) g.FillPath(b, gp);
            }
        }

        void Arte(Graphics g)
        {
            U.Poly(g, U.Pt(540, 960, 700, 700, 972, 470, 972, 960), Color.FromArgb(210, 150, 60, 255), Color.FromArgb(240, 255, 120, 60), 60f);
            U.Poly(g, U.Pt(684, 205, 880, 150, 880, 740, 684, 740), Color.FromArgb(240, 255, 232, 215), Color.FromArgb(235, 255, 70, 190), 90f);
            for (int i = 0; i < 16; i++)
                using (var b = new SolidBrush(Color.FromArgb(i % 3 == 0 ? 26 : 12, 255, 255, 255)))
                    g.FillRectangle(b, U.P(692 + i * 11.5f), U.P(215), U.P(4 + (i % 4)), U.P(520));
            U.Poly(g, U.Pt(684, 205, 780, 175, 700, 740, 684, 740), Color.FromArgb(40, 255, 255, 255), Color.FromArgb(0, 255, 255, 255), 0f);
            U.Poly(g, U.Pt(795, 0, 866, 0, 866, 420, 795, 420), Color.FromArgb(255, 255, 200, 60), Color.FromArgb(255, 255, 110, 70), 90f);
            U.Poly(g, U.Pt(866, 0, 922, 0, 922, 330, 866, 400), Color.FromArgb(255, 200, 235, 255), Color.FromArgb(255, 60, 140, 255), 90f);
            U.Poly(g, U.Pt(738, 124, 795, 36, 795, 124), Color.FromArgb(255, 255, 205, 40), Color.FromArgb(255, 255, 140, 30), 90f);
            U.Poly(g, U.Pt(795, 150, 866, 150, 866, 420, 795, 420), Color.FromArgb(50, 255, 255, 255), Color.FromArgb(0, 255, 255, 255), 0f);

            // Disco oscuro con aro de neón
            var circ = new RectangleF(U.P(740), U.P(340), U.P(490), U.P(490));
            using (var gp = new GraphicsPath())
            {
                gp.AddEllipse(circ);
                using (var b = new SolidBrush(Color.FromArgb(245, 4, 8, 44))) g.FillPath(b, gp);
                U.GlowPath(g, gp, Color.FromArgb(220, 80, 220), 1f, 18, 11, 6);
                using (var lb = new LinearGradientBrush(circ, Color.FromArgb(255, 90, 210), Color.FromArgb(70, 130, 255), 75f))
                using (var p = new Pen(lb, 3.5f)) g.DrawPath(p, gp);
            }
            U.Poly(g, U.Pt(880, 700, 940, 705, 940, 960, 880, 960), Color.FromArgb(255, 255, 90, 170), Color.FromArgb(255, 255, 165, 40), 90f);

            using (var p = new Pen(Color.FromArgb(230, 70, 120, 255), 2f)) g.DrawLine(p, U.P(800), U.P(380), U.P(910), U.P(160));
            using (var p = new Pen(Color.FromArgb(100, 150, 190, 255), 1.5f)) g.DrawLines(p, U.Pt(800, 380, 910, 330, 910, 160));

            // Cuadrícula de puntos y destellos
            for (int x = 0; x < 5; x++)
                for (int y = 0; y < 8; y++)
                    using (var b = new SolidBrush(Color.FromArgb(120 + (x + y) * 8, 255, 170 - y * 8, 70)))
                        g.FillEllipse(b, U.P(908 + x * 11), U.P(826 + y * 11), 3, 3);
            for (int i = 0; i < 14; i++)
                using (var b = new SolidBrush(Color.FromArgb(110, 255, 255, 255)))
                    g.FillEllipse(b, U.P(935 + (i * 7) % 28), U.P(95 + (i * 11) % 120), 2, 2);

            string[] pal = { "DISEÑO", "IDEAS", "ESTRATEGIA", "RESULTADOS" };
            for (int i = 0; i < pal.Length; i++)
                U.Spaced(g, pal[i], U.F(13, FontStyle.Bold), Color.FromArgb(225, 225, 255), 705, 385 + i * 23, 5);

            var st = g.Save();
            g.TranslateTransform(U.P(645), U.P(752));
            g.RotateTransform(-12);
            var sf = U.F(27, FontStyle.Italic, "Segoe Script");
            using (var b = new SolidBrush(Color.FromArgb(60, 120, 160, 255))) g.DrawString("Tu idea,\nnuestra inspiración", sf, b, 2, 2);
            g.DrawString("Tu idea,\nnuestra inspiración", sf, Brushes.White, 0, 0);
            g.Restore(st);
            using (var p = new Pen(Color.FromArgb(120, 255, 255, 255), 6f)) g.DrawBezier(p, U.P(650), U.P(852), U.P(740), U.P(832), U.P(830), U.P(805), U.P(905), U.P(792));
            using (var p = new Pen(Color.FromArgb(240, 255, 255, 255), 2f)) g.DrawBezier(p, U.P(650), U.P(852), U.P(740), U.P(832), U.P(830), U.P(805), U.P(905), U.P(792));
        }

        void Izquierda(Graphics g)
        {
            var bar = U.R(34, 38, 6, 64);
            using (var b = new LinearGradientBrush(bar, Color.FromArgb(80, 120, 255), Color.FromArgb(200, 60, 255), 90f)) g.FillRectangle(b, bar);
            U.Glow(g, 37, 70, 22, Color.FromArgb(120, 110, 90, 255));
            U.Hex(g, 118, 68, 36);
            U.T(g, "Publicidad", U.F(34, FontStyle.Bold), Color.White, 172, 36);
            U.Spaced(g, "MULTISUCURSAL", U.F(17), Color.FromArgb(60, 200, 255), 177, 77, 4);

            U.Spaced(g, "TU MARCA, EN CADA UBICACIÓN", U.F(17), Color.FromArgb(70, 170, 255), 85, 160, 3);
            U.T(g, "Ideas que", U.F(76, FontStyle.Regular, "Segoe UI Light"), Color.White, 78, 183);

            using (var gp = U.TextPath("conectan", U.F(88, FontStyle.Bold | FontStyle.Italic), 80, 236))
            {
                U.GlowPath(g, gp, Color.FromArgb(200, 70, 255), 1f, 16, 10, 5);
                var bb = gp.GetBounds();
                using (var b = new LinearGradientBrush(bb, Color.Blue, Color.Orange, 0f))
                {
                    var cb = new ColorBlend(4);
                    cb.Colors = new[] { Color.FromArgb(60, 90, 255), Color.FromArgb(190, 60, 255), Color.FromArgb(255, 70, 170), Color.FromArgb(255, 150, 50) };
                    cb.Positions = new[] { 0f, 0.4f, 0.7f, 1f };
                    b.InterpolationColors = cb;
                    g.FillPath(b, gp);
                }
            }
            U.T(g, "marcas", U.F(76, FontStyle.Regular, "Segoe UI Light"), Color.White, 78, 330);
            var ul = U.R(85, 420, 82, 4);
            U.Glow(g, 126, 422, 40, Color.FromArgb(90, 220, 80, 255));
            using (var b = new LinearGradientBrush(ul, Color.FromArgb(200, 60, 255), Color.FromArgb(255, 170, 40), 0f)) g.FillRectangle(b, ul);
            U.T(g, "Sistema de gestión para una publicidad\nque deja huella.", U.F(24), Color.FromArgb(215, 232, 255), 85, 440);

            Caracteristica(g, 565, Color.FromArgb(60, 90, 255), 0, "Cotizaciones y órdenes de trabajo", "De la primera idea al proyecto terminado.", Color.FromArgb(70, 170, 255));
            Caracteristica(g, 660, Color.FromArgb(235, 60, 205), 1, "Compras, materiales e inventarios", "Todo lo que tu creatividad necesita, a la mano.", Color.FromArgb(70, 200, 255));
            Caracteristica(g, 755, Color.FromArgb(255, 205, 40), 2, "Facturación y reportes en tiempo real", "Resultados claros para cada sucursal.", Color.FromArgb(70, 190, 255));

            var pill = U.R(38, 830, 508, 72);
            using (var path = U.Round(pill, pill.Height / 2f))
            {
                U.GlowPath(g, path, Color.FromArgb(200, 70, 255), 0.8f, 12, 7, 3);
                using (var b = new LinearGradientBrush(pill, Color.FromArgb(40, 255, 255, 255), Color.FromArgb(8, 255, 255, 255), 90f)) g.FillPath(b, path);
                using (var lb = new LinearGradientBrush(pill, Color.FromArgb(200, 120, 90, 255), Color.FromArgb(200, 230, 70, 230), 0f))
                using (var p = new Pen(lb, 2f)) g.DrawPath(p, path);
            }
            var ic = Color.FromArgb(80, 175, 255);
            using (var p = new Pen(ic, 2f))
            {
                g.DrawEllipse(p, U.P(74), U.P(853), U.P(16), U.P(17));
                g.DrawLine(p, U.P(78), U.P(876), U.P(86), U.P(876));
                g.DrawEllipse(p, U.P(231), U.P(853), U.P(26), U.P(26));
                g.DrawEllipse(p, U.P(237), U.P(859), U.P(14), U.P(14));
                g.DrawEllipse(p, U.P(242), U.P(864), U.P(4), U.P(4));
                g.DrawRectangle(p, U.P(381), U.P(868), U.P(5), U.P(11));
                g.DrawRectangle(p, U.P(390), U.P(861), U.P(5), U.P(18));
                g.DrawRectangle(p, U.P(399), U.P(852), U.P(5), U.P(27));
            }
            using (var p = new Pen(Color.FromArgb(60, 255, 255, 255), 1f))
            {
                g.DrawLine(p, U.P(208), U.P(850), U.P(208), U.P(882));
                g.DrawLine(p, U.P(354), U.P(850), U.P(354), U.P(882));
            }
            var f = U.F(18);
            U.T(g, "Creatividad", f, Color.FromArgb(220, 235, 255), 107, 853);
            U.T(g, "Estrategia", f, Color.FromArgb(220, 235, 255), 267, 853);
            U.T(g, "Resultados", f, Color.FromArgb(220, 235, 255), 417, 853);
        }

        void Caracteristica(Graphics g, float cy, Color c, int icono, string titulo, string sub, Color sc)
        {
            U.Glow(g, 123, cy, 62, Color.FromArgb(70, c));
            var rc = new RectangleF(U.P(85), U.P(cy - 38), U.P(76), U.P(76));
            using (var gp = new GraphicsPath())
            {
                gp.AddEllipse(rc);
                U.GlowPath(g, gp, c, 1f, 14, 9, 5);
                using (var b = new LinearGradientBrush(rc, Color.FromArgb(55, c), Color.FromArgb(8, c), 90f)) g.FillPath(b, gp);
                using (var p = new Pen(c, 3f)) g.DrawPath(p, gp);
            }
            using (var p = new Pen(c, 3f) { StartCap = LineCap.Round, EndCap = LineCap.Round, LineJoin = LineJoin.Round })
            {
                if (icono == 0)
                {
                    g.DrawLine(p, U.P(112), U.P(cy + 14), U.P(136), U.P(cy - 10));
                    g.DrawLine(p, U.P(108), U.P(cy + 18), U.P(112), U.P(cy + 14));
                    g.DrawLine(p, U.P(130), U.P(cy - 16), U.P(142), U.P(cy - 4));
                }
                else if (icono == 1)
                {
                    g.DrawPolygon(p, U.Pt(123, cy - 21, 141, cy - 10, 141, cy + 11, 123, cy + 21, 105, cy + 11, 105, cy - 10));
                    g.DrawLines(p, U.Pt(105, cy - 10, 123, cy, 141, cy - 10));
                    g.DrawLine(p, U.P(123), U.P(cy), U.P(123), U.P(cy + 21));
                }
                else
                {
                    g.DrawRectangle(p, U.P(107), U.P(cy + 3), U.P(9), U.P(14));
                    g.DrawRectangle(p, U.P(119), U.P(cy - 8), U.P(9), U.P(25));
                    g.DrawRectangle(p, U.P(131), U.P(cy - 20), U.P(9), U.P(37));
                }
            }
            U.T(g, titulo, U.F(20, FontStyle.Bold), Color.White, 190, cy - 24);
            U.T(g, sub, U.F(17), sc, 190, cy + 4);
        }

        void Tarjeta(Graphics g)
        {
            var card = U.R(1012, 118, 590, 835);
            using (var path = U.Round(card, U.P(40)))
            {
                U.GlowPath(g, path, Color.FromArgb(90, 110, 255), 0.9f, 22, 14, 8, 4);
                using (var b = new LinearGradientBrush(card, Color.FromArgb(40, 70, 90, 255), Color.FromArgb(10, 255, 255, 255), 90f)) g.FillPath(b, path);
                using (var b = new LinearGradientBrush(card, Color.FromArgb(30, 255, 255, 255), Color.FromArgb(0, 255, 255, 255), 60f)) g.FillPath(b, path);
                using (var lb = new LinearGradientBrush(card, Color.FromArgb(220, 80, 140, 255), Color.FromArgb(220, 170, 70, 255), 60f))
                using (var p = new Pen(lb, 2f)) g.DrawPath(p, path);
            }
            using (var p = new Pen(Color.FromArgb(70, 255, 255, 255), 1.5f)) g.DrawLine(p, U.P(1470), U.P(160), U.P(1545), U.P(130));
            U.Hex(g, 1091, 182, 36);
            U.T(g, "Publicidad", U.F(34, FontStyle.Bold), Color.White, 1141, 150);
            U.Spaced(g, "MULTISUCURSAL", U.F(17), Color.FromArgb(60, 200, 255), 1146, 190, 4);

            var inner = U.R(1030, 243, 555, 425);
            using (var path = U.Round(inner, U.P(32)))
            {
                using (var b = new LinearGradientBrush(inner, Color.FromArgb(18, 255, 255, 255), Color.FromArgb(4, 255, 255, 255), 90f)) g.FillPath(b, path);
                using (var p = new Pen(Color.FromArgb(100, 80, 100, 220), 1.5f)) g.DrawPath(p, path);
            }
            U.Glow(g, 1308, 252, 210, Color.FromArgb(22, 110, 120, 255));
            U.Glow(g, 1073, 292, 34, Color.FromArgb(60, 150, 110, 255));
            U.T(g, "\uE72E", U.Ico(44), Color.FromArgb(175, 160, 255), 1056, 270);
            U.T(g, "Iniciar sesión", U.F(36, FontStyle.Bold), Color.White, 1108, 262);
            U.T(g, "Ingresa tus credenciales para acceder al sistema.", U.F(18), Color.FromArgb(140, 205, 255), 1110, 309);

            Campo_(g, 358, "\uE77B", "Usuario");
            Campo_(g, 449, "\uE72E", "Contraseña");

            using (var p = new Pen(Color.FromArgb(70, 160, 190, 255), 1f))
            {
                g.DrawLine(p, U.P(1075), U.P(691), U.P(1228), U.P(691));
                g.DrawLine(p, U.P(1388), U.P(691), U.P(1540), U.P(691));
            }
            U.TC(g, "o ingresa como", U.F(17), Color.FromArgb(160, 185, 235), new RectangleF(1228, 676, 160, 30), StringAlignment.Center, StringAlignment.Center);
            U.TC(g, "© 2026 Publicidad Multisucursal - Todos los derechos reservados.", U.F(12), Color.FromArgb(150, 170, 220),
                new RectangleF(1030, 930, 555, 22), StringAlignment.Center, StringAlignment.Center);
        }

        void Campo_(Graphics g, float y, string glyph, string label)
        {
            var rc = U.R(1047, y, 520, 70);
            using (var path = U.Round(rc, U.P(24)))
            {
                U.GlowPath(g, path, Color.FromArgb(60, 140, 255), 0.5f, 8, 4);
                using (var b = new LinearGradientBrush(rc, Color.FromArgb(11, 21, 70), Color.FromArgb(15, 28, 86), 0f)) g.FillPath(b, path);
                var st = g.Save();
                g.SetClip(path);
                using (var b = new SolidBrush(Color.FromArgb(15, 255, 255, 255))) g.FillPolygon(b, U.Pt(1485, y, 1545, y, 1505, y + 70, 1445, y + 70));
                using (var b = new SolidBrush(Color.FromArgb(14, 120, 180, 255))) g.FillRectangle(b, U.P(1047), U.P(y), U.P(65), U.P(70));
                g.Restore(st);
                using (var lb = new LinearGradientBrush(rc, Color.FromArgb(60, 120, 255), Color.FromArgb(90, 210, 255), 0f))
                using (var p = new Pen(lb, 2f)) g.DrawPath(p, path);
            }
            using (var p = new Pen(Color.FromArgb(50, 130, 170, 255), 1f)) g.DrawLine(p, U.P(1112), U.P(y + 2), U.P(1112), U.P(y + 68));
            U.Glow(g, 1080, y + 35, 24, Color.FromArgb(50, 60, 170, 255));
            U.T(g, glyph, U.Ico(34), Color.FromArgb(80, 180, 255), 1065, y + 17);
            U.T(g, label, U.F(16, FontStyle.Bold), Color.White, 1125, y + 10);
        }

        // ============ CAPA ANIMADA ============
        void Dinamico(Graphics g)
        {
            // Destello que recorre la lámina rosa
            var st = g.Save();
            using (var clip = new GraphicsPath())
            {
                clip.AddPolygon(U.Pt(684, 205, 880, 150, 880, 740, 684, 740));
                g.SetClip(clip);
                float sx = (float)((t * 70) % 520) - 120;
                var band = new RectangleF(U.P(684 + sx), U.P(150), U.P(90), U.P(600));
                using (var bb = new LinearGradientBrush(band, Color.White, Color.White, 0f))
                {
                    var cb = new ColorBlend(3);
                    cb.Colors = new[] { Color.FromArgb(0, 255, 255, 255), Color.FromArgb(70, 255, 255, 255), Color.FromArgb(0, 255, 255, 255) };
                    cb.Positions = new[] { 0f, 0.5f, 1f };
                    bb.InterpolationColors = cb;
                    g.FillRectangle(bb, band);
                }
            }
            g.Restore(st);

            // Partículas flotantes
            for (int i = 0; i < N; i++)
            {
                float y = (float)(((py[i] - t * pv[i]) % 960 + 960) % 960);
                float a = (float)(0.5 + 0.5 * Math.Sin(t * 2 + pp[i]));
                Color c = i % 4 == 0 ? Color.FromArgb(255, 190, 80) : (i % 3 == 0 ? Color.FromArgb(120, 220, 255) : Color.White);
                float s = 2 + (i % 3);
                using (var b = new SolidBrush(Color.FromArgb((int)(40 + 190 * a), c)))
                    g.FillEllipse(b, px[i] * U.K, y * U.K, s, s);
            }

            // Resplandor del campo enfocado
            if (foco > 0)
            {
                var rc = U.R(1047, foco == 1 ? 358 : 449, 520, 70);
                float pul = (float)(0.5 + 0.5 * Math.Sin(t * 4));
                using (var path = U.Round(rc, U.P(24)))
                {
                    for (int i = 3; i >= 1; i--)
                        using (var p = new Pen(Color.FromArgb((int)((22 + 30 * pul) * (4 - i) / 3f), 80, 200, 255), U.P(5) * i))
                            g.DrawPath(p, path);
                    using (var p = new Pen(Color.FromArgb(240, 110, 220, 255), 2f)) g.DrawPath(p, path);
                }
            }
        }
    }
}
