using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Entidad;

namespace Datos
{
    /// <summary>Acceso parametrizado a SQL Server para los diseñadores.</summary>
    public class DisenadorDatos
    {
        public List<Disenador> Listar()
        {
            return Buscar(string.Empty, "Todos");
        }

        public List<Disenador> Buscar(string texto, string estado)
        {
            const string sql = @"SELECT [CodigoDiseñador], [NombreDiseñador], Edad, Especialidad,
                    Telefono, Correo, Estado
                FROM dbo.[Tbl_Diseñadores]
                WHERE (@texto = ''
                    OR CONVERT(varchar(20), [CodigoDiseñador]) LIKE @patron
                    OR [NombreDiseñador] LIKE @patron
                    OR CONVERT(varchar(20), Edad) LIKE @patron
                    OR Especialidad LIKE @patron
                    OR CONVERT(varchar(20), Telefono) LIKE @patron
                    OR Correo LIKE @patron)
                  AND (@estado IS NULL OR Estado = @estado)
                ORDER BY [CodigoDiseñador]";

            try
            {
                List<Disenador> disenadores = new List<Disenador>();
                string termino = (texto ?? string.Empty).Trim();

                using (SqlConnection conexion = ConexionDatos.CrearConexion())
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add("@texto", SqlDbType.VarChar, 1000).Value = termino;
                    comando.Parameters.Add("@patron", SqlDbType.VarChar, 1002).Value = "%" + termino + "%";
                    AgregarEstado(comando, estado);

                    conexion.Open();
                    using (SqlDataReader lector = comando.ExecuteReader())
                        while (lector.Read()) disenadores.Add(LeerDisenador(lector));
                }

                return disenadores;
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudieron consultar los diseñadores: " + ex.Message, ex);
            }
        }

        private static void AgregarEstado(SqlCommand comando, string estado)
        {
            SqlParameter parametro = comando.Parameters.Add("@estado", SqlDbType.Bit);
            if (estado == "Activo") parametro.Value = true;
            else if (estado == "Inactivo") parametro.Value = false;
            else parametro.Value = DBNull.Value;
        }

        private static Disenador LeerDisenador(SqlDataReader lector)
        {
            return new Disenador
            {
                CodigoDiseñador = Convert.ToInt32(lector["CodigoDiseñador"]),
                NombreDiseñador = Convert.ToString(lector["NombreDiseñador"]),
                Edad = Convert.ToInt32(lector["Edad"]),
                Especialidad = Convert.ToString(lector["Especialidad"]),
                Telefono = Convert.ToInt32(lector["Telefono"]),
                Correo = Convert.ToString(lector["Correo"]),
                Estado = Convert.ToBoolean(lector["Estado"])
            };
        }

        // CodigoDiseñador es IDENTITY; SQL Server asigna su valor al insertar.
        public int Insertar(Disenador disenador)
        {
            const string sql = @"INSERT INTO dbo.[Tbl_Diseñadores]
                ([NombreDiseñador], Edad, Especialidad, Telefono, Correo, Estado)
                VALUES (@nombre, @edad, @especialidad, @telefono, @correo, @estado)";

            try
            {
                using (SqlConnection conexion = ConexionDatos.CrearConexion())
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    AgregarParametros(comando, disenador);
                    conexion.Open();
                    return comando.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo agregar el diseñador: " + ex.Message, ex);
            }
        }

        public int Actualizar(Disenador disenador)
        {
            const string sql = @"UPDATE dbo.[Tbl_Diseñadores]
                SET [NombreDiseñador] = @nombre, Edad = @edad, Especialidad = @especialidad,
                    Telefono = @telefono, Correo = @correo, Estado = @estado
                WHERE [CodigoDiseñador] = @codigo";

            try
            {
                using (SqlConnection conexion = ConexionDatos.CrearConexion())
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    AgregarParametros(comando, disenador);
                    comando.Parameters.Add("@codigo", SqlDbType.Int).Value = disenador.CodigoDiseñador;
                    conexion.Open();
                    return comando.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo actualizar el diseñador: " + ex.Message, ex);
            }
        }

        private static void AgregarParametros(SqlCommand comando, Disenador disenador)
        {
            comando.Parameters.Add("@nombre", SqlDbType.VarChar, 45).Value = disenador.NombreDiseñador;
            comando.Parameters.Add("@edad", SqlDbType.Int).Value = disenador.Edad;
            comando.Parameters.Add("@especialidad", SqlDbType.VarChar, 45).Value = disenador.Especialidad;
            comando.Parameters.Add("@telefono", SqlDbType.Int).Value = disenador.Telefono;
            comando.Parameters.Add("@correo", SqlDbType.VarChar, 150).Value = disenador.Correo;
            comando.Parameters.Add("@estado", SqlDbType.Bit).Value = disenador.Estado;
        }

        public int Eliminar(int codigo)
        {
            const string sql = "DELETE FROM dbo.[Tbl_Diseñadores] WHERE [CodigoDiseñador] = @codigo";

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
                    throw new Exception("No se puede eliminar el diseñador porque tiene diseños u órdenes relacionadas.", ex);
                throw new Exception("No se pudo eliminar el diseñador: " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo eliminar el diseñador: " + ex.Message, ex);
            }
        }
    }
}
