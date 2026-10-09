using System;
using System.Globalization;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class FrmMateriales : Form
    {
        public FrmMateriales()
        {
            InitializeComponent();
            Tema.EstilizarGrid(dgvMateriales);

            colCosto.DefaultCellStyle.Format = "C2";
            colCosto.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            MostrarTab(true);

            cmbFiltroEstado.SelectedIndex = 0;
            rbActivo.Checked = true;

            // Costo: solo números y un separador decimal
            txtCosto.KeyPress += SoloDecimal_KeyPress;

            CargarOrdenesTrabajo();
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

        // La orden de trabajo es una llave foránea (Tbl_OrdenesDeTrabajo):
        // se elige de una lista, no se escribe a mano.
        private void CargarOrdenesTrabajo()
        {
            // TODO: obtener las órdenes desde la capa de negocio, por ejemplo:
            //   cmbOrdenTrabajo.DataSource    = ordenNegocio.Listar();   // DataTable o List<OrdenTrabajo>
            //   cmbOrdenTrabajo.DisplayMember = "CodigoOrdenTrabajo";    // o un texto descriptivo
            //   cmbOrdenTrabajo.ValueMember   = "CodigoOrdenTrabajo";
            //   cmbOrdenTrabajo.SelectedIndex = -1;
        }

        private void SoloDecimal_KeyPress(object sender, KeyPressEventArgs e)
        {
            var tb = (TextBox)sender;
            string sep = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;

            if (char.IsControl(e.KeyChar) || char.IsDigit(e.KeyChar)) return;
            if (e.KeyChar.ToString() == sep && !tb.Text.Contains(sep)) return;

            e.Handled = true;
        }

        private void LimpiarCampos()
        {
            txtCodigo.Clear();
            cmbOrdenTrabajo.SelectedIndex = -1;
            txtNombre.Clear();
            txtTipo.Clear();
            txtCategoria.Clear();
            txtUnidad.Clear();
            txtCosto.Clear();
            rbActivo.Checked = true;
            txtNombre.Focus();
        }

        private bool Validar()
        {
            if (cmbOrdenTrabajo.SelectedValue == null)
            {
                MessageBox.Show("Seleccione la orden de trabajo.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbOrdenTrabajo.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtTipo.Text) ||
                string.IsNullOrWhiteSpace(txtCategoria.Text) ||
                string.IsNullOrWhiteSpace(txtUnidad.Text))
            {
                MessageBox.Show("Complete todos los campos obligatorios.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            decimal costo;
            if (!decimal.TryParse(txtCosto.Text, NumberStyles.Number, CultureInfo.CurrentCulture, out costo) || costo < 0)
            {
                MessageBox.Show("Ingrese un costo válido.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCosto.Focus();
                return false;
            }
            return true;
        }

        // Valores listos para enviar a la capa de negocio / entidad
        private int CodigoActual { get { return string.IsNullOrWhiteSpace(txtCodigo.Text) ? 0 : int.Parse(txtCodigo.Text); } }
        private int OrdenTrabajoActual { get { return Convert.ToInt32(cmbOrdenTrabajo.SelectedValue); } }
        private string NombreActual { get { return txtNombre.Text.Trim(); } }
        private string TipoActual { get { return txtTipo.Text.Trim(); } }
        private string CategoriaActual { get { return txtCategoria.Text.Trim(); } }
        private string UnidadActual { get { return txtUnidad.Text.Trim(); } }
        private decimal CostoActual { get { return decimal.Parse(txtCosto.Text, NumberStyles.Number, CultureInfo.CurrentCulture); } }
        private bool EstadoActual { get { return rbActivo.Checked; } }   // SQL BIT (Activo = 1)

        // ---------- Botones ----------

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!Validar()) return;

            // TODO: llamar a MaterialNegocio
            //   CodigoActual == 0  -> insertar
            //   CodigoActual  > 0  -> actualizar
            // usando: OrdenTrabajoActual, NombreActual, TipoActual, CategoriaActual,
            //         UnidadActual, CostoActual, EstadoActual
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvMateriales.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un material de la tabla.", "Editar",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var fila = dgvMateriales.CurrentRow;
            txtCodigo.Text = Convert.ToString(fila.Cells[colCodigo.Index].Value);
            cmbOrdenTrabajo.SelectedValue = Convert.ToInt32(fila.Cells[colOrdenTrabajo.Index].Value);
            txtNombre.Text = Convert.ToString(fila.Cells[colNombre.Index].Value);
            txtTipo.Text = Convert.ToString(fila.Cells[colTipo.Index].Value);
            txtCategoria.Text = Convert.ToString(fila.Cells[colCategoria.Index].Value);
            txtUnidad.Text = Convert.ToString(fila.Cells[colUnidad.Index].Value);
            txtCosto.Text = Convert.ToDecimal(fila.Cells[colCosto.Index].Value).ToString("0.00", CultureInfo.CurrentCulture);

            bool inactivo = Convert.ToString(fila.Cells[colEstado.Index].Value) == "Inactivo";
            rbInactivo.Checked = inactivo;
            rbActivo.Checked = !inactivo;

            MostrarTab(true);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (CodigoActual == 0)
            {
                MessageBox.Show("Seleccione un material y pulse Editar antes de eliminar.", "Eliminar",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (MessageBox.Show("¿Desea eliminar este material?", "Confirmar",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            // TODO: MaterialNegocio.Eliminar(CodigoActual);
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
            // TODO: filtrar por nombre o código con MaterialNegocio y llenar la tabla
        }

        private void btnQuitarFiltros_Click(object sender, EventArgs e)
        {
            cmbFiltroEstado.SelectedIndex = 0;
            // TODO: recargar todos los registros
        }

        // ---------- Tabla ----------
        // Para llenar la tabla (Estado BIT -> texto):
        //   dgvMateriales.Rows.Add(
        //       m.CodigoMaterial, m.CodigoOrdenTrabajo, m.NombreMaterial, m.TipoDeMaterial,
        //       m.CategoriaMaterial, m.UnidadMedida, m.CostoMaterial,
        //       m.Estado ? "Activo" : "Inactivo");
        //   lblTotalRegistros.Text = "Total de registros: " + dgvMateriales.Rows.Count;

        private void dgvMateriales_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Colorea la columna Estado (verde / ámbar / rojo).
            if (e.ColumnIndex >= 0 && dgvMateriales.Columns[e.ColumnIndex] == colEstado && e.Value != null)
            {
                var color = Tema.ColorEstado(e.Value.ToString());
                e.CellStyle.ForeColor = color;
                e.CellStyle.SelectionForeColor = color;
            }
        }
    }
}