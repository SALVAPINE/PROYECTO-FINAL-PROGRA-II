using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Entidad;

namespace Datos
{
    /// <summary>Acceso parametrizado a las columnas reales de Tbl_Diseñadores.</summary>
    public class DisenadorDatos
    {
        public List<Disenador> Listar()
        {
            return Buscar(string.Empty, "Todos");
        }

        // Devuelve el conjunto completo: la paginación pertenece a Presentación.
        public List<Disenador> Buscar(string texto, string estado)
        {
            const string sql = @"SELECT [CodigoDiseñador], [NombreDiseñador], Edad,
                Especialidad, Telefono, Correo, Estado
                FROM dbo.[Tbl_Diseñadores]
                WHERE (@Texto = '' OR [NombreDiseñador] LIKE '%' + @Texto + '%'
                    OR Especialidad LIKE '%' + @Texto + '%'
                    OR Correo LIKE '%' + @Texto + '%'
                    OR CONVERT(varchar(11), [CodigoDiseñador]) LIKE '%' + @Texto + '%')
                  AND (@Estado IS NULL OR Estado = @Estado)
                ORDER BY [CodigoDiseñador];";
            List<Disenador> lista = new List<Disenador>();
            using (SqlConnection conexion = ConexionDatos.CrearConexion())
            using (SqlCommand comando = new SqlCommand(sql, conexion))
            {
                comando.Parameters.Add("@Texto", SqlDbType.VarChar, -1).Value = texto ?? string.Empty;
                comando.Parameters.Add("@Estado", SqlDbType.Bit).Value =
                    estado == "Activo" ? (object)true :
                    estado == "Inactivo" ? (object)false : DBNull.Value;
                conexion.Open();
                using (SqlDataReader lector = comando.ExecuteReader())
                {
                    while (lector.Read())
                    {
                        lista.Add(new Disenador
                        {
                            CodigoDiseñador = Convert.ToInt32(lector["CodigoDiseñador"]),
                            NombreDiseñador = Convert.ToString(lector["NombreDiseñador"]),
                            Edad = Convert.ToInt32(lector["Edad"]),
                            Especialidad = Convert.ToString(lector["Especialidad"]),
                            Telefono = Convert.ToInt32(lector["Telefono"]),
                            Correo = Convert.ToString(lector["Correo"]),
                            Estado = Convert.ToBoolean(lector["Estado"])
                        });
                    }
                }
            }
            return lista;
        }

        public int Insertar(Disenador disenador)
        {
            // La PK es IDENTITY; SQL Server genera el código.
            const string sql = @"INSERT INTO dbo.[Tbl_Diseñadores]
                ([NombreDiseñador], Edad, Especialidad, Telefono, Correo, Estado)
                VALUES (@Nombre, @Edad, @Especialidad, @Telefono, @Correo, @Estado);";
            return Guardar(sql, disenador, false);
        }

        public int Actualizar(Disenador disenador)
        {
            const string sql = @"UPDATE dbo.[Tbl_Diseñadores]
                SET [NombreDiseñador] = @Nombre, Edad = @Edad,
                    Especialidad = @Especialidad, Telefono = @Telefono,
                    Correo = @Correo, Estado = @Estado
                WHERE [CodigoDiseñador] = @Codigo;";
            return Guardar(sql, disenador, true);
        }

        private static int Guardar(string sql, Disenador disenador, bool actualizar)
        {
            using (SqlConnection conexion = ConexionDatos.CrearConexion())
            using (SqlCommand comando = new SqlCommand(sql, conexion))
            {
                comando.Parameters.Add("@Nombre", SqlDbType.VarChar, 45).Value = disenador.NombreDiseñador;
                comando.Parameters.Add("@Edad", SqlDbType.Int).Value = disenador.Edad;
                comando.Parameters.Add("@Especialidad", SqlDbType.VarChar, 45).Value = disenador.Especialidad;
                comando.Parameters.Add("@Telefono", SqlDbType.Int).Value = disenador.Telefono;
                comando.Parameters.Add("@Correo", SqlDbType.VarChar, 150).Value = disenador.Correo;
                comando.Parameters.Add("@Estado", SqlDbType.Bit).Value = disenador.Estado;
                if (actualizar)
                    comando.Parameters.Add("@Codigo", SqlDbType.Int).Value = disenador.CodigoDiseñador;
                conexion.Open();
                return comando.ExecuteNonQuery();
            }
        }

        public int Eliminar(int codigo)
        {
            const string sql = "DELETE FROM dbo.[Tbl_Diseñadores] WHERE [CodigoDiseñador] = @Codigo;";
            using (SqlConnection conexion = ConexionDatos.CrearConexion())
            using (SqlCommand comando = new SqlCommand(sql, conexion))
            {
                comando.Parameters.Add("@Codigo", SqlDbType.Int).Value = codigo;
                conexion.Open();
                return comando.ExecuteNonQuery();
            }
        }
    }
}
