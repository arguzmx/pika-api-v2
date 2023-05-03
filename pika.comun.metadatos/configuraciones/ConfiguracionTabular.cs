using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pika.comun.metadatos.configuraciones
{
    public class ConfiguracionTabular
    {
        /// <summary>
        /// Posición o número de columna en el despliegue tabular si MostrarEnTabla es true 
        /// </summary>
        public int Indice { get; set; }

        /// <summary>
        /// Determina si la propiedad se muestra en el despliegue tabular
        /// </summary>
        public bool MostrarEnTabla { get; set; }

        /// <summary>
        /// Determina si la propiedad puede alternar su visibilidad en el despliegue tabular
        /// </summary>
        public bool AlternarEnTabla { get; set; }
    }
}
