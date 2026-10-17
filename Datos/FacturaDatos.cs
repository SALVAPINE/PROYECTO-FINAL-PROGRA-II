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

        public int Insertar(Factura factura)
        {
            // Las operaciones de escritura siguen pendientes de autorización.
            return 0;
        }

        public int Actualizar(Factura factura)
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
