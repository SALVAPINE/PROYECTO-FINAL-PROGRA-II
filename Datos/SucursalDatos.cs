using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;
using Entidad;

namespace Datos
{
    /// <summary>Consultas de lectura para la tabla de sucursales.</summary>
    public class SucursalDatos
    {
        public List<Sucursal> Listar()
        {
            return Consultar(string.Empty, null);
        }

        public List<Sucursal> Buscar(string texto, bool? estado)
        {
            return Consultar(texto, estado);
        }

        // La búsqueda se hace en SQL; la paginación se aplica después en Presentación.
        private List<Sucursal> Consultar(string texto, bool? estado)
        {
            List<Sucursal> sucursales = new List<Sucursal>();
            string consulta = @"
                SELECT CodigoSucursal, NombreSucursal, Direccion, Municipio,
                       Departamento, Telefono, HorarioDeAtencion, Estado
                FROM dbo.Tbl_Sucursales
                WHERE (@Texto = ''
                       OR NombreSucursal LIKE '%' + @Texto + '%'
                       OR CONVERT(varchar(11), CodigoSucursal) LIKE '%' + @Texto + '%')
                  AND (@Estado IS NULL OR Estado = @Estado)
                ORDER BY CodigoSucursal;";

            using (SqlConnection conexion = ConexionDatos.CrearConexion())
            using (SqlCommand comando = new SqlCommand(consulta, conexion))
            {
                // Los valores de búsqueda se envían como parámetros para evitar concatenarlos al SQL.
                comando.Parameters.Add("@Texto", SqlDbType.VarChar, 4000).Value = texto ?? string.Empty;
                SqlParameter parametroEstado = comando.Parameters.Add("@Estado", SqlDbType.Bit);
                parametroEstado.Value = estado.HasValue ? (object)estado.Value : DBNull.Value;

                conexion.Open();
                using (SqlDataReader lector = comando.ExecuteReader())
                {
                    while (lector.Read())
                    {
                        sucursales.Add(new Sucursal
                        {
                            CodigoSucursal = Convert.ToInt32(lector["CodigoSucursal"]),
                            NombreSucursal = Convert.ToString(lector["NombreSucursal"]),
                            Direccion = Convert.ToString(lector["Direccion"]),
                            Municipio = Convert.ToString(lector["Municipio"]),
                            Departamento = Convert.ToString(lector["Departamento"]),
                            Telefono = Convert.ToInt32(lector["Telefono"]),
                            HorarioDeAtencion = (TimeSpan)lector["HorarioDeAtencion"],
                            Estado = Convert.ToBoolean(lector["Estado"])
                        });
                    }
                }
            }

            return sucursales;
        }

        public int Insertar(Sucursal sucursal)
        {
            string consulta = @"
                INSERT INTO dbo.Tbl_Sucursales
                    (NombreSucursal, Direccion, Municipio, Departamento,
                     Telefono, HorarioDeAtencion, Estado)
                VALUES
                    (@NombreSucursal, @Direccion, @Municipio, @Departamento,
                     @Telefono, @HorarioDeAtencion, @Estado);";

            using (SqlConnection conexion = ConexionDatos.CrearConexion())
            using (SqlCommand comando = new SqlCommand(consulta, conexion))
            {
                // CodigoSucursal se genera en SQL Server porque es IDENTITY.
                comando.Parameters.Add("@NombreSucursal", SqlDbType.VarChar, 45).Value = sucursal.NombreSucursal;
                comando.Parameters.Add("@Direccion", SqlDbType.VarChar, 150).Value = sucursal.Direccion;
                comando.Parameters.Add("@Municipio", SqlDbType.VarChar, 100).Value = sucursal.Municipio;
                comando.Parameters.Add("@Departamento", SqlDbType.VarChar, 100).Value = sucursal.Departamento;
                comando.Parameters.Add("@Telefono", SqlDbType.Int).Value = sucursal.Telefono;
                comando.Parameters.Add("@HorarioDeAtencion", SqlDbType.Time).Value = sucursal.HorarioDeAtencion;
                comando.Parameters.Add("@Estado", SqlDbType.Bit).Value = sucursal.Estado;

                conexion.Open();
                return comando.ExecuteNonQuery();
            }
        }

        public int Actualizar(Sucursal sucursal)
        {
            string consulta = @"
                UPDATE dbo.Tbl_Sucursales
                SET NombreSucursal = @NombreSucursal,
                    Direccion = @Direccion,
                    Municipio = @Municipio,
                    Departamento = @Departamento,
                    Telefono = @Telefono,
                    HorarioDeAtencion = @HorarioDeAtencion,
                    Estado = @Estado
                WHERE CodigoSucursal = @CodigoSucursal;";

            using (SqlConnection conexion = ConexionDatos.CrearConexion())
            using (SqlCommand comando = new SqlCommand(consulta, conexion))
            {
                comando.Parameters.Add("@NombreSucursal", SqlDbType.VarChar, 45).Value = sucursal.NombreSucursal;
                comando.Parameters.Add("@Direccion", SqlDbType.VarChar, 150).Value = sucursal.Direccion;
                comando.Parameters.Add("@Municipio", SqlDbType.VarChar, 100).Value = sucursal.Municipio;
                comando.Parameters.Add("@Departamento", SqlDbType.VarChar, 100).Value = sucursal.Departamento;
                comando.Parameters.Add("@Telefono", SqlDbType.Int).Value = sucursal.Telefono;
                comando.Parameters.Add("@HorarioDeAtencion", SqlDbType.Time).Value = sucursal.HorarioDeAtencion;
                comando.Parameters.Add("@Estado", SqlDbType.Bit).Value = sucursal.Estado;
                comando.Parameters.Add("@CodigoSucursal", SqlDbType.Int).Value = sucursal.CodigoSucursal;

                conexion.Open();
                return comando.ExecuteNonQuery();
            }
        }

        public int Eliminar(int codigo)
        {
            const string consulta = @"
                DELETE FROM dbo.Tbl_Sucursales
                WHERE CodigoSucursal = @CodigoSucursal;";

            using (SqlConnection conexion = ConexionDatos.CrearConexion())
            using (SqlCommand comando = new SqlCommand(consulta, conexion))
            {
                comando.Parameters.Add("@CodigoSucursal", SqlDbType.Int).Value = codigo;
                conexion.Open();
                return comando.ExecuteNonQuery();
            }
        }
    }
}
