using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Entidad;

namespace Datos
{
    /// <summary>Consultas de solo lectura para los detalles de factura.</summary>
    public class DetalleFacturaDatos
    {
        public List<DetalleFactura> Listar()
        {
            return Buscar(string.Empty, "Todos");
        }

        public List<DetalleFactura> Buscar(string texto, string estado)
        {
            const string sql = @"SELECT CodigoDetalleFactura, CodigoFacturacion,
                    DescuentoAplicado, Cantidad, Precio, Descripcion, Estado
                FROM dbo.Tbl_DetalleFactura
                WHERE (@texto = ''
                    OR CONVERT(varchar(20), CodigoDetalleFactura) LIKE @patron
                    OR CONVERT(varchar(20), CodigoFacturacion) LIKE @patron
                    OR CONVERT(varchar(40), DescuentoAplicado) LIKE @patron
                    OR CONVERT(varchar(20), Cantidad) LIKE @patron
                    OR CONVERT(varchar(40), Precio) LIKE @patron
                    OR Descripcion LIKE @patron)
                  AND (@estado IS NULL OR Estado = @estado)
                ORDER BY CodigoDetalleFactura";

            try
            {
                List<DetalleFactura> detalles = new List<DetalleFactura>();
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
                            detalles.Add(LeerDetalle(lector));
                    }
                }

                return detalles;
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudieron consultar los detalles de factura: " + ex.Message, ex);
            }
        }

        /// <summary>Devuelve únicamente las líneas pertenecientes a una factura.</summary>
        public List<DetalleFactura> ListarPorFactura(int codigoFacturacion)
        {
            const string sql = @"SELECT CodigoDetalleFactura, CodigoFacturacion,
                    DescuentoAplicado, Cantidad, Precio, Descripcion, Estado
                FROM dbo.Tbl_DetalleFactura
                WHERE CodigoFacturacion = @codigoFacturacion
                ORDER BY CodigoDetalleFactura";

            try
            {
                List<DetalleFactura> detalles = new List<DetalleFactura>();
                using (SqlConnection conexion = ConexionDatos.CrearConexion())
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add("@codigoFacturacion", SqlDbType.Int).Value = codigoFacturacion;
                    conexion.Open();
                    using (SqlDataReader lector = comando.ExecuteReader())
                    {
                        while (lector.Read())
                            detalles.Add(LeerDetalle(lector));
                    }
                }

                return detalles;
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudieron consultar los detalles de la factura: " + ex.Message, ex);
            }
        }

        /// <summary>Busca conceptos solo dentro de la factura indicada.</summary>
        public List<DetalleFactura> BuscarPorFactura(int codigoFacturacion, string texto)
        {
            const string sql = @"SELECT CodigoDetalleFactura, CodigoFacturacion,
                    DescuentoAplicado, Cantidad, Precio, Descripcion, Estado
                FROM dbo.Tbl_DetalleFactura
                WHERE CodigoFacturacion = @codigoFacturacion
                  AND (@texto = ''
                    OR CONVERT(varchar(20), CodigoDetalleFactura) LIKE @patron
                    OR CONVERT(varchar(20), Cantidad) LIKE @patron
                    OR CONVERT(varchar(40), Precio) LIKE @patron
                    OR CONVERT(varchar(40), DescuentoAplicado) LIKE @patron
                    OR Descripcion LIKE @patron)
                ORDER BY CodigoDetalleFactura";

            try
            {
                List<DetalleFactura> detalles = new List<DetalleFactura>();
                string termino = (texto ?? string.Empty).Trim();
                using (SqlConnection conexion = ConexionDatos.CrearConexion())
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add("@codigoFacturacion", SqlDbType.Int).Value = codigoFacturacion;
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
                throw new Exception("No se pudo buscar el concepto de la factura: " + ex.Message, ex);
            }
        }

        private static DetalleFactura LeerDetalle(SqlDataReader lector)
        {
            return new DetalleFactura
            {
                CodigoDetalleFactura = Convert.ToInt32(lector["CodigoDetalleFactura"]),
                CodigoFacturacion = Convert.ToInt32(lector["CodigoFacturacion"]),
                DescuentoAplicado = Convert.ToDecimal(lector["DescuentoAplicado"]),
                Cantidad = Convert.ToInt32(lector["Cantidad"]),
                Precio = Convert.ToDecimal(lector["Precio"]),
                Descripcion = Convert.ToString(lector["Descripcion"]),
                Estado = Convert.ToBoolean(lector["Estado"])
            };
        }

        // CodigoDetalleFactura es IDENTITY; SQL Server asigna su valor al insertar.
        public int Insertar(DetalleFactura detalleFactura)
        {
            const string sql = @"INSERT INTO dbo.Tbl_DetalleFactura
                (CodigoFacturacion, DescuentoAplicado, Cantidad, Precio, Descripcion, Estado)
                VALUES (@factura, @descuento, @cantidad, @precio, @descripcion, @estado)";

            try
            {
                using (SqlConnection conexion = ConexionDatos.CrearConexion())
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    AgregarParametros(comando, detalleFactura);
                    conexion.Open();
                    return comando.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo agregar el concepto de la factura: " + ex.Message, ex);
            }
        }

        public int Actualizar(DetalleFactura detalleFactura)
        {
            const string sql = @"UPDATE dbo.Tbl_DetalleFactura
                SET CodigoFacturacion = @factura, DescuentoAplicado = @descuento,
                    Cantidad = @cantidad, Precio = @precio,
                    Descripcion = @descripcion, Estado = @estado
                WHERE CodigoDetalleFactura = @codigo";

            try
            {
                using (SqlConnection conexion = ConexionDatos.CrearConexion())
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    AgregarParametros(comando, detalleFactura);
                    comando.Parameters.Add("@codigo", SqlDbType.Int).Value = detalleFactura.CodigoDetalleFactura;
                    conexion.Open();
                    return comando.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo actualizar el concepto de la factura: " + ex.Message, ex);
            }
        }

        private static void AgregarParametros(SqlCommand comando, DetalleFactura detalleFactura)
        {
            comando.Parameters.Add("@factura", SqlDbType.Int).Value = detalleFactura.CodigoFacturacion;
            comando.Parameters.Add("@descuento", SqlDbType.Decimal).Value = detalleFactura.DescuentoAplicado;
            comando.Parameters.Add("@cantidad", SqlDbType.Int).Value = detalleFactura.Cantidad;
            comando.Parameters.Add("@precio", SqlDbType.Decimal).Value = detalleFactura.Precio;
            comando.Parameters.Add("@descripcion", SqlDbType.VarChar, 150).Value = detalleFactura.Descripcion;
            comando.Parameters.Add("@estado", SqlDbType.Bit).Value = detalleFactura.Estado;
        }

        public int Eliminar(int codigo)
        {
            const string sql = "DELETE FROM dbo.Tbl_DetalleFactura WHERE CodigoDetalleFactura = @codigo";

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
                    throw new Exception("No se puede eliminar el concepto porque tiene registros relacionados.", ex);
                throw new Exception("No se pudo eliminar el concepto de la factura: " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo eliminar el concepto de la factura: " + ex.Message, ex);
            }
        }

        /// <summary>Elimina un concepto solo si pertenece a la factura indicada.</summary>
        public int Eliminar(int codigoDetalle, int codigoFacturacion)
        {
            const string sql = @"DELETE FROM dbo.Tbl_DetalleFactura
                WHERE CodigoDetalleFactura = @codigoDetalle AND CodigoFacturacion = @codigoFacturacion";

            try
            {
                using (SqlConnection conexion = ConexionDatos.CrearConexion())
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add("@codigoDetalle", SqlDbType.Int).Value = codigoDetalle;
                    comando.Parameters.Add("@codigoFacturacion", SqlDbType.Int).Value = codigoFacturacion;
                    conexion.Open();
                    return comando.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo eliminar el concepto de la factura: " + ex.Message, ex);
            }
        }
    }
}
