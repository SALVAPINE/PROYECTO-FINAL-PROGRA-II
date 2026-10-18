using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Presentacion
{
    /// <summary>
    /// TabControl que al ejecutar la aplicación NO muestra las pestañas (se cambia de página con SelectedIndex desde los botones de la pantalla).
    /// En el diseñador de Visual Studio se ven las pestañas normales, para poder hacer clic en cada página y editarla.
    /// </summary>
    public class TabControlSinEncabezado : TabControl
    {
        private const int TCM_ADJUSTRECT = 0x1328;

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == TCM_ADJUSTRECT && !DesignMode)
            {
                m.Result = (IntPtr)1;
                return;
            }
            base.WndProc(ref m);
        }
    }
}
