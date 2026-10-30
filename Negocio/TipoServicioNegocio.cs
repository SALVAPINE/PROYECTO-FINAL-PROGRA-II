using System.Collections.Generic;
using System.Linq;
using Datos;
using Entidad;

namespace Negocio
{
    /// <summary>
    /// Capa de negocio de tipos de servicio: validaciones y reglas; llama a la capa de datos.
    /// </summary>
    public class TipoServicioNegocio
    {
        private readonly TipoServicioDatos datos = new TipoServicioDatos();

        public List<TipoServicio> Listar()
        {
            return datos.Listar();
        }

        public List<TipoServicio> Buscar(string texto, bool? estado)
        {
            return datos.Buscar(texto, estado);
        }

        public int Insertar(TipoServicio tipoServicio)
        {
            ValidarTipoServicio(tipoServicio, false);
            return datos.Insertar(tipoServicio);
        }

        public int Actualizar(TipoServicio tipoServicio)
        {
            ValidarTipoServicio(tipoServicio, true);
            return datos.Actualizar(tipoServicio);
        }

        public int Eliminar(int codigo)
        {
            if (codigo <= 0)
                throw new System.ArgumentException("Selecciona un tipo de servicio válido para eliminar.");

            return datos.Eliminar(codigo);
        }

        // Valida longitudes y precisión que coinciden con el esquema confirmado.
        private static void ValidarTipoServicio(TipoServicio tipoServicio, bool requiereCodigo)
        {
            if (tipoServicio == null)
                throw new System.ArgumentNullException("tipoServicio");
            if (requiereCodigo && tipoServicio.CodigoTipoServicio <= 0)
                throw new System.ArgumentException("Selecciona un tipo de servicio válido para editar.");
            if (string.IsNullOrWhiteSpace(tipoServicio.NombreServicio) || tipoServicio.NombreServicio.Length > 45)
                throw new System.ArgumentException("El nombre es obligatorio y admite hasta 45 caracteres.");
            if (string.IsNullOrWhiteSpace(tipoServicio.Descripcion) || tipoServicio.Descripcion.Length > 150)
                throw new System.ArgumentException("La descripción es obligatoria y admite hasta 150 caracteres.");

            ValidarDecimal(tipoServicio.CostoServicio, "costo");
            ValidarDecimal(tipoServicio.RecargoServicio, "recargo");
            tipoServicio.TotalServicio = decimal.Round(
                tipoServicio.CostoServicio + tipoServicio.RecargoServicio, 2);
            ValidarDecimal(tipoServicio.TotalServicio, "total");
        }

        private static void ValidarDecimal(decimal valor, string campo)
        {
            if (valor < -99999999.99m || valor > 99999999.99m || decimal.Round(valor, 2) != valor)
                throw new System.ArgumentException("El " + campo + " debe tener hasta 8 enteros y 2 decimales.");
        }

        /// <summary>Resumen del módulo (se muestra en la pestaña Resumen).</summary>
        public ResumenModulo ObtenerResumen()
        {
            List<TipoServicio> lista = datos.Listar() ?? new List<TipoServicio>();
            ResumenModulo r = new ResumenModulo();
            r.Total = lista.Count;
            r.TituloEstado = "Registros por estado";
            r.PorEstado = ResumenHelper.Contar(lista.Select(x => x.Estado ? "Activo" : "Inactivo"), new string[] { "Activo", "Inactivo" }, 0);
            r.TituloCategoria = r.TituloEstado;
            r.PorCategoria = r.PorEstado;
            return r;
        }
    }
}
