using System.Collections.Generic;
using System;
using System.Linq;
using Datos;
using Entidad;

namespace Negocio
{
    /// <summary>
    /// Capa de negocio de sucursales: validaciones y reglas; llama a la capa de datos.
    /// </summary>
    public class SucursalNegocio
    {
        private readonly SucursalDatos datos = new SucursalDatos();

        public List<Sucursal> Listar()
        {
            return datos.Listar();
        }

        public List<Sucursal> Buscar(string texto, bool? estado)
        {
            return datos.Buscar(texto, estado);
        }

        public int Insertar(Sucursal sucursal)
        {
            if (sucursal == null)
                throw new ArgumentNullException("sucursal");

            if (string.IsNullOrWhiteSpace(sucursal.NombreSucursal) || sucursal.NombreSucursal.Length > 45)
                throw new ArgumentException("El nombre es obligatorio y admite hasta 45 caracteres.");
            if (string.IsNullOrWhiteSpace(sucursal.Direccion) || sucursal.Direccion.Length > 150)
                throw new ArgumentException("La dirección es obligatoria y admite hasta 150 caracteres.");
            if (string.IsNullOrWhiteSpace(sucursal.Municipio) || sucursal.Municipio.Length > 100)
                throw new ArgumentException("El municipio es obligatorio y admite hasta 100 caracteres.");
            if (string.IsNullOrWhiteSpace(sucursal.Departamento) || sucursal.Departamento.Length > 100)
                throw new ArgumentException("El departamento es obligatorio y admite hasta 100 caracteres.");
            if (sucursal.HorarioDeAtencion < TimeSpan.Zero || sucursal.HorarioDeAtencion >= TimeSpan.FromDays(1))
                throw new ArgumentException("El horario debe ser una hora válida del día.");

            return datos.Insertar(sucursal);
        }

        public int Actualizar(Sucursal sucursal)
        {
            if (sucursal == null)
                throw new ArgumentNullException("sucursal");
            if (sucursal.CodigoSucursal <= 0)
                throw new ArgumentException("Selecciona una sucursal válida para editar.");
            if (string.IsNullOrWhiteSpace(sucursal.NombreSucursal) || sucursal.NombreSucursal.Length > 45)
                throw new ArgumentException("El nombre es obligatorio y admite hasta 45 caracteres.");
            if (string.IsNullOrWhiteSpace(sucursal.Direccion) || sucursal.Direccion.Length > 150)
                throw new ArgumentException("La dirección es obligatoria y admite hasta 150 caracteres.");
            if (string.IsNullOrWhiteSpace(sucursal.Municipio) || sucursal.Municipio.Length > 100)
                throw new ArgumentException("El municipio es obligatorio y admite hasta 100 caracteres.");
            if (string.IsNullOrWhiteSpace(sucursal.Departamento) || sucursal.Departamento.Length > 100)
                throw new ArgumentException("El departamento es obligatorio y admite hasta 100 caracteres.");
            if (sucursal.HorarioDeAtencion < TimeSpan.Zero || sucursal.HorarioDeAtencion >= TimeSpan.FromDays(1))
                throw new ArgumentException("El horario debe ser una hora válida del día.");

            return datos.Actualizar(sucursal);
        }

        public int Eliminar(int codigo)
        {
            if (codigo <= 0)
                throw new ArgumentException("Selecciona una sucursal válida para eliminar.");

            return datos.Eliminar(codigo);
        }

        /// <summary>Resumen del módulo (se muestra en la pestaña Resumen).</summary>
        public ResumenModulo ObtenerResumen()
        {
            List<Sucursal> lista = datos.Listar() ?? new List<Sucursal>();
            ResumenModulo r = new ResumenModulo();
            r.Total = lista.Count;
            r.TituloEstado = "Registros por estado";
            r.PorEstado = ResumenHelper.Contar(lista.Select(x => x.Estado ? "Activo" : "Inactivo"), new string[] { "Activo", "Inactivo" }, 0);
            r.TituloCategoria = "Sucursales por departamento";
            r.PorCategoria = ResumenHelper.Contar(lista.Select(x => x.Departamento), new string[] {  }, 6);
            return r;
        }
    }
}
