using pika.comun.metadatos.i18n;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pika.comun.metadatos
{
    public class Entidad
    {

        /// <summary>
        /// Identificador único de la entidad, para reflexi{on es el nombre completo del objeto 
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Nombre de la entidad o clave para internacionalización en la UI
        /// </summary>
        public string Nombre{ get; set; }

        /// <summary>
        /// Ruta relativa del endpoint en la API de PIKA
        /// </summary>
        public string? EndpointAPI { get; set; }

        /// <summary>
        /// Lista de propiedades de la entidad
        /// </summary>
        public List<Propiedad> Propiedades { get; set; } = new List<Propiedad>();

        /// <summary>
        /// Traducciones para la UI 
        /// </summary>
        public List<I18n>? I18n { get; set; }
    }
}
