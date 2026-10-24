using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Entidad;

namespace Datos
{
    /// <summary>Acceso parametrizado a SQL Server para el detalle de las compras.</summary>
    public class DetalleCompraDatos
    {
        public List<DetalleCompra> Listar()
        {
            return Buscar(string.Empty, "Todos");
        }

        public List<DetalleCompra> Buscar(string texto, string estado)
        {
            const string sql = @"SELECT CodigoDetalleCompra, CodigoCompra, PrecioUnitario,
                    TipoDeCompra, Subtotal, DescuentoCompra, Descripcion, Estado
                FROM dbo.Tbl_DetalleCompra
                WHERE (@texto = ''
                    OR CONVERT(varchar(20), CodigoDetalleCompra) LIKE @patron
                    OR CONVERT(varchar(20), CodigoCompra) LIKE @patron
                    OR TipoDeCompra LIKE @patron
                    OR Descripcion LIKE @patron
                    OR CONVERT(varchar(40), PrecioUnitario) LIKE @patron
                    OR CONVERT(varchar(40), Subtotal) LIKE @patron
                    OR CONVERT(varchar(40), DescuentoCompra) LIKE @patron)
                  AND (@estado IS NULL OR Estado = @estado)
                ORDER BY CodigoDetalleCompra";

            try
            {
                List<DetalleCompra> detalles = new List<DetalleCompra>();
                string termino = (texto ?? string.Empty).Trim();

                using (SqlConnection conexion = ConexionDatos.CrearConexion())
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add("@texto", SqlDbType.VarChar, 1000).Value = termino;
                    comando.Parameters.Add("@patron", SqlDbType.VarChar, 1002).Value = "%" + termino + "%";
                    AgregarEstado(comando, estado);

                    conexion.Open();
                    using (SqlDataReader lector = comando.ExecuteReader())
                        while (lector.Read()) detalles.Add(LeerDetalle(lector));
                }

                return detalles;
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudieron consultar los detalles de compra: " + ex.Message, ex);
            }
        }

        /// <summary>Devuelve únicamente las líneas pertenecientes a una compra.</summary>
        public List<DetalleCompra> ListarPorCompra(int codigoCompra)
        {
            return BuscarPorCompra(codigoCompra, string.Empty);
        }

        /// <summary>Busca detalles dentro de la compra indicada, nunca en otras compras.</summary>
        public List<DetalleCompra> BuscarPorCompra(int codigoCompra, string texto)
        {
            const string sql = @"SELECT CodigoDetalleCompra, CodigoCompra, PrecioUnitario,
                    TipoDeCompra, Subtotal, DescuentoCompra, Descripcion, Estado
                FROM dbo.Tbl_DetalleCompra
                WHERE CodigoCompra = @codigoCompra
                  AND (@texto = ''
                    OR CONVERT(varchar(20), CodigoDetalleCompra) LIKE @patron
                    OR TipoDeCompra LIKE @patron
                    OR Descripcion LIKE @patron
                    OR CONVERT(varchar(40), PrecioUnitario) LIKE @patron
                    OR CONVERT(varchar(40), Subtotal) LIKE @patron
                    OR CONVERT(varchar(40), DescuentoCompra) LIKE @patron)
                ORDER BY CodigoDetalleCompra";

            try
            {
                List<DetalleCompra> detalles = new List<DetalleCompra>();
                string termino = (texto ?? string.Empty).Trim();
                using (SqlConnection conexion = ConexionDatos.CrearConexion())
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add("@codigoCompra", SqlDbType.Int).Value = codigoCompra;
                    comando.Parameters.Add("@texto", SqlDbType.VarChar, 1000).Value = termino;
                    comando.Parameters.Add("@patron", SqlDbType.VarChar, 1002).Value = "%" + termino + "%";
                    conexion.Open();
                    using (SqlDataReader lector = comando.ExecuteReader())
                        while (lector.Read()) detalles.Add(LeerDetalle(lector));
                }

                return detalles;
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo consultar el detalle de la compra: " + ex.Message, ex);
            }
        }

        private static void AgregarEstado(SqlCommand comando, string estado)
        {
            SqlParameter parametro = comando.Parameters.Add("@estado", SqlDbType.Bit);
            if (estado == "Activo") parametro.Value = true;
            else if (estado == "Inactivo") parametro.Value = false;
            else parametro.Value = DBNull.Value;
        }

        private static DetalleCompra LeerDetalle(SqlDataReader lector)
        {
            return new DetalleCompra
            {
                CodigoDetalleCompra = Convert.ToInt32(lector["CodigoDetalleCompra"]),
                CodigoCompra = Convert.ToInt32(lector["CodigoCompra"]),
                PrecioUnitario = Convert.ToDecimal(lector["PrecioUnitario"]),
                TipoDeCompra = Convert.ToString(lector["TipoDeCompra"]),
                Subtotal = Convert.ToDecimal(lector["Subtotal"]),
                DescuentoCompra = Convert.ToDecimal(lector["DescuentoCompra"]),
                Descripcion = Convert.ToString(lector["Descripcion"]),
                Estado = Convert.ToBoolean(lector["Estado"])
            };
        }

        // CodigoDetalleCompra es IDENTITY; SQL Server asigna su valor al insertar.
        public int Insertar(DetalleCompra detalleCompra)
        {
            const string sql = @"INSERT INTO dbo.Tbl_DetalleCompra
                (CodigoCompra, PrecioUnitario, TipoDeCompra, Subtotal,
                 DescuentoCompra, Descripcion, Estado)
                VALUES (@compra, @precio, @tipo, @subtotal, @descuento, @descripcion, @estado)";

            try
            {
                using (SqlConnection conexion = ConexionDatos.CrearConexion())
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    AgregarParametros(comando, detalleCompra);
                    conexion.Open();
                    return comando.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo agregar el detalle de la compra: " + ex.Message, ex);
            }
        }

        public int Actualizar(DetalleCompra detalleCompra)
        {
            const string sql = @"UPDATE dbo.Tbl_DetalleCompra
                SET CodigoCompra = @compra, PrecioUnitario = @precio, TipoDeCompra = @tipo,
                    Subtotal = @subtotal, DescuentoCompra = @descuento,
                    Descripcion = @descripcion, Estado = @estado
                WHERE CodigoDetalleCompra = @codigo";

            try
            {
                using (SqlConnection conexion = ConexionDatos.CrearConexion())
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    AgregarParametros(comando, detalleCompra);
                    comando.Parameters.Add("@codigo", SqlDbType.Int).Value = detalleCompra.CodigoDetalleCompra;
                    conexion.Open();
                    return comando.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo actualizar el detalle de la compra: " + ex.Message, ex);
            }
        }

        private static void AgregarParametros(SqlCommand comando, DetalleCompra detalleCompra)
        {
            comando.Parameters.Add("@compra", SqlDbType.Int).Value = detalleCompra.CodigoCompra;
            comando.Parameters.Add("@precio", SqlDbType.Decimal).Value = detalleCompra.PrecioUnitario;
            comando.Parameters.Add("@tipo", SqlDbType.VarChar, 45).Value = detalleCompra.TipoDeCompra;
            comando.Parameters.Add("@subtotal", SqlDbType.Decimal).Value = detalleCompra.Subtotal;
            comando.Parameters.Add("@descuento", SqlDbType.Decimal).Value = detalleCompra.DescuentoCompra;
            comando.Parameters.Add("@descripcion", SqlDbType.VarChar, 150).Value = detalleCompra.Descripcion;
            comando.Parameters.Add("@estado", SqlDbType.Bit).Value = detalleCompra.Estado;
        }

        public int Eliminar(int codigo)
        {
            const string sql = "DELETE FROM dbo.Tbl_DetalleCompra WHERE CodigoDetalleCompra = @codigo";

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
                    throw new Exception("No se puede eliminar el detalle porque tiene registros relacionados.", ex);
                throw new Exception("No se pudo eliminar el detalle de la compra: " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo eliminar el detalle de la compra: " + ex.Message, ex);
            }
        }

        /// <summary>Elimina una línea solo si pertenece al encabezado indicado.</summary>
        public int Eliminar(int codigoDetalle, int codigoCompra)
        {
            const string sql = @"DELETE FROM dbo.Tbl_DetalleCompra
                WHERE CodigoDetalleCompra = @codigoDetalle AND CodigoCompra = @codigoCompra";

            try
            {
                using (SqlConnection conexion = ConexionDatos.CrearConexion())
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add("@codigoDetalle", SqlDbType.Int).Value = codigoDetalle;
                    comando.Parameters.Add("@codigoCompra", SqlDbType.Int).Value = codigoCompra;
                    conexion.Open();
                    return comando.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo eliminar el detalle de la compra: " + ex.Message, ex);
            }
        }
    }
}
