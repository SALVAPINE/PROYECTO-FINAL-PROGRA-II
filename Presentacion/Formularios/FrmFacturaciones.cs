using System;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class FrmFacturaciones : Form
    {
        public FrmFacturaciones()
        {
            InitializeComponent();
            Tema.EstilizarGrid(dgvFacturaciones);
            colFecha.DefaultCellStyle.Format = "dd/MM/yyyy";
            colTotal.DefaultCellStyle.Format = "C2";
            colTotal.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
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
        // Use la capa de negocio (FacturaNegocio) desde estos métodos.

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
        // La tabla (dgvFacturaciones) está vacía: cargue los datos desde aquí cuando implemente la consulta.

        private void dgvFacturaciones_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Colorea la columna Estado (verde / ámbar / rojo).
            if (e.ColumnIndex >= 0 && dgvFacturaciones.Columns[e.ColumnIndex] == colEstado && e.Value != null)
            {
                var color = Tema.ColorEstado(e.Value.ToString());
                e.CellStyle.ForeColor = color;
                e.CellStyle.SelectionForeColor = color;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
