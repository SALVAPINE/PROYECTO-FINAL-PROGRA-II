using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using Negocio;

namespace SistemaPublicidad.Formularios
{
    public class FrmPrincipal : Form
    {
        // icono, nombre, con submenú ("sub" = Compras y Facturaciones)
        static readonly string[][] Opciones = {
            new[] {"🏠","Inicio",""}, new[] {"👤","Usuarios",""}, new[] {"👥","Clientes",""}, new[] {"📄","Cotizaciones",""}, new[] {"🛠","Tipo de Servicio",""},
            new[] {"🖼","Materiales",""}, new[] {"🎨","Diseños",""}, new[] {"✏","Diseñadores",""}, new[] {"📋","Órdenes de Trabajo",""}, new[] {"🧾","Facturaciones","sub"},
            new[] {"📍","Sucursales",""}, new[] {"🚚","Proveedores",""}, new[] {"📦","Inventarios",""}, new[] {"🛒","Compras","sub"} };
        static readonly string[] SubNombres = { "Consultar", "Gestionar", "Resumen" };
        static readonly string[] SubIconos = { "\U0001F50D", "\u2699", "\U0001F4CA" };

        readonly Panel contenido = new Tarjeta { C1 = Color.Transparent, C2 = Color.Transparent, ColorBorde = Color.Transparent };
        readonly List<ItemMenu> items = new List<ItemMenu>();
        readonly HashSet<ItemMenu> abiertos = new HashSet<ItemMenu>();
        ItemMenu actual; Tarjeta menuPanel; readonly Dictionary<string, Form> cache = new Dictionary<string, Form>();
        Form vistaActiva;
        readonly string rolActual;
        readonly HashSet<string> modulosPermitidos;
        public TextBox BuscarGlobal;
        public bool CerrarSesionSolicitado { get; private set; }

        public FrmPrincipal(string usuario, string rol)
        {
            AutoScaleMode = AutoScaleMode.None;
            SuspendLayout();
            Text = "Publicidad Multisucursal"; ClientSize = new Size(1366, 768); MinimumSize = new Size(1300, 720);
            StartPosition = FormStartPosition.CenterScreen; BackColor = Tema.Fondo; DoubleBuffered = true;
            SetStyle(ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
            rolActual = rol;
            FrmModulo.UsuarioActual = usuario;
            FrmModulo.RolActual = rol;
            var listaPermisos = new RolNegocio().ListarModulosPermitidos(rol);
            modulosPermitidos = new HashSet<string>(listaPermisos, StringComparer.OrdinalIgnoreCase);

            // ---- Menú lateral ----
            var menu = new Lateral { Left = 16, Top = 16, Width = 250, Height = ClientSize.Height - 32, Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left,
                                     C1 = Color.FromArgb(20, 14, 125), C2 = Color.FromArgb(48, 14, 135), Radio = 20, Opacidad = 250, Brillo = Color.FromArgb(60, 255, 60, 190), Brillo2 = Color.FromArgb(60, 60, 140, 255) };
            menu.Controls.Add(new LogoBox { Left = 14, Top = 12, Width = 64, Height = 64 });
            menu.Controls.Add(Tema.L("Publicidad", 13, Color.White, 84, 12, true));
            menu.Controls.Add(Tema.L("Multisucursal", 13, Color.White, 84, 33, true));
            menu.Controls.Add(Tema.L("Ideas que se ven", 10f, Color.FromArgb(215, 225, 255), 85, 58));
            foreach (var o in Opciones)
            {
                if (!Permitido(o[1])) continue;
                var it = Nuevo(o[0], o[1], 0, null, menu);
                if (o[2] == "sub")
                {
                    it.Hijos = new List<ItemMenu>(); it.Expandible = true;
                    for (int k = 0; k < 2; k++) it.Hijos.Add(Nuevo(SubIconos[k], SubNombres[k], 1, it, menu));
                }
            }
            var salIt = Nuevo("⏻", "Cerrar sesión", 0, null, menu);
            salIt.Tag = "fijo"; salIt.Anchor = AnchorStyles.Bottom | AnchorStyles.Left; salIt.Height = 36; salIt.Top = menu.Height - 56;
            menu.Controls.Add(new Panel { Left = 26, Width = 198, Height = 1, Top = menu.Height - 66, BackColor = Color.FromArgb(80, 90, 200), Anchor = AnchorStyles.Bottom | AnchorStyles.Left });
            menuPanel = menu; menu.Resize += (s, e) => Reacomodar(); Reacomodar();
            Controls.Add(menu);

            // ---- Barra superior ----
            var bus = new Tarjeta { Left = 282, Top = 16, Width = 460, Height = 44, Radio = 22, C1 = Tema.Campo, C2 = Tema.Campo, Vidrio = false, Padding = new Padding(48, 12, 14, 4) };
            BuscarGlobal = new TextBox { Dock = DockStyle.Fill, BorderStyle = BorderStyle.None, BackColor = Tema.Campo, ForeColor = Color.White, Font = Tema.F(10.5f) };
            Tema.Cue(BuscarGlobal, "Buscar...");
            bus.Controls.Add(BuscarGlobal); bus.Controls.Add(new IconoLinea { Imagen = Recursos.Img("top_buscar"), Key = "\U0001F50D", Color = Color.White, Left = 16, Top = 11, Width = 22, Height = 22 });
            Controls.Add(bus);

            string d = DateTime.Now.ToString("dddd, d 'de' MMMM 'de' yyyy", new CultureInfo("es-ES")); d = char.ToUpper(d[0]) + d.Substring(1);
            int w = ClientSize.Width;
            var usr = new Tarjeta { Width = 200, Height = 48, Left = w - 16 - 200, Top = 14, C1 = Color.Transparent, C2 = Color.Transparent, ColorBorde = Color.Transparent, Anchor = AnchorStyles.Top | AnchorStyles.Right };
            usr.Controls.Add(new ImgBox { Imagen = Recursos.Img("avatar"), Left = 0, Top = 2, Width = 44, Height = 44 });
            usr.Controls.Add(Tema.L(usuario, 10.5f, Color.White, 54, 5, true)); usr.Controls.Add(Tema.L(rol, 8.5f, Tema.Sub, 54, 25));
            usr.Controls.Add(Tema.L("⌄", 11, Color.White, 176, 10));
            var campana = new Tarjeta { Width = 44, Height = 44, Radio = 22, Left = usr.Left - 56, Top = 16, C1 = Tema.Campo, C2 = Tema.Campo, Anchor = AnchorStyles.Top | AnchorStyles.Right };
            campana.Controls.Add(new IconoLinea { Imagen = Recursos.Img("top_campana"), Key = "\U0001F514", Color = Color.White, Left = 11, Top = 11, Width = 22, Height = 22 });
            var badge = new Tarjeta { Width = 16, Height = 16, Radio = 8, C1 = Tema.Rosa, C2 = Tema.Rosa, ColorBorde = Color.Transparent, Left = 26, Top = 1 };
            badge.Controls.Add(Tema.L("1", 7, Color.White, 4, 0, true)); campana.Controls.Add(badge);
            var fecha = new Tarjeta { Width = 320, Height = 44, Radio = 22, Left = campana.Left - 16 - 320, Top = 16, C1 = Tema.Campo, C2 = Tema.Campo, Anchor = AnchorStyles.Top | AnchorStyles.Right };
            fecha.Controls.Add(new IconoLinea { Imagen = Recursos.Img("top_fecha"), Key = "\U0001F4C5", Color = Color.White, Left = 16, Top = 11, Width = 22, Height = 22 }); fecha.Controls.Add(Tema.L(d + "   ▾", 10, Color.White, 48, 11));
            Controls.AddRange(new Control[] { usr, campana, fecha });

            // ---- Contenido ----
            contenido.Left = 282; contenido.Top = 72; contenido.Width = ClientSize.Width - 298; contenido.Height = ClientSize.Height - 88;
            contenido.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            Controls.Add(contenido);

            ResumeLayout(true);
            WindowState = FormWindowState.Maximized;
            Seleccionar(items[0]);
        }

        bool Permitido(string modulo)
        {
            if (string.Equals(modulo, "Inicio", StringComparison.OrdinalIgnoreCase)) return true;
            if (modulosPermitidos != null && modulosPermitidos.Contains(modulo)) return true;
            return false;
        }

        static string Slug(string t)
        {
            switch (t)
            {
                case "Tipo de Servicio": return "tipo"; case "Diseños": return "disenos"; case "Diseñadores": return "disenadores"; case "Órdenes de Trabajo": return "ordenes";
                case "Configuración": return "configuracion"; case "Cerrar sesión": return "cerrar"; default: return t.ToLower();
            }
        }

        ItemMenu Nuevo(string icono, string texto, int nivel, ItemMenu padre, Tarjeta menu)
        {
            var it = new ItemMenu { Imagen = nivel == 0 ? Recursos.Img("ico_" + Slug(texto)) : null, Icono = icono, Texto = texto, Nivel = nivel, Padre = padre, Left = nivel == 0 ? 12 : 24, Width = nivel == 0 ? 226 : 214, Height = 34 };
            it.Click += (s, e) => Seleccionar((ItemMenu)s);
            items.Add(it); menu.Controls.Add(it); return it;
        }

        void Reacomodar()
        {
            if (menuPanel == null) return;
            int n = items.Count(i => i.Tag == null && (i.Nivel == 0 || abiertos.Contains(i.Padre)));
            int paso = (int)Math.Max(26, Math.Min(41, (menuPanel.Height - 96 - 84) / (float)n)); int y = 96;
            foreach (var it in items)
            {
                if (it.Tag != null) continue; bool vis = it.Nivel == 0 || abiertos.Contains(it.Padre); it.Visible = vis; if (!vis) continue;
                it.Top = y; it.Height = paso - 2; y += paso;
            }
        }

        // Cada vista se crea una sola vez y se conserva en caché, sin mantenerla montada en pantalla.
        Form Vista(string nombre, string icono)
        {
            Form f; if (cache.TryGetValue(nombre, out f)) return f;
            f = Crear(nombre, icono);
            PrepararVista(f);
            f.Visible = false;
            cache[nombre] = f;
            return f;
        }

        // Todas las vistas permanecen acopladas al contenedor para conservar su tamaño al navegar.
        static void PrepararVista(Form f)
        {
            f.TopLevel = false;
            f.FormBorderStyle = FormBorderStyle.None;
            f.Dock = DockStyle.Fill;
            f.Margin = Padding.Empty;
        }

        // Un formulario por apartado (carpeta del mismo nombre dentro de Formularios)
        Form Crear(string nombre, string icono)
        {
            switch (nombre)
            {
                case "Inicio": return new FrmInicio(rolActual);
                case "Usuarios": return new FrmUsuarios();
                case "Clientes": return new FrmClientes();
                case "Cotizaciones": return new FrmCotizaciones();
                case "Tipo de Servicio": return new FrmTipoServicio();
                case "Materiales": return new FrmMateriales();
                case "Diseños": return new FrmDisenos();
                case "Diseñadores": return new FrmDisenadores();
                case "Órdenes de Trabajo": return new FrmOrdenesTrabajo();
                case "Facturaciones": return new FrmFacturaciones();
                case "Compras": return new FrmCompras();
                case "Sucursales": return new FrmSucursales();
                case "Proveedores": return new FrmProveedores();
                case "Inventarios": return new FrmInventarios();
                default: return new FrmModulo(Modulos.Obtener(nombre, icono, 0));
            }
        }

        void Refrescar()
        {
            foreach (var i in items)
            {
                i.Activo = (i == actual) || (i.Hijos != null && actual != null && actual.Padre == i);
                if (i.Hijos != null) i.Expandido = abiertos.Contains(i);
            }
        }

        void Seleccionar(ItemMenu it)
        {
            if (it.Texto == "Cerrar sesión") { CerrarSesionSolicitado = true; Close(); return; }
            if (it.Hijos != null)
            {
                if (actual == it || (actual != null && actual.Padre == it)) { if (!abiertos.Remove(it)) abiertos.Add(it); Reacomodar(); Refrescar(); return; }
                abiertos.Add(it); it = it.Hijos[0];
            }
            ItemMenu mod = it.Padre ?? it; int tab = it.Padre == null ? 0 : it.Padre.Hijos.IndexOf(it);
            // Crear primero la vista evita que el menú anuncie el módulo nuevo
            // mientras todavía se ve el anterior durante la construcción.
            Form f = Vista(mod.Texto, mod.Icono);
            var fm = f as FrmModulo; if (fm != null && fm.Tabs.Seleccion != tab) fm.Tabs.Seleccion = tab;
            actual = it; Reacomodar(); Refrescar();
            contenido.SuspendLayout();
            try
            {
                // El contenedor aloja solo la vista activa. Las vistas ocultas permanecen en caché,
                // pero fuera del árbol visual para evitar layouts y repintados cruzados.
                if (vistaActiva != null && vistaActiva != f)
                {
                    vistaActiva.Hide();
                    contenido.Controls.Remove(vistaActiva);
                }
                if (f.Parent != contenido) contenido.Controls.Add(f);
                contenido.Controls.SetChildIndex(f, 0);
                vistaActiva = f;
                if (!f.Visible) f.Show();
                f.BringToFront();
            }
            finally
            {
                contenido.ResumeLayout(true);
            }
            var modulo = f as FrmModulo;
            if (modulo != null) modulo.EnsureLoaded();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                // Las vistas retiradas del contenedor también pertenecen a esta ventana.
                foreach (Form vista in cache.Values)
                    vista.Dispose();
                cache.Clear();
            }
            base.Dispose(disposing);
        }

        protected override void OnPaintBackground(PaintEventArgs e) { Tema.PintarFondo(e.Graphics, this); }
    }
}