using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Entidad;
using Negocio;

namespace Presentacion
{
    public partial class FrmFacturaciones : Form
    {
        private const int REGISTROS_POR_PAGINA = 10;
        private readonly FacturaNegocio negocio = new FacturaNegocio();
        private readonly DetalleFacturaNegocio detalleNegocio = new DetalleFacturaNegocio();
        private List<Factura> facturasFiltradas = new List<Factura>();
        private int paginaActual;
        private bool actualizandoPagina;

        public FrmFacturaciones()
        {
            InitializeComponent();
            Tema.EstilizarGrid(dgvFacturaciones);
            Tema.EstilizarGrid(dgvDetalleFactura);

            ToolTip ayuda = new ToolTip();
            ayuda.SetToolTip(btnEditar, "Editar el registro seleccionado");
            ayuda.SetToolTip(btnEliminar, "Eliminar el registro seleccionado");

            btnPagAnterior.Click += btnPagAnterior_Click;
            btnPagSiguiente.Click += btnPagSiguiente_Click;
            cmbFiltroEstado.SelectedIndexChanged += cmbFiltroEstado_SelectedIndexChanged;
            csBuscar.EnterPresionado += csBuscar_EnterPresionado;
            dgvFacturaciones.SelectionChanged += dgvFacturaciones_SelectionChanged;

            CargarFacturas();
            MostrarTab(0);
        }

        // ---------- Pestañas: 0 = Consultar, 1 = Gestionar, 2 = Resumen ----------
        // Cada página (tpConsultar, tpGestionar, tpResumen) se edita en el diseñador haciendo clic en su pestaña.
        private void MostrarTab(int tab)
        {
            tabModulo.SelectedIndex = tab;
            btnTabConsultar.Seleccionado = (tab == 0);
            btnTabGestionar.Seleccionado = (tab == 1);
            btnTabResumen.Seleccionado = (tab == 2);

            if (tab != 1)
                ActualizarResumen();
        }

        private void btnTabConsultar_Click(object sender, EventArgs e) { MostrarTab(0); }
        private void btnTabGestionar_Click(object sender, EventArgs e) { MostrarTab(1); }
        private void btnTabResumen_Click(object sender, EventArgs e) { MostrarTab(2); }

        /// <summary>Llena los valores de las tarjetas y los gráficos con el resumen que calcula la capa de negocio.</summary>
        private void ActualizarResumen()
        {
            ResumenModulo r;
            try
            {
                r = negocio.ObtenerResumen();
            }
            catch (Exception ex)
            {
                Tema.Aviso("No se pudo cargar el resumen: " + ex.Message);
                return;
            }
            Resumenes.Aplicar(r, statTotal, statEstado1, statEstado2, statExtra, graEstado, graCategoria);
        }

        // ---------- Botones (pendientes de implementar) ----------
        // Use la capa de negocio (FacturaNegocio) desde estos métodos.

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            MostrarTab(1);
            // TODO: preparar un registro nuevo
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            MostrarTab(1);
            // TODO: cargar el registro seleccionado de la tabla
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            // TODO
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // TODO
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            MostrarTab(0);
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            // TODO
        }

        private void CargarFacturas()
        {
            try
            {
                string estado = cmbFiltroEstado.SelectedItem == null
                    ? "Todos" : cmbFiltroEstado.SelectedItem.ToString();
                facturasFiltradas = negocio.Buscar(csBuscar.Texto, estado);
                paginaActual = 0;
                MostrarPagina();
            }
            catch (Exception ex)
            {
                facturasFiltradas = new List<Factura>();
                paginaActual = 0;
                MostrarPagina();
                Tema.Aviso("No se pudieron cargar las facturas: " + ex.Message);
            }
        }

        /// <summary>La paginación se mantiene en Presentación; los totales usan todos los registros.</summary>
        private void MostrarPagina()
        {
            int totalFiltrado = facturasFiltradas.Count;
            int cantidadPaginas = Math.Max(1,
                (int)Math.Ceiling(totalFiltrado / (double)REGISTROS_POR_PAGINA));
            paginaActual = Math.Max(0, Math.Min(paginaActual, cantidadPaginas - 1));

            List<Factura> filas = facturasFiltradas
                .Skip(paginaActual * REGISTROS_POR_PAGINA)
                .Take(REGISTROS_POR_PAGINA)
                .ToList();

            actualizandoPagina = true;
            try
            {
                dgvFacturaciones.DataSource = null;
                dgvFacturaciones.DataSource = filas;
                dgvFacturaciones.ClearSelection();
                if (dgvFacturaciones.Rows.Count > 0)
                    dgvFacturaciones.CurrentCell = null;
            }
            finally
            {
                actualizandoPagina = false;
            }

            btnPagina.Text = (paginaActual + 1).ToString();
            btnPagAnterior.Enabled = paginaActual > 0;
            btnPagSiguiente.Enabled = paginaActual < cantidadPaginas - 1;

            int desde = totalFiltrado == 0 ? 0 : paginaActual * REGISTROS_POR_PAGINA + 1;
            int hasta = Math.Min((paginaActual + 1) * REGISTROS_POR_PAGINA, totalFiltrado);
            lblTotalRegistros.Text = "Mostrando " + desde + "-" + hasta
                + " de " + totalFiltrado + " resultados";

            LimpiarFacturaSeleccionada();
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
            if ((paginaActual + 1) * REGISTROS_POR_PAGINA < facturasFiltradas.Count)
            {
                paginaActual++;
                MostrarPagina();
            }
        }

        private void cmbFiltroEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarFacturas();
        }

        private void csBuscar_EnterPresionado(object sender, EventArgs e)
        {
            CargarFacturas();
        }

        private void dgvFacturaciones_SelectionChanged(object sender, EventArgs e)
        {
            if (actualizandoPagina || dgvFacturaciones.CurrentRow == null)
                return;

            Factura factura = dgvFacturaciones.CurrentRow.DataBoundItem as Factura;
            if (factura == null)
                return;

            txtCodigoFacturacion.Text = factura.CodigoFacturacion.ToString();
            cmbCodigoOrdenTrabajo.Items.Clear();
            cmbCodigoOrdenTrabajo.Items.Add(factura.CodigoOrdenTrabajo);
            cmbCodigoOrdenTrabajo.SelectedIndex = 0;
            txtNoFactura.Text = factura.NoFactura.ToString();
            dtpFechaDeEntrega.Value = factura.FechaDeEntrega;
            txtSubtotal.Text = factura.Subtotal.ToString();
            txtImpuesto.Text = factura.Impuesto.ToString();
            txtTotalPagar.Text = factura.TotalPagar.ToString();
            rdoActivo.Checked = factura.Estado;
            rdoInactivo.Checked = !factura.Estado;

            try
            {
                List<DetalleFactura> detalles = detalleNegocio.ListarPorFactura(factura.CodigoFacturacion);
                dgvDetalleFactura.DataSource = null;
                dgvDetalleFactura.DataSource = detalles;
                lblSubtotalDetalle.Text = "Subtotal:  Q " + factura.Subtotal.ToString("N2");
                lblDescuentoDetalle.Text = "Descuento:  Q " + detalles.Sum(x => x.DescuentoAplicado).ToString("N2");
                lblTotalDetalle.Text = "Total:  Q " + factura.TotalPagar.ToString("N2");
                MostrarTab(1);
            }
            catch (Exception ex)
            {
                dgvDetalleFactura.DataSource = null;
                Tema.Aviso("No se pudieron cargar los detalles de la factura: " + ex.Message);
            }
        }

        private void LimpiarFacturaSeleccionada()
        {
            txtCodigoFacturacion.Clear();
            cmbCodigoOrdenTrabajo.Items.Clear();
            txtNoFactura.Clear();
            dtpFechaDeEntrega.Value = DateTime.Today;
            txtSubtotal.Clear();
            txtImpuesto.Clear();
            txtTotalPagar.Clear();
            rdoActivo.Checked = false;
            rdoInactivo.Checked = false;
            dgvDetalleFactura.DataSource = null;
            lblSubtotalDetalle.Text = "Subtotal:  Q 0.00";
            lblDescuentoDetalle.Text = "Descuento:  Q 0.00";
            lblTotalDetalle.Text = "Total:  Q 0.00";
        }

        private void btnAgregarDetalle_Click(object sender, EventArgs e)
        {
            // TODO
        }

        // La tabla (dgvFacturaciones) no tiene columnas definidas: se generan solas al asignar el DataSource con los datos de la base de datos.
    }
}
