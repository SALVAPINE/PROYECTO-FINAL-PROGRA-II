using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using Entidad;
using Negocio;

namespace Presentacion
{
    public partial class FrmDisenos : Form
    {
        private const int RegistrosPorPagina = 10;
        private readonly DisenoNegocio negocio = new DisenoNegocio();
        private List<Diseno> disenosConsultados = new List<Diseno>();
        private int paginaActual;
        private bool modoAgregar;
        private bool modoEditar;

        public FrmDisenos()
        {
            InitializeComponent();
            Tema.EstilizarGrid(dgvDisenos);

            ToolTip ayuda = new ToolTip();
            ayuda.SetToolTip(btnEditar, "Editar el registro seleccionado");
            ayuda.SetToolTip(btnEliminar, "Eliminar el registro seleccionado");

            // Se usan los controles existentes; los enlaces de paginación se hacen aquí.
            cmbFiltroEstado.SelectedIndex = 0;
            cmbFiltroEstado.SelectedIndexChanged += cmbFiltroEstado_SelectedIndexChanged;
            btnPagAnterior.Click += btnPagAnterior_Click;
            btnPagSiguiente.Click += btnPagSiguiente_Click;

            CargarCatalogos();

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
                ConsultarDisenos();
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

        /// <summary>Carga códigos y descripciones en los dos ComboBox relacionados.</summary>
        private void CargarCatalogos()
        {
            try
            {
                cmbCodigoCliente.DisplayMember = "NombreCliente";
                cmbCodigoCliente.ValueMember = "CodigoCliente";
                cmbCodigoCliente.DataSource = negocio.ListarClientes();
                cmbCodigoCliente.SelectedIndex = -1;

                cmbCodigoDisenador.DisplayMember = "NombreDiseñador";
                cmbCodigoDisenador.ValueMember = "CodigoDiseñador";
                cmbCodigoDisenador.DataSource = negocio.ListarDisenadores();
                cmbCodigoDisenador.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                cmbCodigoCliente.DataSource = null;
                cmbCodigoDisenador.DataSource = null;
                Tema.Aviso("No se pudieron cargar los catálogos de clientes y diseñadores: " + ex.Message);
            }
        }

        // ---------- Botones (pendientes de implementar) ----------
        // Use la capa de negocio (DisenoNegocio) desde estos métodos.

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
            modoAgregar = true;
            modoEditar = false;
            MostrarTab(1);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvDisenos.CurrentRow == null || !(dgvDisenos.CurrentRow.DataBoundItem is Diseno))
            {
                Tema.Aviso("Selecciona un diseño de la lista para editar.");
                return;
            }

            Diseno seleccionado = (Diseno)dgvDisenos.CurrentRow.DataBoundItem;
            txtCodigoDiseno.Text = seleccionado.CodigoDiseño.ToString();
            txtNombreDiseno.Text = seleccionado.NombreDiseño;
            txtTipoDiseno.Text = seleccionado.TipoDiseño;
            txtDescripcion.Text = seleccionado.Descripcion;
            txtRangoDiseno.Text = seleccionado.RangoDiseño;
            dtpFechaCreacion.Value = seleccionado.FechaCreacion;
            rdoActivo.Checked = seleccionado.Estado;
            rdoInactivo.Checked = !seleccionado.Estado;

            try
            {
                // SelectedValue guarda las claves foráneas reales de los ComboBox.
                cmbCodigoCliente.SelectedValue = seleccionado.CodigoCliente;
                cmbCodigoDisenador.SelectedValue = seleccionado.CodigoDiseñador;
            }
            catch (Exception ex)
            {
                Tema.Aviso("No se pudieron seleccionar las relaciones del diseño: " + ex.Message);
                return;
            }

            modoAgregar = false;
            modoEditar = true;
            MostrarTab(1);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvDisenos.CurrentRow == null || !(dgvDisenos.CurrentRow.DataBoundItem is Diseno))
            {
                Tema.Aviso("Selecciona un diseño de la lista para eliminar.");
                return;
            }

            Diseno seleccionado = (Diseno)dgvDisenos.CurrentRow.DataBoundItem;
            DialogResult confirmar = MessageBox.Show(
                "¿Deseas eliminar el diseño con código " + seleccionado.CodigoDiseño + "?",
                "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirmar != DialogResult.Yes)
                return;

            try
            {
                int filasAfectadas = negocio.Eliminar(seleccionado.CodigoDiseño);
                if (filasAfectadas != 1)
                {
                    Tema.Aviso("No se eliminó el diseño. Verifica que el registro siga existiendo.");
                    return;
                }

                ConsultarDisenos();
                ActualizarResumen();
                Tema.Aviso("Diseño eliminado correctamente.");
            }
            catch (Exception ex)
            {
                Tema.Aviso("No se pudo eliminar el diseño: " + ex.Message);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!modoAgregar && !modoEditar)
            {
                Tema.Aviso("Selecciona Nuevo o elige un diseño y pulsa Editar antes de guardar.");
                return;
            }

            int codigoCliente;
            int codigoDisenador;
            if (cmbCodigoCliente.SelectedValue == null ||
                !int.TryParse(Convert.ToString(cmbCodigoCliente.SelectedValue), out codigoCliente))
            {
                Tema.Aviso("Selecciona un cliente válido.");
                return;
            }
            if (cmbCodigoDisenador.SelectedValue == null ||
                !int.TryParse(Convert.ToString(cmbCodigoDisenador.SelectedValue), out codigoDisenador))
            {
                Tema.Aviso("Selecciona un diseñador válido.");
                return;
            }

            Diseno diseno = new Diseno
            {
                CodigoCliente = codigoCliente,
                CodigoDiseñador = codigoDisenador,
                NombreDiseño = txtNombreDiseno.Text.Trim(),
                TipoDiseño = txtTipoDiseno.Text.Trim(),
                Descripcion = txtDescripcion.Text.Trim(),
                RangoDiseño = txtRangoDiseno.Text.Trim(),
                FechaCreacion = dtpFechaCreacion.Value,
                Estado = rdoActivo.Checked
            };

            try
            {
                int filasAfectadas;
                string mensaje;
                if (modoEditar)
                {
                    int codigoDiseno;
                    if (!int.TryParse(txtCodigoDiseno.Text.Trim(), out codigoDiseno))
                    {
                        Tema.Aviso("El código del diseño seleccionado no es válido.");
                        return;
                    }
                    diseno.CodigoDiseño = codigoDiseno;
                    filasAfectadas = negocio.Actualizar(diseno);
                    mensaje = "Diseño actualizado correctamente.";
                }
                else
                {
                    filasAfectadas = negocio.Insertar(diseno);
                    mensaje = "Diseño agregado correctamente.";
                }

                if (filasAfectadas != 1)
                {
                    Tema.Aviso("No se guardó el diseño. SQL Server no confirmó una fila afectada.");
                    return;
                }

                modoAgregar = false;
                modoEditar = false;
                LimpiarCampos();
                MostrarTab(0);
                Tema.Aviso(mensaje);
            }
            catch (Exception ex)
            {
                Tema.Aviso("No se pudo guardar el diseño: " + ex.Message);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
            MostrarTab(0);
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void LimpiarCampos()
        {
            txtCodigoDiseno.Clear();
            txtNombreDiseno.Clear();
            txtTipoDiseno.Clear();
            txtDescripcion.Clear();
            txtRangoDiseno.Clear();
            cmbCodigoCliente.SelectedIndex = -1;
            cmbCodigoDisenador.SelectedIndex = -1;
            dtpFechaCreacion.Value = DateTime.Today;
            rdoActivo.Checked = true;
            rdoInactivo.Checked = false;
        }

        private void csBuscar_EnterPresionado(object sender, EventArgs e)
        {
            ConsultarDisenos();
        }

        private void cmbFiltroEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            ConsultarDisenos();
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
            int totalPaginas = Math.Max(1, (int)Math.Ceiling(disenosConsultados.Count / (double)RegistrosPorPagina));
            if (paginaActual < totalPaginas - 1)
            {
                paginaActual++;
                MostrarPaginaActual();
            }
        }

        /// <summary>Consulta todo el resultado filtrado; no aplica paginación en Datos.</summary>
        private void ConsultarDisenos()
        {
            try
            {
                string texto = (csBuscar.Texto ?? string.Empty).Trim();
                string estado = cmbFiltroEstado.SelectedItem as string;
                disenosConsultados = negocio.Buscar(texto, estado);
                paginaActual = 0;
                MostrarPaginaActual();
            }
            catch (Exception ex)
            {
                disenosConsultados = new List<Diseno>();
                paginaActual = 0;
                MostrarPaginaActual();
                Tema.Aviso("No se pudieron consultar los diseños: " + ex.Message);
            }
        }

        /// <summary>Muestra diez registros como máximo y conserva el total filtrado.</summary>
        private void MostrarPaginaActual()
        {
            int totalResultados = disenosConsultados.Count;
            int totalPaginas = Math.Max(1, (int)Math.Ceiling(totalResultados / (double)RegistrosPorPagina));
            if (paginaActual >= totalPaginas)
                paginaActual = totalPaginas - 1;

            dgvDisenos.DataSource = disenosConsultados
                .Skip(paginaActual * RegistrosPorPagina)
                .Take(RegistrosPorPagina)
                .ToList();

            // El total refleja toda la búsqueda y no cambia al avanzar de página.
            lblTotalRegistros.Text = "Total de resultados: " + totalResultados;
            btnPagina.Text = (paginaActual + 1).ToString();
            btnPagAnterior.Enabled = paginaActual > 0;
            btnPagSiguiente.Enabled = paginaActual < totalPaginas - 1;
        }

        // La tabla (dgvDisenos) no tiene columnas definidas: se generan solas al asignar el DataSource con los datos de la base de datos.
    }
}
