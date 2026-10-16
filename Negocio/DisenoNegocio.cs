using System.Collections.Generic;
using System;
using System.Linq;
using Datos;
using Entidad;

namespace Negocio
{
    /// <summary>
    /// Capa de negocio de diseños: validaciones y reglas; llama a la capa de datos.
    /// </summary>
    public class DisenoNegocio
    {
        private readonly DisenoDatos datos = new DisenoDatos();

        public List<Diseno> Listar()
        {
            return datos.Listar();
        }

        public List<Diseno> Buscar(string texto, string estado)
        {
            bool? estadoSeleccionado = null;
            if (estado == "Activo")
                estadoSeleccionado = true;
            else if (estado == "Inactivo")
                estadoSeleccionado = false;

            return datos.Buscar(texto, estadoSeleccionado);
        }

        public List<Cliente> ListarClientes()
        {
            return datos.ListarClientes();
        }

        public List<Disenador> ListarDisenadores()
        {
            return datos.ListarDisenadores();
        }

        public int Insertar(Diseno diseno)
        {
            Validar(diseno);
            return datos.Insertar(diseno);
        }

        public int Actualizar(Diseno diseno)
        {
            Validar(diseno);
            if (diseno.CodigoDiseño <= 0)
                throw new ArgumentException("El código del diseño que se editará no es válido.");
            return datos.Actualizar(diseno);
        }

        public int Eliminar(int codigo)
        {
            if (codigo <= 0)
                throw new ArgumentException("El código del diseño que se eliminará no es válido.");
            return datos.Eliminar(codigo);
        }

        private static void Validar(Diseno diseno)
        {
            if (diseno == null)
                throw new ArgumentNullException("diseno", "No se recibieron los datos del diseño.");
            if (diseno.CodigoCliente <= 0)
                throw new ArgumentException("Selecciona un cliente válido.");
            if (diseno.CodigoDiseñador <= 0)
                throw new ArgumentException("Selecciona un diseñador válido.");
            if (string.IsNullOrWhiteSpace(diseno.NombreDiseño) || diseno.NombreDiseño.Length > 45)
                throw new ArgumentException("El nombre del diseño es obligatorio y admite hasta 45 caracteres.");
            if (string.IsNullOrWhiteSpace(diseno.TipoDiseño) || diseno.TipoDiseño.Length > 45)
                throw new ArgumentException("El tipo de diseño es obligatorio y admite hasta 45 caracteres.");
            if (string.IsNullOrWhiteSpace(diseno.Descripcion) || diseno.Descripcion.Length > 150)
                throw new ArgumentException("La descripción es obligatoria y admite hasta 150 caracteres.");
            if (string.IsNullOrWhiteSpace(diseno.RangoDiseño) || diseno.RangoDiseño.Length > 45)
                throw new ArgumentException("El rango del diseño es obligatorio y admite hasta 45 caracteres.");
        }

        /// <summary>Resumen del módulo (se muestra en la pestaña Resumen).</summary>
        public ResumenModulo ObtenerResumen()
        {
            List<Diseno> lista = datos.Listar() ?? new List<Diseno>();
            ResumenModulo r = new ResumenModulo();
            r.Total = lista.Count;
            r.TituloEstado = "Registros por estado";
            r.PorEstado = ResumenHelper.Contar(lista.Select(x => x.Estado ? "Activo" : "Inactivo"), new string[] { "Activo", "Inactivo" }, 0);
            r.TituloCategoria = "Diseños por tipo";
            r.PorCategoria = ResumenHelper.Contar(lista.Select(x => x.TipoDiseño), new string[] {  }, 6);
            return r;
        }
    }
}
