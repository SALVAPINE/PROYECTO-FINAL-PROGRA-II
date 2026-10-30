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
            using (var dialogo = new ModalDialog(tipo, titulo, mensaje, textoConfirmar, destructivo, propietario))
            {
                return propietario == null
                    ? dialogo.ShowDialog()
                    : dialogo.ShowDialog(propietario);
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

        sealed class ModalDialog : Form
        {
            const int AnchoBase = 490;
            const int AltoMinimo = 190;
            const int AltoMaximo = 420;
            readonly int anchoObjetivo;
            readonly int altoObjetivo;
            readonly Color colorInicial;
            readonly Color colorFinal;
            readonly DialogActionButton botonPrincipal;
            readonly DialogActionButton botonCancelar;

            void ActualizarRegion()
            {
                if (Width > 0 && Height > 0)
                {
                    using (GraphicsPath ruta = Tema.Ruta(new RectangleF(0, 0, Width, Height), 16))
                    {
                        Region = new Region(ruta);
                    }
                }
            }

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
                BackColor = Color.FromArgb(13, 18, 44);
                ForeColor = Color.White;
                Text = titulo ?? string.Empty;
                DoubleBuffered = true;

                Rectangle area = ObtenerAreaTrabajo(owner);
                anchoObjetivo = Math.Max(340, Math.Min(AnchoBase, area.Width - 32));
                int anchoTexto = anchoObjetivo - 128;
                Size medida = TextRenderer.MeasureText(mensaje ?? string.Empty,
                    Tema.F(10.5f), new Size(anchoTexto, AltoMaximo),
                    TextFormatFlags.WordBreak | TextFormatFlags.TextBoxControl);
                int altoMensaje = Math.Max(34, Math.Min(AltoMaximo - 140, medida.Height));
                altoObjetivo = Math.Max(AltoMinimo, Math.Min(AltoMaximo, 26 + 32 + altoMensaje + 24 + 40 + 20));
                ClientSize = new Size(anchoObjetivo, altoObjetivo);
                ActualizarRegion();

                Rectangle centro = ObtenerCentro(owner);
                Location = new Point(
                    centro.Left + Math.Max(0, (centro.Width - anchoObjetivo) / 2),
                    centro.Top + Math.Max(0, (centro.Height - altoObjetivo) / 2));

                Controls.Add(new DialogGlyph
                {
                    Bounds = new Rectangle(24, 24, 48, 48),
                    Tipo = glifo,
                    ColorInicial = colorInicial,
                    ColorFinal = colorFinal,
                    TabStop = false
                });
                Controls.Add(new Label
                {
                    Text = titulo ?? string.Empty,
                    Font = Tema.F(12.5f, true),
                    ForeColor = Color.White,
                    BackColor = Color.Transparent,
                    AutoEllipsis = true,
                    Bounds = new Rectangle(88, 25, anchoObjetivo - 110, 26)
                });
                Controls.Add(new Label
                {
                    Text = mensaje ?? string.Empty,
                    Font = Tema.F(10f),
                    ForeColor = Color.FromArgb(205, 215, 240),
                    BackColor = Color.Transparent,
                    AutoSize = false,
                    Bounds = new Rectangle(88, 54, anchoObjetivo - 110, altoMensaje)
                });

                int yBotones = altoObjetivo - 54;
                if (tipo == AppDialogType.Confirmation)
                {
                    botonCancelar = CrearBoton("Cancelar", Tema.Campo, Tema.Panel, false);
                    botonCancelar.Bounds = new Rectangle(anchoObjetivo - 238, yBotones, 104, 38);
                    botonCancelar.Click += (sender, args) => CerrarConResultado(DialogResult.Cancel);
                    Controls.Add(botonCancelar);
                }

                string textoBoton = tipo == AppDialogType.Confirmation
                    ? textoConfirmar : "Aceptar";
                botonPrincipal = CrearBoton(textoBoton, colorInicial, colorFinal, true);
                botonPrincipal.Bounds = new Rectangle(
                    anchoObjetivo - (tipo == AppDialogType.Confirmation ? 124 : 132),
                    yBotones,
                    112,
                    38);
                botonPrincipal.Click += (sender, args) => CerrarConResultado(DialogResult.OK);
                Controls.Add(botonPrincipal);
            }

            protected override void OnShown(EventArgs e)
            {
                base.OnShown(e);
                Opacity = 1;
                botonPrincipal.Focus();
            }

            protected override void OnPaint(PaintEventArgs e)
            {
                base.OnPaint(e);
                Graphics g = e.Graphics;
                g.SmoothingMode = SmoothingMode.AntiAlias;
                RectangleF tarjeta = new RectangleF(0.5f, 0.5f, Width - 1f, Height - 1f);

                using (GraphicsPath ruta = Tema.Ruta(tarjeta, 16))
                {
                    // Fondo limpio con degradado azul noche acorde a la aplicacion
                    using (var fondo = new LinearGradientBrush(tarjeta, Color.FromArgb(16, 23, 56), Color.FromArgb(10, 14, 38), 65f))
                        g.FillPath(fondo, ruta);

                    // Borde unico, limpio y solido con el acento tematico
                    using (var borde = new Pen(Color.FromArgb(185, colorInicial), 1.5f))
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

            static Rectangle ObtenerCentro(Form owner)
            {
                if (owner != null && !owner.IsDisposed && owner.Visible)
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
                DialogResult = resultado;
                Close();
            }

            static DialogActionButton CrearBoton(string texto, Color inicial, Color final, bool principal)
            {
                return new DialogActionButton
                {
                    Texto = texto,
                    C1 = inicial,
                    C2 = final,
                    Radio = 10,
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
                RectangleF borde = new RectangleF(1.5f, 1.5f, Width - 3f, Height - 3f);
                using (GraphicsPath ruta = Tema.Ruta(borde, Radio))
                using (var pen = new Pen(Color.FromArgb(140, 255, 255, 255), 1.2f))
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
