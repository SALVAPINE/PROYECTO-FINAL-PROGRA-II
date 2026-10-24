using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Entidad;

namespace Datos
{
    /// <summary>Acceso parametrizado a SQL Server para las órdenes de trabajo.</summary>
    public class OrdenTrabajoDatos
    {
        public List<OrdenTrabajo> Listar()
        {
            return Buscar(string.Empty, "Todos");
        }

        public List<OrdenTrabajo> Buscar(string texto, string estado)
        {
            const string sql = @"SELECT CodigoOrdenTrabajo, CodigoSucursal, CodigoTipoServicio,
                    CodigoCotizacion, [CodigoDiseñador], NombreOrdenTrabajo, TipoDeOrden,
                    FechaInicio, FechaFinalizacion, Descripcion, Estado
                FROM dbo.Tbl_OrdenesDeTrabajo
                WHERE (@texto = ''
                    OR CONVERT(varchar(20), CodigoOrdenTrabajo) LIKE @patron
                    OR CONVERT(varchar(20), CodigoSucursal) LIKE @patron
                    OR CONVERT(varchar(20), CodigoTipoServicio) LIKE @patron
                    OR CONVERT(varchar(20), CodigoCotizacion) LIKE @patron
                    OR CONVERT(varchar(20), [CodigoDiseñador]) LIKE @patron
                    OR NombreOrdenTrabajo LIKE @patron
                    OR TipoDeOrden LIKE @patron
                    OR CONVERT(varchar(23), FechaInicio, 121) LIKE @patron
                    OR CONVERT(varchar(23), FechaFinalizacion, 121) LIKE @patron
                    OR Descripcion LIKE @patron)
                  AND (@estado IS NULL OR Estado = @estado)
                ORDER BY CodigoOrdenTrabajo";

            try
            {
                List<OrdenTrabajo> ordenes = new List<OrdenTrabajo>();
                string termino = (texto ?? string.Empty).Trim();

                using (SqlConnection conexion = ConexionDatos.CrearConexion())
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add("@texto", SqlDbType.VarChar, 1000).Value = termino;
                    comando.Parameters.Add("@patron", SqlDbType.VarChar, 1002).Value = "%" + termino + "%";
                    AgregarEstado(comando, estado);

                    conexion.Open();
                    using (SqlDataReader lector = comando.ExecuteReader())
                        while (lector.Read()) ordenes.Add(LeerOrden(lector));
                }

                return ordenes;
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudieron consultar las órdenes de trabajo: " + ex.Message, ex);
            }
        }

        private static void AgregarEstado(SqlCommand comando, string estado)
        {
            SqlParameter parametro = comando.Parameters.Add("@estado", SqlDbType.Bit);
            if (estado == "Activo") parametro.Value = true;
            else if (estado == "Inactivo") parametro.Value = false;
            else parametro.Value = DBNull.Value;
        }

        private static OrdenTrabajo LeerOrden(SqlDataReader lector)
        {
            return new OrdenTrabajo
            {
                CodigoOrdenTrabajo = Convert.ToInt32(lector["CodigoOrdenTrabajo"]),
                CodigoSucursal = Convert.ToInt32(lector["CodigoSucursal"]),
                CodigoTipoServicio = Convert.ToInt32(lector["CodigoTipoServicio"]),
                CodigoCotizacion = Convert.ToInt32(lector["CodigoCotizacion"]),
                CodigoDiseñador = Convert.ToInt32(lector["CodigoDiseñador"]),
                NombreOrdenTrabajo = Convert.ToString(lector["NombreOrdenTrabajo"]),
                TipoDeOrden = Convert.ToString(lector["TipoDeOrden"]),
                FechaInicio = Convert.ToDateTime(lector["FechaInicio"]),
                FechaFinalizacion = Convert.ToDateTime(lector["FechaFinalizacion"]),
                Descripcion = Convert.ToString(lector["Descripcion"]),
                Estado = Convert.ToBoolean(lector["Estado"])
            };
        }

        // CodigoOrdenTrabajo es IDENTITY; SQL Server asigna su valor al insertar.
        public int Insertar(OrdenTrabajo ordenTrabajo)
        {
            const string sql = @"INSERT INTO dbo.Tbl_OrdenesDeTrabajo
                (CodigoSucursal, CodigoTipoServicio, CodigoCotizacion, [CodigoDiseñador],
                 NombreOrdenTrabajo, TipoDeOrden, FechaInicio, FechaFinalizacion, Descripcion, Estado)
                VALUES (@sucursal, @tipoServicio, @cotizacion, @disenador,
                        @nombre, @tipoOrden, @inicio, @fin, @descripcion, @estado)";

            try
            {
                using (SqlConnection conexion = ConexionDatos.CrearConexion())
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    AgregarParametros(comando, ordenTrabajo);
                    conexion.Open();
                    return comando.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo agregar la orden de trabajo: " + ex.Message, ex);
            }
        }

        public int Actualizar(OrdenTrabajo ordenTrabajo)
        {
            const string sql = @"UPDATE dbo.Tbl_OrdenesDeTrabajo
                SET CodigoSucursal = @sucursal, CodigoTipoServicio = @tipoServicio,
                    CodigoCotizacion = @cotizacion, [CodigoDiseñador] = @disenador,
                    NombreOrdenTrabajo = @nombre, TipoDeOrden = @tipoOrden,
                    FechaInicio = @inicio, FechaFinalizacion = @fin,
                    Descripcion = @descripcion, Estado = @estado
                WHERE CodigoOrdenTrabajo = @codigo";

            try
            {
                using (SqlConnection conexion = ConexionDatos.CrearConexion())
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    AgregarParametros(comando, ordenTrabajo);
                    comando.Parameters.Add("@codigo", SqlDbType.Int).Value = ordenTrabajo.CodigoOrdenTrabajo;
                    conexion.Open();
                    return comando.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo actualizar la orden de trabajo: " + ex.Message, ex);
            }
        }

        private static void AgregarParametros(SqlCommand comando, OrdenTrabajo ordenTrabajo)
        {
            comando.Parameters.Add("@sucursal", SqlDbType.Int).Value = ordenTrabajo.CodigoSucursal;
            comando.Parameters.Add("@tipoServicio", SqlDbType.Int).Value = ordenTrabajo.CodigoTipoServicio;
            comando.Parameters.Add("@cotizacion", SqlDbType.Int).Value = ordenTrabajo.CodigoCotizacion;
            comando.Parameters.Add("@disenador", SqlDbType.Int).Value = ordenTrabajo.CodigoDiseñador;
            comando.Parameters.Add("@nombre", SqlDbType.VarChar, 100).Value = ordenTrabajo.NombreOrdenTrabajo;
            comando.Parameters.Add("@tipoOrden", SqlDbType.VarChar, 100).Value = ordenTrabajo.TipoDeOrden;
            comando.Parameters.Add("@inicio", SqlDbType.DateTime).Value = ordenTrabajo.FechaInicio;
            comando.Parameters.Add("@fin", SqlDbType.DateTime).Value = ordenTrabajo.FechaFinalizacion;
            comando.Parameters.Add("@descripcion", SqlDbType.VarChar, 150).Value = ordenTrabajo.Descripcion;
            comando.Parameters.Add("@estado", SqlDbType.Bit).Value = ordenTrabajo.Estado;
        }

        public int Eliminar(int codigo)
        {
            const string sql = "DELETE FROM dbo.Tbl_OrdenesDeTrabajo WHERE CodigoOrdenTrabajo = @codigo";

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
                    throw new Exception("No se puede eliminar la orden porque tiene materiales o facturas relacionadas.", ex);
                throw new Exception("No se pudo eliminar la orden de trabajo: " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo eliminar la orden de trabajo: " + ex.Message, ex);
            }
        }
    }
}
