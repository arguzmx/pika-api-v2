using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pika.comun.metadatos
{
    public class ElementoLista
    {
        /// <summary>
        /// Identificador único del elemento de la lista
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Texto para despliegue humano del elemento
        /// </summary>
        public string Nombre { get; set; }

        /// <summary>
        /// Valor crudo del elemento
        /// </summary>
        public string Valor { get; set; }
        
        /// <summary>
        /// Posición relativa el elemento en el despliegue
        /// </summary>
        public int Posicion { get; set; }
    }
}
