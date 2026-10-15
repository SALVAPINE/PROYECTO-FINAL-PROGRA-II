using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;
using Entidad;

namespace Datos
{
    /// <summary>Consultas de lectura para proveedores.</summary>
    public class ProveedorDatos
    {
        public List<Proveedor> Listar()
        {
            return Consultar(string.Empty, null);
        }

        public List<Proveedor> Buscar(string texto, bool? estado)
        {
            return Consultar(texto, estado);
        }

        // La base devuelve todos los resultados que coinciden; Presentación los pagina.
        private List<Proveedor> Consultar(string texto, bool? estado)
        {
            List<Proveedor> proveedores = new List<Proveedor>();
            string consulta = @"
                SELECT CodgioProveedor, NombreProveedor, Telefono, Correo,
                       TipoProveedor, Direccion, Estado
                FROM dbo.Tbl_Proveedores
                WHERE (@Texto = ''
                       OR NombreProveedor LIKE '%' + @Texto + '%'
                       OR CONVERT(varchar(11), CodgioProveedor) LIKE '%' + @Texto + '%')
                  AND (@Estado IS NULL OR Estado = @Estado)
                ORDER BY CodgioProveedor;";

            using (SqlConnection conexion = ConexionDatos.CrearConexion())
            using (SqlCommand comando = new SqlCommand(consulta, conexion))
            {
                // Los valores de búsqueda se pasan como parámetros, no se concatenan al SQL.
                comando.Parameters.Add("@Texto", SqlDbType.VarChar, 4000).Value = texto ?? string.Empty;
                SqlParameter parametroEstado = comando.Parameters.Add("@Estado", SqlDbType.Bit);
                parametroEstado.Value = estado.HasValue ? (object)estado.Value : DBNull.Value;

                conexion.Open();
                using (SqlDataReader lector = comando.ExecuteReader())
                {
                    while (lector.Read())
                    {
                        proveedores.Add(new Proveedor
                        {
                            CodgioProveedor = Convert.ToInt32(lector["CodgioProveedor"]),
                            NombreProveedor = Convert.ToString(lector["NombreProveedor"]),
                            Telefono = Convert.ToInt32(lector["Telefono"]),
                            Correo = Convert.ToString(lector["Correo"]),
                            TipoProveedor = Convert.ToString(lector["TipoProveedor"]),
                            Direccion = Convert.ToString(lector["Direccion"]),
                            Estado = Convert.ToBoolean(lector["Estado"])
                        });
                    }
                }
            }

            return proveedores;
        }

        public int Insertar(Proveedor proveedor)
        {
            const string consulta = @"
                INSERT INTO dbo.Tbl_Proveedores
                    (NombreProveedor, Telefono, Correo, TipoProveedor, Direccion, Estado)
                VALUES
                    (@NombreProveedor, @Telefono, @Correo, @TipoProveedor, @Direccion, @Estado);";

            using (SqlConnection conexion = ConexionDatos.CrearConexion())
            using (SqlCommand comando = new SqlCommand(consulta, conexion))
            {
                // CodgioProveedor es IDENTITY según el script del modelo existente.
                AgregarParametrosProveedor(comando, proveedor);
                conexion.Open();
                return comando.ExecuteNonQuery();
            }
        }

        public int Actualizar(Proveedor proveedor)
        {
            const string consulta = @"
                UPDATE dbo.Tbl_Proveedores
                SET NombreProveedor = @NombreProveedor,
                    Telefono = @Telefono,
                    Correo = @Correo,
                    TipoProveedor = @TipoProveedor,
                    Direccion = @Direccion,
                    Estado = @Estado
                WHERE CodgioProveedor = @CodgioProveedor;";

            using (SqlConnection conexion = ConexionDatos.CrearConexion())
            using (SqlCommand comando = new SqlCommand(consulta, conexion))
            {
                AgregarParametrosProveedor(comando, proveedor);
                comando.Parameters.Add("@CodgioProveedor", SqlDbType.Int).Value = proveedor.CodgioProveedor;
                conexion.Open();
                return comando.ExecuteNonQuery();
            }
        }

        public int Eliminar(int codigo)
        {
            const string consulta = @"
                DELETE FROM dbo.Tbl_Proveedores
                WHERE CodgioProveedor = @CodgioProveedor;";

            using (SqlConnection conexion = ConexionDatos.CrearConexion())
            using (SqlCommand comando = new SqlCommand(consulta, conexion))
            {
                comando.Parameters.Add("@CodgioProveedor", SqlDbType.Int).Value = codigo;
                conexion.Open();
                return comando.ExecuteNonQuery();
            }
        }

        // Comparte el mapeo de parámetros entre INSERT y UPDATE.
        private static void AgregarParametrosProveedor(SqlCommand comando, Proveedor proveedor)
        {
            comando.Parameters.Add("@NombreProveedor", SqlDbType.VarChar, 45).Value = proveedor.NombreProveedor;
            comando.Parameters.Add("@Telefono", SqlDbType.Int).Value = proveedor.Telefono;
            comando.Parameters.Add("@Correo", SqlDbType.VarChar, 150).Value = proveedor.Correo;
            comando.Parameters.Add("@TipoProveedor", SqlDbType.VarChar, 45).Value = proveedor.TipoProveedor;
            comando.Parameters.Add("@Direccion", SqlDbType.VarChar, 150).Value = proveedor.Direccion;
            comando.Parameters.Add("@Estado", SqlDbType.Bit).Value = proveedor.Estado;
        }
    }
}
