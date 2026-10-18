using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Entidad;

namespace Datos
{
    /// <summary>Consultas de diseños y catálogos relacionados.</summary>
    public class DisenoDatos
    {
        public List<Diseno> Listar()
        {
            return Buscar(string.Empty, null);
        }

        /// <summary>Devuelve todas las coincidencias; la paginación corresponde a Presentación.</summary>
        public List<Diseno> Buscar(string texto, bool? estado)
        {
            List<Diseno> disenos = new List<Diseno>();
            const string consulta = @"
                SELECT d.CodigoDiseño, d.CodigoCliente, c.NombreCliente,
                       d.CodigoDiseñador, ds.NombreDiseñador, d.NombreDiseño,
                       d.TipoDiseño, d.Descripcion, d.RangoDiseño,
                       d.FechaCreacion, d.Estado
                FROM dbo.Tbl_Diseños AS d
                INNER JOIN dbo.Tbl_Clientes AS c
                    ON d.CodigoCliente = c.CodigoCliente
                INNER JOIN dbo.Tbl_Diseñadores AS ds
                    ON d.CodigoDiseñador = ds.CodigoDiseñador
                WHERE (@Texto = ''
                       OR CONVERT(varchar(11), d.CodigoDiseño) LIKE '%' + @Texto + '%'
                       OR d.NombreDiseño LIKE '%' + @Texto + '%'
                       OR d.TipoDiseño LIKE '%' + @Texto + '%'
                       OR d.RangoDiseño LIKE '%' + @Texto + '%')
                  AND (@Estado IS NULL OR d.Estado = @Estado)
                ORDER BY d.CodigoDiseño;";

            using (SqlConnection conexion = ConexionDatos.CrearConexion())
            using (SqlCommand comando = new SqlCommand(consulta, conexion))
            {
                // Los filtros se envían como parámetros para no concatenar datos al SQL.
                comando.Parameters.Add("@Texto", SqlDbType.VarChar, 4000).Value = texto ?? string.Empty;
                SqlParameter parametroEstado = comando.Parameters.Add("@Estado", SqlDbType.Bit);
                parametroEstado.Value = estado.HasValue ? (object)estado.Value : DBNull.Value;

                conexion.Open();
                using (SqlDataReader lector = comando.ExecuteReader())
                {
                    while (lector.Read())
                    {
                        disenos.Add(new Diseno
                        {
                            CodigoDiseño = Convert.ToInt32(lector["CodigoDiseño"]),
                            CodigoCliente = Convert.ToInt32(lector["CodigoCliente"]),
                            NombreCliente = Convert.ToString(lector["NombreCliente"]),
                            CodigoDiseñador = Convert.ToInt32(lector["CodigoDiseñador"]),
                            NombreDiseñador = Convert.ToString(lector["NombreDiseñador"]),
                            NombreDiseño = Convert.ToString(lector["NombreDiseño"]),
                            TipoDiseño = Convert.ToString(lector["TipoDiseño"]),
                            Descripcion = Convert.ToString(lector["Descripcion"]),
                            RangoDiseño = Convert.ToString(lector["RangoDiseño"]),
                            FechaCreacion = Convert.ToDateTime(lector["FechaCreacion"]),
                            Estado = Convert.ToBoolean(lector["Estado"])
                        });
                    }
                }
            }

            return disenos;
        }

        /// <summary>Lista códigos y descripciones para el ComboBox de clientes.</summary>
        public List<Cliente> ListarClientes()
        {
            List<Cliente> clientes = new List<Cliente>();
            const string consulta = @"SELECT CodigoCliente, NombreCliente
                FROM dbo.Tbl_Clientes ORDER BY NombreCliente, CodigoCliente;";

            using (SqlConnection conexion = ConexionDatos.CrearConexion())
            using (SqlCommand comando = new SqlCommand(consulta, conexion))
            {
                conexion.Open();
                using (SqlDataReader lector = comando.ExecuteReader())
                {
                    while (lector.Read())
                    {
                        clientes.Add(new Cliente
                        {
                            CodigoCliente = Convert.ToInt32(lector["CodigoCliente"]),
                            NombreCliente = Convert.ToString(lector["NombreCliente"])
                        });
                    }
                }
            }

            return clientes;
        }

        /// <summary>Lista códigos y descripciones para el ComboBox de diseñadores.</summary>
        public List<Disenador> ListarDisenadores()
        {
            List<Disenador> disenadores = new List<Disenador>();
            const string consulta = @"SELECT CodigoDiseñador, NombreDiseñador
                FROM dbo.Tbl_Diseñadores ORDER BY NombreDiseñador, CodigoDiseñador;";

            using (SqlConnection conexion = ConexionDatos.CrearConexion())
            using (SqlCommand comando = new SqlCommand(consulta, conexion))
            {
                conexion.Open();
                using (SqlDataReader lector = comando.ExecuteReader())
                {
                    while (lector.Read())
                    {
                        disenadores.Add(new Disenador
                        {
                            CodigoDiseñador = Convert.ToInt32(lector["CodigoDiseñador"]),
                            NombreDiseñador = Convert.ToString(lector["NombreDiseñador"])
                        });
                    }
                }
            }

            return disenadores;
        }

        /// <summary>Agrega un diseño; CodigoDiseño es IDENTITY en SQL Server.</summary>
        public int Insertar(Diseno diseno)
        {
            const string consulta = @"
                INSERT INTO dbo.Tbl_Diseños
                    (CodigoCliente, CodigoDiseñador, NombreDiseño, TipoDiseño,
                     Descripcion, RangoDiseño, FechaCreacion, Estado)
                VALUES
                    (@CodigoCliente, @CodigoDiseñador, @NombreDiseño, @TipoDiseño,
                     @Descripcion, @RangoDiseño, @FechaCreacion, @Estado);";

            using (SqlConnection conexion = ConexionDatos.CrearConexion())
            using (SqlCommand comando = new SqlCommand(consulta, conexion))
            {
                AgregarParametros(comando, diseno);
                conexion.Open();
                return comando.ExecuteNonQuery();
            }
        }

        /// <summary>Actualiza los campos del diseño identificado por su clave primaria.</summary>
        public int Actualizar(Diseno diseno)
        {
            const string consulta = @"
                UPDATE dbo.Tbl_Diseños
                SET CodigoCliente = @CodigoCliente,
                    CodigoDiseñador = @CodigoDiseñador,
                    NombreDiseño = @NombreDiseño,
                    TipoDiseño = @TipoDiseño,
                    Descripcion = @Descripcion,
                    RangoDiseño = @RangoDiseño,
                    FechaCreacion = @FechaCreacion,
                    Estado = @Estado
                WHERE CodigoDiseño = @CodigoDiseño;";

            using (SqlConnection conexion = ConexionDatos.CrearConexion())
            using (SqlCommand comando = new SqlCommand(consulta, conexion))
            {
                AgregarParametros(comando, diseno);
                comando.Parameters.Add("@CodigoDiseño", SqlDbType.Int).Value = diseno.CodigoDiseño;
                conexion.Open();
                return comando.ExecuteNonQuery();
            }
        }

        /// <summary>Elimina un diseño por su clave primaria.</summary>
        public int Eliminar(int codigo)
        {
            const string consulta = "DELETE FROM dbo.Tbl_Diseños WHERE CodigoDiseño = @CodigoDiseño;";
            using (SqlConnection conexion = ConexionDatos.CrearConexion())
            using (SqlCommand comando = new SqlCommand(consulta, conexion))
            {
                comando.Parameters.Add("@CodigoDiseño", SqlDbType.Int).Value = codigo;
                conexion.Open();
                return comando.ExecuteNonQuery();
            }
        }

        // Usa parámetros explícitos para que los valores coincidan con los tipos SQL reales.
        private static void AgregarParametros(SqlCommand comando, Diseno diseno)
        {
            comando.Parameters.Add("@CodigoCliente", SqlDbType.Int).Value = diseno.CodigoCliente;
            comando.Parameters.Add("@CodigoDiseñador", SqlDbType.Int).Value = diseno.CodigoDiseñador;
            comando.Parameters.Add("@NombreDiseño", SqlDbType.VarChar, 45).Value = diseno.NombreDiseño;
            comando.Parameters.Add("@TipoDiseño", SqlDbType.VarChar, 45).Value = diseno.TipoDiseño;
            comando.Parameters.Add("@Descripcion", SqlDbType.VarChar, 150).Value = diseno.Descripcion;
            comando.Parameters.Add("@RangoDiseño", SqlDbType.VarChar, 45).Value = diseno.RangoDiseño;
            comando.Parameters.Add("@FechaCreacion", SqlDbType.DateTime).Value = diseno.FechaCreacion;
            comando.Parameters.Add("@Estado", SqlDbType.Bit).Value = diseno.Estado;
        }
    }
}
