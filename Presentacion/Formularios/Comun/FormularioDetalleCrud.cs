using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidad;
using Negocio;

namespace SistemaPublicidad.Formularios
{
    /// <summary>CRUD del detalle asociado a una compra o una factura.</summary>
    internal sealed class FormularioDetalleCrud : UserControl
    {
        readonly bool esCompra;
        int codigoPadre;
        public int CodigoPadre { get { return codigoPadre; } }
        readonly Tabla tabla = new Tabla();
        readonly List<object> filasDetalle = new List<object>();
        readonly List<string[]> filasTablaCompleta = new List<string[]>();
        readonly string[] propiedadesTabla;
        Panel contenedorTabla;
        bool cargandoLista;
        bool listaCargada;
        int solicitudCarga;
        readonly CampoTexto txtTipo = new CampoTexto("Tipo de compra", "");
        readonly CampoTexto txtDescripcion = new CampoTexto("Descripción", "");
        readonly CampoNumero numCantidad = new CampoNumero("Cantidad", 0, false, false);
        readonly CampoNumero numPrecio = new CampoNumero("Precio", 2, true, false);
        readonly CampoNumero numSubtotal = new CampoNumero("Subtotal", 2, true, false);
        readonly CampoNumero numDescuento = new CampoNumero("Descuento", 2, true, false);
        readonly Selector cmbEstado = new Selector { Rotulo = "Estado" };
        int codigoEdicion;
        bool calculandoDetalle;
        int cantidadExterna = 1;
        public int CantidadExterna
        {
            get { return cantidadExterna; }
            set
            {
                cantidadExterna = Math.Max(1, value);
                if (esCompra)
                {
                    RecalcularDetalleDesdeCantidadOPrecio();
                }
            }
        }
        public event EventHandler DatosCambiados;
        public event Action<decimal, int> SubtotalEnVivoCambiado;

        public FormularioDetalleCrud(string modulo, int codigo)
        {
            esCompra = modulo == "Compras";
            propiedadesTabla = esCompra
                ? new[] { "CodigoDetalleCompra", "CodigoCompra", "TipoDeCompra", "Descripcion", "PrecioUnitario", "Subtotal", "DescuentoCompra", "Estado" }
                : new[] { "CodigoDetalleFactura", "CodigoFacturacion", "Cantidad", "Precio", "Descripcion", "DescuentoAplicado", "Estado" };
            codigoPadre = codigo;
            Text = esCompra ? "Detalle de la compra" : "Detalle de la factura";
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            BackColor = Color.Transparent;
            ForeColor = Color.White;

            ConfigurarTabla();
            ConstruirControles();
            ConfigurarEventosCalculo();
            tabla.TituloVacio = esCompra ? "Selecciona una compra existente" : "Selecciona una factura existente";
            tabla.TextoVacio = "El detalle se cargará al seleccionar el registro.";
        }

        void ConfigurarTabla()
        {
            tabla.Dock = DockStyle.Fill;
            tabla.MensajeVacioEnCuerpo = true;
            tabla.TituloVacio = esCompra ? "Esta compra aún no tiene detalles" : "Esta factura aún no tiene detalles";
            tabla.TextoVacio = esCompra ? "El detalle se consulta desde Tbl_DetalleCompra." : "El detalle se consulta desde Tbl_DetalleFactura.";
            tabla.Columnas.Add(new Tabla.Col("", 0, "chk"));
            if (esCompra)
            {
                tabla.Columnas.Add(new Tabla.Col("Código de detalle", 1.15f, "id", true));
                tabla.Columnas.Add(new Tabla.Col("Código de compra", 0.9f, "num", true));
                tabla.Columnas.Add(new Tabla.Col("Tipo de compra", 1.05f, "texto", true));
                tabla.Columnas.Add(new Tabla.Col("Descripción", 1.55f, "texto"));
                tabla.Columnas.Add(new Tabla.Col("Precio unitario", 1.05f, "num", true));
                tabla.Columnas.Add(new Tabla.Col("Subtotal", 0.95f, "num", true));
                tabla.Columnas.Add(new Tabla.Col("Descuento", 1.15f, "num", true));
                tabla.Columnas.Add(new Tabla.Col("Estado", 0.85f, "estado", true));
            }
            else
            {
                tabla.Columnas.Add(new Tabla.Col("Código de detalle", 1.1f, "id", true));
                tabla.Columnas.Add(new Tabla.Col("Código de factura", 1.0f, "num", true));
                tabla.Columnas.Add(new Tabla.Col("Cantidad", 0.8f, "num", true));
                tabla.Columnas.Add(new Tabla.Col("Precio", 0.9f, "num", true));
                tabla.Columnas.Add(new Tabla.Col("Descripcion", 1.5f, "texto"));
                tabla.Columnas.Add(new Tabla.Col("Descuento aplicado", 1.2f, "num", true));
                tabla.Columnas.Add(new Tabla.Col("Estado", 0.85f, "estado", true));
            }
            tabla.Columnas.Add(new Tabla.Col("Acciones", 0, "acc"));
            // Centra encabezados y valores para que los detalles de compra y factura se lean parejos.
            for (int i = 1; i < tabla.Columnas.Count - 1; i++) tabla.Columnas[i].Centrar = true;
            tabla.EditarClick += i =>
            {
                tabla.Seleccion = i;
                CargarSeleccionado();
            };
            tabla.EliminarClick += EliminarDetalleSeleccionado;
            tabla.SeleccionCambio += i => { if (!cargandoLista) CargarSeleccionado(); };
        }

        void ConstruirControles()
        {
            // El detalle se guarda junto con su compra/factura desde el botón
            // principal; los campos quedan arriba y la lista ocupa la franja inferior.
            var raiz = new TableLayoutPanel { Dock = DockStyle.Fill, BackColor = Color.Transparent, ColumnCount = 1, RowCount = 2, Padding = new Padding(4) };
            raiz.RowStyles.Add(new RowStyle(SizeType.Absolute, 122));
            raiz.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
            Controls.Add(raiz);

            var campos = new TableLayoutPanel { Dock = DockStyle.Fill, ColumnCount = 3, RowCount = 2, BackColor = Color.Transparent, Padding = new Padding(2, 2, 2, 0) };
            for (int i = 0; i < 3; i++) campos.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33f));
            campos.RowStyles.Add(new RowStyle(SizeType.Absolute, 56));
            campos.RowStyles.Add(new RowStyle(SizeType.Absolute, 56));
            txtTipo.Margin = txtDescripcion.Margin = new Padding(5, 2, 5, 2);
            numCantidad.Margin = numPrecio.Margin = numSubtotal.Margin = numDescuento.Margin = new Padding(5, 2, 5, 2);
            cmbEstado.Margin = new Padding(5, 2, 5, 2);
            numCantidad.Num.Minimum = 1;
            txtTipo.Dock = txtDescripcion.Dock = numPrecio.Dock = numSubtotal.Dock = numDescuento.Dock = cmbEstado.Dock = DockStyle.Fill;
            numCantidad.Dock = DockStyle.Fill;
            if (esCompra)
            {
                campos.Controls.Add(txtTipo, 0, 0);
                campos.Controls.Add(txtDescripcion, 1, 0);
                campos.Controls.Add(numPrecio, 2, 0);
                campos.Controls.Add(numSubtotal, 0, 1);
                campos.Controls.Add(numDescuento, 1, 1);
                campos.Controls.Add(cmbEstado, 2, 1);
            }
            else
            {
                txtDescripcion.Dock = numCantidad.Dock = numPrecio.Dock = numDescuento.Dock = cmbEstado.Dock = DockStyle.Fill;
                txtDescripcion.Margin = numCantidad.Margin = numPrecio.Margin = numDescuento.Margin = cmbEstado.Margin = new Padding(5, 2, 5, 2);
                numSubtotal.Dock = DockStyle.Fill;
                numSubtotal.Margin = new Padding(5, 2, 5, 2);
                campos.Controls.Add(txtDescripcion, 0, 0);
                campos.Controls.Add(numCantidad, 1, 0);
                campos.Controls.Add(numPrecio, 2, 0);
                campos.Controls.Add(numDescuento, 0, 1);
                campos.Controls.Add(cmbEstado, 1, 1);
                campos.Controls.Add(numSubtotal, 2, 1);
            }
            contenedorTabla = new Panel { Dock = DockStyle.Fill, BackColor = Color.Transparent,
                Padding = esCompra ? new Padding(0, 3, 0, 0) : new Padding(0) };
            contenedorTabla.Controls.Add(tabla);
            raiz.Controls.Add(campos, 0, 0);
            raiz.Controls.Add(contenedorTabla, 0, 1);

            cmbEstado.Items.AddRange(new[] { "Inactivo", "Activo" });
            cmbEstado.Seleccion = 1;
        }

        /// <summary>Prepara el concepto que se guarda desde el botón principal de Facturaciones.</summary>
        public DetalleFactura ObtenerDetalleParaGuardar(int codigoFactura, bool obligatorio)
        {
            if (esCompra) return null;
            if (string.IsNullOrWhiteSpace(txtDescripcion.Caja.Text))
            {
                if (obligatorio || codigoEdicion > 0) throw new ArgumentException("Completa la descripción del detalle de la factura.");
                return null;
            }
            if (codigoFactura < 0) throw new ArgumentException("El código de la factura no es válido.");
            if (numCantidad.EstaVacio || numCantidad.Valor < 1) throw new ArgumentException("La cantidad debe ser mayor que cero.");
            if (numPrecio.EstaVacio || numPrecio.Valor < 0) throw new ArgumentException("Completa un precio válido.");
            if (numDescuento.EstaVacio || numDescuento.Valor < 0) throw new ArgumentException("Completa un descuento válido.");
            if (cmbEstado.Seleccion < 0) throw new ArgumentException("Selecciona el estado del detalle.");

            return new DetalleFactura
            {
                CodigoDetalleFactura = codigoEdicion,
                CodigoFacturacion = codigoFactura,
                Descripcion = txtDescripcion.Caja.Text.Trim(),
                Cantidad = (int)numCantidad.Valor,
                Precio = numPrecio.Valor,
                DescuentoAplicado = numDescuento.Valor,
                Estado = cmbEstado.Seleccion == 1
            };
        }

        /// <summary>Prepara el detalle de compra para guardarlo junto con la compra.</summary>
        public DetalleCompra ObtenerDetalleCompraParaGuardar(bool obligatorio)
        {
            if (!esCompra) return null;
            bool sinDetalle = string.IsNullOrWhiteSpace(txtTipo.Caja.Text)
                && string.IsNullOrWhiteSpace(txtDescripcion.Caja.Text)
                && numPrecio.EstaVacio && numSubtotal.EstaVacio && numDescuento.EstaVacio;
            if (sinDetalle && !obligatorio && codigoEdicion == 0) return null;
            if (string.IsNullOrWhiteSpace(txtTipo.Caja.Text)) throw new ArgumentException("Completa el tipo de compra del detalle.");
            if (txtTipo.Caja.Text.Trim().Length > 45) throw new ArgumentException("El tipo de compra admite hasta 45 caracteres.");
            if (string.IsNullOrWhiteSpace(txtDescripcion.Caja.Text)) throw new ArgumentException("Completa la descripción del detalle.");
            if (txtDescripcion.Caja.Text.Trim().Length > 150) throw new ArgumentException("La descripción admite hasta 150 caracteres.");
            if (numPrecio.EstaVacio || numSubtotal.EstaVacio || numDescuento.EstaVacio)
                throw new ArgumentException("Completa el precio, subtotal y descuento del detalle.");
            if (cmbEstado.Seleccion < 0) throw new ArgumentException("Selecciona el estado del detalle.");

            return new DetalleCompra
            {
                CodigoDetalleCompra = codigoEdicion,
                CodigoCompra = codigoPadre,
                TipoDeCompra = txtTipo.Caja.Text.Trim(),
                Descripcion = txtDescripcion.Caja.Text.Trim(),
                PrecioUnitario = numPrecio.Valor,
                Subtotal = numSubtotal.Valor,
                DescuentoCompra = numDescuento.Valor,
                Estado = cmbEstado.Seleccion == 1
            };
        }

        public void Recargar()
        {
            listaCargada = false;
            _ = CargarListaAsync();
        }

        public void Recargar(int codigo)
        {
            codigoPadre = codigo;
            Recargar();
        }

        async Task CargarListaAsync()
        {
            int solicitud = ++solicitudCarga;
            int padre = codigoPadre;
            cargandoLista = true;
            tabla.Filas.Clear();
            tabla.InvalidarAnchosColumnas();
            tabla.Marcadas.Clear();
            filasDetalle.Clear();
            filasTablaCompleta.Clear();
            tabla.Seleccion = -1;
            Limpiar();
            tabla.TituloVacio = "Cargando detalles...";
            tabla.TextoVacio = "La consulta se ejecuta en segundo plano.";
            try
            {
                List<object> detalles;
                if (esCompra)
                {
                    detalles = codigoPadre > 0
                        ? (await Task.Run(() => new DetalleCompraNegocio().ListarPorCompra(padre))).Cast<object>().ToList()
                        : new List<object>();
                }
                else
                {
                    detalles = codigoPadre > 0
                        ? (await Task.Run(() => new DetalleFacturaNegocio().ListarPorFactura(padre))).Cast<object>().ToList()
                        : new List<object>();
                }

                if (IsDisposed || Disposing || solicitud != solicitudCarga || padre != codigoPadre) return;
                foreach (object elemento in detalles)
                {
                    if (esCompra)
                    {
                        var detalle = (DetalleCompra)elemento;
                        filasTablaCompleta.Add(new[] { "", detalle.CodigoDetalleCompra.ToString(), detalle.CodigoCompra.ToString(), detalle.TipoDeCompra,
                            detalle.Descripcion, detalle.PrecioUnitario.ToString("N2"), detalle.Subtotal.ToString("N2"),
                            detalle.DescuentoCompra.ToString("N2"), detalle.Estado ? "Activo" : "Inactivo", "" });
                    }
                    else
                    {
                        var detalle = (DetalleFactura)elemento;
                        filasTablaCompleta.Add(new[] { "", detalle.CodigoDetalleFactura.ToString(), detalle.CodigoFacturacion.ToString(), detalle.Cantidad.ToString(),
                            detalle.Precio.ToString("N2"), detalle.Descripcion, detalle.DescuentoAplicado.ToString("N2"), detalle.Estado ? "Activo" : "Inactivo", "" });
                    }
                    filasDetalle.Add(elemento);
                }
                tabla.TituloVacio = esCompra
                    ? (padre > 0 ? "Esta compra aún no tiene detalles" : "Selecciona una compra existente")
                    : (padre > 0 ? "Esta factura aún no tiene detalles" : "Selecciona una factura existente");
                tabla.TextoVacio = esCompra ? "Consulta de dbo.Tbl_DetalleCompra" : "Consulta de dbo.Tbl_DetalleFactura";
            }
            catch (Exception ex)
            {
                if (IsDisposed || Disposing || solicitud != solicitudCarga) return;
                tabla.Filas.Clear();
                tabla.InvalidarAnchosColumnas();
                filasDetalle.Clear();
                filasTablaCompleta.Clear();
                tabla.TituloVacio = esCompra ? "No se pudieron cargar los detalles de esta compra" : "No se pudieron cargar los detalles de esta factura";
                tabla.TextoVacio = "Revisa la conexión e inténtalo nuevamente.";
                AppDialog.Error(FindForm(), "No se pudieron consultar los detalles",
                    "Revisa la conexión e inténtalo nuevamente.", ex);
            }
            finally
            {
                if (!IsDisposed && !Disposing && solicitud == solicitudCarga)
                {
                    cargandoLista = false;
                    listaCargada = true;
                    Limpiar();
                    tabla.Filas.Clear();
                    tabla.Filas.AddRange(filasTablaCompleta);
                    tabla.InvalidarAnchosColumnas();
                    tabla.Seleccion = -1;
                    tabla.Invalidate();
                    if (DatosCambiados != null) DatosCambiados(this, EventArgs.Empty);
                }
            }
        }

        public void CambiarPadre(int codigo)
        {
            if (codigoPadre == codigo && (cargandoLista || listaCargada || codigo <= 0)) return;
            codigoPadre = codigo;
            Recargar();
        }

        void EliminarDetalleSeleccionado(int indice)
        {
            if (indice < 0 || indice >= filasDetalle.Count) return;
            int codigoDetalle = esCompra
                ? ((DetalleCompra)filasDetalle[indice]).CodigoDetalleCompra
                : ((DetalleFactura)filasDetalle[indice]).CodigoDetalleFactura;
            string nombreRegistro = esCompra ? "detalle" : "concepto";
            if (!AppDialog.Confirm(FindForm(), "Eliminar " + nombreRegistro,
                "¿Deseas eliminar el " + nombreRegistro + " " + codigoDetalle +
                " de este registro? Esta acción no se puede deshacer.",
                "Eliminar", true)) return;

            try
            {
                if (esCompra) ModuloCrud.EliminarDetalleCompra(codigoDetalle, codigoPadre);
                else ModuloCrud.EliminarDetalleFactura(codigoDetalle, codigoPadre);
                Recargar();
            }
            catch (Exception ex)
            {
                AppDialog.Error(FindForm(), "No se pudo eliminar " + nombreRegistro,
                    "Verifica que no existan restricciones y vuelve a intentarlo.", ex);
            }
        }

        /// <summary>Aplica a cada encabezado el nombre exacto que devuelve el esquema de SQL Server.</summary>
        public void ActualizarTitulos(List<string> columnasBaseDatos)
        {
            for (int i = 0; i < propiedadesTabla.Length; i++)
            {
                string propiedad = propiedadesTabla[i];
                string nombreDb = columnasBaseDatos.Find(x =>
                    string.Equals(x, propiedad, StringComparison.OrdinalIgnoreCase));
                if (nombreDb == null)
                    throw new InvalidOperationException("La columna " + propiedad + " no existe en la tabla de detalle.");
                // Se conserva el encabezado en español; la propiedad se valida contra SQL Server.
            }
            tabla.Invalidate();
        }

        /// <summary>Devuelve las filas ya cargadas para que la vista de consulta use el mismo resultado.</summary>
        public string[][] ObtenerFilasDetalle()
        {
            string[][] filas = new string[filasTablaCompleta.Count][];
            for (int i = 0; i < filasTablaCompleta.Count; i++)
            {
                filas[i] = new string[propiedadesTabla.Length];
                Array.Copy(filasTablaCompleta[i], 1, filas[i], 0, filas[i].Length);
            }
            return filas;
        }

        void CargarSeleccionado()
        {
            int indice = tabla.Seleccion;
            if (indice < 0 || indice >= filasDetalle.Count) return;
            calculandoDetalle = true;
            try
            {
                if (esCompra)
                {
                    var d = (DetalleCompra)filasDetalle[indice];
                    codigoEdicion = d.CodigoDetalleCompra; txtTipo.Caja.Text = d.TipoDeCompra; txtDescripcion.Caja.Text = d.Descripcion;
                    numPrecio.Valor = d.PrecioUnitario; numSubtotal.Valor = d.Subtotal; numDescuento.Valor = d.DescuentoCompra;
                    cmbEstado.Seleccion = d.Estado ? 1 : 0;
                }
                else
                {
                    var d = (DetalleFactura)filasDetalle[indice];
                    codigoEdicion = d.CodigoDetalleFactura; txtDescripcion.Caja.Text = d.Descripcion; numCantidad.Valor = d.Cantidad;
                    numPrecio.Valor = d.Precio; numDescuento.Valor = d.DescuentoAplicado; cmbEstado.Seleccion = d.Estado ? 1 : 0;
                    numSubtotal.Valor = Math.Max(0, (d.Cantidad * d.Precio) - d.DescuentoAplicado);
                }
            }
            finally
            {
                calculandoDetalle = false;
            }
        }

        void Limpiar()
        {
            calculandoDetalle = true;
            try
            {
                codigoEdicion = 0; txtTipo.Caja.Clear(); txtDescripcion.Caja.Clear(); numCantidad.Limpiar();
                numCantidad.Valor = 1;
                numPrecio.Limpiar(); numSubtotal.Limpiar(); numDescuento.Limpiar(); cmbEstado.Seleccion = 1;
            }
            finally
            {
                calculandoDetalle = false;
            }
        }

        /// <summary>Deja vacíos los campos al entrar a Gestionar sin iniciar una edición.</summary>
        public void LimpiarCampos()
        {
            Limpiar();
        }

        void ConfigurarEventosCalculo()
        {
            numCantidad.Num.ValueChanged += (s, e) => RecalcularDetalleDesdeCantidadOPrecio();
            numPrecio.Num.ValueChanged += (s, e) => RecalcularDetalleDesdeCantidadOPrecio();
            numDescuento.Num.ValueChanged += (s, e) => RecalcularDetalleDesdeCantidadOPrecio();
            numSubtotal.Num.ValueChanged += (s, e) => RecalcularDetalleDesdeSubtotal();
        }

        void RecalcularDetalleDesdeCantidadOPrecio()
        {
            if (calculandoDetalle) return;
            calculandoDetalle = true;
            try
            {
                if (esCompra)
                {
                    // Subtotal = (CantidadComprada * PrecioUnitario) - DescuentoCompra
                    int cant = Math.Max(1, cantidadExterna);
                    decimal totalBruto = cant * numPrecio.Valor;
                    numSubtotal.Valor = Math.Max(0, totalBruto - numDescuento.Valor);
                }
                else
                {
                    // Subtotal = (Cantidad * Precio) - DescuentoAplicado
                    decimal totalBruto = numCantidad.Valor * numPrecio.Valor;
                    numSubtotal.Valor = Math.Max(0, totalBruto - numDescuento.Valor);
                }
            }
            finally
            {
                calculandoDetalle = false;
            }
            NotificarCambioEnVivo();
        }

        void RecalcularDetalleDesdeSubtotal()
        {
            if (calculandoDetalle) return;
            calculandoDetalle = true;
            try
            {
                if (esCompra)
                {
                    // Si se ajusta el subtotal directamente, se divide entre CantidadComprada para obtener el PrecioUnitario
                    int cant = Math.Max(1, cantidadExterna);
                    decimal montoTotal = numSubtotal.Valor + numDescuento.Valor;
                    numPrecio.Valor = Math.Round(montoTotal / cant, 2);
                }
                else
                {
                    // Si se ajusta el subtotal directamente y se tiene cantidad > 0, se divide para obtener el precio
                    if (numCantidad.Valor > 0)
                    {
                        decimal montoTotal = numSubtotal.Valor + numDescuento.Valor;
                        numPrecio.Valor = Math.Round(montoTotal / numCantidad.Valor, 2);
                    }
                }
            }
            finally
            {
                calculandoDetalle = false;
            }
            NotificarCambioEnVivo();
        }

        void NotificarCambioEnVivo()
        {
            if (SubtotalEnVivoCambiado == null) return;
            decimal totalCalculado = 0;
            int cantidadCalculada = 0;

            if (esCompra)
            {
                for (int i = 0; i < filasDetalle.Count; i++)
                {
                    if (i == tabla.Seleccion && codigoEdicion > 0) continue;
                    var d = filasDetalle[i] as DetalleCompra;
                    if (d != null) totalCalculado += d.Subtotal;
                }
                totalCalculado += numSubtotal.Valor;
                cantidadCalculada = Math.Max(1, cantidadExterna);
            }
            else
            {
                for (int i = 0; i < filasDetalle.Count; i++)
                {
                    if (i == tabla.Seleccion && codigoEdicion > 0) continue;
                    var d = filasDetalle[i] as DetalleFactura;
                    if (d != null)
                    {
                        totalCalculado += Math.Max(0, (d.Cantidad * d.Precio) - d.DescuentoAplicado);
                        cantidadCalculada += d.Cantidad;
                    }
                }
                totalCalculado += numSubtotal.Valor;
                cantidadCalculada += (int)numCantidad.Valor;
            }

            SubtotalEnVivoCambiado(totalCalculado, cantidadCalculada);
        }

        public void EstablecerDescripcionSiVacia(string texto)
        {
            if (string.IsNullOrWhiteSpace(txtDescripcion.Caja.Text) && !string.IsNullOrWhiteSpace(texto))
            {
                txtDescripcion.Caja.Text = texto;
            }
        }

        public void EstablecerTipoCompraSiVacio(string texto)
        {
            if (string.IsNullOrWhiteSpace(txtTipo.Caja.Text) && !string.IsNullOrWhiteSpace(texto))
            {
                txtTipo.Caja.Text = texto;
            }
        }

        /// <summary>Calcula la suma total de los subtotales de los detalles cargados.</summary>
        public decimal ObtenerSumaSubtotales()
        {
            decimal total = 0;
            if (esCompra)
            {
                foreach (var obj in filasDetalle)
                {
                    var d = obj as DetalleCompra;
                    if (d != null) total += d.Subtotal;
                }
            }
            else
            {
                foreach (var obj in filasDetalle)
                {
                    var d = obj as DetalleFactura;
                    if (d != null) total += Math.Max(0, (d.Cantidad * d.Precio) - d.DescuentoAplicado);
                }
            }
            return total;
        }

        /// <summary>Calcula la cantidad total de artículos o líneas en los detalles cargados.</summary>
        public int ObtenerCantidadTotal()
        {
            int total = 0;
            if (esCompra)
            {
                total = filasDetalle.Count;
            }
            else
            {
                foreach (var obj in filasDetalle)
                {
                    var d = obj as DetalleFactura;
                    if (d != null) total += d.Cantidad;
                }
            }
            return total;
        }

    }
}
