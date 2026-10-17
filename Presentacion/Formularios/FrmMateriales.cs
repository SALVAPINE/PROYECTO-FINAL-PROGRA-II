using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Entidad;
using Negocio;

namespace Presentacion
{
    public partial class FrmMateriales : Form
    {
        private const int RegistrosPorPagina = 10;
        private readonly MaterialNegocio negocio = new MaterialNegocio();
        private List<Material> materialesConsultados = new List<Material>();
        private int paginaActual;
        private bool modoAgregar;
        private bool modoEditar;

        public FrmMateriales()
        {
            InitializeComponent();
            Tema.EstilizarGrid(dgvMateriales);

            ToolTip ayuda = new ToolTip();
            ayuda.SetToolTip(btnEditar, "Editar el registro seleccionado");
            ayuda.SetToolTip(btnEliminar, "Eliminar el registro seleccionado");

            // Se conectan los controles existentes sin editar el archivo Designer.
            cmbFiltroEstado.SelectedIndex = 0;
            cmbFiltroEstado.SelectedIndexChanged += cmbFiltroEstado_SelectedIndexChanged;
            btnPagAnterior.Click += btnPagAnterior_Click;
            btnPagSiguiente.Click += btnPagSiguiente_Click;

            CargarOrdenesTrabajo();
            MostrarTab(0);
        }

        // ---------- Pestañas: 0 = Consultar, 1 = Gestionar, 2 = Resumen ----------
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
                ConsultarMateriales();
            if (tab != 1)
                ActualizarResumen();
        }

        private void btnTabConsultar_Click(object sender, EventArgs e) { MostrarTab(0); }
        private void btnTabGestionar_Click(object sender, EventArgs e) { MostrarTab(1); }
        private void btnTabResumen_Click(object sender, EventArgs e) { MostrarTab(2); }

        /// <summary>Carga órdenes para mostrar su descripción y conservar su código.</summary>
        private void CargarOrdenesTrabajo()
        {
            try
            {
                cmbCodigoOrdenTrabajo.DataSource = negocio.ListarOrdenesTrabajo();
                cmbCodigoOrdenTrabajo.DisplayMember = "NombreOrdenTrabajo";
                cmbCodigoOrdenTrabajo.ValueMember = "CodigoOrdenTrabajo";
                cmbCodigoOrdenTrabajo.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                cmbCodigoOrdenTrabajo.DataSource = null;
                Tema.Aviso("No se pudo cargar el catálogo de órdenes de trabajo: " + ex.Message);
            }
        }

        /// <summary>Actualiza las tarjetas y gráficos con datos completos del módulo.</summary>
        private void ActualizarResumen()
        {
            ResumenModulo resumen;
            try
            {
                resumen = negocio.ObtenerResumen();
            }
            catch (Exception ex)
            {
                Tema.Aviso("No se pudo cargar el resumen de materiales: " + ex.Message);
                return;
            }

            Resumenes.Aplicar(resumen, statTotal, statEstado1, statEstado2, statExtra, graEstado, graCategoria);
        }

        // Los eventos operan solo sobre Materiales; las demás entidades no se modifican.
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
            modoAgregar = true;
            modoEditar = false;
            MostrarTab(1);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvMateriales.CurrentRow == null || !(dgvMateriales.CurrentRow.DataBoundItem is Material))
            {
                Tema.Aviso("Selecciona un material de la lista para editar.");
                return;
            }

            Material seleccionado = (Material)dgvMateriales.CurrentRow.DataBoundItem;
            txtCodigoMaterial.Text = seleccionado.CodigoMaterial.ToString();
            txtNombreMaterial.Text = seleccionado.NombreMaterial;
            txtTipoDeMaterial.Text = seleccionado.TipoDeMaterial;
            txtUnidadMedida.Text = seleccionado.UnidadMedida;
            txtCategoriaMaterial.Text = seleccionado.CategoriaMaterial;
            txtCostoMaterial.Text = seleccionado.CostoMaterial.ToString("0.00");
            rdoActivo.Checked = seleccionado.Estado;
            rdoInactivo.Checked = !seleccionado.Estado;

            try
            {
                // SelectedValue conserva la FK real aunque el ComboBox muestre el nombre.
                cmbCodigoOrdenTrabajo.SelectedValue = seleccionado.CodigoOrdenTrabajo;
            }
            catch (Exception ex)
            {
                Tema.Aviso("No se pudo seleccionar la orden de trabajo del material: " + ex.Message);
                return;
            }

            modoAgregar = false;
            modoEditar = true;
            MostrarTab(1);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvMateriales.CurrentRow == null || !(dgvMateriales.CurrentRow.DataBoundItem is Material))
            {
                Tema.Aviso("Selecciona un material de la lista para eliminar.");
                return;
            }

            Material seleccionado = (Material)dgvMateriales.CurrentRow.DataBoundItem;
            DialogResult confirmar = MessageBox.Show(
                "¿Deseas eliminar el material con código " + seleccionado.CodigoMaterial + "?",
                "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirmar != DialogResult.Yes)
                return;

            try
            {
                int filasAfectadas = negocio.Eliminar(seleccionado.CodigoMaterial);
                if (filasAfectadas != 1)
                {
                    Tema.Aviso("No se eliminó el material. Verifica que el registro siga existiendo.");
                    return;
                }

                ConsultarMateriales();
                ActualizarResumen();
                Tema.Aviso("Material eliminado correctamente.");
            }
            catch (Exception ex)
            {
                Tema.Aviso("No se pudo eliminar el material. Puede estar relacionado con compras o inventarios. Detalle: " + ex.Message);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!modoAgregar && !modoEditar)
            {
                Tema.Aviso("Selecciona Nuevo o elige un material y pulsa Editar antes de guardar.");
                return;
            }

            int codigoOrdenTrabajo;
            if (cmbCodigoOrdenTrabajo.SelectedValue == null ||
                !int.TryParse(Convert.ToString(cmbCodigoOrdenTrabajo.SelectedValue), out codigoOrdenTrabajo))
            {
                Tema.Aviso("Selecciona una orden de trabajo válida.");
                return;
            }

            decimal costo;
            if (!decimal.TryParse(txtCostoMaterial.Text.Trim(), out costo))
            {
                Tema.Aviso("El costo debe ser un número decimal válido.");
                return;
            }

            Material material = new Material
            {
                CodigoOrdenTrabajo = codigoOrdenTrabajo,
                NombreMaterial = txtNombreMaterial.Text.Trim(),
                TipoDeMaterial = txtTipoDeMaterial.Text.Trim(),
                UnidadMedida = txtUnidadMedida.Text.Trim(),
                CategoriaMaterial = txtCategoriaMaterial.Text.Trim(),
                CostoMaterial = costo,
                Estado = rdoActivo.Checked
            };

            try
            {
                int filasAfectadas;
                string mensaje;
                if (modoEditar)
                {
                    int codigoMaterial;
                    if (!int.TryParse(txtCodigoMaterial.Text.Trim(), out codigoMaterial))
                    {
                        Tema.Aviso("El código del material seleccionado no es válido.");
                        return;
                    }
                    material.CodigoMaterial = codigoMaterial;
                    filasAfectadas = negocio.Actualizar(material);
                    mensaje = "Material actualizado correctamente.";
                }
                else
                {
                    filasAfectadas = negocio.Insertar(material);
                    mensaje = "Material agregado correctamente.";
                }

                if (filasAfectadas != 1)
                {
                    Tema.Aviso("No se guardó el material. SQL Server no confirmó una fila afectada.");
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
                Tema.Aviso("No se pudo guardar el material: " + ex.Message);
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
            txtCodigoMaterial.Clear();
            txtNombreMaterial.Clear();
            txtTipoDeMaterial.Clear();
            txtUnidadMedida.Clear();
            txtCategoriaMaterial.Clear();
            txtCostoMaterial.Clear();
            cmbCodigoOrdenTrabajo.SelectedIndex = -1;
            rdoActivo.Checked = true;
            rdoInactivo.Checked = false;
        }

        private void csBuscar_EnterPresionado(object sender, EventArgs e)
        {
            ConsultarMateriales();
        }

        private void cmbFiltroEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            ConsultarMateriales();
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
            int totalPaginas = Math.Max(1, (int)Math.Ceiling(materialesConsultados.Count / (double)RegistrosPorPagina));
            if (paginaActual < totalPaginas - 1)
            {
                paginaActual++;
                MostrarPaginaActual();
            }
        }

        /// <summary>Obtiene todas las coincidencias; la paginación se deja a Presentación.</summary>
        private void ConsultarMateriales()
        {
            try
            {
                string texto = (csBuscar.Texto ?? string.Empty).Trim();
                string estado = cmbFiltroEstado.SelectedItem as string;

                // Se conserva la lista completa para paginar y calcular el total correcto.
                materialesConsultados = negocio.Buscar(texto, estado);
                paginaActual = 0;
                MostrarPaginaActual();
            }
            catch (Exception ex)
            {
                materialesConsultados = new List<Material>();
                paginaActual = 0;
                MostrarPaginaActual();
                Tema.Aviso("No se pudieron consultar los materiales: " + ex.Message);
            }
        }

        /// <summary>Muestra hasta diez filas sin alterar el total de resultados filtrados.</summary>
        private void MostrarPaginaActual()
        {
            int totalResultados = materialesConsultados.Count;
            int totalPaginas = Math.Max(1, (int)Math.Ceiling(totalResultados / (double)RegistrosPorPagina));

            if (paginaActual >= totalPaginas)
                paginaActual = totalPaginas - 1;

            dgvMateriales.DataSource = materialesConsultados
                .Skip(paginaActual * RegistrosPorPagina)
                .Take(RegistrosPorPagina)
                .ToList();

            // El total refleja todos los resultados, no solo los de la página visible.
            lblTotalRegistros.Text = "Total de resultados: " + totalResultados;
            btnPagina.Text = (paginaActual + 1).ToString();
            btnPagAnterior.Enabled = paginaActual > 0;
            btnPagSiguiente.Enabled = paginaActual < totalPaginas - 1;
        }
    }
}
