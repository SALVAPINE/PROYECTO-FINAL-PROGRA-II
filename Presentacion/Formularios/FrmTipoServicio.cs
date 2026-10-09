using System;
using System.Globalization;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class FrmTipoServicio : Form
    {
        public FrmTipoServicio()
        {
            InitializeComponent();
            Tema.EstilizarGrid(dgvTipoServicio);

            // Columnas de dinero: formato moneda alineado a la derecha
            foreach (var c in new[] { colCosto, colRecargo, colTotal })
            {
                c.DefaultCellStyle.Format = "C2";
                c.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }

            MostrarTab(true);

            cmbFiltroEstado.SelectedIndex = 0;
            rbActivo.Checked = true;

            // Costo y recargo: solo números y un separador decimal
            txtCosto.KeyPress += SoloDecimal_KeyPress;
            txtRecargo.KeyPress += SoloDecimal_KeyPress;

            // El total se recalcula solo
            txtCosto.TextChanged += (s, e) => CalcularTotal();
            txtRecargo.TextChanged += (s, e) => CalcularTotal();
            CalcularTotal();
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

        private void SoloDecimal_KeyPress(object sender, KeyPressEventArgs e)
        {
            var tb = (TextBox)sender;
            string sep = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;

            if (char.IsControl(e.KeyChar) || char.IsDigit(e.KeyChar)) return;

            // un solo separador decimal
            if (e.KeyChar.ToString() == sep && !tb.Text.Contains(sep)) return;

            e.Handled = true;
        }

        private static decimal LeerDecimal(string texto)
        {
            decimal valor;
            return decimal.TryParse(texto, NumberStyles.Number, CultureInfo.CurrentCulture, out valor) ? valor : 0m;
        }

        // Total = Costo + Recargo
        private void CalcularTotal()
        {
            decimal total = LeerDecimal(txtCosto.Text) + LeerDecimal(txtRecargo.Text);
            txtTotal.Text = total.ToString("N2", CultureInfo.CurrentCulture);
        }

        private void LimpiarCampos()
        {
            txtCodigo.Clear();
            txtNombre.Clear();
            txtCosto.Clear();
            txtRecargo.Clear();
            txtDescripcion.Clear();
            rbActivo.Checked = true;
            CalcularTotal();
            txtNombre.Focus();
        }

        private bool Validar()
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtDescripcion.Text))
            {
                MessageBox.Show("Complete todos los campos obligatorios.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            decimal costo, recargo;
            if (!decimal.TryParse(txtCosto.Text, NumberStyles.Number, CultureInfo.CurrentCulture, out costo) || costo < 0)
            {
                MessageBox.Show("Ingrese un costo válido.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCosto.Focus();
                return false;
            }
            if (!decimal.TryParse(txtRecargo.Text, NumberStyles.Number, CultureInfo.CurrentCulture, out recargo) || recargo < 0)
            {
                MessageBox.Show("Ingrese un recargo válido (puede ser 0).", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtRecargo.Focus();
                return false;
            }
            return true;
        }

        // Valores listos para enviar a la capa de negocio / entidad
        private int CodigoActual { get { return string.IsNullOrWhiteSpace(txtCodigo.Text) ? 0 : int.Parse(txtCodigo.Text); } }
        private string NombreActual { get { return txtNombre.Text.Trim(); } }
        private decimal CostoActual { get { return LeerDecimal(txtCosto.Text); } }
        private decimal RecargoActual { get { return LeerDecimal(txtRecargo.Text); } }
        private decimal TotalActual { get { return CostoActual + RecargoActual; } }
        private string DescripcionActual { get { return txtDescripcion.Text.Trim(); } }
        private bool EstadoActual { get { return rbActivo.Checked; } }   // SQL BIT (Activo = 1)

        // ---------- Botones ----------

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!Validar()) return;

            // TODO: llamar a TipoServicioNegocio
            //   CodigoActual == 0  -> insertar
            //   CodigoActual  > 0  -> actualizar
            // usando: NombreActual, CostoActual, RecargoActual, TotalActual,
            //         DescripcionActual, EstadoActual
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvTipoServicio.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un tipo de servicio de la tabla.", "Editar",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var fila = dgvTipoServicio.CurrentRow;
            txtCodigo.Text = Convert.ToString(fila.Cells[colCodigo.Index].Value);
            txtNombre.Text = Convert.ToString(fila.Cells[colNombre.Index].Value);
            txtDescripcion.Text = Convert.ToString(fila.Cells[colDescripcion.Index].Value);
            txtCosto.Text = Convert.ToDecimal(fila.Cells[colCosto.Index].Value).ToString("0.00", CultureInfo.CurrentCulture);
            txtRecargo.Text = Convert.ToDecimal(fila.Cells[colRecargo.Index].Value).ToString("0.00", CultureInfo.CurrentCulture);

            bool inactivo = Convert.ToString(fila.Cells[colEstado.Index].Value) == "Inactivo";
            rbInactivo.Checked = inactivo;
            rbActivo.Checked = !inactivo;

            MostrarTab(true);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (CodigoActual == 0)
            {
                MessageBox.Show("Seleccione un tipo de servicio y pulse Editar antes de eliminar.", "Eliminar",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (MessageBox.Show("¿Desea eliminar este tipo de servicio?", "Confirmar",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            // TODO: TipoServicioNegocio.Eliminar(CodigoActual);
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
            // TODO: filtrar por nombre o código con TipoServicioNegocio y llenar la tabla
        }

        private void btnQuitarFiltros_Click(object sender, EventArgs e)
        {
            cmbFiltroEstado.SelectedIndex = 0;
            // TODO: recargar todos los registros
        }

        // ---------- Tabla ----------
        // Para llenar la tabla (Estado BIT -> texto):
        //   dgvTipoServicio.Rows.Add(
        //       t.CodigoTipoServicio, t.NombreServicio, t.Descripcion,
        //       t.CostoServicio, t.RecargoServicio, t.TotalServicio,
        //       t.Estado ? "Activo" : "Inactivo");
        //   lblTotalRegistros.Text = "Total de registros: " + dgvTipoServicio.Rows.Count;

        private void dgvTipoServicio_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Colorea la columna Estado (verde / ámbar / rojo).
            if (e.ColumnIndex >= 0 && dgvTipoServicio.Columns[e.ColumnIndex] == colEstado && e.Value != null)
            {
                var color = Tema.ColorEstado(e.Value.ToString());
                e.CellStyle.ForeColor = color;
                e.CellStyle.SelectionForeColor = color;
            }
        }
    }
}