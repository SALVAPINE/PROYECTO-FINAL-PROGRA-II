using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Entidad;
using Negocio;

namespace Presentacion
{
    public partial class FrmClientes : Form
    {
        private const int REGISTROS_POR_PAGINA = 10;
        private readonly ClienteNegocio negocio = new ClienteNegocio();
        private List<Cliente> clientesFiltrados = new List<Cliente>();
        private int paginaActual = 0;
        private bool editando = false;

        public FrmClientes()
        {
            InitializeComponent();
            Tema.EstilizarGrid(dgvClientes);

            // Se conservan los controles diseñados; esta etapa permite consultar y agregar.
            btnNuevo.Enabled = true;
            btnEditar.Enabled = true;
            btnEliminar.Enabled = true;
            btnGuardar.Enabled = false;
            btnLimpiar.Enabled = false;
            txtCodigoCliente.Enabled = false;
            txtNombreCliente.Enabled = false;
            txtDireccion.Enabled = false;
            txtDPI.Enabled = false;
            txtEdad.Enabled = false;
            txtNIT.Enabled = false;
            txtTelefono.Enabled = false;
            rdoActivo.Enabled = false;
            rdoInactivo.Enabled = false;

            btnPagAnterior.Click += btnPagAnterior_Click;
            btnPagSiguiente.Click += btnPagSiguiente_Click;
            cmbFiltroEstado.SelectedIndexChanged += cmbFiltroEstado_SelectedIndexChanged;

            CargarClientes();
            MostrarTab(0);
        }

        private void MostrarTab(int tab)
        {
            tabModulo.SelectedIndex = tab;
            btnTabConsultar.Seleccionado = tab == 0;
            btnTabGestionar.Seleccionado = tab == 1;
            btnTabResumen.Seleccionado = tab == 2;
            if (tab != 1) ActualizarResumen();
        }

        private void btnTabConsultar_Click(object sender, EventArgs e) { MostrarTab(0); }
        private void btnTabGestionar_Click(object sender, EventArgs e) { MostrarTab(1); }
        private void btnTabResumen_Click(object sender, EventArgs e) { MostrarTab(2); }

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
                Tema.Aviso("No se pudo cargar el resumen: " + ex.Message);
            }
        }

        private void CargarClientes()
        {
            try
            {
                string estado = cmbFiltroEstado.SelectedItem == null
                    ? "Todos" : cmbFiltroEstado.SelectedItem.ToString();
                clientesFiltrados = negocio.Buscar(csBuscar.Texto, estado);
                paginaActual = 0;
                MostrarPagina();
            }
            catch (Exception ex)
            {
                Tema.Aviso("No se pudieron cargar los clientes: " + ex.Message);
            }
        }

        /// <summary>La paginación se hace solo aquí; los totales resumen abarcan todos los registros.</summary>
        private void MostrarPagina()
        {
            int totalFiltrado = clientesFiltrados.Count;
            int cantidadPaginas = Math.Max(1,
                (int)Math.Ceiling(totalFiltrado / (double)REGISTROS_POR_PAGINA));
            paginaActual = Math.Max(0, Math.Min(paginaActual, cantidadPaginas - 1));

            List<Cliente> filas = clientesFiltrados
                .Skip(paginaActual * REGISTROS_POR_PAGINA)
                .Take(REGISTROS_POR_PAGINA)
                .ToList();

            dgvClientes.DataSource = null;
            dgvClientes.DataSource = filas;
            btnPagina.Text = (paginaActual + 1).ToString();
            btnPagAnterior.Enabled = paginaActual > 0;
            btnPagSiguiente.Enabled = paginaActual < cantidadPaginas - 1;

            int desde = totalFiltrado == 0 ? 0 : paginaActual * REGISTROS_POR_PAGINA + 1;
            int hasta = Math.Min((paginaActual + 1) * REGISTROS_POR_PAGINA, totalFiltrado);
            lblTotalRegistros.Text = "Mostrando " + desde + "-" + hasta
                + " de " + totalFiltrado + " resultados";
        }

        private void btnPagAnterior_Click(object sender, EventArgs e)
        {
            if (paginaActual > 0) { paginaActual--; MostrarPagina(); }
        }

        private void btnPagSiguiente_Click(object sender, EventArgs e)
        {
            if ((paginaActual + 1) * REGISTROS_POR_PAGINA < clientesFiltrados.Count)
            { paginaActual++; MostrarPagina(); }
        }

        private void cmbFiltroEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarClientes();
        }

        private void csBuscar_EnterPresionado(object sender, EventArgs e)
        {
            CargarClientes();
        }


        private void HabilitarFormulario(bool habilitado)
        {
            btnNuevo.Enabled = !habilitado;
            btnEditar.Enabled = !habilitado;
            btnEliminar.Enabled = !habilitado;
            txtNombreCliente.Enabled = habilitado;
            txtDireccion.Enabled = habilitado;
            txtDPI.Enabled = habilitado;
            txtEdad.Enabled = habilitado;
            txtNIT.Enabled = habilitado;
            txtTelefono.Enabled = habilitado;
            rdoActivo.Enabled = habilitado;
            rdoInactivo.Enabled = habilitado;
            btnGuardar.Enabled = habilitado;
            btnLimpiar.Enabled = habilitado && !editando;
        }

        private void LimpiarFormulario()
        {
            txtCodigoCliente.Clear();
            txtNombreCliente.Clear();
            txtDireccion.Clear();
            txtDPI.Clear();
            txtEdad.Clear();
            txtNIT.Clear();
            txtTelefono.Clear();
            rdoActivo.Checked = true;
            rdoInactivo.Checked = false;
        }

        // Los siguientes eventos se mantienen porque están enlazados en el diseñador.
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            editando = false;
            LimpiarFormulario();
            HabilitarFormulario(true);
            MostrarTab(1);
            txtNombreCliente.Focus();
        }
        private void btnEditar_Click(object sender, EventArgs e)
        {
            Cliente cliente = dgvClientes.CurrentRow == null
                ? null : dgvClientes.CurrentRow.DataBoundItem as Cliente;
            if (cliente == null)
            {
                Tema.Aviso("Selecciona un cliente para editar.");
                return;
            }

            editando = true;
            txtCodigoCliente.Text = cliente.CodigoCliente.ToString();
            txtNombreCliente.Text = cliente.NombreCliente;
            txtDireccion.Text = cliente.Direccion;
            txtDPI.Text = cliente.DPI.ToString();
            txtEdad.Text = cliente.Edad.ToString();
            txtNIT.Text = cliente.NIT.HasValue ? cliente.NIT.Value.ToString() : string.Empty;
            txtTelefono.Text = cliente.Telefono.ToString();
            rdoActivo.Checked = cliente.Estado;
            rdoInactivo.Checked = !cliente.Estado;

            HabilitarFormulario(true);
            MostrarTab(1);
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Cliente cliente = dgvClientes.CurrentRow == null
                ? null : dgvClientes.CurrentRow.DataBoundItem as Cliente;
            if (cliente == null)
            {
                Tema.Aviso("Selecciona un cliente para eliminar.");
                return;
            }

            DialogResult respuesta = MessageBox.Show(
                "¿Deseas eliminar al cliente " + cliente.NombreCliente + "? Esta acción no se puede deshacer.",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (respuesta != DialogResult.Yes)
                return;

            try
            {
                int filas = negocio.Eliminar(cliente.CodigoCliente);
                if (filas == 0)
                {
                    Tema.Aviso("El cliente ya no existe o fue eliminado.");
                    return;
                }

                CargarClientes();
                ActualizarResumen();
                Tema.Aviso("Cliente eliminado correctamente.");
            }
            catch (Exception ex)
            {
                Tema.Aviso(ex.Message);
            }
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            int dpi, edad, telefono;
            int? nit = null;
            if (!int.TryParse(txtDPI.Text.Trim(), out dpi) || !int.TryParse(txtEdad.Text.Trim(), out edad)
                || !int.TryParse(txtTelefono.Text.Trim(), out telefono))
            { Tema.Aviso("DPI, edad y teléfono deben ser enteros válidos."); return; }

            if (!string.IsNullOrWhiteSpace(txtNIT.Text))
            {
                int valorNit;
                if (!int.TryParse(txtNIT.Text.Trim(), out valorNit))
                { Tema.Aviso("El NIT debe ser entero válido o quedar vacío."); return; }
                nit = valorNit;
            }

            int codigo = 0;
            if (editando && !int.TryParse(txtCodigoCliente.Text, out codigo))
            { Tema.Aviso("No se pudo identificar el cliente seleccionado."); return; }

            Cliente cliente = new Cliente
            {
                CodigoCliente = codigo,
                NombreCliente = txtNombreCliente.Text.Trim(),
                Direccion = txtDireccion.Text.Trim(),
                DPI = dpi,
                Edad = edad,
                NIT = nit,
                Telefono = telefono,
                Estado = rdoActivo.Checked
            };

            try
            {
                int filas = editando ? negocio.Editar(cliente) : negocio.Agregar(cliente);
                if (filas == 0)
                {
                    Tema.Aviso(editando ? "No se encontró el cliente para actualizar." : "No se agregó el cliente.");
                    return;
                }

                editando = false;
                HabilitarFormulario(false);
                LimpiarFormulario();
                CargarClientes();
                ActualizarResumen();
                MostrarTab(0);
                Tema.Aviso("Cliente " + (codigo > 0 ? "actualizado" : "agregado") + " correctamente.");
            }
            catch (Exception ex) { Tema.Aviso(ex.Message); }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            editando = false;
            LimpiarFormulario();
            HabilitarFormulario(false);
            MostrarTab(0);
        }
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
            txtNombreCliente.Focus();
        }
    }
}