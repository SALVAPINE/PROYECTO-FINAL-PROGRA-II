using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Entidad;
using Negocio;

namespace Presentacion
{
    public partial class FrmSucursales : Form
    {
        private const int RegistrosPorPagina = 10;
        private readonly SucursalNegocio negocio = new SucursalNegocio();
        private List<Sucursal> sucursalesConsultadas = new List<Sucursal>();
        private int paginaActual;
        private bool modoAgregar;
        private bool modoEditar;

        public FrmSucursales()
        {
            InitializeComponent();
            Tema.EstilizarGrid(dgvSucursales);

            ToolTip ayuda = new ToolTip();
            ayuda.SetToolTip(btnEditar, "Editar el registro seleccionado");
            ayuda.SetToolTip(btnEliminar, "Eliminar el registro seleccionado");

            // Se conectan los controles existentes sin modificar el diseñador.
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
                ConsultarSucursales();
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
        // Use la capa de negocio (SucursalNegocio) desde estos métodos.

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarCamposSucursal();
            modoAgregar = true;
            modoEditar = false;
            MostrarTab(1);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvSucursales.CurrentRow == null || !(dgvSucursales.CurrentRow.DataBoundItem is Sucursal))
            {
                Tema.Aviso("Selecciona una sucursal de la lista para editar.");
                return;
            }

            Sucursal seleccionada = (Sucursal)dgvSucursales.CurrentRow.DataBoundItem;
            txtCodigoSucursal.Text = seleccionada.CodigoSucursal.ToString();
            txtNombreSucursal.Text = seleccionada.NombreSucursal;
            txtDireccion.Text = seleccionada.Direccion;
            txtMunicipio.Text = seleccionada.Municipio;
            txtDepartamento.Text = seleccionada.Departamento;
            txtTelefono.Text = seleccionada.Telefono.ToString();
            dtpHorarioDeAtencion.Value = DateTime.Today.Add(seleccionada.HorarioDeAtencion);
            rdoActivo.Checked = seleccionada.Estado;
            rdoInactivo.Checked = !seleccionada.Estado;
            modoAgregar = false;
            modoEditar = true;
            MostrarTab(1);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvSucursales.CurrentRow == null || !(dgvSucursales.CurrentRow.DataBoundItem is Sucursal))
            {
                Tema.Aviso("Selecciona una sucursal de la lista para eliminar.");
                return;
            }

            Sucursal seleccionada = (Sucursal)dgvSucursales.CurrentRow.DataBoundItem;
            DialogResult confirmar = MessageBox.Show(
                "¿Deseas eliminar la sucursal con código " + seleccionada.CodigoSucursal + "?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirmar != DialogResult.Yes)
                return;

            try
            {
                int filasAfectadas = negocio.Eliminar(seleccionada.CodigoSucursal);
                if (filasAfectadas != 1)
                {
                    Tema.Aviso("No se eliminó la sucursal. Verifica que el registro siga existiendo.");
                    return;
                }

                // Recarga la búsqueda y los totales completos, manteniendo sus filtros actuales.
                MostrarTab(0);
                Tema.Aviso("Sucursal eliminada correctamente.");
            }
            catch (Exception ex)
            {
                Tema.Aviso("No se pudo eliminar la sucursal: " + ex.Message);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!modoAgregar && !modoEditar)
            {
                Tema.Aviso("Selecciona Nuevo para agregar o una sucursal y Editar para modificarla.");
                return;
            }

            int telefono;
            if (!int.TryParse(txtTelefono.Text.Trim(), out telefono))
            {
                Tema.Aviso("El teléfono debe ser un número entero válido.");
                return;
            }

            Sucursal sucursal = new Sucursal
            {
                NombreSucursal = txtNombreSucursal.Text.Trim(),
                Direccion = txtDireccion.Text.Trim(),
                Municipio = txtMunicipio.Text.Trim(),
                Departamento = txtDepartamento.Text.Trim(),
                Telefono = telefono,
                HorarioDeAtencion = dtpHorarioDeAtencion.Value.TimeOfDay,
                Estado = rdoActivo.Checked
            };

            if (modoEditar)
            {
                int codigoSucursal;
                if (!int.TryParse(txtCodigoSucursal.Text.Trim(), out codigoSucursal))
                {
                    Tema.Aviso("El código de la sucursal seleccionada no es válido.");
                    return;
                }
                sucursal.CodigoSucursal = codigoSucursal;

                try
                {
                    int filasAfectadas = negocio.Actualizar(sucursal);
                    if (filasAfectadas != 1)
                    {
                        Tema.Aviso("No se actualizó la sucursal. Verifica que el registro siga existiendo.");
                        return;
                    }

                    modoEditar = false;
                    LimpiarCamposSucursal();
                    MostrarTab(0);
                    Tema.Aviso("Sucursal actualizada correctamente.");
                }
                catch (Exception ex)
                {
                    Tema.Aviso("No se pudo actualizar la sucursal: " + ex.Message);
                }
                return;
            }

            try
            {
                int filasAfectadas = negocio.Insertar(sucursal);
                if (filasAfectadas != 1)
                {
                    Tema.Aviso("No se agregó la sucursal. SQL Server no confirmó una fila insertada.");
                    return;
                }

                modoAgregar = false;
                LimpiarCamposSucursal();
                MostrarTab(0);
                Tema.Aviso("Sucursal agregada correctamente.");
            }
            catch (Exception ex)
            {
                Tema.Aviso("No se pudo agregar la sucursal: " + ex.Message);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            modoAgregar = false;
            modoEditar = false;
            LimpiarCamposSucursal();
            MostrarTab(0);
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            // TODO
        }

        // Limpia los campos al iniciar una captura nueva sin alterar la consulta.
        private void LimpiarCamposSucursal()
        {
            txtCodigoSucursal.Clear();
            txtNombreSucursal.Clear();
            txtDireccion.Clear();
            txtMunicipio.Clear();
            txtDepartamento.Clear();
            txtTelefono.Clear();
            rdoActivo.Checked = true;
            rdoInactivo.Checked = false;
        }

        private void csBuscar_EnterPresionado(object sender, EventArgs e)
        {
            ConsultarSucursales();
        }

        private void cmbFiltroEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            ConsultarSucursales();
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
            int totalPaginas = Math.Max(1, (int)Math.Ceiling(sucursalesConsultadas.Count / (double)RegistrosPorPagina));
            if (paginaActual < totalPaginas - 1)
            {
                paginaActual++;
                MostrarPaginaActual();
            }
        }

        private void ConsultarSucursales()
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

                // Se conserva todo el resultado; el recorte por página ocurre solo en Presentación.
                sucursalesConsultadas = negocio.Buscar(texto, estado);
                paginaActual = 0;
                MostrarPaginaActual();
            }
            catch (Exception ex)
            {
                sucursalesConsultadas = new List<Sucursal>();
                paginaActual = 0;
                MostrarPaginaActual();
                Tema.Aviso("No se pudieron consultar las sucursales: " + ex.Message);
            }
        }

        private void MostrarPaginaActual()
        {
            int totalResultados = sucursalesConsultadas.Count;
            int totalPaginas = Math.Max(1, (int)Math.Ceiling(totalResultados / (double)RegistrosPorPagina));

            if (paginaActual >= totalPaginas)
                paginaActual = totalPaginas - 1;

            dgvSucursales.DataSource = sucursalesConsultadas
                .Skip(paginaActual * RegistrosPorPagina)
                .Take(RegistrosPorPagina)
                .ToList();

            // La etiqueta indica el total filtrado, que no depende de la página visible.
            lblTotalRegistros.Text = "Total de resultados: " + totalResultados;
            btnPagina.Text = (paginaActual + 1).ToString();
            btnPagAnterior.Enabled = paginaActual > 0;
            btnPagSiguiente.Enabled = paginaActual < totalPaginas - 1;
        }

        // La cuadrícula genera sus columnas a partir de las propiedades de Sucursal.
    }
}
