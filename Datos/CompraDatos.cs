using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Entidad;

namespace Datos
{
    /// <summary>Acceso parametrizado a SQL Server para las compras.</summary>
    public class CompraDatos
    {
        public List<Compra> Listar()
        {
            return Buscar(string.Empty, "Todos");
        }

        public List<Compra> Buscar(string texto, string estado)
        {
            const string sql = @"SELECT CodigoCompra, CodigoProveedor, CodigoMaterial,
                    CantidadComprada, TotalCompra, FechaCompra, FechaEntrega, Estado
                FROM dbo.Tbl_Compras
                WHERE (@texto = ''
                    OR CONVERT(varchar(20), CodigoCompra) LIKE @patron
                    OR CONVERT(varchar(20), CodigoProveedor) LIKE @patron
                    OR CONVERT(varchar(20), CodigoMaterial) LIKE @patron
                    OR CONVERT(varchar(20), CantidadComprada) LIKE @patron
                    OR CONVERT(varchar(40), TotalCompra) LIKE @patron
                    OR CONVERT(varchar(23), FechaCompra, 121) LIKE @patron
                    OR CONVERT(varchar(23), FechaEntrega, 121) LIKE @patron)
                  AND (@estado IS NULL OR Estado = @estado)
                ORDER BY CodigoCompra";

            try
            {
                List<Compra> compras = new List<Compra>();
                string termino = (texto ?? string.Empty).Trim();

                using (SqlConnection conexion = ConexionDatos.CrearConexion())
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add("@texto", SqlDbType.VarChar, 1000).Value = termino;
                    comando.Parameters.Add("@patron", SqlDbType.VarChar, 1002).Value = "%" + termino + "%";
                    AgregarEstado(comando, estado);

                    conexion.Open();
                    using (SqlDataReader lector = comando.ExecuteReader())
                        while (lector.Read()) compras.Add(LeerCompra(lector));
                }

                return compras;
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudieron consultar las compras: " + ex.Message, ex);
            }
        }

        public CompraDocumento ObtenerDocumento(int codigoCompra)
        {
            const string sql = @"SELECT c.CodigoCompra, c.FechaCompra, c.FechaEntrega,
                    c.CantidadComprada, c.TotalCompra, p.NombreProveedor, p.Telefono,
                    p.Direccion, m.NombreMaterial, m.UnidadMedida,
                    d.CodigoDetalleCompra, d.TipoDeCompra, d.Descripcion,
                    d.PrecioUnitario, d.DescuentoCompra, d.Subtotal
                FROM dbo.Tbl_Compras c
                INNER JOIN dbo.Tbl_Proveedores p ON p.CodgioProveedor = c.CodigoProveedor
                INNER JOIN dbo.Tbl_Materiales m ON m.CodigoMaterial = c.CodigoMaterial
                LEFT JOIN dbo.Tbl_DetalleCompra d ON d.CodigoCompra = c.CodigoCompra
                WHERE c.CodigoCompra = @codigoCompra
                ORDER BY d.CodigoDetalleCompra";

            try
            {
                CompraDocumento documento = null;
                using (SqlConnection conexion = ConexionDatos.CrearConexion())
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add("@codigoCompra", SqlDbType.Int).Value = codigoCompra;
                    conexion.Open();
                    using (SqlDataReader lector = comando.ExecuteReader())
                    {
                        while (lector.Read())
                        {
                            if (documento == null)
                            {
                                documento = new CompraDocumento
                                {
                                    CodigoCompra = Convert.ToInt32(lector["CodigoCompra"]),
                                    FechaCompra = Convert.ToDateTime(lector["FechaCompra"]),
                                    FechaEntrega = Convert.ToDateTime(lector["FechaEntrega"]),
                                    TotalCompra = Convert.ToDecimal(lector["TotalCompra"]),
                                    NombreProveedor = Convert.ToString(lector["NombreProveedor"]),
                                    TelefonoProveedor = Convert.ToString(lector["Telefono"]),
                                    DireccionProveedor = Convert.ToString(lector["Direccion"])
                                };
                            }

                            if (lector.IsDBNull(lector.GetOrdinal("CodigoDetalleCompra")))
                                continue;

                            if (documento.Detalles.Count > 0)
                            {
                                throw new InvalidOperationException(
                                    "La compra tiene varias líneas, pero el modelo solo relaciona un material y una cantidad en la cabecera. " +
                                    "No se puede asignar una cantidad correcta a cada línea sin cambiar el modelo de datos.");
                            }

                            documento.CondicionPago = Convert.ToString(lector["TipoDeCompra"]);
                            documento.Detalles.Add(new DetalleCompraDocumento
                            {
                                NombreMaterial = Convert.ToString(lector["NombreMaterial"]),
                                Cantidad = Convert.ToInt32(lector["CantidadComprada"]),
                                UnidadMedida = Convert.ToString(lector["UnidadMedida"]),
                                Observaciones = Convert.ToString(lector["Descripcion"]),
                                PrecioUnitario = Convert.ToDecimal(lector["PrecioUnitario"]),
                                Descuento = Convert.ToDecimal(lector["DescuentoCompra"]),
                                Subtotal = Convert.ToDecimal(lector["Subtotal"])
                            });
                        }
                    }
                }

                return documento;
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo obtener el comprobante de compra: " + ex.Message, ex);
            }
        }

        private static void AgregarEstado(SqlCommand comando, string estado)
        {
            SqlParameter parametro = comando.Parameters.Add("@estado", SqlDbType.Bit);
            if (estado == "Activo") parametro.Value = true;
            else if (estado == "Inactivo") parametro.Value = false;
            else parametro.Value = DBNull.Value;
        }

        private static Compra LeerCompra(SqlDataReader lector)
        {
            return new Compra
            {
                CodigoCompra = Convert.ToInt32(lector["CodigoCompra"]),
                CodigoProveedor = Convert.ToInt32(lector["CodigoProveedor"]),
                CodigoMaterial = Convert.ToInt32(lector["CodigoMaterial"]),
                CantidadComprada = Convert.ToInt32(lector["CantidadComprada"]),
                TotalCompra = Convert.ToDecimal(lector["TotalCompra"]),
                FechaCompra = Convert.ToDateTime(lector["FechaCompra"]),
                FechaEntrega = Convert.ToDateTime(lector["FechaEntrega"]),
                Estado = Convert.ToBoolean(lector["Estado"])
            };
        }

        // CodigoCompra es IDENTITY; SQL Server asigna su valor al insertar.
        public int Insertar(Compra compra)
        {
            const string sql = @"INSERT INTO dbo.Tbl_Compras
                (CodigoProveedor, CodigoMaterial, CantidadComprada, TotalCompra,
                 FechaCompra, FechaEntrega, Estado)
                VALUES (@proveedor, @material, @cantidad, @total, @compra, @entrega, @estado)";

            try
            {
                using (SqlConnection conexion = ConexionDatos.CrearConexion())
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    AgregarParametros(comando, compra);
                    conexion.Open();
                    return comando.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo agregar la compra: " + ex.Message, ex);
            }
        }

        /// <summary>
        /// Inserta la compra y devuelve el código que generó SQL Server.
        /// La Presentación lo usa para poder agregar el detalle sin volver a abrir la compra.
        /// </summary>
        public int InsertarYObtenerCodigo(Compra compra)
        {
            const string sql = @"INSERT INTO dbo.Tbl_Compras
                (CodigoProveedor, CodigoMaterial, CantidadComprada, TotalCompra,
                 FechaCompra, FechaEntrega, Estado)
                VALUES (@proveedor, @material, @cantidad, @total, @compra, @entrega, @estado);
                SELECT CAST(SCOPE_IDENTITY() AS int);";

            try
            {
                using (SqlConnection conexion = ConexionDatos.CrearConexion())
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    AgregarParametros(comando, compra);
                    conexion.Open();
                    return Convert.ToInt32(comando.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo agregar la compra: " + ex.Message, ex);
            }
        }

        /// <summary>Guarda la compra y su detalle en una sola transacción.</summary>
        public int InsertarConDetalle(Compra compra, DetalleCompra detalle)
        {
            const string sqlCompra = @"INSERT INTO dbo.Tbl_Compras
                (CodigoProveedor, CodigoMaterial, CantidadComprada, TotalCompra,
                 FechaCompra, FechaEntrega, Estado)
                VALUES (@proveedor, @material, @cantidad, @total, @compra, @entrega, @estado);
                SELECT CAST(SCOPE_IDENTITY() AS int);";
            const string sqlDetalle = @"INSERT INTO dbo.Tbl_DetalleCompra
                (CodigoCompra, PrecioUnitario, TipoDeCompra, Subtotal,
                 DescuentoCompra, Descripcion, Estado)
                VALUES (@codigoCompra, @precio, @tipo, @subtotal, @descuento, @descripcion, @estado)";

            try
            {
                using (SqlConnection conexion = ConexionDatos.CrearConexion())
                {
                    conexion.Open();
                    using (SqlTransaction transaccion = conexion.BeginTransaction())
                    {
                        try
                        {
                            int codigoCompra;
                            using (SqlCommand comandoCompra = new SqlCommand(sqlCompra, conexion, transaccion))
                            {
                                AgregarParametros(comandoCompra, compra);
                                codigoCompra = Convert.ToInt32(comandoCompra.ExecuteScalar());
                            }

                            detalle.CodigoCompra = codigoCompra;
                            using (SqlCommand comandoDetalle = new SqlCommand(sqlDetalle, conexion, transaccion))
                            {
                                comandoDetalle.Parameters.Add("@codigoCompra", SqlDbType.Int).Value = codigoCompra;
                                comandoDetalle.Parameters.Add("@precio", SqlDbType.Decimal).Value = detalle.PrecioUnitario;
                                comandoDetalle.Parameters.Add("@tipo", SqlDbType.VarChar, 45).Value = detalle.TipoDeCompra;
                                comandoDetalle.Parameters.Add("@subtotal", SqlDbType.Decimal).Value = detalle.Subtotal;
                                comandoDetalle.Parameters.Add("@descuento", SqlDbType.Decimal).Value = detalle.DescuentoCompra;
                                comandoDetalle.Parameters.Add("@descripcion", SqlDbType.VarChar, 150).Value = detalle.Descripcion;
                                comandoDetalle.Parameters.Add("@estado", SqlDbType.Bit).Value = detalle.Estado;
                                comandoDetalle.ExecuteNonQuery();
                            }

                            transaccion.Commit();
                            return codigoCompra;
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
                throw new Exception("No se pudo guardar la compra y su detalle: " + ex.Message, ex);
            }
        }

        /// <summary>Actualiza encabezado y detalle juntos y revierte ambos si algo falla.</summary>
        public int ActualizarConDetalle(Compra compra, DetalleCompra detalle)
        {
            const string sqlCompra = @"UPDATE dbo.Tbl_Compras
                SET CodigoProveedor = @proveedor, CodigoMaterial = @material,
                    CantidadComprada = @cantidad, TotalCompra = @total,
                    FechaCompra = @compra, FechaEntrega = @entrega, Estado = @estado
                WHERE CodigoCompra = @codigo";
            const string sqlDetalle = @"UPDATE dbo.Tbl_DetalleCompra
                SET PrecioUnitario = @precio, TipoDeCompra = @tipo, Subtotal = @subtotal,
                    DescuentoCompra = @descuento, Descripcion = @descripcion, Estado = @estado
                WHERE CodigoDetalleCompra = @codigoDetalle AND CodigoCompra = @codigoCompra";

            try
            {
                using (SqlConnection conexion = ConexionDatos.CrearConexion())
                {
                    conexion.Open();
                    using (SqlTransaction transaccion = conexion.BeginTransaction())
                    {
                        try
                        {
                            int filasCompra;
                            using (SqlCommand comandoCompra = new SqlCommand(sqlCompra, conexion, transaccion))
                            {
                                AgregarParametros(comandoCompra, compra);
                                comandoCompra.Parameters.Add("@codigo", SqlDbType.Int).Value = compra.CodigoCompra;
                                filasCompra = comandoCompra.ExecuteNonQuery();
                            }
                            if (filasCompra != 1)
                                throw new InvalidOperationException("No se encontró el encabezado de la compra.");

                            int filasDetalle;
                            using (SqlCommand comandoDetalle = new SqlCommand(sqlDetalle, conexion, transaccion))
                            {
                                comandoDetalle.Parameters.Add("@precio", SqlDbType.Decimal).Value = detalle.PrecioUnitario;
                                comandoDetalle.Parameters.Add("@tipo", SqlDbType.VarChar, 45).Value = detalle.TipoDeCompra;
                                comandoDetalle.Parameters.Add("@subtotal", SqlDbType.Decimal).Value = detalle.Subtotal;
                                comandoDetalle.Parameters.Add("@descuento", SqlDbType.Decimal).Value = detalle.DescuentoCompra;
                                comandoDetalle.Parameters.Add("@descripcion", SqlDbType.VarChar, 150).Value = detalle.Descripcion;
                                comandoDetalle.Parameters.Add("@estado", SqlDbType.Bit).Value = detalle.Estado;
                                comandoDetalle.Parameters.Add("@codigoDetalle", SqlDbType.Int).Value = detalle.CodigoDetalleCompra;
                                comandoDetalle.Parameters.Add("@codigoCompra", SqlDbType.Int).Value = compra.CodigoCompra;
                                filasDetalle = comandoDetalle.ExecuteNonQuery();
                            }
                            if (filasDetalle != 1)
                                throw new InvalidOperationException("El detalle seleccionado no pertenece a esta compra.");

                            transaccion.Commit();
                            return filasCompra;
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
                throw new Exception("No se pudieron actualizar juntos el encabezado y el detalle: " + ex.Message, ex);
            }
        }

        public int Actualizar(Compra compra)
        {
            const string sql = @"UPDATE dbo.Tbl_Compras
                SET CodigoProveedor = @proveedor, CodigoMaterial = @material,
                    CantidadComprada = @cantidad, TotalCompra = @total,
                    FechaCompra = @compra, FechaEntrega = @entrega, Estado = @estado
                WHERE CodigoCompra = @codigo";

            try
            {
                using (SqlConnection conexion = ConexionDatos.CrearConexion())
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    AgregarParametros(comando, compra);
                    comando.Parameters.Add("@codigo", SqlDbType.Int).Value = compra.CodigoCompra;
                    conexion.Open();
                    return comando.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo actualizar la compra: " + ex.Message, ex);
            }
        }

        private static void AgregarParametros(SqlCommand comando, Compra compra)
        {
            comando.Parameters.Add("@proveedor", SqlDbType.Int).Value = compra.CodigoProveedor;
            comando.Parameters.Add("@material", SqlDbType.Int).Value = compra.CodigoMaterial;
            comando.Parameters.Add("@cantidad", SqlDbType.Int).Value = compra.CantidadComprada;
            comando.Parameters.Add("@total", SqlDbType.Decimal).Value = compra.TotalCompra;
            comando.Parameters.Add("@compra", SqlDbType.DateTime).Value = compra.FechaCompra;
            comando.Parameters.Add("@entrega", SqlDbType.DateTime).Value = compra.FechaEntrega;
            comando.Parameters.Add("@estado", SqlDbType.Bit).Value = compra.Estado;
        }

        public int Eliminar(int codigo)
        {
            const string sql = "DELETE FROM dbo.Tbl_Compras WHERE CodigoCompra = @codigo";

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
                    throw new Exception("No se puede eliminar la compra porque tiene detalle relacionado.", ex);
                throw new Exception("No se pudo eliminar la compra: " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo eliminar la compra: " + ex.Message, ex);
            }
        }
    }
}
