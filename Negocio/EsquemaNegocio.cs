using System;
using System.Collections.Generic;
using Datos;

namespace Negocio
{
    /// <summary>Entrega a Presentación los nombres reales de las columnas de una tabla.</summary>
    public class EsquemaNegocio
    {
        private readonly EsquemaDatos datos = new EsquemaDatos();

        public List<string> ListarColumnas(string tabla)
        {
            if (string.IsNullOrWhiteSpace(tabla))
                throw new ArgumentException("Indica la tabla que se va a consultar.", "tabla");
            return datos.ListarColumnas(tabla);
        }
    }
}
