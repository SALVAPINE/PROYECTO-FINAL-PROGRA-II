using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;
using Entidad;
using Negocio;

namespace Presentacion
{
    public partial class FrmCotizaciones : Form
    {
        private const int RegistrosPorPagina = 10;
        private readonly CotizacionNegocio negocio = new CotizacionNegocio();
        private List<Cotizacion> cotizaciones = new List<Cotizacion>();
        private int paginaActual;
        private bool vistaListaPreparada;
        private bool editando;
        private bool montoExcedeLimite;
        private const decimal MaximoMontoSql = 99999999.99M;

        public FrmCotizaciones()
        {
            InitializeComponent();
            txtCantidad.ValueChanged += RecalcularTotales;
            txtPrecio.ValueChanged += RecalcularTotales;
            Tema.EstilizarGrid(dgvCotizaciones);

            ToolTip ayuda = new ToolTip();
            ayuda.SetToolTip(btnEditar, "Editar el registro seleccionado");
            ayuda.SetToolTip(btnEliminar, "Eliminar el registro seleccionado");

            btnPagAnterior.Click += btnPagAnterior_Click;
            btnPagSiguiente.Click += btnPagSiguiente_Click;

            if (cmbFiltroEstado.SelectedIndex < 0 && cmbFiltroEstado.Items.Count > 0)
                cmbFiltroEstado.SelectedIndex = 0;
            cmbFiltroEstado.SelectedIndexChanged += cmbFiltroEstado_SelectedIndexChanged;

            CargarCatalogos();
            CargarCotizaciones();
            vistaListaPreparada = true;
            MostrarTab(0);
        }

        private void MostrarTab(int tab)
        {
            tabModulo.SelectedIndex = tab;
            btnTabConsultar.Seleccionado = tab == 0;
            btnTabGestionar.Seleccionado = tab == 1;
            btnTabResumen.Seleccionado = tab == 2;

            if (tab != 1)
                ActualizarResumen();
        }

        private void btnTabConsultar_Click(object sender, EventArgs e)
        {
            BuscarCotizaciones();
            MostrarTab(0);
        }

        private void btnTabGestionar_Click(object sender, EventArgs e) { MostrarTab(1); }
        private void btnTabResumen_Click(object sender, EventArgs e) { MostrarTab(2); }

        private void CargarCatalogos()
        {
            try
            {
                List<Cliente> clientes = negocio.ListarClientes();
                List<Sucursal> sucursales = negocio.ListarSucursales();
                List<TipoServicio> tiposServicio = negocio.ListarTiposServicio();

                cmbCodigoCliente.ValueMember = "CodigoCliente";
                cmbCodigoCliente.DisplayMember = "NombreCliente";
                cmbCodigoCliente.DataSource = clientes;

                cmbCodigoSucursal.ValueMember = "CodigoSucursal";
                cmbCodigoSucursal.DisplayMember = "NombreSucursal";
                cmbCodigoSucursal.DataSource = sucursales;

                cmbCodigoTipoServicio.ValueMember = "CodigoTipoServicio";
                cmbCodigoTipoServicio.DisplayMember = "NombreServicio";
                cmbCodigoTipoServicio.DataSource = tiposServicio;
            }
            catch (Exception ex)
            {
                Tema.Aviso("No se pudieron cargar los catalogos de Cotizaciones: " + ex.Message);
            }
        }

        private void CargarCotizaciones()
        {
            try
            {
                cotizaciones = negocio.Listar() ?? new List<Cotizacion>();
                paginaActual = 0;
                MostrarPagina();
            }
            catch (Exception ex)
            {
                MostrarErrorDeConsulta(ex);
            }
        }

        private void BuscarCotizaciones()
        {
            try
            {
                string estado = cmbFiltroEstado.SelectedItem == null
                    ? "Todos"
                    : cmbFiltroEstado.SelectedItem.ToString();

                cotizaciones = negocio.Buscar(csBuscar.Texto, estado) ?? new List<Cotizacion>();
                paginaActual = 0;
                MostrarPagina();
            }
            catch (Exception ex)
            {
                MostrarErrorDeConsulta(ex);
            }
        }

        private void MostrarErrorDeConsulta(Exception ex)
        {
            cotizaciones = new List<Cotizacion>();
            paginaActual = 0;
            MostrarPagina();
            Tema.Aviso("No se pudieron consultar las cotizaciones: " + ex.Message);
        }

        private void cmbFiltroEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (vistaListaPreparada)
                BuscarCotizaciones();
        }

        private void csBuscar_EnterPresionado(object sender, EventArgs e)
        {
            BuscarCotizaciones();
        }

        private void MostrarPagina()
        {
            int total = cotizaciones.Count;
            int totalPaginas = Math.Max(1, (total + RegistrosPorPagina - 1) / RegistrosPorPagina);
            paginaActual = Math.Max(0, Math.Min(paginaActual, totalPaginas - 1));

            int inicio = paginaActual * RegistrosPorPagina;
            int cantidad = Math.Min(RegistrosPorPagina, total - inicio);
            List<Cotizacion> filas = cantidad > 0
                ? cotizaciones.GetRange(inicio, cantidad)
                : new List<Cotizacion>();

            dgvCotizaciones.DataSource = null;
            dgvCotizaciones.DataSource = filas;

            // La etiqueta informa las filas visibles y el total completo del resultado filtrado.
            lblTotalRegistros.Text = "Mostrando " + filas.Count + " de " + total + " resultados";
            btnPagina.Text = total == 0
                ? "0 / 0"
                : (paginaActual + 1) + " / " + totalPaginas;
            btnPagAnterior.Enabled = paginaActual > 0;
            btnPagSiguiente.Enabled = paginaActual < totalPaginas - 1;
            btnPagina.Enabled = total > 0;
        }

        private void btnPagAnterior_Click(object sender, EventArgs e)
        {
            if (paginaActual > 0)
            {
                paginaActual--;
                MostrarPagina();
            }
        }

        private void btnPagSiguiente_Click(object sender, EventArgs e)
        {
            int totalPaginas = Math.Max(1,
                (cotizaciones.Count + RegistrosPorPagina - 1) / RegistrosPorPagina);
            if (paginaActual < totalPaginas - 1)
            {
                paginaActual++;
                MostrarPagina();
            }
        }

        private Cotizacion RegistroSeleccionado()
        {
            if (dgvCotizaciones.CurrentRow == null)
                return null;

            return dgvCotizaciones.CurrentRow.DataBoundItem as Cotizacion;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            editando = false;
            LimpiarFormulario();
            MostrarTab(1);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            Cotizacion seleccionada = RegistroSeleccionado();
            if (seleccionada == null)
            {
                Tema.Aviso("Selecciona una cotizacion de la tabla para editar.");
                return;
            }

            editando = true;
            CargarFormulario(seleccionada);
            MostrarTab(1);
        }

        private void CargarFormulario(Cotizacion cotizacion)
        {
            txtCodigoCotizacion.Text = cotizacion.CodigoCotizacion.ToString();
            cmbCodigoTipoServicio.SelectedValue = cotizacion.CodigoTipoServicio;
            cmbCodigoSucursal.SelectedValue = cotizacion.CodigoSucursal;
            cmbCodigoCliente.SelectedValue = cotizacion.CodigoCliente;
            txtNombreCotizador.Text = cotizacion.NombreCotizador;
            txtNIT.Text = cotizacion.NIT.HasValue ? cotizacion.NIT.Value.ToString() : string.Empty;
            txtDireccionCotizador.Text = cotizacion.DireccionCotizador;
            dtpFechaEmision.Value = cotizacion.FechaEmision;
            txtDescripcion.Text = cotizacion.Descripcion;
            txtCantidad.Value = cotizacion.Cantidad;
            txtPrecio.Value = cotizacion.Precio;
            RecalcularTotales(this, EventArgs.Empty);
            rdoActivo.Checked = cotizacion.Estado;
            rdoInactivo.Checked = !cotizacion.Estado;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Cotizacion seleccionada = RegistroSeleccionado();
            if (seleccionada == null)
            {
                Tema.Aviso("Selecciona una cotizacion de la tabla para eliminar.");
                return;
            }

            DialogResult respuesta = MessageBox.Show(
                "¿Deseas eliminar la cotizacion " + seleccionada.CodigoCotizacion + "?",
                "Confirmar eliminacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (respuesta != DialogResult.Yes)
                return;

            try
            {
                int filas = negocio.Eliminar(seleccionada.CodigoCotizacion);
                if (filas == 0)
                {
                    Tema.Aviso("La cotizacion ya no existe o no se pudo eliminar.");
                    return;
                }

                MessageBox.Show("Cotizacion eliminada.", "Cotizaciones",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                ActualizarDespuesDeCambio();
            }
            catch (Exception ex)
            {
                Tema.Aviso(ex.Message);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                Cotizacion cotizacion = LeerFormulario();

                if (editando)
                {
                    int filas = negocio.Actualizar(cotizacion);
                    if (filas == 0)
                    {
                        Tema.Aviso("No se encontro la cotizacion para editar.");
                        return;
                    }
                    MessageBox.Show("Cotizacion actualizada.", "Cotizaciones",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    int filas = negocio.Insertar(cotizacion);
                    if (filas == 0)
                    {
                        Tema.Aviso("No se agrego la cotizacion.");
                        return;
                    }
                    MessageBox.Show("Cotizacion agregada.", "Cotizaciones",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                editando = false;
                LimpiarFormulario();
                ActualizarDespuesDeCambio();
            }
            catch (FormatException ex)
            {
                Tema.Aviso("Revisa los valores numericos: " + ex.Message);
            }
            catch (Exception ex)
            {
                Tema.Aviso("No se pudo guardar la cotizacion: " + ex.Message);
            }
        }

        private Cotizacion LeerFormulario()
        {
            int? nit = null;
            int codigo = 0;

            if (montoExcedeLimite)
                throw new InvalidOperationException(
                    "Cantidad por precio supera el limite decimal de la tabla.");

            if (!string.IsNullOrWhiteSpace(txtNIT.Text))
            {
                int valorNit;
                if (!int.TryParse(txtNIT.Text, out valorNit))
                    throw new FormatException("NIT debe ser un numero entero o quedar vacio.");
                nit = valorNit;
            }

            if (editando && !int.TryParse(txtCodigoCotizacion.Text, out codigo))
                throw new FormatException("No se pudo leer el codigo de la cotizacion.");

            return new Cotizacion
            {
                CodigoCotizacion = codigo,
                CodigoTipoServicio = CodigoSeleccionado(cmbCodigoTipoServicio, "tipo de servicio"),
                CodigoSucursal = CodigoSeleccionado(cmbCodigoSucursal, "sucursal"),
                CodigoCliente = CodigoSeleccionado(cmbCodigoCliente, "cliente"),
                NombreCotizador = txtNombreCotizador.Text.Trim(),
                NIT = nit,
                DireccionCotizador = txtDireccionCotizador.Text.Trim(),
                FechaEmision = dtpFechaEmision.Value,
                Descripcion = txtDescripcion.Text.Trim(),
                Cantidad = Decimal.ToInt32(txtCantidad.Value),
                Precio = txtPrecio.Value,
                Subtotal = txtSubtotal.Value,
                Total = txtTotal.Value,
                Estado = rdoActivo.Checked
            };
        }

        /// <summary>Calcula subtotal y total cuando cambia Cantidad o Precio.</summary>
        private void RecalcularTotales(object sender, EventArgs e)
        {
            decimal subtotal = Decimal.Round(
                txtCantidad.Value * txtPrecio.Value, 2, MidpointRounding.AwayFromZero);

            montoExcedeLimite = subtotal > MaximoMontoSql;
            if (montoExcedeLimite)
            {
                txtSubtotal.Value = MaximoMontoSql;
                txtTotal.Value = MaximoMontoSql;
                return;
            }

            txtSubtotal.Value = subtotal;
            // La tabla no tiene columna de descuento: el total queda igual al subtotal.
            txtTotal.Value = subtotal;
        }

        private int CodigoSeleccionado(ComboBox combo, string nombreCampo)
        {
            if (combo.SelectedValue == null)
                throw new InvalidOperationException("Selecciona un " + nombreCampo + ".");

            return Convert.ToInt32(combo.SelectedValue);
        }

        private void ActualizarDespuesDeCambio()
        {
            BuscarCotizaciones();
            MostrarTab(0);
        }

        private void LimpiarFormulario()
        {
            txtCodigoCotizacion.Clear();
            txtNombreCotizador.Clear();
            txtNIT.Clear();
            txtDireccionCotizador.Clear();
            txtDescripcion.Clear();
            txtCantidad.Value = 0M;
            txtPrecio.Value = 0M;
            txtSubtotal.Value = 0M;
            txtTotal.Value = 0M;
            montoExcedeLimite = false;
            dtpFechaEmision.Value = DateTime.Today;
            rdoActivo.Checked = true;
            rdoInactivo.Checked = false;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            editando = false;
            LimpiarFormulario();
            MostrarTab(0);
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            editando = false;
            LimpiarFormulario();
        }

        private void ActualizarResumen()
        {
            try
            {
                ResumenModulo resumen = negocio.ObtenerResumen();
                Resumenes.Aplicar(resumen, statTotal, statEstado1, statEstado2,
                    statExtra, graEstado, graCategoria);
            }
            catch (Exception ex)
            {
                Tema.Aviso("No se pudo actualizar el resumen: " + ex.Message);
            }
        }
    }
}
