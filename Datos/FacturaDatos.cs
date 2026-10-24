using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Entidad;

namespace Datos
{
    /// <summary>Consultas de solo lectura para las facturas.</summary>
    public class FacturaDatos
    {
        public List<Factura> Listar()
        {
            return Buscar(string.Empty, "Todos");
        }

        public List<Factura> Buscar(string texto, string estado)
        {
            const string sql = @"SELECT CodigoFacturacion, CodigoOrdenTrabajo, NoFactura,
                    FechaDeEntrega, Subtotal, Impuesto, TotalPagar, Estado
                FROM dbo.Tbl_Facturacion
                WHERE (@texto = ''
                    OR CONVERT(varchar(20), CodigoFacturacion) LIKE @patron
                    OR CONVERT(varchar(20), CodigoOrdenTrabajo) LIKE @patron
                    OR CONVERT(varchar(20), NoFactura) LIKE @patron
                    OR CONVERT(varchar(23), FechaDeEntrega, 121) LIKE @patron
                    OR CONVERT(varchar(40), Subtotal) LIKE @patron
                    OR CONVERT(varchar(40), Impuesto) LIKE @patron
                    OR CONVERT(varchar(40), TotalPagar) LIKE @patron)
                  AND (@estado IS NULL OR Estado = @estado)
                ORDER BY CodigoFacturacion";

            try
            {
                List<Factura> facturas = new List<Factura>();
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
                        {
                            facturas.Add(new Factura
                            {
                                CodigoFacturacion = Convert.ToInt32(lector["CodigoFacturacion"]),
                                CodigoOrdenTrabajo = Convert.ToInt32(lector["CodigoOrdenTrabajo"]),
                                NoFactura = Convert.ToInt32(lector["NoFactura"]),
                                FechaDeEntrega = Convert.ToDateTime(lector["FechaDeEntrega"]),
                                Subtotal = Convert.ToDecimal(lector["Subtotal"]),
                                Impuesto = Convert.ToDecimal(lector["Impuesto"]),
                                TotalPagar = Convert.ToDecimal(lector["TotalPagar"]),
                                Estado = Convert.ToBoolean(lector["Estado"])
                            });
                        }
                    }
                }

                return facturas;
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudieron consultar las facturas: " + ex.Message, ex);
            }
        }

        // CodigoFacturacion es IDENTITY; SQL Server asigna su valor al insertar.
        public int Insertar(Factura factura)
        {
            const string sql = @"INSERT INTO dbo.Tbl_Facturacion
                (CodigoOrdenTrabajo, NoFactura, FechaDeEntrega, Subtotal,
                 Impuesto, TotalPagar, Estado)
                VALUES (@orden, @numero, @fecha, @subtotal, @impuesto, @total, @estado)";

            try
            {
                using (SqlConnection conexion = ConexionDatos.CrearConexion())
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    AgregarParametros(comando, factura);
                    conexion.Open();
                    return comando.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo agregar la factura: " + ex.Message, ex);
            }
        }

        /// <summary>
        /// Inserta la factura y devuelve el código generado, para agregar
        /// sus conceptos sin tener que volver a abrirla.
        /// </summary>
        public int InsertarYObtenerCodigo(Factura factura)
        {
            const string sql = @"INSERT INTO dbo.Tbl_Facturacion
                (CodigoOrdenTrabajo, NoFactura, FechaDeEntrega, Subtotal,
                 Impuesto, TotalPagar, Estado)
                VALUES (@orden, @numero, @fecha, @subtotal, @impuesto, @total, @estado);
                SELECT CAST(SCOPE_IDENTITY() AS int);";

            try
            {
                using (SqlConnection conexion = ConexionDatos.CrearConexion())
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    AgregarParametros(comando, factura);
                    conexion.Open();
                    return Convert.ToInt32(comando.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo agregar la factura: " + ex.Message, ex);
            }
        }

        /// <summary>Inserta la factura y su primer concepto como una sola operación.</summary>
        public int InsertarConDetalle(Factura factura, DetalleFactura detalle)
        {
            const string sqlFactura = @"INSERT INTO dbo.Tbl_Facturacion
                (CodigoOrdenTrabajo, NoFactura, FechaDeEntrega, Subtotal, Impuesto, TotalPagar, Estado)
                VALUES (@orden, @numero, @fecha, @subtotal, @impuesto, @total, @estado);
                SELECT CAST(SCOPE_IDENTITY() AS int);";
            const string sqlDetalle = @"INSERT INTO dbo.Tbl_DetalleFactura
                (CodigoFacturacion, DescuentoAplicado, Cantidad, Precio, Descripcion, Estado)
                VALUES (@factura, @descuento, @cantidad, @precio, @descripcion, @estado)";

            try
            {
                using (SqlConnection conexion = ConexionDatos.CrearConexion())
                {
                    conexion.Open();
                    using (SqlTransaction transaccion = conexion.BeginTransaction())
                    {
                        try
                        {
                            int codigoFactura;
                            using (SqlCommand comandoFactura = new SqlCommand(sqlFactura, conexion, transaccion))
                            {
                                AgregarParametros(comandoFactura, factura);
                                codigoFactura = Convert.ToInt32(comandoFactura.ExecuteScalar());
                            }

                            detalle.CodigoFacturacion = codigoFactura;
                            using (SqlCommand comandoDetalle = new SqlCommand(sqlDetalle, conexion, transaccion))
                            {
                                AgregarParametros(comandoDetalle, detalle);
                                comandoDetalle.ExecuteNonQuery();
                            }

                            transaccion.Commit();
                            return codigoFactura;
                        }
                        catch
                        {
                            transaccion.Rollback();
                            throw;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo guardar la factura y su concepto: " + ex.Message, ex);
            }
        }

        /// <summary>Actualiza la factura y un concepto suyo dentro de una transacción.</summary>
        public int ActualizarConDetalle(Factura factura, DetalleFactura detalle)
        {
            const string sqlFactura = @"UPDATE dbo.Tbl_Facturacion
                SET CodigoOrdenTrabajo = @orden, NoFactura = @numero, FechaDeEntrega = @fecha,
                    Subtotal = @subtotal, Impuesto = @impuesto, TotalPagar = @total, Estado = @estado
                WHERE CodigoFacturacion = @codigo";
            const string sqlDetalle = @"UPDATE dbo.Tbl_DetalleFactura
                SET DescuentoAplicado = @descuento, Cantidad = @cantidad, Precio = @precio,
                    Descripcion = @descripcion, Estado = @estado
                WHERE CodigoDetalleFactura = @codigoDetalle AND CodigoFacturacion = @codigoFactura";

            try
            {
                using (SqlConnection conexion = ConexionDatos.CrearConexion())
                {
                    conexion.Open();
                    using (SqlTransaction transaccion = conexion.BeginTransaction())
                    {
                        try
                        {
                            int filasFactura;
                            using (SqlCommand comandoFactura = new SqlCommand(sqlFactura, conexion, transaccion))
                            {
                                AgregarParametros(comandoFactura, factura);
                                comandoFactura.Parameters.Add("@codigo", SqlDbType.Int).Value = factura.CodigoFacturacion;
                                filasFactura = comandoFactura.ExecuteNonQuery();
                            }
                            if (filasFactura != 1)
                                throw new InvalidOperationException("No se encontró el encabezado de la factura.");

                            int filasDetalle;
                            using (SqlCommand comandoDetalle = new SqlCommand(sqlDetalle, conexion, transaccion))
                            {
                                comandoDetalle.Parameters.Add("@descuento", SqlDbType.Decimal).Value = detalle.DescuentoAplicado;
                                comandoDetalle.Parameters.Add("@cantidad", SqlDbType.Int).Value = detalle.Cantidad;
                                comandoDetalle.Parameters.Add("@precio", SqlDbType.Decimal).Value = detalle.Precio;
                                comandoDetalle.Parameters.Add("@descripcion", SqlDbType.VarChar, 150).Value = detalle.Descripcion;
                                comandoDetalle.Parameters.Add("@estado", SqlDbType.Bit).Value = detalle.Estado;
                                comandoDetalle.Parameters.Add("@codigoDetalle", SqlDbType.Int).Value = detalle.CodigoDetalleFactura;
                                comandoDetalle.Parameters.Add("@codigoFactura", SqlDbType.Int).Value = factura.CodigoFacturacion;
                                filasDetalle = comandoDetalle.ExecuteNonQuery();
                            }
                            if (filasDetalle != 1)
                                throw new InvalidOperationException("El concepto seleccionado no pertenece a esta factura.");

                            transaccion.Commit();
                            return filasFactura;
                        }
                        catch
                        {
                            transaccion.Rollback();
                            throw;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudieron actualizar juntos la factura y su concepto: " + ex.Message, ex);
            }
        }

        /// <summary>Actualiza la factura y agrega un concepto nuevo como una sola operación.</summary>
        public int ActualizarConNuevoDetalle(Factura factura, DetalleFactura detalle)
        {
            const string sqlFactura = @"UPDATE dbo.Tbl_Facturacion
                SET CodigoOrdenTrabajo = @orden, NoFactura = @numero, FechaDeEntrega = @fecha,
                    Subtotal = @subtotal, Impuesto = @impuesto, TotalPagar = @total, Estado = @estado
                WHERE CodigoFacturacion = @codigo";
            const string sqlDetalle = @"INSERT INTO dbo.Tbl_DetalleFactura
                (CodigoFacturacion, DescuentoAplicado, Cantidad, Precio, Descripcion, Estado)
                VALUES (@factura, @descuento, @cantidad, @precio, @descripcion, @estado)";

            try
            {
                using (SqlConnection conexion = ConexionDatos.CrearConexion())
                {
                    conexion.Open();
                    using (SqlTransaction transaccion = conexion.BeginTransaction())
                    {
                        try
                        {
                            int filasFactura;
                            using (SqlCommand comandoFactura = new SqlCommand(sqlFactura, conexion, transaccion))
                            {
                                AgregarParametros(comandoFactura, factura);
                                comandoFactura.Parameters.Add("@codigo", SqlDbType.Int).Value = factura.CodigoFacturacion;
                                filasFactura = comandoFactura.ExecuteNonQuery();
                            }
                            if (filasFactura != 1)
                                throw new InvalidOperationException("No se encontró el encabezado de la factura.");

                            detalle.CodigoFacturacion = factura.CodigoFacturacion;
                            using (SqlCommand comandoDetalle = new SqlCommand(sqlDetalle, conexion, transaccion))
                            {
                                AgregarParametros(comandoDetalle, detalle);
                                comandoDetalle.ExecuteNonQuery();
                            }

                            transaccion.Commit();
                            return factura.CodigoFacturacion;
                        }
                        catch
                        {
                            transaccion.Rollback();
                            throw;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo actualizar la factura y agregar su concepto: " + ex.Message, ex);
            }
        }

        public int Actualizar(Factura factura)
        {
            const string sql = @"UPDATE dbo.Tbl_Facturacion
                SET CodigoOrdenTrabajo = @orden, NoFactura = @numero,
                    FechaDeEntrega = @fecha, Subtotal = @subtotal,
                    Impuesto = @impuesto, TotalPagar = @total, Estado = @estado
                WHERE CodigoFacturacion = @codigo";

            try
            {
                using (SqlConnection conexion = ConexionDatos.CrearConexion())
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    AgregarParametros(comando, factura);
                    comando.Parameters.Add("@codigo", SqlDbType.Int).Value = factura.CodigoFacturacion;
                    conexion.Open();
                    return comando.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo actualizar la factura: " + ex.Message, ex);
            }
        }

        private static void AgregarParametros(SqlCommand comando, Factura factura)
        {
            comando.Parameters.Add("@orden", SqlDbType.Int).Value = factura.CodigoOrdenTrabajo;
            comando.Parameters.Add("@numero", SqlDbType.Int).Value = factura.NoFactura;
            comando.Parameters.Add("@fecha", SqlDbType.DateTime).Value = factura.FechaDeEntrega;
            comando.Parameters.Add("@subtotal", SqlDbType.Decimal).Value = factura.Subtotal;
            comando.Parameters.Add("@impuesto", SqlDbType.Decimal).Value = factura.Impuesto;
            comando.Parameters.Add("@total", SqlDbType.Decimal).Value = factura.TotalPagar;
            comando.Parameters.Add("@estado", SqlDbType.Bit).Value = factura.Estado;
        }

        private static void AgregarParametros(SqlCommand comando, DetalleFactura detalle)
        {
            comando.Parameters.Add("@factura", SqlDbType.Int).Value = detalle.CodigoFacturacion;
            comando.Parameters.Add("@descuento", SqlDbType.Decimal).Value = detalle.DescuentoAplicado;
            comando.Parameters.Add("@cantidad", SqlDbType.Int).Value = detalle.Cantidad;
            comando.Parameters.Add("@precio", SqlDbType.Decimal).Value = detalle.Precio;
            comando.Parameters.Add("@descripcion", SqlDbType.VarChar, 150).Value = detalle.Descripcion;
            comando.Parameters.Add("@estado", SqlDbType.Bit).Value = detalle.Estado;
        }

        public int Eliminar(int codigo)
        {
            const string sql = "DELETE FROM dbo.Tbl_Facturacion WHERE CodigoFacturacion = @codigo";

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
                    throw new Exception("No se puede eliminar la factura porque tiene conceptos relacionados.", ex);
                throw new Exception("No se pudo eliminar la factura: " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo eliminar la factura: " + ex.Message, ex);
            }
        }
    }
}
