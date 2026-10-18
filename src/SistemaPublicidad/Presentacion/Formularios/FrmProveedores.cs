using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Entidad;
using Negocio;

namespace Presentacion
{
    public partial class FrmProveedores : Form
    {
        private const int RegistrosPorPagina = 10;
        private readonly ProveedorNegocio negocio = new ProveedorNegocio();
        private List<Proveedor> proveedoresConsultados = new List<Proveedor>();
        private int paginaActual;
        private bool modoAgregar;
        private bool modoEditar;

        public FrmProveedores()
        {
            InitializeComponent();
            Tema.EstilizarGrid(dgvProveedores);

            ToolTip ayuda = new ToolTip();
            ayuda.SetToolTip(btnEditar, "Editar el registro seleccionado");
            ayuda.SetToolTip(btnEliminar, "Eliminar el registro seleccionado");

            // Se enlazan los eventos de consulta y paginación sin modificar el diseñador.
            cmbFiltroEstado.SelectedIndex = 0;
            cmbFiltroEstado.SelectedIndexChanged += cmbFiltroEstado_SelectedIndexChanged;
            btnPagAnterior.Click += btnPagAnterior_Click;
            btnPagSiguiente.Click += btnPagSiguiente_Click;

            MostrarTab(0);
        }

        // ---------- Pestañas: 0 = Consultar, 1 = Gestionar, 2 = Resumen ----------
        // Cada página (tpConsultar, tpGestionar, tpResumen) se edita en el diseñador haciendo clic en su pestaña.
        private void MostrarTab(int tab)
        {
            if (tab != 1)
            {
                modoAgregar = false;
                modoEditar = false;
            }

            tabModulo.SelectedIndex = tab;
            btnTabConsultar.Seleccionado = (tab == 0);
            btnTabGestionar.Seleccionado = (tab == 1);
            btnTabResumen.Seleccionado = (tab == 2);

            if (tab == 0)
                ConsultarProveedores();
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

        // ---------- Botones de gestión: llaman a la capa de negocio. ----------

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarCamposProveedor();
            modoAgregar = true;
            modoEditar = false;
            MostrarTab(1);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvProveedores.CurrentRow == null || !(dgvProveedores.CurrentRow.DataBoundItem is Proveedor))
            {
                Tema.Aviso("Selecciona un proveedor de la lista para editar.");
                return;
            }

            Proveedor seleccionado = (Proveedor)dgvProveedores.CurrentRow.DataBoundItem;
            txtCodgioProveedor.Text = seleccionado.CodgioProveedor.ToString();
            txtNombreProveedor.Text = seleccionado.NombreProveedor;
            txtTelefono.Text = seleccionado.Telefono.ToString();
            txtCorreo.Text = seleccionado.Correo;
            txtTipoProveedor.Text = seleccionado.TipoProveedor;
            txtDireccion.Text = seleccionado.Direccion;
            rdoActivo.Checked = seleccionado.Estado;
            rdoInactivo.Checked = !seleccionado.Estado;
            modoAgregar = false;
            modoEditar = true;
            MostrarTab(1);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvProveedores.CurrentRow == null || !(dgvProveedores.CurrentRow.DataBoundItem is Proveedor))
            {
                Tema.Aviso("Selecciona un proveedor de la lista para eliminar.");
                return;
            }

            Proveedor seleccionado = (Proveedor)dgvProveedores.CurrentRow.DataBoundItem;
            DialogResult confirmar = MessageBox.Show(
                "¿Deseas eliminar el proveedor con código " + seleccionado.CodgioProveedor + "?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirmar != DialogResult.Yes)
                return;

            try
            {
                int filasAfectadas = negocio.Eliminar(seleccionado.CodgioProveedor);
                if (filasAfectadas != 1)
                {
                    Tema.Aviso("No se eliminó el proveedor. Verifica que el registro siga existiendo.");
                    return;
                }

                // Actualiza consulta y resumen completos; conserva el texto y el filtro actuales.
                MostrarTab(0);
                Tema.Aviso("Proveedor eliminado correctamente.");
            }
            catch (Exception ex)
            {
                Tema.Aviso("No se pudo eliminar el proveedor: " + ex.Message);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!modoAgregar && !modoEditar)
            {
                Tema.Aviso("Selecciona Nuevo para agregar o elige un registro y pulsa Editar.");
                return;
            }

            int telefono;
            if (!int.TryParse(txtTelefono.Text.Trim(), out telefono))
            {
                Tema.Aviso("El teléfono debe ser un número entero válido.");
                return;
            }

            Proveedor proveedor = new Proveedor
            {
                NombreProveedor = txtNombreProveedor.Text.Trim(),
                Telefono = telefono,
                Correo = txtCorreo.Text.Trim(),
                TipoProveedor = txtTipoProveedor.Text.Trim(),
                Direccion = txtDireccion.Text.Trim(),
                Estado = rdoActivo.Checked
            };

            if (modoEditar)
            {
                int codigo;
                if (!int.TryParse(txtCodgioProveedor.Text.Trim(), out codigo))
                {
                    Tema.Aviso("El código del proveedor seleccionado no es válido.");
                    return;
                }
                proveedor.CodgioProveedor = codigo;
            }

            try
            {
                int filasAfectadas = modoEditar
                    ? negocio.Actualizar(proveedor)
                    : negocio.Insertar(proveedor);

                if (filasAfectadas != 1)
                {
                    Tema.Aviso(modoEditar
                        ? "No se actualizó el proveedor. Verifica que siga existiendo."
                        : "No se agregó el proveedor. SQL Server no confirmó una fila insertada.");
                    return;
                }

                bool fueEdicion = modoEditar;
                modoAgregar = false;
                modoEditar = false;
                LimpiarCamposProveedor();
                MostrarTab(0);
                Tema.Aviso(fueEdicion
                    ? "Proveedor actualizado correctamente."
                    : "Proveedor agregado correctamente.");
            }
            catch (Exception ex)
            {
                Tema.Aviso("No se pudo guardar el proveedor: " + ex.Message);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            modoAgregar = false;
            modoEditar = false;
            LimpiarCamposProveedor();
            MostrarTab(0);
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            // TODO
        }

        // Limpia los controles de gestión sin cambiar la consulta ni sus filtros.
        private void LimpiarCamposProveedor()
        {
            txtCodgioProveedor.Clear();
            txtNombreProveedor.Clear();
            txtTelefono.Clear();
            txtCorreo.Clear();
            txtTipoProveedor.Clear();
            txtDireccion.Clear();
            rdoActivo.Checked = true;
            rdoInactivo.Checked = false;
        }

        private void csBuscar_EnterPresionado(object sender, EventArgs e)
        {
            ConsultarProveedores();
        }

        private void cmbFiltroEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            ConsultarProveedores();
        }

        private void btnPagAnterior_Click(object sender, EventArgs e)
        {
            if (paginaActual > 0)
            {
                paginaActual--;
                MostrarPaginaActual();
            }
        }

        private void btnPagSiguiente_Click(object sender, EventArgs e)
        {
            int totalPaginas = Math.Max(1, (int)Math.Ceiling(proveedoresConsultados.Count / (double)RegistrosPorPagina));
            if (paginaActual < totalPaginas - 1)
            {
                paginaActual++;
                MostrarPaginaActual();
            }
        }

        private void ConsultarProveedores()
        {
            try
            {
                string texto = csBuscar.Texto.Trim();
                string estadoSeleccionado = cmbFiltroEstado.SelectedItem as string;
                bool? estado = null;

                if (estadoSeleccionado == "Activo")
                    estado = true;
                else if (estadoSeleccionado == "Inactivo")
                    estado = false;

                // Se conserva el resultado completo y se muestra una página a la vez.
                proveedoresConsultados = negocio.Buscar(texto, estado);
                paginaActual = 0;
                MostrarPaginaActual();
            }
            catch (Exception ex)
            {
                proveedoresConsultados = new List<Proveedor>();
                paginaActual = 0;
                MostrarPaginaActual();
                Tema.Aviso("No se pudieron consultar los proveedores: " + ex.Message);
            }
        }

        private void MostrarPaginaActual()
        {
            int totalResultados = proveedoresConsultados.Count;
            int totalPaginas = Math.Max(1, (int)Math.Ceiling(totalResultados / (double)RegistrosPorPagina));

            if (paginaActual >= totalPaginas)
                paginaActual = totalPaginas - 1;

            dgvProveedores.DataSource = proveedoresConsultados
                .Skip(paginaActual * RegistrosPorPagina)
                .Take(RegistrosPorPagina)
                .ToList();

            // El total incluye todos los resultados del filtro, no solo la página actual.
            lblTotalRegistros.Text = "Total de resultados: " + totalResultados;
            btnPagina.Text = (paginaActual + 1).ToString();
            btnPagAnterior.Enabled = paginaActual > 0;
            btnPagSiguiente.Enabled = paginaActual < totalPaginas - 1;
        }

        // Las columnas de la cuadrícula se generan desde las propiedades de Proveedor.
    }
}
