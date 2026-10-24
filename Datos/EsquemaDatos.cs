using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Datos
{
    /// <summary>Consulta los nombres de columnas que existen en las tablas de SQL Server.</summary>
    public class EsquemaDatos
    {
        public List<string> ListarColumnas(string tabla)
        {
            const string sql = @"SELECT c.name
                FROM sys.columns AS c
                INNER JOIN sys.tables AS t ON t.object_id = c.object_id
                INNER JOIN sys.schemas AS s ON s.schema_id = t.schema_id
                WHERE s.name = @esquema AND t.name = @tabla
                ORDER BY c.column_id";

            try
            {
                List<string> columnas = new List<string>();
                using (SqlConnection conexion = ConexionDatos.CrearConexion())
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add("@esquema", SqlDbType.NVarChar, 128).Value = "dbo";
                    comando.Parameters.Add("@tabla", SqlDbType.NVarChar, 128).Value = tabla;
                    conexion.Open();
                    using (SqlDataReader lector = comando.ExecuteReader())
                        while (lector.Read()) columnas.Add(Convert.ToString(lector[0]));
                }

                if (columnas.Count == 0)
                    throw new InvalidOperationException("No se encontraron columnas para dbo." + tabla + ".");
                return columnas;
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudieron consultar las columnas de dbo." + tabla + ": " + ex.Message, ex);
            }
        }
    }
}
