using System;
using System.Windows.Forms;
using Entidad;
using Negocio;

namespace Presentacion
{
    public partial class FrmCompras : Form
    {
        private readonly CompraNegocio negocio = new CompraNegocio();

        public FrmCompras()
        {
            InitializeComponent();
            Tema.EstilizarGrid(dgvCompras);
            Tema.EstilizarGrid(dgvDetalleCompra);

            ToolTip ayuda = new ToolTip();
            ayuda.SetToolTip(btnEditar, "Editar el registro seleccionado");
            ayuda.SetToolTip(btnEliminar, "Eliminar el registro seleccionado");

            MostrarTab(0);
        }

        // ---------- Pestañas: 0 = Consultar, 1 = Gestionar, 2 = Resumen ----------
        // Cada página (tpConsultar, tpGestionar, tpResumen) se edita en el diseñador haciendo clic en su pestaña.
        private void MostrarTab(int tab)
        {
            tabModulo.SelectedIndex = tab;
            btnTabConsultar.Seleccionado = (tab == 0);
            btnTabGestionar.Seleccionado = (tab == 1);
            btnTabResumen.Seleccionado = (tab == 2);

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
        // Use la capa de negocio (CompraNegocio) desde estos métodos.

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            MostrarTab(1);
            // TODO: preparar un registro nuevo
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            MostrarTab(1);
            // TODO: cargar el registro seleccionado de la tabla
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            // TODO
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // TODO
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            MostrarTab(0);
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            // TODO
        }

        private void csBuscar_EnterPresionado(object sender, EventArgs e)
        {
            // TODO: buscar con el texto de csBuscar y los filtros
        }

        private void btnAgregarDetalle_Click(object sender, EventArgs e)
        {
            // TODO
        }

        // La tabla (dgvCompras) no tiene columnas definidas: se generan solas al asignar el DataSource con los datos de la base de datos.
    }
}
