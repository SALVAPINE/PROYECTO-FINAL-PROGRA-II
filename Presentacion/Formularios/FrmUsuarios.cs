using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Entidad;
using Negocio;

namespace Presentacion
{
    public partial class FrmUsuarios : Form
    {
        private const int RegistrosPorPagina = 10;
        private readonly UsuarioNegocio negocio = new UsuarioNegocio();
        private List<Usuario> usuarios = new List<Usuario>();
        private int paginaActual;
        private bool vistaListaPreparada;
        private bool editando;

        public FrmUsuarios()
        {
            InitializeComponent();
            Tema.EstilizarGrid(dgvUsuarios);

            ToolTip ayuda = new ToolTip();
            ayuda.SetToolTip(btnEditar, "Editar el registro seleccionado");
            ayuda.SetToolTip(btnEliminar, "Eliminar el registro seleccionado");

            btnPagAnterior.Click += btnPagAnterior_Click;
            btnPagSiguiente.Click += btnPagSiguiente_Click;

            if (cmbFiltroTipo.Items.Count > 0) cmbFiltroTipo.SelectedIndex = 0;
            if (cmbFiltroEstado.Items.Count > 0) cmbFiltroEstado.SelectedIndex = 0;
            cmbFiltroTipo.SelectedIndexChanged += cmbFiltroTipo_SelectedIndexChanged;
            cmbFiltroEstado.SelectedIndexChanged += cmbFiltroEstado_SelectedIndexChanged;

            CargarSucursales();
            CargarUsuarios();
            vistaListaPreparada = true;
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

        private void btnTabConsultar_Click(object sender, EventArgs e)
        {
            BuscarUsuarios();
            MostrarTab(0);
        }

        private void btnTabGestionar_Click(object sender, EventArgs e) { MostrarTab(1); }
        private void btnTabResumen_Click(object sender, EventArgs e) { MostrarTab(2); }

        private void CargarSucursales()
        {
            try
            {
                List<Sucursal> sucursales = negocio.ListarSucursales();
                cmbCodigoSucursal.ValueMember = "CodigoSucursal";
                cmbCodigoSucursal.DisplayMember = "NombreSucursal";
                cmbCodigoSucursal.DataSource = sucursales;
                cmbCodigoSucursal.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                Tema.Aviso("No se pudieron cargar las sucursales: " + ex.Message);
            }
        }

        private void CargarUsuarios()
        {
            try
            {
                usuarios = negocio.Listar() ?? new List<Usuario>();
                paginaActual = 0;
                MostrarPagina();
            }
            catch (Exception ex)
            {
                MostrarErrorDeConsulta(ex);
            }
        }

        private void BuscarUsuarios()
        {
            try
            {
                string tipo = cmbFiltroTipo.SelectedItem == null
                    ? "Todos" : cmbFiltroTipo.SelectedItem.ToString();
                string estado = cmbFiltroEstado.SelectedItem == null
                    ? "Todos" : cmbFiltroEstado.SelectedItem.ToString();
                usuarios = negocio.Buscar(csBuscar.Texto, tipo, estado) ?? new List<Usuario>();
                paginaActual = 0;
                MostrarPagina();
            }
            catch (Exception ex)
            {
                MostrarErrorDeConsulta(ex);
            }
        }

        private void MostrarErrorDeConsulta(Exception ex)
        {
            usuarios = new List<Usuario>();
            paginaActual = 0;
            MostrarPagina();
            Tema.Aviso("No se pudieron consultar los usuarios: " + ex.Message);
        }

        private void cmbFiltroTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (vistaListaPreparada) BuscarUsuarios();
        }

        private void cmbFiltroEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (vistaListaPreparada) BuscarUsuarios();
        }

        private void csBuscar_EnterPresionado(object sender, EventArgs e)
        {
            BuscarUsuarios();
        }

        private void MostrarPagina()
        {
            int total = usuarios.Count;
            int totalPaginas = Math.Max(1, (total + RegistrosPorPagina - 1) / RegistrosPorPagina);
            paginaActual = Math.Max(0, Math.Min(paginaActual, totalPaginas - 1));
            int inicio = paginaActual * RegistrosPorPagina;
            int cantidad = Math.Min(RegistrosPorPagina, total - inicio);
            List<Usuario> filas = cantidad > 0
                ? usuarios.GetRange(inicio, cantidad)
                : new List<Usuario>();

            dgvUsuarios.DataSource = null;
            dgvUsuarios.DataSource = filas;
            // La clave se mantiene oculta en la cuadrilla.
            if (dgvUsuarios.Columns["Clave"] != null)
                dgvUsuarios.Columns["Clave"].Visible = false;

            // El total corresponde a todos los resultados del filtro, no a esta pagina.
            lblTotalRegistros.Text = "Mostrando " + filas.Count + " de " + total + " resultados";
            btnPagina.Text = (paginaActual + 1).ToString();
            btnPagAnterior.Enabled = paginaActual > 0;
            btnPagSiguiente.Enabled = paginaActual < totalPaginas - 1;
            btnPagina.Enabled = total > 0;
        }

        private void btnPagAnterior_Click(object sender, EventArgs e)
        {
            if (paginaActual > 0)
            {
                paginaActual--;
                MostrarPagina();
            }
        }

        private void btnPagSiguiente_Click(object sender, EventArgs e)
        {
            int totalPaginas = Math.Max(1,
                (usuarios.Count + RegistrosPorPagina - 1) / RegistrosPorPagina);
            if (paginaActual < totalPaginas - 1)
            {
                paginaActual++;
                MostrarPagina();
            }
        }

        private Usuario RegistroSeleccionado()
        {
            if (dgvUsuarios.CurrentRow == null) return null;
            return dgvUsuarios.CurrentRow.DataBoundItem as Usuario;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            editando = false;
            LimpiarFormulario();
            MostrarTab(1);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            Usuario seleccionado = RegistroSeleccionado();
            if (seleccionado == null)
            {
                Tema.Aviso("Selecciona un usuario de la tabla para editar.");
                return;
            }
            editando = true;
            CargarFormulario(seleccionado);
            MostrarTab(1);
        }

        private void CargarFormulario(Usuario usuario)
        {
            txtCodigoUsuario.Text = usuario.CodigoUsuario.ToString();
            cmbCodigoSucursal.SelectedValue = usuario.CodigoSucursal;
            txtNombreUsuario.Text = usuario.NombreUsuario;
            txtClave.Text = usuario.Clave;
            dtpFechaCreacion.Value = usuario.FechaCreacion;
            cmbTipoUsuario.SelectedItem = usuario.TipoUsuario;
            rdoActivo.Checked = usuario.Estado;
            rdoInactivo.Checked = !usuario.Estado;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Usuario seleccionado = RegistroSeleccionado();
            if (seleccionado == null)
            {
                Tema.Aviso("Selecciona un usuario de la tabla para eliminar.");
                return;
            }
            DialogResult respuesta = MessageBox.Show(
                "Deseas eliminar el usuario " + seleccionado.CodigoUsuario + "?",
                "Confirmar eliminacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (respuesta != DialogResult.Yes) return;

            try
            {
                int filas = negocio.Eliminar(seleccionado.CodigoUsuario);
                if (filas == 0)
                {
                    Tema.Aviso("El usuario ya no existe o no se pudo eliminar.");
                    return;
                }
                MessageBox.Show("Usuario eliminado.", "Usuarios",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                ActualizarDespuesDeCambio();
            }
            catch (Exception ex)
            {
                Tema.Aviso(ex.Message);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                Usuario usuario = LeerFormulario();
                if (editando)
                {
                    int filas = negocio.Actualizar(usuario);
                    if (filas == 0)
                    {
                        Tema.Aviso("No se encontro el usuario para editar.");
                        return;
                    }
                    MessageBox.Show("Usuario actualizado.", "Usuarios",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    int filas = negocio.Insertar(usuario);
                    if (filas == 0)
                    {
                        Tema.Aviso("No se agrego el usuario.");
                        return;
                    }
                    MessageBox.Show("Usuario agregado.", "Usuarios",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                editando = false;
                LimpiarFormulario();
                ActualizarDespuesDeCambio();
            }
            catch (Exception ex)
            {
                Tema.Aviso("No se pudo guardar el usuario: " + ex.Message);
            }
        }

        private Usuario LeerFormulario()
        {
            int codigo = 0;
            if (editando && !int.TryParse(txtCodigoUsuario.Text, out codigo))
                throw new FormatException("No se pudo leer el codigo del usuario.");
            if (cmbTipoUsuario.SelectedItem == null)
                throw new InvalidOperationException("Selecciona un tipo de usuario.");

            return new Usuario
            {
                CodigoUsuario = codigo,
                CodigoSucursal = CodigoSucursalSeleccionada(),
                NombreUsuario = txtNombreUsuario.Text.Trim(),
                Clave = txtClave.Text,
                FechaCreacion = dtpFechaCreacion.Value,
                TipoUsuario = cmbTipoUsuario.SelectedItem.ToString(),
                Estado = rdoActivo.Checked
            };
        }

        private int CodigoSucursalSeleccionada()
        {
            if (cmbCodigoSucursal.SelectedValue == null)
                throw new InvalidOperationException("Selecciona una sucursal.");
            return Convert.ToInt32(cmbCodigoSucursal.SelectedValue);
        }

        private void ActualizarDespuesDeCambio()
        {
            BuscarUsuarios();
            MostrarTab(0);
        }

        private void LimpiarFormulario()
        {
            txtCodigoUsuario.Clear();
            txtNombreUsuario.Clear();
            txtClave.Clear();
            dtpFechaCreacion.Value = DateTime.Today;
            cmbCodigoSucursal.SelectedIndex = -1;
            cmbTipoUsuario.SelectedIndex = -1;
            rdoActivo.Checked = true;
            rdoInactivo.Checked = false;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            editando = false;
            LimpiarFormulario();
            MostrarTab(0);
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            editando = false;
            LimpiarFormulario();
        }

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
    }
}
