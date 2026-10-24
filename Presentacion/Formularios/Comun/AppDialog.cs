using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

namespace SistemaPublicidad.Formularios
{
    internal enum AppDialogType
    {
        Success,
        Error,
        Warning,
        Information,
        Confirmation
    }

    // Use this component for all user-facing messages and confirmations.
    public static class AppDialog
    {
        static readonly Color ExitoInicial = Color.FromArgb(0, 190, 150);
        static readonly Color ExitoFinal = Color.FromArgb(0, 215, 125);
        static readonly Color ErrorInicial = Color.FromArgb(255, 50, 170);
        static readonly Color ErrorFinal = Color.FromArgb(225, 40, 130);

        public static void Success(Form owner, string titulo, string mensaje)
        {
            var notificacion = new ToastDialog(titulo, mensaje, ExitoInicial, ExitoFinal);
            notificacion.ShowToast(owner);
        }

        public static void Information(Form owner, string titulo, string mensaje)
        {
            ShowModal(owner, AppDialogType.Information, titulo, mensaje, "Aceptar", false);
        }

        public static void Warning(Form owner, string titulo, string mensaje)
        {
            ShowModal(owner, AppDialogType.Warning, titulo, mensaje, "Aceptar", false);
        }

        public static void Error(Form owner, string titulo, string mensaje)
        {
            ShowModal(owner, AppDialogType.Error, titulo, mensaje, "Aceptar", false);
        }

        public static void Error(Form owner, string titulo, string mensaje, Exception excepcion)
        {
            RegistrarError(titulo, excepcion);
            ShowModal(owner, AppDialogType.Error, titulo, mensaje, "Aceptar", false);
        }

        public static bool Confirm(Form owner, string titulo, string mensaje,
            string textoConfirmar, bool destructivo)
        {
            return ShowModal(owner, AppDialogType.Confirmation, titulo, mensaje,
                string.IsNullOrWhiteSpace(textoConfirmar) ? "Confirmar" : textoConfirmar,
                destructivo) == DialogResult.OK;
        }

        static DialogResult ShowModal(Form owner, AppDialogType tipo, string titulo,
            string mensaje, string textoConfirmar, bool destructivo)
        {
            Form propietario = owner != null && !owner.IsDisposed ? owner : null;
            using (var superposicion = new DialogOverlay())
            using (var dialogo = new ModalDialog(tipo, titulo, mensaje, textoConfirmar, destructivo, propietario))
            {
                if (propietario != null && propietario.Visible)
                {
                    superposicion.Bounds = propietario.Bounds;
                    superposicion.Show(propietario);
                    superposicion.BringToFront();
                }

                try
                {
                    return propietario == null
                        ? dialogo.ShowDialog()
                        : dialogo.ShowDialog(propietario);
                }
                finally
                {
                    if (!superposicion.IsDisposed)
                        superposicion.Close();
                }
            }
        }

        static void RegistrarError(string contexto, Exception excepcion)
        {
            if (excepcion == null) return;

            try
            {
                string carpeta = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                    "PublicidadMultisucursal", "Logs");
                Directory.CreateDirectory(carpeta);
                string ruta = Path.Combine(carpeta, "errores.log");
                string entrada = string.Format(CultureInfo.InvariantCulture,
                    "[{0:yyyy-MM-dd HH:mm:ss}] {1}{2}{3}{2}{2}",
                    DateTime.Now, contexto, Environment.NewLine, excepcion);
                File.AppendAllText(ruta, entrada);
            }
            catch (IOException errorRegistro)
            {
                Trace.TraceError("No se pudo registrar un error de la aplicación: {0}", errorRegistro);
            }
            catch (UnauthorizedAccessException errorRegistro)
            {
                Trace.TraceError("No se pudo registrar un error de la aplicación: {0}", errorRegistro);
            }
        }

        static void Apariencia(AppDialogType tipo, bool destructivo,
            out Color colorInicial, out Color colorFinal, out string glifo)
        {
            switch (tipo)
            {
                case AppDialogType.Success:
                    colorInicial = ExitoInicial;
                    colorFinal = ExitoFinal;
                    glifo = "success";
                    break;
                case AppDialogType.Error:
                    colorInicial = ErrorInicial;
                    colorFinal = ErrorFinal;
                    glifo = "error";
                    break;
                case AppDialogType.Warning:
                    colorInicial = Tema.Naranja;
                    colorFinal = Color.FromArgb(255, 200, 60);
                    glifo = "warning";
                    break;
                case AppDialogType.Confirmation:
                    colorInicial = destructivo ? ErrorInicial : Tema.Azul;
                    colorFinal = destructivo ? ErrorFinal : Tema.Morado;
                    glifo = "confirmation";
                    break;
                default:
                    colorInicial = Tema.Azul;
                    colorFinal = Tema.Morado;
                    glifo = "information";
                    break;
            }
        }

        sealed class DialogOverlay : Form
        {
            public DialogOverlay()
            {
                FormBorderStyle = FormBorderStyle.None;
                ShowInTaskbar = false;
                StartPosition = FormStartPosition.Manual;
                BackColor = Color.Black;
                Opacity = 0.58;
            }
        }

        sealed class ModalDialog : Form
        {
            const int AnchoBase = 520;
            const int AltoMinimo = 222;
            const int AltoMaximo = 440;
            int anchoObjetivo;
            int altoObjetivo;
            readonly Color colorInicial;
            readonly Color colorFinal;
            readonly DialogActionButton botonPrincipal;
            readonly DialogActionButton botonCancelar;
            readonly Timer animacion;
            readonly System.Collections.Generic.Dictionary<Control, Rectangle> limitesOriginales =
                new System.Collections.Generic.Dictionary<Control, Rectangle>();
            DialogResult resultadoPendiente = DialogResult.Cancel;
            float progreso;
            bool cerrando;

            public ModalDialog(AppDialogType tipo, string titulo, string mensaje,
                string textoConfirmar, bool destructivo, Form owner)
            {
                Apariencia(tipo, destructivo, out colorInicial, out colorFinal, out string glifo);

                FormBorderStyle = FormBorderStyle.None;
                StartPosition = FormStartPosition.Manual;
                ShowInTaskbar = false;
                ControlBox = false;
                KeyPreview = true;
                AutoScaleMode = AutoScaleMode.Dpi;
                AutoScaleDimensions = new SizeF(96F, 96F);
                BackColor = Tema.Fondo;
                ForeColor = Color.White;
                Text = titulo ?? string.Empty;
                DoubleBuffered = true;

                Rectangle area = ObtenerAreaTrabajo(owner);
                anchoObjetivo = Math.Max(300, Math.Min(AnchoBase, area.Width - 32));
                int anchoTexto = anchoObjetivo - 145;
                Size medida = TextRenderer.MeasureText(mensaje ?? string.Empty,
                    Tema.F(10.5f), new Size(anchoTexto, AltoMaximo),
                    TextFormatFlags.WordBreak | TextFormatFlags.TextBoxControl);
                int altoMensaje = Math.Max(38, Math.Min(AltoMaximo - 150, medida.Height));
                altoObjetivo = Math.Max(AltoMinimo, Math.Min(AltoMaximo, 34 + 58 + altoMensaje + 36 + 52 + 28));
                ClientSize = new Size(anchoObjetivo, altoObjetivo);

                Controls.Add(new DialogGlyph
                {
                    Bounds = new Rectangle(30, 30, 54, 54),
                    Tipo = glifo,
                    ColorInicial = colorInicial,
                    ColorFinal = colorFinal,
                    TabStop = false
                });
                Controls.Add(new Label
                {
                    Text = titulo ?? string.Empty,
                    Font = Tema.F(13, true),
                    ForeColor = Color.White,
                    BackColor = Color.Transparent,
                    AutoEllipsis = true,
                    Bounds = new Rectangle(104, 31, anchoObjetivo - 138, 30)
                });
                Controls.Add(new Label
                {
                    Text = mensaje ?? string.Empty,
                    Font = Tema.F(10.5f),
                    ForeColor = Tema.Sub,
                    BackColor = Color.Transparent,
                    AutoSize = false,
                    Bounds = new Rectangle(104, 67, anchoObjetivo - 138, altoMensaje)
                });

                int yBotones = altoObjetivo - 64;
                if (tipo == AppDialogType.Confirmation)
                {
                    botonCancelar = CrearBoton("Cancelar", Tema.Campo, Tema.Panel, false);
                    botonCancelar.Bounds = new Rectangle(anchoObjetivo - 260, yBotones, 112, 42);
                    botonCancelar.Click += (sender, args) => CerrarConResultado(DialogResult.Cancel);
                    Controls.Add(botonCancelar);
                }

                string textoBoton = tipo == AppDialogType.Confirmation
                    ? textoConfirmar : "Aceptar";
                botonPrincipal = CrearBoton(textoBoton, colorInicial, colorFinal, true);
                botonPrincipal.Bounds = new Rectangle(
                    anchoObjetivo - (tipo == AppDialogType.Confirmation ? 136 : 148),
                    yBotones,
                    116,
                    42);
                botonPrincipal.Click += (sender, args) => CerrarConResultado(DialogResult.OK);
                Controls.Add(botonPrincipal);
                animacion = new Timer { Interval = 15 };
                animacion.Tick += Animar;
            }

            protected override void OnShown(EventArgs e)
            {
                base.OnShown(e);
                anchoObjetivo = ClientSize.Width;
                altoObjetivo = ClientSize.Height;
                foreach (Control control in Controls)
                    limitesOriginales.Add(control, control.Bounds);
                progreso = 0;
                Opacity = 0;
                AjustarEscala(0.97f);
                animacion.Start();
                botonPrincipal.Focus();
            }

            protected override void OnPaint(PaintEventArgs e)
            {
                base.OnPaint(e);
                Graphics g = e.Graphics;
                g.SmoothingMode = SmoothingMode.AntiAlias;
                RectangleF tarjeta = new RectangleF(12, 12, Width - 25, Height - 25);

                for (int i = 5; i >= 1; i--)
                {
                    RectangleF sombra = tarjeta;
                    sombra.Offset(0, i);
                    sombra.Inflate(i, i);
                    using (GraphicsPath rutaSombra = Tema.Ruta(sombra, 22 + i))
                    using (var pincelSombra = new SolidBrush(Color.FromArgb(12 + (6 - i) * 3, 0, 0, 0)))
                        g.FillPath(pincelSombra, rutaSombra);
                }

                using (GraphicsPath ruta = Tema.Ruta(tarjeta, 22))
                {
                    GraphicsState estado = g.Save();
                    g.SetClip(ruta);
                    using (var fondo = new LinearGradientBrush(tarjeta, Tema.Panel, Tema.Panel2, 45f))
                        g.FillRectangle(fondo, tarjeta);
                    using (var brillo = new SolidBrush(Color.FromArgb(24, colorInicial)))
                        g.FillEllipse(brillo, tarjeta.Right - 185, tarjeta.Top - 115, 245, 215);
                    g.Restore(estado);
                    using (var borde = new Pen(Color.FromArgb(150, Tema.Borde), 1f))
                        g.DrawPath(borde, ruta);
                }
            }

            protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
            {
                if (keyData == Keys.Escape)
                {
                    CerrarConResultado(DialogResult.Cancel);
                    return true;
                }
                if (keyData == Keys.Enter)
                {
                    CerrarConResultado(DialogResult.OK);
                    return true;
                }
                return base.ProcessCmdKey(ref msg, keyData);
            }

            protected override void OnFormClosing(FormClosingEventArgs e)
            {
                if (!cerrando && e.CloseReason == CloseReason.UserClosing)
                    resultadoPendiente = DialogResult.Cancel;
                base.OnFormClosing(e);
            }

            protected override void OnFormClosed(FormClosedEventArgs e)
            {
                animacion.Stop();
                animacion.Dispose();
                base.OnFormClosed(e);
            }

            void Animar(object sender, EventArgs e)
            {
                progreso += cerrando ? -0.22f : 0.22f;
                progreso = Math.Max(0, Math.Min(1, progreso));
                Opacity = progreso;
                AjustarEscala(0.97f + progreso * 0.03f);
                if (progreso > 0) return;

                animacion.Stop();
                if (cerrando)
                {
                    DialogResult = resultadoPendiente;
                    Close();
                }
            }

            void AjustarEscala(float escala)
            {
                int ancho = Math.Max(1, (int)(anchoObjetivo * escala));
                int alto = Math.Max(1, (int)(altoObjetivo * escala));
                Rectangle centro = ObtenerCentro();
                ClientSize = new Size(ancho, alto);
                foreach (var limite in limitesOriginales)
                {
                    Rectangle original = limite.Value;
                    limite.Key.Bounds = new Rectangle(
                        (int)(original.X * escala),
                        (int)(original.Y * escala),
                        Math.Max(1, (int)(original.Width * escala)),
                        Math.Max(1, (int)(original.Height * escala)));
                }
                Location = new Point(centro.Left + (centro.Width - ancho) / 2,
                    centro.Top + (centro.Height - alto) / 2);
            }

            Rectangle ObtenerCentro()
            {
                Form owner = Owner;
                if (owner != null && !owner.IsDisposed)
                    return owner.Bounds;
                return ObtenerAreaTrabajo(null);
            }

            static Rectangle ObtenerAreaTrabajo(Form owner)
            {
                if (owner != null && !owner.IsDisposed)
                    return Screen.FromControl(owner).WorkingArea;
                return Screen.PrimaryScreen == null
                    ? new Rectangle(0, 0, 1024, 768)
                    : Screen.PrimaryScreen.WorkingArea;
            }

            void CerrarConResultado(DialogResult resultado)
            {
                if (cerrando) return;
                resultadoPendiente = resultado;
                cerrando = true;
                if (progreso <= 0)
                {
                    progreso = 1;
                    Opacity = 1;
                }
                animacion.Start();
            }

            static DialogActionButton CrearBoton(string texto, Color inicial, Color final, bool principal)
            {
                return new DialogActionButton
                {
                    Texto = texto,
                    C1 = inicial,
                    C2 = final,
                    ColorBorde = principal ? Color.Transparent : Color.FromArgb(110, Tema.Borde),
                    BackColor = Tema.Panel,
                    ForeColor = Color.White,
                    TabStop = true,
                    AccessibleRole = AccessibleRole.PushButton
                };
            }
        }

        sealed class ToastDialog : Form
        {
            readonly Timer temporizador;
            readonly int vidaMs = 3000;
            readonly Color colorInicial;
            readonly Color colorFinal;
            int tiempoTranscurrido;
            Form propietario;

            public ToastDialog(string titulo, string mensaje, Color inicial, Color final)
            {
                colorInicial = inicial;
                colorFinal = final;
                FormBorderStyle = FormBorderStyle.None;
                StartPosition = FormStartPosition.Manual;
                ShowInTaskbar = false;
                AutoScaleMode = AutoScaleMode.Dpi;
                AutoScaleDimensions = new SizeF(96F, 96F);
                BackColor = Tema.Fondo;
                ClientSize = new Size(396, 124);
                DoubleBuffered = true;
                Opacity = 0;

                Controls.Add(new DialogGlyph
                {
                    Bounds = new Rectangle(22, 27, 50, 50),
                    Tipo = "success",
                    ColorInicial = colorInicial,
                    ColorFinal = colorFinal
                });
                Controls.Add(new Label
                {
                    Text = titulo ?? string.Empty,
                    Font = Tema.F(11.5f, true),
                    ForeColor = Color.White,
                    BackColor = Color.Transparent,
                    AutoEllipsis = true,
                    Bounds = new Rectangle(86, 25, 282, 26)
                });
                Controls.Add(new Label
                {
                    Text = mensaje ?? string.Empty,
                    Font = Tema.F(9.5f),
                    ForeColor = Tema.Sub,
                    BackColor = Color.Transparent,
                    Bounds = new Rectangle(86, 55, 282, 52)
                });

                temporizador = new Timer { Interval = 15 };
                temporizador.Tick += AnimarNotificacion;
            }

            protected override void OnPaint(PaintEventArgs e)
            {
                base.OnPaint(e);
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                RectangleF tarjeta = new RectangleF(9, 9, Width - 19, Height - 19);
                for (int i = 4; i >= 1; i--)
                {
                    RectangleF sombra = tarjeta;
                    sombra.Offset(0, i);
                    sombra.Inflate(i, i);
                    using (GraphicsPath rutaSombra = Tema.Ruta(sombra, 18 + i))
                    using (var pincelSombra = new SolidBrush(Color.FromArgb(15, 0, 0, 0)))
                        e.Graphics.FillPath(pincelSombra, rutaSombra);
                }
                using (GraphicsPath ruta = Tema.Ruta(tarjeta, 18))
                {
                    using (var fondo = new LinearGradientBrush(tarjeta, Tema.Panel, Tema.Panel2, 45f))
                        e.Graphics.FillPath(fondo, ruta);
                    using (var pen = new Pen(Color.FromArgb(145, colorInicial), 1f))
                        e.Graphics.DrawPath(pen, ruta);
                }
            }

            public void ShowToast(Form owner)
            {
                propietario = owner != null && !owner.IsDisposed ? owner : null;
                if (propietario == null)
                {
                    Show();
                    Reubicar();
                    temporizador.Start();
                    return;
                }

                Show(propietario);
                Reubicar();
                temporizador.Start();
            }

            protected override bool ShowWithoutActivation
            {
                get { return true; }
            }

            void Reubicar()
            {
                Rectangle area = propietario != null
                    ? Screen.FromControl(propietario).WorkingArea
                    : Screen.PrimaryScreen == null
                        ? new Rectangle(0, 0, 1024, 768)
                        : Screen.PrimaryScreen.WorkingArea;
                int derecha = propietario != null ? propietario.Bounds.Right : area.Right;
                int arriba = propietario != null ? propietario.Bounds.Top : area.Top;
                Location = new Point(
                    Math.Max(area.Left + 8, Math.Min(derecha - Width - 18, area.Right - Width - 8)),
                    Math.Max(area.Top + 8, Math.Min(arriba + 18, area.Bottom - Height - 8)));

            }

            protected override void OnFormClosed(FormClosedEventArgs e)
            {
                temporizador.Stop();
                temporizador.Dispose();
                base.OnFormClosed(e);
            }

            void AnimarNotificacion(object sender, EventArgs e)
            {
                tiempoTranscurrido += temporizador.Interval;
                if (tiempoTranscurrido <= 150)
                {
                    Opacity = Math.Min(1, tiempoTranscurrido / 150.0);
                    return;
                }

                int inicioSalida = vidaMs - 180;
                if (tiempoTranscurrido < inicioSalida) return;
                Opacity = Math.Max(0, 1.0 - (tiempoTranscurrido - inicioSalida) / 180.0);
                if (Opacity <= 0)
                {
                    temporizador.Stop();
                    Close();
                }
            }
        }

        sealed class DialogActionButton : Boton
        {
            public DialogActionButton()
            {
                SetStyle(ControlStyles.Selectable, true);
            }

            protected override void OnPaint(PaintEventArgs e)
            {
                base.OnPaint(e);
                if (!Focused) return;
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                Rectangle borde = Rectangle.Inflate(ClientRectangle, -5, -5);
                using (GraphicsPath ruta = Tema.Ruta(borde, Math.Max(4, Radio - 3)))
                using (var pen = new Pen(Color.FromArgb(205, Color.White), 1.4f))
                    e.Graphics.DrawPath(pen, ruta);
            }
        }

        sealed class DialogGlyph : Control
        {
            public string Tipo { get; set; }
            public Color ColorInicial { get; set; }
            public Color ColorFinal { get; set; }

            public DialogGlyph()
            {
                SetStyle(ControlStyles.SupportsTransparentBackColor | ControlStyles.UserPaint |
                    ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true);
                BackColor = Color.Transparent;
            }

            protected override void OnPaint(PaintEventArgs e)
            {
                base.OnPaint(e);
                Graphics g = e.Graphics;
                g.SmoothingMode = SmoothingMode.AntiAlias;
                Rectangle circulo = new Rectangle(2, 2, Width - 5, Height - 5);
                using (var fondo = new SolidBrush(Color.FromArgb(42, ColorInicial)))
                    g.FillEllipse(fondo, circulo);
                using (var borde = new Pen(Color.FromArgb(190, ColorInicial), 1.4f))
                    g.DrawEllipse(borde, circulo);

                using (var linea = new Pen(ColorFinal, 2.5f))
                {
                    linea.StartCap = LineCap.Round;
                    linea.EndCap = LineCap.Round;
                    float cx = Width / 2f;
                    float cy = Height / 2f;
                    switch (Tipo)
                    {
                        case "success":
                            g.DrawLines(linea, new[]
                            {
                                new PointF(cx - 10, cy),
                                new PointF(cx - 3, cy + 7),
                                new PointF(cx + 11, cy - 9)
                            });
                            break;
                        case "error":
                            g.DrawLine(linea, cx, cy - 10, cx, cy + 3);
                            using (var punto = new SolidBrush(ColorFinal))
                                g.FillEllipse(punto, cx - 1.5f, cy + 8, 3, 3);
                            break;
                        case "warning":
                            PointF[] triangulo =
                            {
                                new PointF(cx, cy - 13),
                                new PointF(cx + 13, cy + 11),
                                new PointF(cx - 13, cy + 11)
                            };
                            g.DrawPolygon(linea, triangulo);
                            g.DrawLine(linea, cx, cy - 4, cx, cy + 3);
                            using (var punto = new SolidBrush(ColorFinal))
                                g.FillEllipse(punto, cx - 1.5f, cy + 7, 3, 3);
                            break;
                        case "confirmation":
                            using (var fuente = Tema.F(24, true))
                            using (var texto = new SolidBrush(ColorFinal))
                            using (var formato = new StringFormat
                            {
                                Alignment = StringAlignment.Center,
                                LineAlignment = StringAlignment.Center
                            })
                                g.DrawString("?", fuente, texto, circulo, formato);
                            break;
                        default:
                            g.DrawLine(linea, cx, cy - 3, cx, cy + 10);
                            using (var punto = new SolidBrush(ColorFinal))
                                g.FillEllipse(punto, cx - 1.6f, cy - 10, 3.2f, 3.2f);
                            break;
                    }
                }
            }
        }
    }
}
