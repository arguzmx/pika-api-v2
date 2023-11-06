using System.Text.Json.Serialization;
using System.Xml.Serialization;
using api.comunes.modelos.modelos;
using pika.comun.metadatos.atributos;
using pika.modelo.organizacion;

namespace pika.modelo.organizacion

{
    /// <summary>
    /// Relaciona un usuario con su dominio
    /// </summary>
   // [Entidad()]
    public class UsuarioDominio// : ElementoCatalogo
    {

        /// <summary>
        /// Identificador único de la relacióm
        /// </summary>
        public string Id { get; set; }
        // [d]
        // R [128]

        /// <summary>
        /// Identificador único del usuario, este viene del servicio de identidad
        /// </summary>
        public string UsuarioId { get; set; }
        // [i] [d]
        // R [128]

        /// <summary>
        /// Identificador único del dominio
        /// </summary>
        public string DominioId { get; set; }
        // [i] [d]
        // R [128]

        [JsonIgnore]
        [XmlIgnore]
        public Dominio Dominios { get; set; }

        // PAra esta entidad el método UPDATE no debe implmentarse

    }
}
