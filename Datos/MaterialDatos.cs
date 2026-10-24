using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Entidad;

namespace Datos
{
    /// <summary>Consultas de solo lectura para materiales y su catálogo relacionado.</summary>
    public class MaterialDatos
    {
        /// <summary>Devuelve todos los materiales y el nombre de su orden de trabajo.</summary>
        public List<Material> Listar()
        {
            return Buscar(string.Empty, null);
        }

        /// <summary>Filtra materiales por texto y estado. La paginación se realiza en Presentación.</summary>
        public List<Material> Buscar(string texto, bool? estado)
        {
            List<Material> materiales = new List<Material>();
            const string consulta = @"
                SELECT m.CodigoMaterial, m.CodigoOrdenTrabajo,
                       ot.NombreOrdenTrabajo, m.NombreMaterial, m.TipoDeMaterial,
                       m.UnidadMedida, m.CategoriaMaterial, m.CostoMaterial, m.Estado
                FROM dbo.Tbl_Materiales AS m
                INNER JOIN dbo.Tbl_OrdenesDeTrabajo AS ot
                    ON m.CodigoOrdenTrabajo = ot.CodigoOrdenTrabajo
                WHERE (@Texto = ''
                       OR CONVERT(varchar(11), m.CodigoMaterial) LIKE '%' + @Texto + '%'
                       OR m.NombreMaterial LIKE '%' + @Texto + '%'
                       OR m.TipoDeMaterial LIKE '%' + @Texto + '%'
                       OR m.CategoriaMaterial LIKE '%' + @Texto + '%')
                  AND (@Estado IS NULL OR m.Estado = @Estado)
                ORDER BY m.CodigoMaterial;";

            using (SqlConnection conexion = ConexionDatos.CrearConexion())
            using (SqlCommand comando = new SqlCommand(consulta, conexion))
            {
                // Los valores del filtro se envían como parámetros, no se concatenan al SQL.
                comando.Parameters.Add("@Texto", SqlDbType.VarChar, 4000).Value = texto ?? string.Empty;
                SqlParameter parametroEstado = comando.Parameters.Add("@Estado", SqlDbType.Bit);
                parametroEstado.Value = estado.HasValue ? (object)estado.Value : DBNull.Value;

                conexion.Open();
                using (SqlDataReader lector = comando.ExecuteReader())
                {
                    while (lector.Read())
                    {
                        materiales.Add(new Material
                        {
                            CodigoMaterial = Convert.ToInt32(lector["CodigoMaterial"]),
                            CodigoOrdenTrabajo = Convert.ToInt32(lector["CodigoOrdenTrabajo"]),
                            NombreOrdenTrabajo = Convert.ToString(lector["NombreOrdenTrabajo"]),
                            NombreMaterial = Convert.ToString(lector["NombreMaterial"]),
                            TipoDeMaterial = Convert.ToString(lector["TipoDeMaterial"]),
                            UnidadMedida = Convert.ToString(lector["UnidadMedida"]),
                            CategoriaMaterial = Convert.ToString(lector["CategoriaMaterial"]),
                            CostoMaterial = Convert.ToDecimal(lector["CostoMaterial"]),
                            Estado = Convert.ToBoolean(lector["Estado"])
                        });
                    }
                }
            }

            return materiales;
        }

        /// <summary>Lista las órdenes para mostrar su nombre y conservar su código como valor.</summary>
        public List<OrdenTrabajo> ListarOrdenesTrabajo()
        {
            List<OrdenTrabajo> ordenes = new List<OrdenTrabajo>();
            const string consulta = @"
                SELECT CodigoOrdenTrabajo, NombreOrdenTrabajo
                FROM dbo.Tbl_OrdenesDeTrabajo
                ORDER BY NombreOrdenTrabajo, CodigoOrdenTrabajo;";

            using (SqlConnection conexion = ConexionDatos.CrearConexion())
            using (SqlCommand comando = new SqlCommand(consulta, conexion))
            {
                conexion.Open();
                using (SqlDataReader lector = comando.ExecuteReader())
                {
                    while (lector.Read())
                    {
                        ordenes.Add(new OrdenTrabajo
                        {
                            CodigoOrdenTrabajo = Convert.ToInt32(lector["CodigoOrdenTrabajo"]),
                            NombreOrdenTrabajo = Convert.ToString(lector["NombreOrdenTrabajo"])
                        });
                    }
                }
            }

            return ordenes;
        }

        /// <summary>Agrega un material; CodigoMaterial se genera como IDENTITY en SQL Server.</summary>
        public int Insertar(Material material)
        {
            const string consulta = @"
                INSERT INTO dbo.Tbl_Materiales
                    (CodigoOrdenTrabajo, NombreMaterial, TipoDeMaterial, UnidadMedida,
                     CategoriaMaterial, CostoMaterial, Estado)
                VALUES
                    (@CodigoOrdenTrabajo, @NombreMaterial, @TipoDeMaterial, @UnidadMedida,
                     @CategoriaMaterial, @CostoMaterial, @Estado);";

            using (SqlConnection conexion = ConexionDatos.CrearConexion())
            using (SqlCommand comando = new SqlCommand(consulta, conexion))
            {
                AgregarParametrosMaterial(comando, material);
                conexion.Open();
                return comando.ExecuteNonQuery();
            }
        }

        /// <summary>Actualiza un material identificado por su clave primaria.</summary>
        public int Actualizar(Material material)
        {
            const string consulta = @"
                UPDATE dbo.Tbl_Materiales
                SET CodigoOrdenTrabajo = @CodigoOrdenTrabajo,
                    NombreMaterial = @NombreMaterial,
                    TipoDeMaterial = @TipoDeMaterial,
                    UnidadMedida = @UnidadMedida,
                    CategoriaMaterial = @CategoriaMaterial,
                    CostoMaterial = @CostoMaterial,
                    Estado = @Estado
                WHERE CodigoMaterial = @CodigoMaterial;";

            using (SqlConnection conexion = ConexionDatos.CrearConexion())
            using (SqlCommand comando = new SqlCommand(consulta, conexion))
            {
                AgregarParametrosMaterial(comando, material);
                comando.Parameters.Add("@CodigoMaterial", SqlDbType.Int).Value = material.CodigoMaterial;
                conexion.Open();
                return comando.ExecuteNonQuery();
            }
        }

        /// <summary>Elimina un material por su clave primaria.</summary>
        public int Eliminar(int codigo)
        {
            const string consulta = "DELETE FROM dbo.Tbl_Materiales WHERE CodigoMaterial = @CodigoMaterial;";
            using (SqlConnection conexion = ConexionDatos.CrearConexion())
            using (SqlCommand comando = new SqlCommand(consulta, conexion))
            {
                comando.Parameters.Add("@CodigoMaterial", SqlDbType.Int).Value = codigo;
                conexion.Open();
                return comando.ExecuteNonQuery();
            }
        }

        // Mantiene en un solo lugar los parámetros usados por INSERT y UPDATE.
        private static void AgregarParametrosMaterial(SqlCommand comando, Material material)
        {
            comando.Parameters.Add("@CodigoOrdenTrabajo", SqlDbType.Int).Value = material.CodigoOrdenTrabajo;
            comando.Parameters.Add("@NombreMaterial", SqlDbType.VarChar, 45).Value = material.NombreMaterial;
            comando.Parameters.Add("@TipoDeMaterial", SqlDbType.VarChar, 45).Value = material.TipoDeMaterial;
            comando.Parameters.Add("@UnidadMedida", SqlDbType.VarChar, 45).Value = material.UnidadMedida;
            comando.Parameters.Add("@CategoriaMaterial", SqlDbType.VarChar, 45).Value = material.CategoriaMaterial;
            comando.Parameters.Add("@CostoMaterial", SqlDbType.Decimal).Value = material.CostoMaterial;
            comando.Parameters["@CostoMaterial"].Precision = 10;
            comando.Parameters["@CostoMaterial"].Scale = 2;
            comando.Parameters.Add("@Estado", SqlDbType.Bit).Value = material.Estado;
        }
    }
}
