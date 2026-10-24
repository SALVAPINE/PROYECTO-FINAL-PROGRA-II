using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Entidad;

namespace Datos
{
    /// <summary>Acceso parametrizado a SQL Server para el inventario por sucursal.</summary>
    public class InventarioDatos
    {
        public List<Inventario> Listar()
        {
            return Buscar(string.Empty, "Todos");
        }

        public FichaInventario ObtenerFicha(int codigoInventario)
        {
            const string sql = @"SELECT i.CodigoInventario, i.NombreProducto, i.TipoProducto,
                    i.Stock, i.PrecioCompra, i.FechaAlmacenamiento, i.Estado,
                    s.NombreSucursal, m.NombreMaterial, m.UnidadMedida
                FROM dbo.Tbl_Inventarios AS i
                INNER JOIN dbo.Tbl_Sucursales AS s ON s.CodigoSucursal = i.CodigoSucursal
                INNER JOIN dbo.Tbl_Materiales AS m ON m.CodigoMaterial = i.CodigoMaterial
                WHERE i.CodigoInventario = @codigo";

            try
            {
                using (SqlConnection conexion = ConexionDatos.CrearConexion())
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add("@codigo", SqlDbType.Int).Value = codigoInventario;
                    conexion.Open();
                    using (SqlDataReader lector = comando.ExecuteReader())
                    {
                        if (!lector.Read()) return null;
                        return new FichaInventario
                        {
                            CodigoInventario = Convert.ToInt32(lector["CodigoInventario"]),
                            NombreProducto = Convert.ToString(lector["NombreProducto"]),
                            TipoProducto = Convert.ToString(lector["TipoProducto"]),
                            Stock = Convert.ToInt32(lector["Stock"]),
                            PrecioCompra = Convert.ToDecimal(lector["PrecioCompra"]),
                            FechaIngreso = Convert.ToDateTime(lector["FechaAlmacenamiento"]),
                            Estado = Convert.ToBoolean(lector["Estado"]),
                            NombreSucursal = Convert.ToString(lector["NombreSucursal"]),
                            NombreMaterial = Convert.ToString(lector["NombreMaterial"]),
                            UnidadMedida = Convert.ToString(lector["UnidadMedida"])
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo consultar la ficha de inventario: " + ex.Message, ex);
            }
        }

        public List<Inventario> Buscar(string texto, string estado)
        {
            const string sql = @"SELECT CodigoInventario, CodigoSucursal, CodigoMaterial,
                    NombreProducto, TipoProducto, Stock, PrecioCompra,
                    FechaAlmacenamiento, Estado
                FROM dbo.Tbl_Inventarios
                WHERE (@texto = ''
                    OR CONVERT(varchar(20), CodigoInventario) LIKE @patron
                    OR CONVERT(varchar(20), CodigoSucursal) LIKE @patron
                    OR CONVERT(varchar(20), CodigoMaterial) LIKE @patron
                    OR NombreProducto LIKE @patron
                    OR TipoProducto LIKE @patron
                    OR CONVERT(varchar(20), Stock) LIKE @patron
                    OR CONVERT(varchar(40), PrecioCompra) LIKE @patron
                    OR CONVERT(varchar(23), FechaAlmacenamiento, 121) LIKE @patron)
                  AND (@estado IS NULL OR Estado = @estado)
                ORDER BY CodigoInventario";

            try
            {
                List<Inventario> inventarios = new List<Inventario>();
                string termino = (texto ?? string.Empty).Trim();

                using (SqlConnection conexion = ConexionDatos.CrearConexion())
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add("@texto", SqlDbType.VarChar, 1000).Value = termino;
                    comando.Parameters.Add("@patron", SqlDbType.VarChar, 1002).Value = "%" + termino + "%";
                    AgregarEstado(comando, estado);

                    conexion.Open();
                    using (SqlDataReader lector = comando.ExecuteReader())
                        while (lector.Read()) inventarios.Add(LeerInventario(lector));
                }

                return inventarios;
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo consultar el inventario: " + ex.Message, ex);
            }
        }

        private static void AgregarEstado(SqlCommand comando, string estado)
        {
            SqlParameter parametro = comando.Parameters.Add("@estado", SqlDbType.Bit);
            if (estado == "Activo") parametro.Value = true;
            else if (estado == "Inactivo") parametro.Value = false;
            else parametro.Value = DBNull.Value;
        }

        private static Inventario LeerInventario(SqlDataReader lector)
        {
            return new Inventario
            {
                CodigoInventario = Convert.ToInt32(lector["CodigoInventario"]),
                CodigoSucursal = Convert.ToInt32(lector["CodigoSucursal"]),
                CodigoMaterial = Convert.ToInt32(lector["CodigoMaterial"]),
                NombreProducto = Convert.ToString(lector["NombreProducto"]),
                TipoProducto = Convert.ToString(lector["TipoProducto"]),
                Stock = Convert.ToInt32(lector["Stock"]),
                PrecioCompra = Convert.ToDecimal(lector["PrecioCompra"]),
                FechaAlmacenamiento = Convert.ToDateTime(lector["FechaAlmacenamiento"]),
                Estado = Convert.ToBoolean(lector["Estado"])
            };
        }

        // CodigoInventario es IDENTITY; SQL Server asigna su valor al insertar.
        public int Insertar(Inventario inventario)
        {
            const string sql = @"INSERT INTO dbo.Tbl_Inventarios
                (CodigoSucursal, CodigoMaterial, NombreProducto, TipoProducto,
                 Stock, PrecioCompra, FechaAlmacenamiento, Estado)
                VALUES (@sucursal, @material, @nombre, @tipo, @stock, @precio, @fecha, @estado)";

            try
            {
                using (SqlConnection conexion = ConexionDatos.CrearConexion())
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    AgregarParametros(comando, inventario);
                    conexion.Open();
                    return comando.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo agregar el registro de inventario: " + ex.Message, ex);
            }
        }

        public int Actualizar(Inventario inventario)
        {
            const string sql = @"UPDATE dbo.Tbl_Inventarios
                SET CodigoSucursal = @sucursal, CodigoMaterial = @material,
                    NombreProducto = @nombre, TipoProducto = @tipo, Stock = @stock,
                    PrecioCompra = @precio, FechaAlmacenamiento = @fecha, Estado = @estado
                WHERE CodigoInventario = @codigo";

            try
            {
                using (SqlConnection conexion = ConexionDatos.CrearConexion())
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    AgregarParametros(comando, inventario);
                    comando.Parameters.Add("@codigo", SqlDbType.Int).Value = inventario.CodigoInventario;
                    conexion.Open();
                    return comando.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo actualizar el inventario: " + ex.Message, ex);
            }
        }

        private static void AgregarParametros(SqlCommand comando, Inventario inventario)
        {
            comando.Parameters.Add("@sucursal", SqlDbType.Int).Value = inventario.CodigoSucursal;
            comando.Parameters.Add("@material", SqlDbType.Int).Value = inventario.CodigoMaterial;
            comando.Parameters.Add("@nombre", SqlDbType.VarChar, 45).Value = inventario.NombreProducto;
            comando.Parameters.Add("@tipo", SqlDbType.VarChar, 45).Value = inventario.TipoProducto;
            comando.Parameters.Add("@stock", SqlDbType.Int).Value = inventario.Stock;
            comando.Parameters.Add("@precio", SqlDbType.Decimal).Value = inventario.PrecioCompra;
            comando.Parameters.Add("@fecha", SqlDbType.DateTime).Value = inventario.FechaAlmacenamiento;
            comando.Parameters.Add("@estado", SqlDbType.Bit).Value = inventario.Estado;
        }

        public int Eliminar(int codigo)
        {
            const string sql = "DELETE FROM dbo.Tbl_Inventarios WHERE CodigoInventario = @codigo";

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
                    throw new Exception("No se puede eliminar el inventario porque tiene registros relacionados.", ex);
                throw new Exception("No se pudo eliminar el inventario: " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo eliminar el inventario: " + ex.Message, ex);
            }
        }
    }
}
