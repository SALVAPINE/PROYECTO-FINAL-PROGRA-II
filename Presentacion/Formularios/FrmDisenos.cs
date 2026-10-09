using System;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class FrmDisenos : Form
    {
        public FrmDisenos()
        {
            InitializeComponent();
            Tema.EstilizarGrid(dgvDisenos);
            colFecha.DefaultCellStyle.Format = "dd/MM/yyyy hh:mm tt";

            MostrarTab(true);

            cmbFiltroEstado.SelectedIndex = 0;
            rbActivo.Checked = true;
            dtpFecha.Value = DateTime.Now;

            CargarClientes();
            CargarDisenadores();
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

        // ---------- Utilidades del formulario ----------

        // Cliente y diseñador son llaves foráneas (Tbl_Clientes / Tbl_Diseñadores):
        // se eligen de una lista, no se escriben a mano.
        private void CargarClientes()
        {
            // TODO: obtener los clientes desde la capa de negocio, por ejemplo:
            //   cmbCliente.DataSource    = clienteNegocio.Listar();
            //   cmbCliente.DisplayMember = "NombreCliente";     // texto que se ve
            //   cmbCliente.ValueMember   = "CodigoCliente";     // valor que se guarda
            //   cmbCliente.SelectedIndex = -1;
        }

        private void CargarDisenadores()
        {
            // TODO: obtener los diseñadores desde la capa de negocio, por ejemplo:
            //   cmbDisenador.DataSource    = disenadorNegocio.Listar();
            //   cmbDisenador.DisplayMember = "NombreDiseñador";
            //   cmbDisenador.ValueMember   = "CodigoDiseñador";
            //   cmbDisenador.SelectedIndex = -1;
        }

        private void LimpiarCampos()
        {
            txtCodigo.Clear();
            cmbCliente.SelectedIndex = -1;
            cmbDisenador.SelectedIndex = -1;
            dtpFecha.Value = DateTime.Now;
            txtNombre.Clear();
            txtTipo.Clear();
            txtRango.Clear();
            txtDescripcion.Clear();
            rbActivo.Checked = true;
            txtNombre.Focus();
        }

        private bool Validar()
        {
            if (cmbCliente.SelectedValue == null)
            {
                MessageBox.Show("Seleccione el cliente.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbCliente.Focus();
                return false;
            }

            if (cmbDisenador.SelectedValue == null)
            {
                MessageBox.Show("Seleccione el diseñador.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbDisenador.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtTipo.Text) ||
                string.IsNullOrWhiteSpace(txtRango.Text) ||
                string.IsNullOrWhiteSpace(txtDescripcion.Text))
            {
                MessageBox.Show("Complete todos los campos obligatorios.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        // Valores listos para enviar a la capa de negocio / entidad
        private int CodigoActual { get { return string.IsNullOrWhiteSpace(txtCodigo.Text) ? 0 : int.Parse(txtCodigo.Text); } }
        private int ClienteActual { get { return Convert.ToInt32(cmbCliente.SelectedValue); } }
        private int DisenadorActual { get { return Convert.ToInt32(cmbDisenador.SelectedValue); } }
        private string NombreActual { get { return txtNombre.Text.Trim(); } }
        private string TipoActual { get { return txtTipo.Text.Trim(); } }
        private string RangoActual { get { return txtRango.Text.Trim(); } }
        private string DescripcionActual { get { return txtDescripcion.Text.Trim(); } }
        private DateTime FechaActual { get { return dtpFecha.Value; } }       // SQL DATETIME
        private bool EstadoActual { get { return rbActivo.Checked; } }        // SQL BIT (Activo = 1)

        // ---------- Botones ----------

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!Validar()) return;

            // TODO: llamar a DisenoNegocio
            //   CodigoActual == 0  -> insertar
            //   CodigoActual  > 0  -> actualizar
            // usando: ClienteActual, DisenadorActual, NombreActual, TipoActual,
            //         DescripcionActual, RangoActual, FechaActual, EstadoActual
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvDisenos.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un diseño de la tabla.", "Editar",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var fila = dgvDisenos.CurrentRow;
            txtCodigo.Text = Convert.ToString(fila.Cells[colCodigo.Index].Value);
            cmbCliente.SelectedValue = Convert.ToInt32(fila.Cells[colCliente.Index].Value);
            cmbDisenador.SelectedValue = Convert.ToInt32(fila.Cells[colDisenador.Index].Value);
            txtNombre.Text = Convert.ToString(fila.Cells[colNombre.Index].Value);
            txtTipo.Text = Convert.ToString(fila.Cells[colTipo.Index].Value);
            txtRango.Text = Convert.ToString(fila.Cells[colRango.Index].Value);
            txtDescripcion.Text = Convert.ToString(fila.Cells[colDescripcion.Index].Value);

            DateTime fecha;
            if (DateTime.TryParse(Convert.ToString(fila.Cells[colFecha.Index].Value), out fecha))
                dtpFecha.Value = fecha;

            bool inactivo = Convert.ToString(fila.Cells[colEstado.Index].Value) == "Inactivo";
            rbInactivo.Checked = inactivo;
            rbActivo.Checked = !inactivo;

            MostrarTab(true);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (CodigoActual == 0)
            {
                MessageBox.Show("Seleccione un diseño y pulse Editar antes de eliminar.", "Eliminar",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (MessageBox.Show("¿Desea eliminar este diseño?", "Confirmar",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            // TODO: DisenoNegocio.Eliminar(CodigoActual);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            // TODO: filtrar por nombre o código con DisenoNegocio y llenar la tabla
        }

        private void btnQuitarFiltros_Click(object sender, EventArgs e)
        {
            cmbFiltroEstado.SelectedIndex = 0;
            // TODO: recargar todos los registros
        }

        // ---------- Tabla ----------
        // Para llenar la tabla (Estado BIT -> texto):
        //   dgvDisenos.Rows.Add(
        //       d.CodigoDiseño, d.CodigoCliente, d.CodigoDiseñador, d.NombreDiseño,
        //       d.TipoDiseño, d.RangoDiseño, d.Descripcion, d.FechaCreacion,
        //       d.Estado ? "Activo" : "Inactivo");
        //   lblTotalRegistros.Text = "Total de registros: " + dgvDisenos.Rows.Count;

        private void dgvDisenos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Colorea la columna Estado (verde / ámbar / rojo).
            if (e.ColumnIndex >= 0 && dgvDisenos.Columns[e.ColumnIndex] == colEstado && e.Value != null)
            {
                var color = Tema.ColorEstado(e.Value.ToString());
                e.CellStyle.ForeColor = color;
                e.CellStyle.SelectionForeColor = color;
            }
        }
    }
}