using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Entidad;
using Negocio;

namespace Presentacion
{
    public partial class FrmDisenadores : Form
    {
        private const int REGISTROS_POR_PAGINA = 10;
        private readonly DisenadorNegocio negocio = new DisenadorNegocio();
        private List<Disenador> resultados = new List<Disenador>();
        private int paginaActual;
        private int codigoEdicion;

        public FrmDisenadores()
        {
            InitializeComponent();
            Tema.EstilizarGrid(dgvDisenadores);

            // Se enlazan los controles existentes sin modificar el diseñador.
            btnPagAnterior.Click += btnPagAnterior_Click;
            btnPagSiguiente.Click += btnPagSiguiente_Click;
            cmbFiltroEstado.SelectedIndexChanged += cmbFiltroEstado_SelectedIndexChanged;
            // El control ya notifica cada cambio: buscar al escribir, pegar o borrar.
            csBuscar.TextoCambiado += csBuscar_TextoCambiado;
            LimpiarFormulario();
            HabilitarEdicion(false);
            CargarDisenadores();
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
            // Consultar vuelve a leer SQL Server y comienza en la primera página.
            // Se mantienen el texto de búsqueda y el filtro seleccionados.
            CargarDisenadores();
            MostrarTab(0);
        }
        private void btnTabGestionar_Click(object sender, EventArgs e) { MostrarTab(1); }
        private void btnTabResumen_Click(object sender, EventArgs e) { MostrarTab(2); }

        private void ActualizarResumen()
        {
            try
            {
                // El resumen usa TODOS los registros, nunca las filas de la página.
                ResumenModulo resumen = negocio.ObtenerResumen();
                Resumenes.Aplicar(resumen, statTotal, statEstado1, statEstado2,
                    statExtra, graEstado, graCategoria);
            }
            catch (Exception ex) { Tema.Aviso("No se pudo cargar el resumen: " + ex.Message); }
        }

        private void CargarDisenadores(bool reiniciarPagina = true)
        {
            try
            {
                string estado = Convert.ToString(cmbFiltroEstado.SelectedItem);
                resultados = negocio.Buscar(csBuscar.Texto, estado);
                if (reiniciarPagina) paginaActual = 0;
                MostrarPagina();
            }
            catch (Exception ex) { Tema.Aviso("No se pudo cargar el listado: " + ex.Message); }
        }

        private void MostrarPagina()
        {
            int paginas = Math.Max(1, (int)Math.Ceiling(resultados.Count / (double)REGISTROS_POR_PAGINA));
            paginaActual = Math.Max(0, Math.Min(paginaActual, paginas - 1));
            dgvDisenadores.DataSource = null;
            dgvDisenadores.DataSource = resultados
                .Skip(paginaActual * REGISTROS_POR_PAGINA)
                .Take(REGISTROS_POR_PAGINA).ToList();
            btnPagina.Text = (paginaActual + 1).ToString();
            btnPagAnterior.Enabled = paginaActual > 0;
            btnPagSiguiente.Enabled = paginaActual < paginas - 1;
            // Este total no cambia al navegar entre páginas.
            lblTotalRegistros.Text = "Total de resultados: " + resultados.Count;
        }

        private void btnPagAnterior_Click(object sender, EventArgs e)
        {
            if (paginaActual > 0) { paginaActual--; MostrarPagina(); }
        }

        private void btnPagSiguiente_Click(object sender, EventArgs e)
        {
            if ((paginaActual + 1) * REGISTROS_POR_PAGINA < resultados.Count)
            { paginaActual++; MostrarPagina(); }
        }

        private void cmbFiltroEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarDisenadores();
        }

        private void csBuscar_EnterPresionado(object sender, EventArgs e)
        {
            CargarDisenadores();
        }

        private void csBuscar_TextoCambiado(object sender, EventArgs e)
        {
            // Reutiliza la consulta parametrizada y regresa a la primera página.
            CargarDisenadores();
        }

        private void HabilitarEdicion(bool habilitar)
        {
            txtNombreDisenador.Enabled = habilitar;
            txtEdad.Enabled = habilitar;
            txtEspecialidad.Enabled = habilitar;
            txtTelefono.Enabled = habilitar;
            txtCorreo.Enabled = habilitar;
            rdoActivo.Enabled = habilitar;
            rdoInactivo.Enabled = habilitar;
            btnGuardar.Enabled = habilitar;
            btnLimpiar.Enabled = habilitar;
            btnNuevo.Enabled = !habilitar;
            btnEditar.Enabled = !habilitar;
            btnEliminar.Enabled = !habilitar;
        }

        private void LimpiarFormulario()
        {
            txtCodigoDisenador.Clear();
            txtNombreDisenador.Clear();
            txtEdad.Clear();
            txtEspecialidad.Clear();
            txtTelefono.Clear();
            txtCorreo.Clear();
            rdoActivo.Checked = true;
            rdoInactivo.Checked = false;
        }

        private Disenador Seleccionado()
        {
            return dgvDisenadores.CurrentRow == null ? null :
                dgvDisenadores.CurrentRow.DataBoundItem as Disenador;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            codigoEdicion = 0;
            LimpiarFormulario();
            HabilitarEdicion(true);
            MostrarTab(1);
            txtNombreDisenador.Focus();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            Disenador seleccionado = Seleccionado();
            if (seleccionado == null) { Tema.Aviso("Selecciona un diseñador para editar."); return; }
            // Guardar usará esta PK de la fila seleccionada, no un código escrito por el usuario.
            codigoEdicion = seleccionado.CodigoDiseñador;
            txtCodigoDisenador.Text = codigoEdicion.ToString();
            txtNombreDisenador.Text = seleccionado.NombreDiseñador;
            txtEdad.Text = seleccionado.Edad.ToString();
            txtEspecialidad.Text = seleccionado.Especialidad;
            txtTelefono.Text = seleccionado.Telefono.ToString();
            txtCorreo.Text = seleccionado.Correo;
            rdoActivo.Checked = seleccionado.Estado;
            rdoInactivo.Checked = !seleccionado.Estado;
            HabilitarEdicion(true);
            MostrarTab(1);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            int edad, telefono;
            if (!int.TryParse(txtEdad.Text.Trim(), out edad) ||
                !int.TryParse(txtTelefono.Text.Trim(), out telefono))
            { Tema.Aviso("Edad y teléfono deben ser enteros válidos dentro del rango int."); return; }

            Disenador disenador = new Disenador
            {
                CodigoDiseñador = codigoEdicion,
                NombreDiseñador = txtNombreDisenador.Text.Trim(),
                Edad = edad,
                Especialidad = txtEspecialidad.Text.Trim(),
                Telefono = telefono,
                Correo = txtCorreo.Text.Trim(),
                Estado = rdoActivo.Checked
            };
            try
            {
                // Nuevo usa IDENTITY; conservar el modo para confirmar el alta al terminar.
                bool agregando = codigoEdicion == 0;
                int filas = agregando ?
                    negocio.Insertar(disenador) : negocio.Actualizar(disenador);
                if (filas == 0) { Tema.Aviso("No se guardó el registro; puede haber sido eliminado."); return; }
                codigoEdicion = 0;
                LimpiarFormulario();
                HabilitarEdicion(false);
                CargarDisenadores(false);
                MostrarTab(0);
                Tema.Aviso(agregando ? "Diseñador agregado correctamente." : "Diseñador actualizado correctamente.");
            }
            catch (Exception ex) { Tema.Aviso("No se pudo guardar: " + ex.Message); }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Disenador seleccionado = Seleccionado();
            if (seleccionado == null) { Tema.Aviso("Selecciona un diseñador para eliminar."); return; }
            // Confirmar también la PK evita confundir registros con el mismo nombre.
            if (MessageBox.Show("¿Eliminar al diseñador " + seleccionado.NombreDiseñador +
                " (código " + seleccionado.CodigoDiseñador + ")? Esta acción no se puede deshacer.",
                "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                return;
            try
            {
                int filas = negocio.Eliminar(seleccionado.CodigoDiseñador);
                if (filas == 0) { Tema.Aviso("El registro ya no existe."); return; }
                codigoEdicion = 0;
                LimpiarFormulario();
                HabilitarEdicion(false);
                CargarDisenadores(false);
                ActualizarResumen();
                Tema.Aviso("Diseñador eliminado correctamente.");
            }
            catch (Exception ex) { Tema.Aviso(ex.Message); }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            codigoEdicion = 0;
            LimpiarFormulario();
            HabilitarEdicion(false);
            MostrarTab(0);
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            // En edición se conserva la PK; limpiar no convierte la operación en alta.
            LimpiarFormulario();
            if (codigoEdicion > 0) txtCodigoDisenador.Text = codigoEdicion.ToString();
            txtNombreDisenador.Focus();
        }
    }
}
