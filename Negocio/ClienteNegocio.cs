using System;
using System.Collections.Generic;
using System.Linq;
using Datos;
using Entidad;

namespace Negocio
{
    /// <summary>Coordina las consultas y prepara el resumen con todos los clientes.</summary>
    public class ClienteNegocio
    {
        private readonly ClienteDatos datos = new ClienteDatos();

        public List<Cliente> Buscar(string texto, string estado)
        {
            return datos.Buscar(texto, estado);
        }

        public ResumenModulo ObtenerResumen()
        {
            List<Cliente> lista = datos.Listar();
            ResumenModulo resumen = new ResumenModulo();
            resumen.Total = lista.Count;
            resumen.TituloEstado = "Registros por estado";
            resumen.PorEstado = ResumenHelper.Contar(
                lista.Select(cliente => cliente.Estado ? "Activo" : "Inactivo"),
                new string[] { "Activo", "Inactivo" }, 0);
            resumen.TituloCategoria = resumen.TituloEstado;
            resumen.PorCategoria = resumen.PorEstado;
            return resumen;
        }
        // Se validan los campos antes de pedir a Datos que guarde el cliente.
        public int Agregar(Cliente cliente)
        {
            if (cliente == null) throw new ArgumentNullException("cliente");
            if (string.IsNullOrWhiteSpace(cliente.NombreCliente) || cliente.NombreCliente.Trim().Length > 45)
                throw new ArgumentException("El nombre es obligatorio y admite máximo 45 caracteres.");
            if (string.IsNullOrWhiteSpace(cliente.Direccion) || cliente.Direccion.Trim().Length > 150)
                throw new ArgumentException("La dirección es obligatoria y admite máximo 150 caracteres.");
            if (cliente.DPI <= 0 || cliente.DPI > 9999999999999L || cliente.Edad <= 0 || cliente.Telefono <= 0)
                throw new ArgumentException("El DPI debe ser positivo y tener hasta 13 dígitos; edad y teléfono deben ser enteros positivos.");
            if (cliente.NIT.HasValue && cliente.NIT.Value <= 0)
                throw new ArgumentException("El NIT debe ser positivo o dejarse vacío.");
            return datos.Insertar(cliente);
        }

        // La clave primaria se valida antes de enviar la actualización a Datos.
        public int Editar(Cliente cliente)
        {
            if (cliente == null) throw new ArgumentNullException("cliente");
            if (cliente.CodigoCliente <= 0)
                throw new ArgumentException("El código del cliente no es válido.");
            if (string.IsNullOrWhiteSpace(cliente.NombreCliente) || cliente.NombreCliente.Trim().Length > 45)
                throw new ArgumentException("El nombre es obligatorio y admite máximo 45 caracteres.");
            if (string.IsNullOrWhiteSpace(cliente.Direccion) || cliente.Direccion.Trim().Length > 150)
                throw new ArgumentException("La dirección es obligatoria y admite máximo 150 caracteres.");
            if (cliente.DPI <= 0 || cliente.DPI > 9999999999999L || cliente.Edad <= 0 || cliente.Telefono <= 0)
                throw new ArgumentException("El DPI debe ser positivo y tener hasta 13 dígitos; edad y teléfono deben ser enteros positivos.");
            if (cliente.NIT.HasValue && cliente.NIT.Value <= 0)
                throw new ArgumentException("El NIT debe ser positivo o dejarse vacío.");
            return datos.Actualizar(cliente);
        }

        public int Eliminar(int codigoCliente)
        {
            if (codigoCliente <= 0)
                throw new ArgumentException("Selecciona un cliente válido.");
            return datos.Eliminar(codigoCliente);
        }

    }
}
