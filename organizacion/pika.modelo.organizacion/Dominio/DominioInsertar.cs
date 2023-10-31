using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pika.modelo.organizacion
{
    public class DominioInsertar
    {
        /// <summary>
        /// Nombre único del volumen
        /// </summary>
        public string Nombre { get; set; }
        /// <summary>
        /// Determina si el dominio se encuentra activo
        /// </summary>
        public bool Activo { get; set; } = true;
    }
}
