using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Entidad;

namespace Datos
{
    /// <summary>
    /// Acceso parametrizado a SQL Server para los materiales.
    /// La Presentación nunca usa esta clase directamente: la llama Negocio.
    /// </summary>
    public class MaterialDatos
    {
        public List<Material> Listar()
        {
            return Buscar(string.Empty, "Todos");
        }

        public List<Material> Buscar(string texto, string estado)
        {
            const string sql = @"SELECT CodigoMaterial, CodigoOrdenTrabajo, NombreMaterial,
                    TipoDeMaterial, UnidadMedida, CategoriaMaterial, CostoMaterial, Estado
                FROM dbo.Tbl_Materiales
                WHERE (@texto = ''
                    OR CONVERT(varchar(20), CodigoMaterial) LIKE @patron
                    OR CONVERT(varchar(20), CodigoOrdenTrabajo) LIKE @patron
                    OR NombreMaterial LIKE @patron
                    OR TipoDeMaterial LIKE @patron
                    OR UnidadMedida LIKE @patron
                    OR CategoriaMaterial LIKE @patron
                    OR CONVERT(varchar(40), CostoMaterial) LIKE @patron)
                  AND (@estado IS NULL OR Estado = @estado)
                ORDER BY CodigoMaterial";

            try
            {
                List<Material> materiales = new List<Material>();
                string termino = (texto ?? string.Empty).Trim();

                using (SqlConnection conexion = ConexionDatos.CrearConexion())
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add("@texto", SqlDbType.VarChar, 1000).Value = termino;
                    comando.Parameters.Add("@patron", SqlDbType.VarChar, 1002).Value = "%" + termino + "%";
                    AgregarEstado(comando, estado);

                    conexion.Open();
                    using (SqlDataReader lector = comando.ExecuteReader())
                        while (lector.Read()) materiales.Add(LeerMaterial(lector));
                }

                return materiales;
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudieron consultar los materiales: " + ex.Message, ex);
            }
        }

        private static void AgregarEstado(SqlCommand comando, string estado)
        {
            SqlParameter parametro = comando.Parameters.Add("@estado", SqlDbType.Bit);
            if (estado == "Activo") parametro.Value = true;
            else if (estado == "Inactivo") parametro.Value = false;
            else parametro.Value = DBNull.Value;
        }

        private static Material LeerMaterial(SqlDataReader lector)
        {
            return new Material
            {
                CodigoMaterial = Convert.ToInt32(lector["CodigoMaterial"]),
                CodigoOrdenTrabajo = Convert.ToInt32(lector["CodigoOrdenTrabajo"]),
                NombreMaterial = Convert.ToString(lector["NombreMaterial"]),
                TipoDeMaterial = Convert.ToString(lector["TipoDeMaterial"]),
                UnidadMedida = Convert.ToString(lector["UnidadMedida"]),
                CategoriaMaterial = Convert.ToString(lector["CategoriaMaterial"]),
                CostoMaterial = Convert.ToDecimal(lector["CostoMaterial"]),
                Estado = Convert.ToBoolean(lector["Estado"])
            };
        }

        // CodigoMaterial es IDENTITY; SQL Server asigna su valor al insertar.
        public int Insertar(Material material)
        {
            const string sql = @"INSERT INTO dbo.Tbl_Materiales
                (CodigoOrdenTrabajo, NombreMaterial, TipoDeMaterial, UnidadMedida,
                 CategoriaMaterial, CostoMaterial, Estado)
                VALUES (@orden, @nombre, @tipo, @unidad, @categoria, @costo, @estado)";

            try
            {
                using (SqlConnection conexion = ConexionDatos.CrearConexion())
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    AgregarParametros(comando, material);
                    conexion.Open();
                    return comando.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo agregar el material: " + ex.Message, ex);
            }
        }

        public int Actualizar(Material material)
        {
            const string sql = @"UPDATE dbo.Tbl_Materiales
                SET CodigoOrdenTrabajo = @orden, NombreMaterial = @nombre,
                    TipoDeMaterial = @tipo, UnidadMedida = @unidad,
                    CategoriaMaterial = @categoria, CostoMaterial = @costo, Estado = @estado
                WHERE CodigoMaterial = @codigo";

            try
            {
                using (SqlConnection conexion = ConexionDatos.CrearConexion())
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    AgregarParametros(comando, material);
                    comando.Parameters.Add("@codigo", SqlDbType.Int).Value = material.CodigoMaterial;
                    conexion.Open();
                    return comando.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo actualizar el material: " + ex.Message, ex);
            }
        }

        private static void AgregarParametros(SqlCommand comando, Material material)
        {
            comando.Parameters.Add("@orden", SqlDbType.Int).Value = material.CodigoOrdenTrabajo;
            comando.Parameters.Add("@nombre", SqlDbType.VarChar, 45).Value = material.NombreMaterial;
            comando.Parameters.Add("@tipo", SqlDbType.VarChar, 45).Value = material.TipoDeMaterial;
            comando.Parameters.Add("@unidad", SqlDbType.VarChar, 45).Value = material.UnidadMedida;
            comando.Parameters.Add("@categoria", SqlDbType.VarChar, 45).Value = material.CategoriaMaterial;
            comando.Parameters.Add("@costo", SqlDbType.Decimal).Value = material.CostoMaterial;
            comando.Parameters.Add("@estado", SqlDbType.Bit).Value = material.Estado;
        }

        public int Eliminar(int codigo)
        {
            const string sql = "DELETE FROM dbo.Tbl_Materiales WHERE CodigoMaterial = @codigo";

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
                    throw new Exception("No se puede eliminar el material porque tiene compras o inventario relacionados.", ex);
                throw new Exception("No se pudo eliminar el material: " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo eliminar el material: " + ex.Message, ex);
            }
        }
    }
}
