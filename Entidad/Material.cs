namespace Entidad
{
    public class Material
    {
        public int CodigoMaterial { get; set; }
        public int CodigoOrdenTrabajo { get; set; }
        public string NombreMaterial { get; set; }
        public string TipoDeMaterial { get; set; }
        public string UnidadMedida { get; set; }
        public string CategoriaMaterial { get; set; }
        public decimal CostoMaterial { get; set; }
        public bool Estado { get; set; }
    }
}
