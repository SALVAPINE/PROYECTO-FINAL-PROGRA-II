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

        public int Insertar(DetalleFactura detalleFactura)
        {
            // Las operaciones de escritura siguen pendientes de autorización.
            return 0;
        }

        public int Actualizar(DetalleFactura detalleFactura)
        {
            // Las operaciones de escritura siguen pendientes de autorización.
            return 0;
        }

        public int Eliminar(int codigo)
        {
            // Las operaciones de escritura siguen pendientes de autorización.
            return 0;
        }
    }
}
