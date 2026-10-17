using System;
using System.Windows.Forms;
using Entidad;

namespace Presentacion
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Usuario usuario;
            using (var login = new CAPAZ.Presentacion.FrmLogin())
            {
                if (login.ShowDialog() != DialogResult.OK) return;
                usuario = login.UsuarioAutenticado;
            }

            Form menu;
            if (usuario.TipoUsuario == "Diseñador") menu = new FrmMenuDisenador(usuario);
            else if (usuario.TipoUsuario == "Operador") menu = new FrmMenuOperador(usuario);
            else menu = new FrmMain(usuario);
            Application.Run(menu);
        }
    }
}
