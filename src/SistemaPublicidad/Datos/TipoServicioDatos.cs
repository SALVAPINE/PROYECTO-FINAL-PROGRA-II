using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;
using Entidad;

namespace Datos
{
    /// <summary>Consultas de lectura para los tipos de servicio.</summary>
    public class TipoServicioDatos
    {
        public List<TipoServicio> Listar()
        {
            return Consultar(string.Empty, null);
        }

        public List<TipoServicio> Buscar(string texto, bool? estado)
        {
            return Consultar(texto, estado);
        }

        // Se consultan todos los resultados coincidentes; la paginación se realiza en Presentación.
        private List<TipoServicio> Consultar(string texto, bool? estado)
        {
            List<TipoServicio> tiposServicio = new List<TipoServicio>();
            string consulta = @"
                SELECT CodigoTipoServicio, NombreServicio, CostoServicio,
                       RecargoServicio, TotalServicio, Descripcion, Estado
                FROM dbo.Tbl_TipoDeServicio
                WHERE (@Texto = ''
                       OR NombreServicio LIKE '%' + @Texto + '%'
                       OR CONVERT(varchar(11), CodigoTipoServicio) LIKE '%' + @Texto + '%')
                  AND (@Estado IS NULL OR Estado = @Estado)
                ORDER BY CodigoTipoServicio;";

            using (SqlConnection conexion = ConexionDatos.CrearConexion())
            using (SqlCommand comando = new SqlCommand(consulta, conexion))
            {
                // Los valores ingresados se envían como parámetros al comando SQL.
                comando.Parameters.Add("@Texto", SqlDbType.VarChar, 4000).Value = texto ?? string.Empty;
                SqlParameter parametroEstado = comando.Parameters.Add("@Estado", SqlDbType.Bit);
                parametroEstado.Value = estado.HasValue ? (object)estado.Value : DBNull.Value;

                conexion.Open();
                using (SqlDataReader lector = comando.ExecuteReader())
                {
                    while (lector.Read())
                    {
                        tiposServicio.Add(new TipoServicio
                        {
                            CodigoTipoServicio = Convert.ToInt32(lector["CodigoTipoServicio"]),
                            NombreServicio = Convert.ToString(lector["NombreServicio"]),
                            CostoServicio = Convert.ToDecimal(lector["CostoServicio"]),
                            RecargoServicio = Convert.ToDecimal(lector["RecargoServicio"]),
                            TotalServicio = Convert.ToDecimal(lector["TotalServicio"]),
                            Descripcion = Convert.ToString(lector["Descripcion"]),
                            Estado = Convert.ToBoolean(lector["Estado"])
                        });
                    }
                }
            }

            return tiposServicio;
        }

        public int Insertar(TipoServicio tipoServicio)
        {
            const string consulta = @"
                INSERT INTO dbo.Tbl_TipoDeServicio
                    (NombreServicio, CostoServicio, RecargoServicio,
                     TotalServicio, Descripcion, Estado)
                VALUES
                    (@NombreServicio, @CostoServicio, @RecargoServicio,
                     @TotalServicio, @Descripcion, @Estado);";

            using (SqlConnection conexion = ConexionDatos.CrearConexion())
            using (SqlCommand comando = new SqlCommand(consulta, conexion))
            {
                // CodigoTipoServicio es IDENTITY; SQL Server asigna su valor.
                AgregarParametrosServicio(comando, tipoServicio);
                conexion.Open();
                return comando.ExecuteNonQuery();
            }
        }

        public int Actualizar(TipoServicio tipoServicio)
        {
            const string consulta = @"
                UPDATE dbo.Tbl_TipoDeServicio
                SET NombreServicio = @NombreServicio,
                    CostoServicio = @CostoServicio,
                    RecargoServicio = @RecargoServicio,
                    TotalServicio = @TotalServicio,
                    Descripcion = @Descripcion,
                    Estado = @Estado
                WHERE CodigoTipoServicio = @CodigoTipoServicio;";

            using (SqlConnection conexion = ConexionDatos.CrearConexion())
            using (SqlCommand comando = new SqlCommand(consulta, conexion))
            {
                AgregarParametrosServicio(comando, tipoServicio);
                comando.Parameters.Add("@CodigoTipoServicio", SqlDbType.Int).Value = tipoServicio.CodigoTipoServicio;
                conexion.Open();
                return comando.ExecuteNonQuery();
            }
        }

        public int Eliminar(int codigo)
        {
            const string consulta = @"
                DELETE FROM dbo.Tbl_TipoDeServicio
                WHERE CodigoTipoServicio = @CodigoTipoServicio;";

            using (SqlConnection conexion = ConexionDatos.CrearConexion())
            using (SqlCommand comando = new SqlCommand(consulta, conexion))
            {
                comando.Parameters.Add("@CodigoTipoServicio", SqlDbType.Int).Value = codigo;
                conexion.Open();
                return comando.ExecuteNonQuery();
            }
        }

        // Comparte el mapeo de parámetros entre INSERT y UPDATE.
        private static void AgregarParametrosServicio(SqlCommand comando, TipoServicio tipoServicio)
        {
            comando.Parameters.Add("@NombreServicio", SqlDbType.VarChar, 45).Value = tipoServicio.NombreServicio;

            SqlParameter costo = comando.Parameters.Add("@CostoServicio", SqlDbType.Decimal);
            costo.Precision = 10;
            costo.Scale = 2;
            costo.Value = tipoServicio.CostoServicio;

            SqlParameter recargo = comando.Parameters.Add("@RecargoServicio", SqlDbType.Decimal);
            recargo.Precision = 10;
            recargo.Scale = 2;
            recargo.Value = tipoServicio.RecargoServicio;

            SqlParameter total = comando.Parameters.Add("@TotalServicio", SqlDbType.Decimal);
            total.Precision = 10;
            total.Scale = 2;
            total.Value = tipoServicio.TotalServicio;

            comando.Parameters.Add("@Descripcion", SqlDbType.VarChar, 150).Value = tipoServicio.Descripcion;
            comando.Parameters.Add("@Estado", SqlDbType.Bit).Value = tipoServicio.Estado;
        }
    }
}
