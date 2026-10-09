using System;
using System.Net.Mail;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class FrmProveedores : Form
    {
        public FrmProveedores()
        {
            InitializeComponent();
            Tema.EstilizarGrid(dgvProveedores);
            MostrarTab(true);

            cmbFiltroEstado.SelectedIndex = 0;
            rbActivo.Checked = true;

            // Teléfono: solo dígitos
            txtTelefono.KeyPress += (s, e) =>
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                    e.Handled = true;
            };
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

        private void LimpiarCampos()
        {
            txtCodigo.Clear();
            txtNombre.Clear();
            txtTelefono.Clear();
            txtCorreo.Clear();
            txtTipo.Clear();
            txtDireccion.Clear();
            rbActivo.Checked = true;
            txtNombre.Focus();
        }

        private bool Validar()
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtCorreo.Text) ||
                string.IsNullOrWhiteSpace(txtTipo.Text) ||
                string.IsNullOrWhiteSpace(txtDireccion.Text))
            {
                MessageBox.Show("Complete todos los campos obligatorios.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (txtTelefono.Text.Length != 8 || !int.TryParse(txtTelefono.Text, out _))
            {
                MessageBox.Show("El teléfono debe tener 8 dígitos numéricos.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTelefono.Focus();
                return false;
            }

            try { new MailAddress(txtCorreo.Text.Trim()); }
            catch
            {
                MessageBox.Show("El correo no tiene un formato válido.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCorreo.Focus();
                return false;
            }
            return true;
        }

        // Valores listos para enviar a la capa de negocio / entidad
        private int CodigoActual { get { return string.IsNullOrWhiteSpace(txtCodigo.Text) ? 0 : int.Parse(txtCodigo.Text); } }
        private string NombreActual { get { return txtNombre.Text.Trim(); } }
        private int TelefonoActual { get { return int.Parse(txtTelefono.Text.Trim()); } }
        private string CorreoActual { get { return txtCorreo.Text.Trim(); } }
        private string TipoActual { get { return txtTipo.Text.Trim(); } }
        private string DireccionActual { get { return txtDireccion.Text.Trim(); } }
        private bool EstadoActual { get { return rbActivo.Checked; } }   // SQL BIT (Activo = 1)

        // ---------- Botones ----------

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!Validar()) return;

            // TODO: llamar a ProveedorNegocio
            //   CodigoActual == 0  -> insertar
            //   CodigoActual  > 0  -> actualizar
            // usando: NombreActual, TelefonoActual, CorreoActual,
            //         TipoActual, DireccionActual, EstadoActual
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvProveedores.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un proveedor de la tabla.", "Editar",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var fila = dgvProveedores.CurrentRow;
            txtCodigo.Text = Convert.ToString(fila.Cells[colCodigo.Index].Value);
            txtNombre.Text = Convert.ToString(fila.Cells[colNombre.Index].Value);
            txtTelefono.Text = Convert.ToString(fila.Cells[colTelefono.Index].Value);
            txtCorreo.Text = Convert.ToString(fila.Cells[colCorreo.Index].Value);
            txtTipo.Text = Convert.ToString(fila.Cells[colTipo.Index].Value);
            txtDireccion.Text = Convert.ToString(fila.Cells[colDireccion.Index].Value);

            bool inactivo = Convert.ToString(fila.Cells[colEstado.Index].Value) == "Inactivo";
            rbInactivo.Checked = inactivo;
            rbActivo.Checked = !inactivo;

            MostrarTab(true);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (CodigoActual == 0)
            {
                MessageBox.Show("Seleccione un proveedor y pulse Editar antes de eliminar.", "Eliminar",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (MessageBox.Show("¿Desea eliminar este proveedor?", "Confirmar",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            // TODO: ProveedorNegocio.Eliminar(CodigoActual);
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
            // TODO: filtrar por nombre, código o correo con ProveedorNegocio y llenar la tabla
        }

        private void btnQuitarFiltros_Click(object sender, EventArgs e)
        {
            cmbFiltroEstado.SelectedIndex = 0;
            // TODO: recargar todos los registros
        }

        // ---------- Tabla ----------
        // Para llenar la tabla (Estado BIT -> texto):
        //   dgvProveedores.Rows.Add(
        //       p.CodigoProveedor, p.NombreProveedor, p.Telefono, p.Correo,
        //       p.TipoProveedor, p.Direccion, p.Estado ? "Activo" : "Inactivo");
        //   lblTotalRegistros.Text = "Total de registros: " + dgvProveedores.Rows.Count;

        private void dgvProveedores_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Colorea la columna Estado (verde / ámbar / rojo).
            if (e.ColumnIndex >= 0 && dgvProveedores.Columns[e.ColumnIndex] == colEstado && e.Value != null)
            {
                var color = Tema.ColorEstado(e.Value.ToString());
                e.CellStyle.ForeColor = color;
                e.CellStyle.SelectionForeColor = color;
            }
        }
    }
}