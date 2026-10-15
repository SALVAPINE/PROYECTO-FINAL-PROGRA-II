using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Entidad;

namespace Datos
{
    /// <summary>Consulta los clientes usando la conexión configurada en el Documento 01.</summary>
    public class ClienteDatos
    {
        public List<Cliente> Buscar(string texto, string estado)
        {
            const string sql = @"SELECT CodigoCliente, NombreCliente, Direccion, DPI, Edad, NIT, Telefono, Estado
                FROM dbo.Tbl_Clientes
                WHERE (@texto = '' OR NombreCliente LIKE @patron OR Direccion LIKE @patron
                    OR CONVERT(varchar(20), DPI) LIKE @patron
                    OR CONVERT(varchar(20), Edad) LIKE @patron
                    OR CONVERT(varchar(20), NIT) LIKE @patron
                    OR CONVERT(varchar(20), Telefono) LIKE @patron
                    OR CONVERT(varchar(20), CodigoCliente) LIKE @patron)
                  AND (@estado IS NULL OR Estado = @estado)
                ORDER BY CodigoCliente";

            try
            {
                List<Cliente> clientes = new List<Cliente>();
                using (SqlConnection conexion = ConexionDatos.CrearConexion())
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    string termino = (texto ?? string.Empty).Trim();
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
                            clientes.Add(new Cliente
                            {
                                CodigoCliente = Convert.ToInt32(lector["CodigoCliente"]),
                                NombreCliente = Convert.ToString(lector["NombreCliente"]),
                                Direccion = Convert.ToString(lector["Direccion"]),
                                DPI = Convert.ToInt32(lector["DPI"]),
                                Edad = Convert.ToInt32(lector["Edad"]),
                                NIT = lector["NIT"] == DBNull.Value ? (int?)null : Convert.ToInt32(lector["NIT"]),
                                Telefono = Convert.ToInt32(lector["Telefono"]),
                                Estado = Convert.ToBoolean(lector["Estado"])
                            });
                        }
                    }
                }
                return clientes;
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudieron consultar los clientes: " + ex.Message, ex);
            }
        }

        public List<Cliente> Listar()
        {
            return Buscar(string.Empty, "Todos");
        }
        // CodigoCliente es identidad; SQL Server asigna su valor al insertar.
        public int Insertar(Cliente cliente)
        {
            const string sql = @"INSERT INTO dbo.Tbl_Clientes
                (NombreCliente, Direccion, DPI, Edad, NIT, Telefono, Estado)
                VALUES (@nombre, @direccion, @dpi, @edad, @nit, @telefono, @estado)";
            try
            {
                using (SqlConnection conexion = ConexionDatos.CrearConexion())
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add("@nombre", SqlDbType.VarChar, 45).Value = cliente.NombreCliente;
                    comando.Parameters.Add("@direccion", SqlDbType.VarChar, 150).Value = cliente.Direccion;
                    comando.Parameters.Add("@dpi", SqlDbType.Int).Value = cliente.DPI;
                    comando.Parameters.Add("@edad", SqlDbType.Int).Value = cliente.Edad;
                    comando.Parameters.Add("@nit", SqlDbType.Int).Value = cliente.NIT.HasValue ? (object)cliente.NIT.Value : DBNull.Value;
                    comando.Parameters.Add("@telefono", SqlDbType.Int).Value = cliente.Telefono;
                    comando.Parameters.Add("@estado", SqlDbType.Bit).Value = cliente.Estado;
                    conexion.Open();
                    return comando.ExecuteNonQuery();
                }
            }
            catch (Exception ex) { throw new Exception("No se pudo agregar el cliente: " + ex.Message, ex); }
        }

        // CodigoCliente identifica el registro que se va a editar.
        public int Actualizar(Cliente cliente)
        {
            const string sql = @"UPDATE dbo.Tbl_Clientes
                SET NombreCliente = @nombre, Direccion = @direccion, DPI = @dpi,
                    Edad = @edad, NIT = @nit, Telefono = @telefono, Estado = @estado
                WHERE CodigoCliente = @codigo";
            try
            {
                using (SqlConnection conexion = ConexionDatos.CrearConexion())
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add("@nombre", SqlDbType.VarChar, 45).Value = cliente.NombreCliente;
                    comando.Parameters.Add("@direccion", SqlDbType.VarChar, 150).Value = cliente.Direccion;
                    comando.Parameters.Add("@dpi", SqlDbType.Int).Value = cliente.DPI;
                    comando.Parameters.Add("@edad", SqlDbType.Int).Value = cliente.Edad;
                    comando.Parameters.Add("@nit", SqlDbType.Int).Value = cliente.NIT.HasValue ? (object)cliente.NIT.Value : DBNull.Value;
                    comando.Parameters.Add("@telefono", SqlDbType.Int).Value = cliente.Telefono;
                    comando.Parameters.Add("@estado", SqlDbType.Bit).Value = cliente.Estado;
                    comando.Parameters.Add("@codigo", SqlDbType.Int).Value = cliente.CodigoCliente;
                    conexion.Open();
                    return comando.ExecuteNonQuery();
                }
            }
            catch (Exception ex) { throw new Exception("No se pudo actualizar el cliente: " + ex.Message, ex); }
        }

        // La PK CodigoCliente identifica solo el cliente seleccionado.
        public int Eliminar(int codigo)
        {
            const string sql = "DELETE FROM dbo.Tbl_Clientes WHERE CodigoCliente = @codigo";
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
                    throw new Exception("No se puede eliminar el cliente porque tiene registros relacionados.", ex);
                throw new Exception("No se pudo eliminar el cliente: " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo eliminar el cliente: " + ex.Message, ex);
            }
        }

    }
}