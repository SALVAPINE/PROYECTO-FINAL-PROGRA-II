using System;
using System.Windows.Forms;
using SistemaPublicidad.Formularios;
using Login.Formularios;

namespace SistemaPublicidad
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            bool cerrarSesion;
            do
            {
                using (var login = new FrmLogin())
                {
                    if (login.ShowDialog() != DialogResult.OK)
                        return;

                    using (var principal = new FrmPrincipal(login.UsuarioAutenticado, login.RolAutenticado))
                    {
                        cerrarSesion = false;
                        principal.FormClosed += (s, e) => cerrarSesion = principal.CerrarSesionSolicitado;
                        Application.Run(principal);
                    }
                    Negocio.SesionActual.Cerrar();
                }
            }
            while (cerrarSesion);
        }
    }
}
