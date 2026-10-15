using System.Collections.Generic;
using System.Linq;
using Datos;
using Entidad;

namespace Negocio
{
    /// <summary>
    /// Capa de negocio de proveedores: validaciones y reglas; llama a la capa de datos.
    /// </summary>
    public class ProveedorNegocio
    {
        private readonly ProveedorDatos datos = new ProveedorDatos();

        public List<Proveedor> Listar()
        {
            return datos.Listar();
        }

        public List<Proveedor> Buscar(string texto, bool? estado)
        {
            return datos.Buscar(texto, estado);
        }

        public int Insertar(Proveedor proveedor)
        {
            ValidarProveedor(proveedor, false);
            return datos.Insertar(proveedor);
        }

        public int Actualizar(Proveedor proveedor)
        {
            ValidarProveedor(proveedor, true);
            return datos.Actualizar(proveedor);
        }

        public int Eliminar(int codigo)
        {
            if (codigo <= 0)
                throw new System.ArgumentException("Selecciona un proveedor válido para eliminar.");

            return datos.Eliminar(codigo);
        }

        // Revisa campos obligatorios y límites conforme al esquema de SQL Server.
        private static void ValidarProveedor(Proveedor proveedor, bool requiereCodigo)
        {
            if (proveedor == null)
                throw new System.ArgumentNullException("proveedor");
            if (requiereCodigo && proveedor.CodgioProveedor <= 0)
                throw new System.ArgumentException("Selecciona un proveedor válido para editar.");
            if (string.IsNullOrWhiteSpace(proveedor.NombreProveedor) || proveedor.NombreProveedor.Length > 45)
                throw new System.ArgumentException("El nombre es obligatorio y admite hasta 45 caracteres.");
            if (string.IsNullOrWhiteSpace(proveedor.Correo) || proveedor.Correo.Length > 150)
                throw new System.ArgumentException("El correo es obligatorio y admite hasta 150 caracteres.");
            if (string.IsNullOrWhiteSpace(proveedor.TipoProveedor) || proveedor.TipoProveedor.Length > 45)
                throw new System.ArgumentException("El tipo de proveedor es obligatorio y admite hasta 45 caracteres.");
            if (string.IsNullOrWhiteSpace(proveedor.Direccion) || proveedor.Direccion.Length > 150)
                throw new System.ArgumentException("La dirección es obligatoria y admite hasta 150 caracteres.");
        }

        /// <summary>Resumen del módulo (se muestra en la pestaña Resumen).</summary>
        public ResumenModulo ObtenerResumen()
        {
            List<Proveedor> lista = datos.Listar() ?? new List<Proveedor>();
            ResumenModulo r = new ResumenModulo();
            r.Total = lista.Count;
            r.TituloEstado = "Registros por estado";
            r.PorEstado = ResumenHelper.Contar(lista.Select(x => x.Estado ? "Activo" : "Inactivo"), new string[] { "Activo", "Inactivo" }, 0);
            r.TituloCategoria = "Proveedores por tipo";
            r.PorCategoria = ResumenHelper.Contar(lista.Select(x => x.TipoProveedor), new string[] {  }, 6);
            return r;
        }
    }
}
