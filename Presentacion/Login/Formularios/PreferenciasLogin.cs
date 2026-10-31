using System;
using System.IO;

namespace Login.Formularios
{
    internal static class PreferenciasLogin
    {
        static string Ruta { get { return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "SistemaPublicidad", "usuario-recordado.txt"); } }

        internal static string[] Leer(string ruta = null)
        {
            ruta = ruta ?? Ruta;
            try { return File.Exists(ruta) ? File.ReadAllLines(ruta) : new string[0]; }
            catch (IOException) { return new string[0]; }
            catch (UnauthorizedAccessException) { return new string[0]; }
        }

        internal static bool Guardar(bool recordar, string usuario, string rol, string ruta = null)
        {
            ruta = ruta ?? Ruta;
            try
            {
                if (recordar)
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(ruta));
                    File.WriteAllLines(ruta, new[] { usuario, rol });
                }
                else if (File.Exists(ruta)) File.Delete(ruta);
                return true;
            }
            catch (IOException) { return false; }
            catch (UnauthorizedAccessException) { return false; }
        }
    }
}
