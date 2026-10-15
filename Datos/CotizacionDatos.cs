using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Entidad;

namespace Datos
{
    /// <summary>Acceso a SQL Server para las cotizaciones y sus catalogos.</summary>
    public class CotizacionDatos
    {
        // Listar usa la misma consulta que Buscar, sin texto ni filtro de estado.
        public List<Cotizacion> Listar()
        {
            return Consultar(string.Empty, "Todos");
        }

        public List<Cotizacion> Buscar(string texto, string estado)
        {
            return Consultar(texto, estado);
        }

        private List<Cotizacion> Consultar(string texto, string estado)
        {
            const string sql = @"SELECT c.CodigoCotizacion, c.CodigoTipoServicio,
                    c.CodigoSucursal, c.CodigoCliente, c.NombreCotizador, c.NIT,
                    c.DireccionCotizador, c.FechaEmision, c.Descripcion, c.Cantidad,
                    c.Precio, c.Subtotal, c.Total, c.Estado
                FROM dbo.Tbl_Cotizaciones AS c
                WHERE (@texto = '' OR
                    CONVERT(varchar(20), c.CodigoCotizacion) LIKE @patron OR
                    c.NombreCotizador LIKE @patron OR
                    CONVERT(varchar(20), c.NIT) LIKE @patron OR
                    c.Descripcion LIKE @patron)
                  AND (@estado IS NULL OR c.Estado = @estado)
                ORDER BY c.CodigoCotizacion";

            try
            {
                List<Cotizacion> cotizaciones = new List<Cotizacion>();
                string termino = (texto ?? string.Empty).Trim();

                using (SqlConnection conexion = ConexionDatos.CrearConexion())
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add("@texto", SqlDbType.VarChar, 1000).Value = termino;
                    comando.Parameters.Add("@patron", SqlDbType.VarChar, 1002).Value = "%" + termino + "%";

                    SqlParameter parametroEstado = comando.Parameters.Add("@estado", SqlDbType.Bit);
                    if (estado == "Activo")
                        parametroEstado.Value = true;
                    else if (estado == "Inactivo")
                        parametroEstado.Value = false;
                    else
                        parametroEstado.Value = DBNull.Value;

                    conexion.Open();
                    using (SqlDataReader lector = comando.ExecuteReader())
                    {
                        while (lector.Read())
                            cotizaciones.Add(MapearCotizacion(lector));
                    }
                }

                return cotizaciones;
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudieron consultar las cotizaciones: " + ex.Message, ex);
            }
        }

        private Cotizacion MapearCotizacion(SqlDataReader lector)
        {
            return new Cotizacion
            {
                CodigoCotizacion = Convert.ToInt32(lector["CodigoCotizacion"]),
                CodigoTipoServicio = Convert.ToInt32(lector["CodigoTipoServicio"]),
                CodigoSucursal = Convert.ToInt32(lector["CodigoSucursal"]),
                CodigoCliente = Convert.ToInt32(lector["CodigoCliente"]),
                NombreCotizador = Convert.ToString(lector["NombreCotizador"]),
                NIT = lector["NIT"] == DBNull.Value
                    ? (int?)null
                    : Convert.ToInt32(lector["NIT"]),
                DireccionCotizador = Convert.ToString(lector["DireccionCotizador"]),
                FechaEmision = Convert.ToDateTime(lector["FechaEmision"]),
                Descripcion = Convert.ToString(lector["Descripcion"]),
                Cantidad = Convert.ToInt32(lector["Cantidad"]),
                Precio = Convert.ToDecimal(lector["Precio"]),
                Subtotal = Convert.ToDecimal(lector["Subtotal"]),
                Total = Convert.ToDecimal(lector["Total"]),
                Estado = Convert.ToBoolean(lector["Estado"])
            };
        }

        public List<Cliente> ListarClientes()
        {
            const string sql = @"SELECT CodigoCliente, NombreCliente
                FROM dbo.Tbl_Clientes ORDER BY NombreCliente";
            try
            {
                List<Cliente> lista = new List<Cliente>();
                using (SqlConnection conexion = ConexionDatos.CrearConexion())
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    conexion.Open();
                    using (SqlDataReader lector = comando.ExecuteReader())
                        while (lector.Read())
                            lista.Add(new Cliente
                            {
                                CodigoCliente = Convert.ToInt32(lector["CodigoCliente"]),
                                NombreCliente = Convert.ToString(lector["NombreCliente"])
                            });
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo cargar el catalogo de clientes: " + ex.Message, ex);
            }
        }

        public List<Sucursal> ListarSucursales()
        {
            const string sql = @"SELECT CodigoSucursal, NombreSucursal
                FROM dbo.Tbl_Sucursales ORDER BY NombreSucursal";
            try
            {
                List<Sucursal> lista = new List<Sucursal>();
                using (SqlConnection conexion = ConexionDatos.CrearConexion())
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    conexion.Open();
                    using (SqlDataReader lector = comando.ExecuteReader())
                        while (lector.Read())
                            lista.Add(new Sucursal
                            {
                                CodigoSucursal = Convert.ToInt32(lector["CodigoSucursal"]),
                                NombreSucursal = Convert.ToString(lector["NombreSucursal"])
                            });
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo cargar el catalogo de sucursales: " + ex.Message, ex);
            }
        }

        public List<TipoServicio> ListarTiposServicio()
        {
            const string sql = @"SELECT CodigoTipoServicio, NombreServicio
                FROM dbo.Tbl_TipoDeServicio ORDER BY NombreServicio";
            try
            {
                List<TipoServicio> lista = new List<TipoServicio>();
                using (SqlConnection conexion = ConexionDatos.CrearConexion())
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    conexion.Open();
                    using (SqlDataReader lector = comando.ExecuteReader())
                        while (lector.Read())
                            lista.Add(new TipoServicio
                            {
                                CodigoTipoServicio = Convert.ToInt32(lector["CodigoTipoServicio"]),
                                NombreServicio = Convert.ToString(lector["NombreServicio"])
                            });
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo cargar el catalogo de tipos de servicio: " + ex.Message, ex);
            }
        }

        public int Insertar(Cotizacion cotizacion)
        {
            const string sql = @"INSERT INTO dbo.Tbl_Cotizaciones
                (CodigoTipoServicio, CodigoSucursal, CodigoCliente, NombreCotizador, NIT,
                 DireccionCotizador, FechaEmision, Descripcion, Cantidad, Precio, Subtotal, Total, Estado)
                VALUES (@tipo, @sucursal, @cliente, @nombre, @nit, @direccion, @fecha,
                        @descripcion, @cantidad, @precio, @subtotal, @total, @estado)";
            try
            {
                using (SqlConnection conexion = ConexionDatos.CrearConexion())
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    AgregarParametros(comando, cotizacion);
                    conexion.Open();
                    return comando.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo agregar la cotizacion: " + ex.Message, ex);
            }
        }

        public int Actualizar(Cotizacion cotizacion)
        {
            const string sql = @"UPDATE dbo.Tbl_Cotizaciones
                SET CodigoTipoServicio = @tipo, CodigoSucursal = @sucursal,
                    CodigoCliente = @cliente, NombreCotizador = @nombre, NIT = @nit,
                    DireccionCotizador = @direccion, FechaEmision = @fecha,
                    Descripcion = @descripcion, Cantidad = @cantidad, Precio = @precio,
                    Subtotal = @subtotal, Total = @total, Estado = @estado
                WHERE CodigoCotizacion = @codigo";
            try
            {
                using (SqlConnection conexion = ConexionDatos.CrearConexion())
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    AgregarParametros(comando, cotizacion);
                    comando.Parameters.Add("@codigo", SqlDbType.Int).Value = cotizacion.CodigoCotizacion;
                    conexion.Open();
                    return comando.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo editar la cotizacion: " + ex.Message, ex);
            }
        }

        private void AgregarParametros(SqlCommand comando, Cotizacion cotizacion)
        {
            comando.Parameters.Add("@tipo", SqlDbType.Int).Value = cotizacion.CodigoTipoServicio;
            comando.Parameters.Add("@sucursal", SqlDbType.Int).Value = cotizacion.CodigoSucursal;
            comando.Parameters.Add("@cliente", SqlDbType.Int).Value = cotizacion.CodigoCliente;
            comando.Parameters.Add("@nombre", SqlDbType.VarChar, 45).Value = cotizacion.NombreCotizador;
            comando.Parameters.Add("@nit", SqlDbType.Int).Value =
                cotizacion.NIT.HasValue ? (object)cotizacion.NIT.Value : DBNull.Value;
            comando.Parameters.Add("@direccion", SqlDbType.VarChar, 150).Value = cotizacion.DireccionCotizador;
            comando.Parameters.Add("@fecha", SqlDbType.DateTime).Value = cotizacion.FechaEmision;
            comando.Parameters.Add("@descripcion", SqlDbType.VarChar, 150).Value = cotizacion.Descripcion;
            comando.Parameters.Add("@cantidad", SqlDbType.Int).Value = cotizacion.Cantidad;

            SqlParameter precio = comando.Parameters.Add("@precio", SqlDbType.Decimal);
            precio.Precision = 10;
            precio.Scale = 2;
            precio.Value = cotizacion.Precio;

            SqlParameter subtotal = comando.Parameters.Add("@subtotal", SqlDbType.Decimal);
            subtotal.Precision = 10;
            subtotal.Scale = 2;
            subtotal.Value = cotizacion.Subtotal;

            SqlParameter total = comando.Parameters.Add("@total", SqlDbType.Decimal);
            total.Precision = 10;
            total.Scale = 2;
            total.Value = cotizacion.Total;

            comando.Parameters.Add("@estado", SqlDbType.Bit).Value = cotizacion.Estado;
        }

        public int Eliminar(int codigo)
        {
            const string sql = "DELETE FROM dbo.Tbl_Cotizaciones WHERE CodigoCotizacion = @codigo";
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
            catch (SqlException ex)
            {
                if (ex.Number == 547)
                    throw new Exception("No se puede eliminar: la cotizacion esta relacionada con una orden de trabajo.", ex);
                throw new Exception("No se pudo eliminar la cotizacion: " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo eliminar la cotizacion: " + ex.Message, ex);
            }
        }
    }
}
