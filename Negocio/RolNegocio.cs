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
        public static readonly string[] TiposUsuario = { "Administrador", "Diseñador", "Operador", "Gerente", "Vendedor" };
        public static readonly string[] Modulos = { "Inicio", "Usuarios", "Clientes", "Cotizaciones", "Tipo de Servicio",
            "Materiales", "Diseños", "Diseñadores", "Órdenes de Trabajo", "Facturaciones", "Sucursales", "Proveedores", "Inventarios", "Compras" };

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
                    "Sucursales", "Proveedores", "Inventarios", "Compras", "Roles"
                };
            }

            List<string> permitidos;
            try
            {
                if (tipoUsuario.Equals("Disenador", StringComparison.OrdinalIgnoreCase)) tipoUsuario = "Diseñador";
                permitidos = datos.ListarModulosPermitidos(tipoUsuario).Where(m => Modulos.Contains(m)).ToList();
            }
            catch
            {
                // Un fallo de permisos nunca concede acceso a módulos de gestión.
                return new List<string> { "Inicio" };
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
            SesionActual.ExigirAdministrador();
            return datos.Listar();
        }

        /// <summary>
        /// Valida y registra un nuevo permiso en la base de datos.
        /// </summary>
        public int Insertar(RolAcceso acceso)
        {
            SesionActual.ExigirAdministrador();
            Validar(acceso);
            return datos.Insertar(acceso);
        }

        /// <summary>
        /// Valida y actualiza un permiso existente en la base de datos.
        /// </summary>
        public int Actualizar(RolAcceso acceso)
        {
            SesionActual.ExigirAdministrador();
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
            SesionActual.ExigirAdministrador();
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
            if (!TiposUsuario.Contains(acceso.TipoUsuario) || acceso.TipoUsuario == "Administrador")
                throw new ArgumentException("Selecciona un rol configurable. Administrador conserva acceso completo.");
            if (!Modulos.Contains(acceso.NombreModulo))
                throw new ArgumentException("Selecciona un módulo válido.");
            if (datos.Listar().Any(x => x.CodigoRolAcceso != acceso.CodigoRolAcceso &&
                x.TipoUsuario == acceso.TipoUsuario && x.NombreModulo == acceso.NombreModulo))
                throw new ArgumentException("Ya existe un permiso para ese rol y módulo; edítalo.");
        }

    }
}
