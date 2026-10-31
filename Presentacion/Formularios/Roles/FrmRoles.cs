using Negocio;

namespace SistemaPublicidad.Formularios
{
    public class FrmRoles : FrmModulo
    {
        public FrmRoles() : base(Configuracion()) { }
        static ModuloCfg Configuracion()
        {
            SesionActual.ExigirAdministrador();
            return Modulos.Obtener("Roles", "\uE77B", 0);
        }
    }
}
