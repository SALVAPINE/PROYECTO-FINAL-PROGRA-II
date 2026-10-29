using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Entidad;

namespace Datos
{
    /// <summary>
    /// Acceso a datos para la tabla dbo.Tbl_RolAccesos en SQL Server.
    /// Permite consultar y configurar los módulos autorizados para cada rol.
    /// Utiliza consultas parametrizadas y control de excepciones try-catch.
    /// </summary>
    public class RolDatos
    {
        /// <summary>
        /// Obtiene los nombres de los módulos autorizados y activos para un tipo de usuario.
        /// </summary>
        public List<string> ListarModulosPermitidos(string tipoUsuario)
        {
            const string sql = @"SELECT NombreModulo
                FROM dbo.Tbl_RolAccesos
                WHERE TipoUsuario = @tipo AND Estado = 1";
            try
            {
                var lista = new List<string>();
                using (SqlConnection conexion = ConexionDatos.CrearConexion())
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add("@tipo", SqlDbType.VarChar, 45).Value = tipoUsuario ?? string.Empty;
                    conexion.Open();
                    using (SqlDataReader lector = comando.ExecuteReader())
                    {
                        while (lector.Read())
                        {
                            lista.Add(Convert.ToString(lector["NombreModulo"]));
                        }
                    }
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudieron consultar los accesos del rol: " + ex.Message, ex);
            }
        }

        /// <summary>
        /// Lista todos los permisos configurados en la tabla dbo.Tbl_RolAccesos para el CRUD.
        /// </summary>
        public List<RolAcceso> Listar()
        {
            const string sql = @"SELECT CodigoRolAcceso, TipoUsuario, NombreModulo, Estado
                FROM dbo.Tbl_RolAccesos
                ORDER BY TipoUsuario, NombreModulo";
            try
            {
                var lista = new List<RolAcceso>();
                using (SqlConnection conexion = ConexionDatos.CrearConexion())
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    conexion.Open();
                    using (SqlDataReader lector = comando.ExecuteReader())
                    {
                        while (lector.Read())
                        {
                            lista.Add(new RolAcceso
                            {
                                CodigoRolAcceso = Convert.ToInt32(lector["CodigoRolAcceso"]),
                                TipoUsuario = Convert.ToString(lector["TipoUsuario"]),
                                NombreModulo = Convert.ToString(lector["NombreModulo"]),
                                Estado = Convert.ToBoolean(lector["Estado"])
                            });
                        }
                    }
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudieron listar los permisos de acceso: " + ex.Message, ex);
            }
        }

        /// <summary>
        /// Registra un nuevo permiso para un rol en dbo.Tbl_RolAccesos.
        /// </summary>
        public int Insertar(RolAcceso acceso)
        {
            const string sql = @"INSERT INTO dbo.Tbl_RolAccesos (TipoUsuario, NombreModulo, Estado)
                VALUES (@tipo, @modulo, @estado)";
            try
            {
                using (SqlConnection conexion = ConexionDatos.CrearConexion())
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add("@tipo", SqlDbType.VarChar, 45).Value = acceso.TipoUsuario ?? string.Empty;
                    comando.Parameters.Add("@modulo", SqlDbType.VarChar, 60).Value = acceso.NombreModulo ?? string.Empty;
                    comando.Parameters.Add("@estado", SqlDbType.Bit).Value = acceso.Estado;
                    conexion.Open();
                    return comando.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo agregar el permiso de acceso: " + ex.Message, ex);
            }
        }

        /// <summary>
        /// Actualiza un permiso existente (por ejemplo, habilitar o deshabilitar acceso).
        /// </summary>
        public int Actualizar(RolAcceso acceso)
        {
            const string sql = @"UPDATE dbo.Tbl_RolAccesos
                SET TipoUsuario = @tipo, NombreModulo = @modulo, Estado = @estado
                WHERE CodigoRolAcceso = @codigo";
            try
            {
                using (SqlConnection conexion = ConexionDatos.CrearConexion())
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add("@codigo", SqlDbType.Int).Value = acceso.CodigoRolAcceso;
                    comando.Parameters.Add("@tipo", SqlDbType.VarChar, 45).Value = acceso.TipoUsuario ?? string.Empty;
                    comando.Parameters.Add("@modulo", SqlDbType.VarChar, 60).Value = acceso.NombreModulo ?? string.Empty;
                    comando.Parameters.Add("@estado", SqlDbType.Bit).Value = acceso.Estado;
                    conexion.Open();
                    return comando.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo actualizar el permiso de acceso: " + ex.Message, ex);
            }
        }

        /// <summary>
        /// Elimina un permiso configurado en dbo.Tbl_RolAccesos.
        /// </summary>
        public int Eliminar(int codigo)
        {
            const string sql = "DELETE FROM dbo.Tbl_RolAccesos WHERE CodigoRolAcceso = @codigo";
            try
            {
                using (SqlConnection conexion = ConexionDatos.CrearConexion())
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add("@codigo", SqlDbType.Int).Value = codigo;
                    conexion.Open();
                    return comando.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo eliminar el permiso de acceso: " + ex.Message, ex);
            }
        }
    }
}
