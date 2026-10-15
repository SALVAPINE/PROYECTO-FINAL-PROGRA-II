using System;
using System.Configuration;
using System.Data.SqlClient;

namespace Datos
{
    /// <summary>
    /// Crea y prueba la conexión a SQL Server. La contraseña se obtiene
    /// de una variable de entorno y no se guarda en archivos del proyecto.
    /// </summary>
    public static class ConexionDatos
    {
        public static SqlConnection CrearConexion()
        {
            string servidor = ConfigurationManager.AppSettings["ServidorSql"];
            string baseDatos = ConfigurationManager.AppSettings["BaseDatosSql"];
            string usuario = ConfigurationManager.AppSettings["UsuarioSql"];
            string nombreVariable = ConfigurationManager.AppSettings["VariableEntornoPasswordSql"];
            string contrasena = Environment.GetEnvironmentVariable(nombreVariable);

            if (string.IsNullOrWhiteSpace(servidor) ||
                string.IsNullOrWhiteSpace(baseDatos) ||
                string.IsNullOrWhiteSpace(usuario))
            {
                throw new InvalidOperationException(
                    "Falta configurar el servidor, la base de datos o el usuario en App.config.");
            }

            if (string.IsNullOrWhiteSpace(contrasena))
            {
                throw new InvalidOperationException(
                    "Falta la contraseña en la variable de entorno " + nombreVariable + ".");
            }

            var constructor = new SqlConnectionStringBuilder
            {
                DataSource = servidor,
                InitialCatalog = baseDatos,
                UserID = usuario,
                Password = contrasena,
                Encrypt = true,
                TrustServerCertificate = true
            };

            return new SqlConnection(constructor.ConnectionString);
        }

        /// <summary>Abre y cierra una conexión para la prueba inicial.</summary>
        public static bool ProbarConexion(out string mensaje)
        {
            try
            {
                using (SqlConnection conexion = CrearConexion())
                {
                    conexion.Open();
                }

                mensaje = "Conexión exitosa con SQL Server y la base de datos configurada.";
                return true;
            }
            catch (SqlException ex)
            {
                mensaje = "No se pudo conectar a SQL Server: " + ex.Message;
                return false;
            }
            catch (Exception ex)
            {
                mensaje = "Error en la configuración de conexión: " + ex.Message;
                return false;
            }
        }
    }
}
