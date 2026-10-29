using System;
using System.Collections.Generic;
using System.Linq;
using Datos;
using Entidad;

namespace Negocio
{
    /// <summary>
    /// Reglas de negocio y validaciones para los roles y accesos del sistema.
    /// Comunica la capa de Presentación con la capa de Datos sin acceso directo a SQL Server.
    /// </summary>
    public class RolNegocio
    {
        private readonly RolDatos datos = new RolDatos();

        /// <summary>
        /// Obtiene la lista de nombres de módulos permitidos para el menú lateral según el rol.
        /// El módulo Inicio siempre se incluye para todos los roles.
        /// </summary>
        public List<string> ListarModulosPermitidos(string tipoUsuario)
        {
            if (string.IsNullOrWhiteSpace(tipoUsuario))
                return new List<string> { "Inicio" };

            // El Administrador tiene acceso completo a todos los módulos
            if (tipoUsuario.Equals("Administrador", StringComparison.OrdinalIgnoreCase))
            {
                return new List<string>
                {
                    "Inicio", "Usuarios", "Clientes", "Cotizaciones", "Tipo de Servicio",
                    "Materiales", "Diseños", "Diseñadores", "Órdenes de Trabajo", "Facturaciones",
                    "Sucursales", "Proveedores", "Inventarios", "Compras"
                };
            }

            List<string> permitidos;
            try
            {
                permitidos = datos.ListarModulosPermitidos(tipoUsuario);
            }
            catch
            {
                permitidos = ObtenerAccesosPorDefecto(tipoUsuario);
            }

            if (permitidos == null || permitidos.Count == 0)
            {
                permitidos = ObtenerAccesosPorDefecto(tipoUsuario);
            }

            // Inicio siempre permanece disponible
            if (!permitidos.Any(m => m.Equals("Inicio", StringComparison.OrdinalIgnoreCase)))
            {
                permitidos.Insert(0, "Inicio");
            }

            return permitidos;
        }

        /// <summary>
        /// Consulta la lista completa de permisos para gestionar en el formulario CRUD.
        /// </summary>
        public List<RolAcceso> Listar()
        {
            return datos.Listar();
        }

        /// <summary>
        /// Valida y registra un nuevo permiso en la base de datos.
        /// </summary>
        public int Insertar(RolAcceso acceso)
        {
            Validar(acceso);
            return datos.Insertar(acceso);
        }

        /// <summary>
        /// Valida y actualiza un permiso existente en la base de datos.
        /// </summary>
        public int Actualizar(RolAcceso acceso)
        {
            Validar(acceso);
            if (acceso.CodigoRolAcceso <= 0)
            {
                throw new ArgumentException("Selecciona un permiso válido para editar.");
            }
            return datos.Actualizar(acceso);
        }

        /// <summary>
        /// Valida y elimina un permiso de acceso por su código.
        /// </summary>
        public int Eliminar(int codigo)
        {
            if (codigo <= 0)
            {
                throw new ArgumentException("Selecciona un permiso válido para eliminar.");
            }
            return datos.Eliminar(codigo);
        }

        /// <summary>
        /// Validaciones sencillas de campos obligatorios para el nivel del curso.
        /// </summary>
        private void Validar(RolAcceso acceso)
        {
            if (acceso == null)
            {
                throw new ArgumentException("No se recibieron los datos del permiso.");
            }
            if (string.IsNullOrWhiteSpace(acceso.TipoUsuario))
            {
                throw new ArgumentException("Selecciona el tipo de usuario (rol).");
            }
            if (string.IsNullOrWhiteSpace(acceso.NombreModulo))
            {
                throw new ArgumentException("Ingresa el nombre del módulo para el permiso.");
            }
        }

        /// <summary>
        /// Accesos por defecto según la regla de roles en caso de contingencia.
        /// </summary>
        public static List<string> ObtenerAccesosPorDefecto(string tipoUsuario)
        {
            if (string.Equals(tipoUsuario, "Diseñador", StringComparison.OrdinalIgnoreCase) ||
                string.Equals(tipoUsuario, "Disenador", StringComparison.OrdinalIgnoreCase))
            {
                return new List<string>
                {
                    "Inicio", "Clientes", "Cotizaciones", "Materiales", "Diseños", "Órdenes de Trabajo", "Sucursales"
                };
            }

            if (string.Equals(tipoUsuario, "Operador", StringComparison.OrdinalIgnoreCase))
            {
                return new List<string>
                {
                    "Inicio", "Clientes", "Cotizaciones", "Tipo de Servicio", "Materiales", "Diseños",
                    "Órdenes de Trabajo", "Facturaciones", "Inventarios", "Compras"
                };
            }

            return new List<string> { "Inicio" };
        }
    }
}
