using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Entidad;

namespace Datos
{
    /// <summary>Acceso parametrizado a SQL Server para los diseños.</summary>
    public class DisenoDatos
    {
        public List<Diseno> Listar()
        {
            return Buscar(string.Empty, "Todos");
        }

        public List<Diseno> Buscar(string texto, string estado)
        {
            const string sql = @"SELECT [CodigoDiseño], CodigoCliente, [CodigoDiseñador], [NombreDiseño],
                    [TipoDiseño], Descripcion, [RangoDiseño], FechaCreacion, Estado
                FROM dbo.[Tbl_Diseños]
                WHERE (@texto = ''
                    OR CONVERT(varchar(20), [CodigoDiseño]) LIKE @patron
                    OR CONVERT(varchar(20), CodigoCliente) LIKE @patron
                    OR CONVERT(varchar(20), [CodigoDiseñador]) LIKE @patron
                    OR [NombreDiseño] LIKE @patron
                    OR [TipoDiseño] LIKE @patron
                    OR Descripcion LIKE @patron
                    OR [RangoDiseño] LIKE @patron
                    OR CONVERT(varchar(23), FechaCreacion, 121) LIKE @patron)
                  AND (@estado IS NULL OR Estado = @estado)
                ORDER BY [CodigoDiseño]";

            try
            {
                List<Diseno> disenos = new List<Diseno>();
                string termino = (texto ?? string.Empty).Trim();

                using (SqlConnection conexion = ConexionDatos.CrearConexion())
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add("@texto", SqlDbType.VarChar, 1000).Value = termino;
                    comando.Parameters.Add("@patron", SqlDbType.VarChar, 1002).Value = "%" + termino + "%";
                    AgregarEstado(comando, estado);

                    conexion.Open();
                    using (SqlDataReader lector = comando.ExecuteReader())
                        while (lector.Read()) disenos.Add(LeerDiseno(lector));
                }

                return disenos;
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudieron consultar los diseños: " + ex.Message, ex);
            }
        }

        private static void AgregarEstado(SqlCommand comando, string estado)
        {
            SqlParameter parametro = comando.Parameters.Add("@estado", SqlDbType.Bit);
            if (estado == "Activo") parametro.Value = true;
            else if (estado == "Inactivo") parametro.Value = false;
            else parametro.Value = DBNull.Value;
        }

        private static Diseno LeerDiseno(SqlDataReader lector)
        {
            return new Diseno
            {
                CodigoDiseño = Convert.ToInt32(lector["CodigoDiseño"]),
                CodigoCliente = Convert.ToInt32(lector["CodigoCliente"]),
                CodigoDiseñador = Convert.ToInt32(lector["CodigoDiseñador"]),
                NombreDiseño = Convert.ToString(lector["NombreDiseño"]),
                TipoDiseño = Convert.ToString(lector["TipoDiseño"]),
                Descripcion = Convert.ToString(lector["Descripcion"]),
                RangoDiseño = Convert.ToString(lector["RangoDiseño"]),
                FechaCreacion = Convert.ToDateTime(lector["FechaCreacion"]),
                Estado = Convert.ToBoolean(lector["Estado"])
            };
        }

        // CodigoDiseño es IDENTITY; SQL Server asigna su valor al insertar.
        public int Insertar(Diseno diseno)
        {
            const string sql = @"INSERT INTO dbo.[Tbl_Diseños]
                (CodigoCliente, [CodigoDiseñador], [NombreDiseño], [TipoDiseño],
                 Descripcion, [RangoDiseño], FechaCreacion, Estado)
                VALUES (@cliente, @disenador, @nombre, @tipo, @descripcion, @rango, @fecha, @estado)";

            try
            {
                using (SqlConnection conexion = ConexionDatos.CrearConexion())
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    AgregarParametros(comando, diseno);
                    conexion.Open();
                    return comando.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo agregar el diseño: " + ex.Message, ex);
            }
        }

        public int Actualizar(Diseno diseno)
        {
            const string sql = @"UPDATE dbo.[Tbl_Diseños]
                SET CodigoCliente = @cliente, [CodigoDiseñador] = @disenador,
                    [NombreDiseño] = @nombre, [TipoDiseño] = @tipo,
                    Descripcion = @descripcion, [RangoDiseño] = @rango,
                    FechaCreacion = @fecha, Estado = @estado
                WHERE [CodigoDiseño] = @codigo";

            try
            {
                using (SqlConnection conexion = ConexionDatos.CrearConexion())
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    AgregarParametros(comando, diseno);
                    comando.Parameters.Add("@codigo", SqlDbType.Int).Value = diseno.CodigoDiseño;
                    conexion.Open();
                    return comando.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo actualizar el diseño: " + ex.Message, ex);
            }
        }

        private static void AgregarParametros(SqlCommand comando, Diseno diseno)
        {
            comando.Parameters.Add("@cliente", SqlDbType.Int).Value = diseno.CodigoCliente;
            comando.Parameters.Add("@disenador", SqlDbType.Int).Value = diseno.CodigoDiseñador;
            comando.Parameters.Add("@nombre", SqlDbType.VarChar, 45).Value = diseno.NombreDiseño;
            comando.Parameters.Add("@tipo", SqlDbType.VarChar, 45).Value = diseno.TipoDiseño;
            comando.Parameters.Add("@descripcion", SqlDbType.VarChar, 150).Value = diseno.Descripcion;
            comando.Parameters.Add("@rango", SqlDbType.VarChar, 45).Value = diseno.RangoDiseño;
            comando.Parameters.Add("@fecha", SqlDbType.DateTime).Value = diseno.FechaCreacion;
            comando.Parameters.Add("@estado", SqlDbType.Bit).Value = diseno.Estado;
        }

        public int Eliminar(int codigo)
        {
            const string sql = "DELETE FROM dbo.[Tbl_Diseños] WHERE [CodigoDiseño] = @codigo";

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
                    throw new Exception("No se puede eliminar el diseño porque tiene registros relacionados.", ex);
                throw new Exception("No se pudo eliminar el diseño: " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo eliminar el diseño: " + ex.Message, ex);
            }
        }
    }
}
