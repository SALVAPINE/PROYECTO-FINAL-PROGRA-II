using System;
using System.Collections.Generic;
using System.Linq;
using Datos;
using Entidad;

namespace Negocio
{
    /// <summary>
    /// Capa de negocio de materiales: validaciones y reglas; llama a la capa de datos.
    /// </summary>
    public class MaterialNegocio
    {
        private readonly MaterialDatos datos = new MaterialDatos();

        public List<Material> Listar()
        {
            return datos.Listar();
        }

        public List<Material> Buscar(string texto, string estado)
        {
            return datos.Buscar(texto, estado);
        }

        public int Insertar(Material material)
        {
            Validar(material);
            return datos.Insertar(material);
        }

        public int Actualizar(Material material)
        {
            Validar(material);
            if (material.CodigoMaterial <= 0)
                throw new ArgumentException("Selecciona un material válido para editar.");
            return datos.Actualizar(material);
        }

        public int Eliminar(int codigo)
        {
            if (codigo <= 0)
                throw new ArgumentException("Selecciona un material válido para eliminar.");
            return datos.Eliminar(codigo);
        }

        private static void Validar(Material material)
        {
            if (material == null)
                throw new ArgumentException("No se recibieron los datos del material.");
            if (material.CodigoOrdenTrabajo <= 0)
                throw new ArgumentException("Selecciona una orden de trabajo.");
            if (string.IsNullOrWhiteSpace(material.NombreMaterial) || material.NombreMaterial.Length > 45)
                throw new ArgumentException("El nombre del material es obligatorio y admite hasta 45 caracteres.");
            if (string.IsNullOrWhiteSpace(material.TipoDeMaterial) || material.TipoDeMaterial.Length > 45)
                throw new ArgumentException("El tipo de material es obligatorio y admite hasta 45 caracteres.");
            if (string.IsNullOrWhiteSpace(material.UnidadMedida) || material.UnidadMedida.Length > 45)
                throw new ArgumentException("La unidad de medida es obligatoria y admite hasta 45 caracteres.");
            if (string.IsNullOrWhiteSpace(material.CategoriaMaterial) || material.CategoriaMaterial.Length > 45)
                throw new ArgumentException("La categoría es obligatoria y admite hasta 45 caracteres.");
            if (material.CostoMaterial < 0)
                throw new ArgumentException("El costo del material no puede ser negativo.");
        }

        /// <summary>Resumen del módulo (se muestra en la pestaña Resumen).</summary>
        public ResumenModulo ObtenerResumen()
        {
            List<Material> lista = datos.Listar() ?? new List<Material>();
            ResumenModulo r = new ResumenModulo();
            r.Total = lista.Count;
            r.TituloEstado = "Registros por estado";
            r.PorEstado = ResumenHelper.Contar(lista.Select(x => x.Estado ? "Activo" : "Inactivo"), new string[] { "Activo", "Inactivo" }, 0);
            r.TituloCategoria = "Materiales por categoría";
            r.PorCategoria = ResumenHelper.Contar(lista.Select(x => x.CategoriaMaterial), new string[] {  }, 6);
            return r;
        }
    }
}
