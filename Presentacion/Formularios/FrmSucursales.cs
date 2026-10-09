using System;
using System.Globalization;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class FrmSucursales : Form
    {
        public FrmSucursales()
        {
            InitializeComponent();
            Tema.EstilizarGrid(dgvSucursales);
            MostrarTab(true);

            cmbEstado.SelectedIndex = 0;
            cmbFiltroEstado.SelectedIndex = 0;
            dtpHorario.Value = DateTime.Today.AddHours(8);

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
            txtDireccion.Clear();
            txtMunicipio.Clear();
            txtDepartamento.Clear();
            txtTelefono.Clear();
            dtpHorario.Value = DateTime.Today.AddHours(8);
            cmbEstado.SelectedIndex = 0;
            txtNombre.Focus();
        }

        private bool Validar()
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtDireccion.Text) ||
                string.IsNullOrWhiteSpace(txtMunicipio.Text) ||
                string.IsNullOrWhiteSpace(txtDepartamento.Text) ||
                cmbEstado.SelectedIndex < 0)
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
            return true;
        }

        // Valores listos para enviar a la capa de negocio / entidad
        private int CodigoActual { get { return string.IsNullOrWhiteSpace(txtCodigo.Text) ? 0 : int.Parse(txtCodigo.Text); } }
        private string NombreActual { get { return txtNombre.Text.Trim(); } }
        private string DireccionActual { get { return txtDireccion.Text.Trim(); } }
        private string MunicipioActual { get { return txtMunicipio.Text.Trim(); } }
        private string DepartamentoActual { get { return txtDepartamento.Text.Trim(); } }
        private int TelefonoActual { get { return int.Parse(txtTelefono.Text.Trim()); } }
        private TimeSpan HorarioActual { get { return dtpHorario.Value.TimeOfDay; } }   // SQL TIME
        private bool EstadoActual { get { return cmbEstado.SelectedIndex == 0; } }       // SQL BIT (Activo = 1)

        // ---------- Botones ----------

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!Validar()) return;

            // TODO: llamar a SucursalNegocio
            //   CodigoActual == 0  -> insertar
            //   CodigoActual  > 0  -> actualizar
            // usando: NombreActual, DireccionActual, MunicipioActual, DepartamentoActual,
            //         TelefonoActual, HorarioActual, EstadoActual
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvSucursales.CurrentRow == null)
            {
                MessageBox.Show("Seleccione una sucursal de la tabla.", "Editar",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var fila = dgvSucursales.CurrentRow;
            txtCodigo.Text = Convert.ToString(fila.Cells[colCodigo.Index].Value);
            txtNombre.Text = Convert.ToString(fila.Cells[colNombre.Index].Value);
            txtDireccion.Text = Convert.ToString(fila.Cells[colDireccion.Index].Value);
            txtMunicipio.Text = Convert.ToString(fila.Cells[colMunicipio.Index].Value);
            txtDepartamento.Text = Convert.ToString(fila.Cells[colDepartamento.Index].Value);
            txtTelefono.Text = Convert.ToString(fila.Cells[colTelefono.Index].Value);

            DateTime hora;
            if (DateTime.TryParse(Convert.ToString(fila.Cells[colHorario.Index].Value),
                                  CultureInfo.CurrentCulture, DateTimeStyles.None, out hora))
                dtpHorario.Value = DateTime.Today.Add(hora.TimeOfDay);

            cmbEstado.SelectedIndex =
                Convert.ToString(fila.Cells[colEstado.Index].Value) == "Inactivo" ? 1 : 0;

            MostrarTab(true);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (CodigoActual == 0)
            {
                MessageBox.Show("Seleccione una sucursal y pulse Editar antes de eliminar.", "Eliminar",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (MessageBox.Show("¿Desea eliminar esta sucursal?", "Confirmar",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            // TODO: SucursalNegocio.Eliminar(CodigoActual);
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
            // TODO: filtrar por código o nombre con SucursalNegocio y llenar la tabla
        }

        private void btnQuitarFiltros_Click(object sender, EventArgs e)
        {
            cmbFiltroEstado.SelectedIndex = 0;
            // TODO: recargar todos los registros
        }

        // ---------- Tabla ----------
        // Para llenar la tabla (Estado BIT -> texto, Horario TIME -> hh:mm tt):
        //   dgvSucursales.Rows.Add(
        //       s.CodigoSucursal, s.NombreSucursal, s.Direccion, s.Municipio,
        //       s.Departamento, s.Telefono,
        //       DateTime.Today.Add(s.HorarioDeAtencion).ToString("hh:mm tt"),
        //       s.Estado ? "Activo" : "Inactivo");
        //   lblTotalRegistros.Text = "Total de registros: " + dgvSucursales.Rows.Count;

        private void dgvSucursales_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Colorea la columna Estado (verde / ámbar / rojo).
            if (e.ColumnIndex >= 0 && dgvSucursales.Columns[e.ColumnIndex] == colEstado && e.Value != null)
            {
                var color = Tema.ColorEstado(e.Value.ToString());
                e.CellStyle.ForeColor = color;
                e.CellStyle.SelectionForeColor = color;
            }
        }
    }
}