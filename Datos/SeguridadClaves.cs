using System;
using System.Security.Cryptography;

namespace Datos
{
    internal static class SeguridadClaves
    {
        const string Prefijo = "PBKDF2-SHA256";
        const int Iteraciones = 600000;

        internal static string Crear(string clave)
        {
            byte[] sal = new byte[16];
            using (var rng = RandomNumberGenerator.Create()) rng.GetBytes(sal);
            using (var derivador = new Rfc2898DeriveBytes(clave, sal, Iteraciones, HashAlgorithmName.SHA256))
                return Prefijo + "$" + Iteraciones + "$" + Convert.ToBase64String(sal) + "$" + Convert.ToBase64String(derivador.GetBytes(32));
        }

        internal static bool EsHash(string valor) { return (valor ?? "").StartsWith(Prefijo + "$", StringComparison.Ordinal); }

        internal static bool Verificar(string clave, string almacenada)
        {
            // Las cuentas antiguas se convierten después de autenticar correctamente.
            if (!EsHash(almacenada)) return string.Equals(clave, almacenada, StringComparison.Ordinal);
            try
            {
                string[] partes = almacenada.Split('$');
                int iteraciones;
                if (partes.Length != 4 || !int.TryParse(partes[1], out iteraciones) || iteraciones < 100000 || iteraciones > 2000000) return false;
                byte[] sal = Convert.FromBase64String(partes[2]), esperado = Convert.FromBase64String(partes[3]);
                if (sal.Length != 16 || esperado.Length != 32) return false;
                using (var derivador = new Rfc2898DeriveBytes(clave, sal, iteraciones, HashAlgorithmName.SHA256))
                {
                    byte[] actual = derivador.GetBytes(32);
                    int diferencia = 0;
                    for (int i = 0; i < actual.Length; i++) diferencia |= actual[i] ^ esperado[i];
                    return diferencia == 0;
                }
            }
            catch (FormatException) { return false; }
        }
    }
}
