using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace pika.modelo.organizacion
{
    /// <summary>
    /// Las unidades organizacionales agrupan recursos para la organización del trabajo
    /// </summary>
    public class UnidadOrganizacional
    {
        
        /// <summary>
        /// Identificador único de la UI
        /// </summary>
        public string Id { get;; set; }
        // [a] [d] 
        // R 128

        /// <summary>
        /// NOmbre de la unodad organizacional
        /// </summary>
        public string Nombre {get; set;}
        // [i] [a] [d] 
        // R 128

        /// <summary>
        /// Identiicador único del cominio al que se asocia la UO
        /// </summary>
        public string DominioId { get; set; }
        // [i] [a] [d] 
        // R 128

        [JsonIgnore]
        [XmlIgnore]
        public Dominio Dominio { get; set; }


        [XmlIgnore]
        [JsonIgnore]
        public List<UsuarioUnidadOrganizacional> UsuariosUnidad { get; set; }

    }
}
