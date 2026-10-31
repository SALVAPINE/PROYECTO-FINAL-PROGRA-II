using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Entidad;

namespace Datos
{
    /// <summary>Acceso parametrizado a SQL Server para usuarios y sucursales.</summary>
    public class UsuarioDatos
    {
        public List<Usuario> Listar() { return Consultar(string.Empty, "Todos", "Todos"); }

        /// <summary>Valida por parámetros un usuario activo.</summary>
        public Usuario Autenticar(string nombreUsuario, string clave)
        {
            const string sql = @"SELECT CodigoUsuario, CodigoSucursal, NombreUsuario,
                    Clave, FechaCreacion, TipoUsuario, Estado
                FROM dbo.Tbl_Usuarios
                WHERE NombreUsuario = @usuario AND Estado = 1";
            try
            {
                using (SqlConnection conexion = ConexionDatos.CrearConexion())
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add("@usuario", SqlDbType.VarChar, 45).Value = nombreUsuario;
                    conexion.Open();
                    Usuario cuenta = null;
                    using (SqlDataReader lector = comando.ExecuteReader())
                    {
                        if (lector.Read()) cuenta = MapearUsuario(lector);
                        if (lector.Read()) throw new InvalidOperationException("Hay nombres de usuario duplicados; consulta al administrador.");
                    }
                    if (cuenta == null || !SeguridadClaves.Verificar(clave, cuenta.Clave)) return null;
                    if (!SeguridadClaves.EsHash(cuenta.Clave))
                    {
                        using (var migrar = new SqlCommand("UPDATE dbo.Tbl_Usuarios SET Clave = @hash WHERE CodigoUsuario = @codigo AND Clave = @anterior", conexion))
                        {
                            migrar.Parameters.Add("@hash", SqlDbType.VarChar, 255).Value = SeguridadClaves.Crear(clave);
                            migrar.Parameters.Add("@codigo", SqlDbType.Int).Value = cuenta.CodigoUsuario;
                            migrar.Parameters.Add("@anterior", SqlDbType.VarChar, 255).Value = cuenta.Clave;
                            if (migrar.ExecuteNonQuery() != 1) return null;
                        }
                    }
                    cuenta.Clave = string.Empty;
                    return cuenta;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo validar el usuario: " + ex.Message, ex);
            }
        }

        public List<Usuario> Buscar(string texto, string tipo, string estado)
        {
            return Consultar(texto, tipo, estado);
        }

        private List<Usuario> Consultar(string texto, string tipo, string estado)
        {
            const string sql = @"SELECT CodigoUsuario, CodigoSucursal, NombreUsuario,
                    CAST('' AS varchar(255)) AS Clave, FechaCreacion, TipoUsuario, Estado
                FROM dbo.Tbl_Usuarios
                WHERE (@texto = '' OR
                    CONVERT(varchar(20), CodigoUsuario) LIKE @patron OR
                    NombreUsuario LIKE @patron OR
                    TipoUsuario LIKE @patron OR
                    CONVERT(varchar(23), FechaCreacion, 121) LIKE @patron)
                  AND (@tipo IS NULL OR TipoUsuario = @tipo)
                  AND (@estado IS NULL OR Estado = @estado)
                ORDER BY CodigoUsuario";
            try
            {
                List<Usuario> lista = new List<Usuario>();
                string termino = (texto ?? string.Empty).Trim();
                using (SqlConnection conexion = ConexionDatos.CrearConexion())
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add("@texto", SqlDbType.VarChar, 1000).Value = termino;
                    comando.Parameters.Add("@patron", SqlDbType.VarChar, 1002).Value = "%" + termino + "%";
                    SqlParameter parametroTipo = comando.Parameters.Add("@tipo", SqlDbType.VarChar, 45);
                    parametroTipo.Value = string.IsNullOrWhiteSpace(tipo) || tipo == "Todos"
                        ? (object)DBNull.Value : tipo;
                    SqlParameter parametroEstado = comando.Parameters.Add("@estado", SqlDbType.Bit);
                    if (estado == "Activo") parametroEstado.Value = true;
                    else if (estado == "Inactivo") parametroEstado.Value = false;
                    else parametroEstado.Value = DBNull.Value;

                    conexion.Open();
                    using (SqlDataReader lector = comando.ExecuteReader())
                        while (lector.Read()) lista.Add(MapearUsuario(lector));
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudieron consultar los usuarios: " + ex.Message, ex);
            }
        }

        private Usuario MapearUsuario(SqlDataReader lector)
        {
            return new Usuario
            {
                CodigoUsuario = Convert.ToInt32(lector["CodigoUsuario"]),
                CodigoSucursal = Convert.ToInt32(lector["CodigoSucursal"]),
                NombreUsuario = Convert.ToString(lector["NombreUsuario"]),
                Clave = Convert.ToString(lector["Clave"]),
                FechaCreacion = Convert.ToDateTime(lector["FechaCreacion"]),
                TipoUsuario = Convert.ToString(lector["TipoUsuario"]),
                Estado = Convert.ToBoolean(lector["Estado"])
            };
        }

        public List<Sucursal> ListarSucursales()
        {
            const string sql = "SELECT CodigoSucursal, NombreSucursal FROM dbo.Tbl_Sucursales ORDER BY NombreSucursal";
            try
            {
                List<Sucursal> lista = new List<Sucursal>();
                using (SqlConnection conexion = ConexionDatos.CrearConexion())
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    conexion.Open();
                    using (SqlDataReader lector = comando.ExecuteReader())
                    {
                        while (lector.Read())
                            lista.Add(new Sucursal
                            {
                                CodigoSucursal = Convert.ToInt32(lector["CodigoSucursal"]),
                                NombreSucursal = Convert.ToString(lector["NombreSucursal"])
                            });
                    }
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo cargar el catalogo de sucursales: " + ex.Message, ex);
            }
        }

        public int Insertar(Usuario usuario)
        {
            // CodigoUsuario es IDENTITY; SQL Server genera el codigo.
            const string sql = @"INSERT INTO dbo.Tbl_Usuarios
                (CodigoSucursal, NombreUsuario, Clave, FechaCreacion, TipoUsuario, Estado)
                VALUES (@sucursal, @nombre, @clave, @fecha, @tipo, @estado)";
            try
            {
                using (SqlConnection conexion = ConexionDatos.CrearConexion())
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    AgregarParametros(comando, usuario);
                    conexion.Open();
                    return comando.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo agregar el usuario: " + ex.Message, ex);
            }
        }

        public int Actualizar(Usuario usuario)
        {
            const string sql = @"UPDATE dbo.Tbl_Usuarios
                SET CodigoSucursal = @sucursal, NombreUsuario = @nombre,
                    Clave = CASE WHEN @clave = '' THEN Clave ELSE @clave END, FechaCreacion = @fecha,
                    TipoUsuario = @tipo, Estado = @estado
                WHERE CodigoUsuario = @codigo";
            try
            {
                using (SqlConnection conexion = ConexionDatos.CrearConexion())
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    AgregarParametros(comando, usuario);
                    comando.Parameters.Add("@codigo", SqlDbType.Int).Value = usuario.CodigoUsuario;
                    conexion.Open();
                    return comando.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo editar el usuario: " + ex.Message, ex);
            }
        }

        private void AgregarParametros(SqlCommand comando, Usuario usuario)
        {
            comando.Parameters.Add("@sucursal", SqlDbType.Int).Value = usuario.CodigoSucursal;
            comando.Parameters.Add("@nombre", SqlDbType.VarChar, 45).Value = usuario.NombreUsuario;
            comando.Parameters.Add("@clave", SqlDbType.VarChar, 255).Value = string.IsNullOrEmpty(usuario.Clave)
                ? string.Empty : SeguridadClaves.Crear(usuario.Clave);
            comando.Parameters.Add("@fecha", SqlDbType.DateTime).Value = usuario.FechaCreacion;
            comando.Parameters.Add("@tipo", SqlDbType.VarChar, 45).Value = usuario.TipoUsuario;
            comando.Parameters.Add("@estado", SqlDbType.Bit).Value = usuario.Estado;
        }

        public int Eliminar(int codigo)
        {
            const string sql = "DELETE FROM dbo.Tbl_Usuarios WHERE CodigoUsuario = @codigo";
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
                throw new Exception("No se pudo eliminar el usuario: " + ex.Message, ex);
            }
        }
    }
}
