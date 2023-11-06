using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pika.modelo.organizacion
{
    public class UnidadOrganizacionalDespliegue
    {
        /// <summary>
        /// Identificador único de la UI
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// NOmbre de la unodad organizacional
        /// </summary>
        public string Nombre { get; set; }

        /// <summary>
        /// Identiicador único del cominio al que se asocia la UO
        /// </summary>
        public string DominioId { get; set; }
    }
}
