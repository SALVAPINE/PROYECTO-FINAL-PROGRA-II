using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Entidad;
using Negocio;

namespace Presentacion
{
    public partial class FrmTipoServicio : Form
    {
        private const int RegistrosPorPagina = 10;
        private readonly TipoServicioNegocio negocio = new TipoServicioNegocio();
        private List<TipoServicio> tiposServicioConsultados = new List<TipoServicio>();
        private int paginaActual;
        private bool modoAgregar;
        private bool modoEditar;

        public FrmTipoServicio()
        {
            InitializeComponent();
            Tema.EstilizarGrid(dgvTipoServicio);

            ToolTip ayuda = new ToolTip();
            ayuda.SetToolTip(btnEditar, "Editar el registro seleccionado");
            ayuda.SetToolTip(btnEliminar, "Eliminar el registro seleccionado");

            // Se conectan búsqueda, filtro y paginación sin modificar el diseñador.
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
                ConsultarTiposServicio();
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
        // Use la capa de negocio (TipoServicioNegocio) desde estos métodos.

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarCamposTipoServicio();
            modoAgregar = true;
            modoEditar = false;
            MostrarTab(1);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvTipoServicio.CurrentRow == null || !(dgvTipoServicio.CurrentRow.DataBoundItem is TipoServicio))
            {
                Tema.Aviso("Selecciona un tipo de servicio de la lista para editar.");
                return;
            }

            TipoServicio seleccionado = (TipoServicio)dgvTipoServicio.CurrentRow.DataBoundItem;
            txtCodigoTipoServicio.Text = seleccionado.CodigoTipoServicio.ToString();
            txtNombreServicio.Text = seleccionado.NombreServicio;
            txtCostoServicio.Text = seleccionado.CostoServicio.ToString();
            txtRecargoServicio.Text = seleccionado.RecargoServicio.ToString();
            txtTotalServicio.Text = seleccionado.TotalServicio.ToString();
            txtDescripcion.Text = seleccionado.Descripcion;
            rdoActivo.Checked = seleccionado.Estado;
            rdoInactivo.Checked = !seleccionado.Estado;
            modoAgregar = false;
            modoEditar = true;
            MostrarTab(1);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvTipoServicio.CurrentRow == null || !(dgvTipoServicio.CurrentRow.DataBoundItem is TipoServicio))
            {
                Tema.Aviso("Selecciona un tipo de servicio de la lista para eliminar.");
                return;
            }

            TipoServicio seleccionado = (TipoServicio)dgvTipoServicio.CurrentRow.DataBoundItem;
            DialogResult confirmar = MessageBox.Show(
                "¿Deseas eliminar el tipo de servicio con código " + seleccionado.CodigoTipoServicio + "?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirmar != DialogResult.Yes)
                return;

            try
            {
                int filasAfectadas = negocio.Eliminar(seleccionado.CodigoTipoServicio);
                if (filasAfectadas != 1)
                {
                    Tema.Aviso("No se eliminó el tipo de servicio. Verifica que el registro siga existiendo.");
                    return;
                }

                // El resumen y la búsqueda se vuelven a cargar con todos los resultados.
                MostrarTab(0);
                Tema.Aviso("Tipo de servicio eliminado correctamente.");
            }
            catch (Exception ex)
            {
                Tema.Aviso("No se pudo eliminar el tipo de servicio: " + ex.Message);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!modoAgregar && !modoEditar)
            {
                Tema.Aviso("Selecciona Nuevo para agregar o elige un registro y pulsa Editar.");
                return;
            }

            decimal costo;
            decimal recargo;
            decimal total;
            if (!decimal.TryParse(txtCostoServicio.Text.Trim(), out costo)
                || !decimal.TryParse(txtRecargoServicio.Text.Trim(), out recargo)
                || !decimal.TryParse(txtTotalServicio.Text.Trim(), out total))
            {
                Tema.Aviso("Costo, recargo y total deben ser números decimales válidos.");
                return;
            }

            TipoServicio tipoServicio = new TipoServicio
            {
                NombreServicio = txtNombreServicio.Text.Trim(),
                CostoServicio = costo,
                RecargoServicio = recargo,
                TotalServicio = total,
                Descripcion = txtDescripcion.Text.Trim(),
                Estado = rdoActivo.Checked
            };

            if (modoEditar)
            {
                int codigo;
                if (!int.TryParse(txtCodigoTipoServicio.Text.Trim(), out codigo))
                {
                    Tema.Aviso("El código del tipo de servicio seleccionado no es válido.");
                    return;
                }
                tipoServicio.CodigoTipoServicio = codigo;
            }

            try
            {
                int filasAfectadas = modoEditar
                    ? negocio.Actualizar(tipoServicio)
                    : negocio.Insertar(tipoServicio);

                if (filasAfectadas != 1)
                {
                    Tema.Aviso(modoEditar
                        ? "No se actualizó el tipo de servicio. Verifica que siga existiendo."
                        : "No se agregó el tipo de servicio. SQL Server no confirmó una fila insertada.");
                    return;
                }

                bool fueEdicion = modoEditar;
                modoAgregar = false;
                modoEditar = false;
                LimpiarCamposTipoServicio();
                MostrarTab(0);
                Tema.Aviso(fueEdicion
                    ? "Tipo de servicio actualizado correctamente."
                    : "Tipo de servicio agregado correctamente.");
            }
            catch (Exception ex)
            {
                Tema.Aviso("No se pudo guardar el tipo de servicio: " + ex.Message);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            modoAgregar = false;
            modoEditar = false;
            LimpiarCamposTipoServicio();
            MostrarTab(0);
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            // TODO
        }

        // Limpia los campos para iniciar una captura sin cambiar la consulta actual.
        private void LimpiarCamposTipoServicio()
        {
            txtCodigoTipoServicio.Clear();
            txtNombreServicio.Clear();
            txtCostoServicio.Clear();
            txtRecargoServicio.Clear();
            txtTotalServicio.Clear();
            txtDescripcion.Clear();
            rdoActivo.Checked = true;
            rdoInactivo.Checked = false;
        }

        private void csBuscar_EnterPresionado(object sender, EventArgs e)
        {
            ConsultarTiposServicio();
        }

        private void cmbFiltroEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            ConsultarTiposServicio();
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
            int totalPaginas = Math.Max(1, (int)Math.Ceiling(tiposServicioConsultados.Count / (double)RegistrosPorPagina));
            if (paginaActual < totalPaginas - 1)
            {
                paginaActual++;
                MostrarPaginaActual();
            }
        }

        private void ConsultarTiposServicio()
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

                // Se guarda el resultado completo; solo Presentación lo divide en páginas.
                tiposServicioConsultados = negocio.Buscar(texto, estado);
                paginaActual = 0;
                MostrarPaginaActual();
            }
            catch (Exception ex)
            {
                tiposServicioConsultados = new List<TipoServicio>();
                paginaActual = 0;
                MostrarPaginaActual();
                Tema.Aviso("No se pudieron consultar los tipos de servicio: " + ex.Message);
            }
        }

        private void MostrarPaginaActual()
        {
            int totalResultados = tiposServicioConsultados.Count;
            int totalPaginas = Math.Max(1, (int)Math.Ceiling(totalResultados / (double)RegistrosPorPagina));

            if (paginaActual >= totalPaginas)
                paginaActual = totalPaginas - 1;

            dgvTipoServicio.DataSource = tiposServicioConsultados
                .Skip(paginaActual * RegistrosPorPagina)
                .Take(RegistrosPorPagina)
                .ToList();

            // El total corresponde a los resultados coincidentes, no a la página actual.
            lblTotalRegistros.Text = "Total de resultados: " + totalResultados;
            btnPagina.Text = (paginaActual + 1).ToString();
            btnPagAnterior.Enabled = paginaActual > 0;
            btnPagSiguiente.Enabled = paginaActual < totalPaginas - 1;
        }

        // La cuadrícula genera sus columnas a partir de las propiedades de TipoServicio.
    }
}
