using System;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class FrmDetalleCompra : Form
    {
        public FrmDetalleCompra()
        {
            InitializeComponent();
            Tema.EstilizarGrid(dgvDetalleCompra);
            colPrecioUnitario.DefaultCellStyle.Format = "C2";
            colPrecioUnitario.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            colSubtotal.DefaultCellStyle.Format = "C2";
            colSubtotal.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            MostrarTab(true);
        }

        // ---------- Pestañas Gestionar / Consultar ----------
        private void MostrarTab(bool gestionar)
        {
            pnlGestionar.Visible = gestionar;
            pnlConsultar.Visible = !gestionar;
            btnTabGestionar.Seleccionado = gestionar;
            btnTabConsultar.Seleccionado = !gestionar;
        }

        private void btnTabGestionar_Click(object sender, EventArgs e) { MostrarTab(true); }
        private void btnTabConsultar_Click(object sender, EventArgs e) { MostrarTab(false); }

        // ---------- Botones (pendientes de implementar) ----------
        // Use la capa de negocio (DetalleCompraNegocio) desde estos métodos.

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            // TODO
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // TODO
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            // TODO
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            // TODO
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            // TODO
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            // TODO
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            // TODO
        }

        private void btnQuitarFiltros_Click(object sender, EventArgs e)
        {
            // TODO
        }

        // ---------- Tabla ----------
        // La tabla (dgvDetalleCompra) está vacía: cargue los datos desde aquí cuando implemente la consulta.
    }
}
