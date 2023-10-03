using pika.comun.metadatos.atributos;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace pika.modelo.gestiondocumental
{
    /// <summary>
    /// DEfine un archivo para la gestión documental de su acervo
    /// </summary>
    [Entidad()]
    public class Archivo
    {
        /// <summary>
        /// Identificador único del archivo
        /// </summary>
        [Id]
        [Formulario(indice: 1, visible: false)]
        [Tabla(indice: 1, visible: false)]
        public string Id { get; set; }
        // [a] [d] 
        // R 128

        /// <summary>
        /// Nombre del archivo
        /// </summary>
        [Nombre]
        [Formulario(indice: 1, ancho: 100)]
        [Tabla(indice: 1)]
        public string Nombre { get; set; }
        // [i] [a] [d] 
        // R 500

        /// <summary>
        /// Dominio al que pertenece el archivo
        /// </summary>
        [Protegido]
        public string DominioId { get; set; }
        // Este valor simpre viene del contexto
        // R 128

        /// <summary>
        /// Unidad organizacional a la que pertenece el archivo
        /// </summary>
        [Protegido]
        public string UOrgId { get; set; }
        //  Este valor simpre viene del contexto
        // R 128

        /// <summary>
        /// Tipo de archivo del catálogo
        /// </summary>
        [UsoCatalogo(idCatalogo: nameof(TipoArchivo))]
        public string TipoArchivoId { get; set; }
        // [i] [a]
        // R 128

        /// <summary>
        /// Propiedades de navegacion
        /// </summary>

        [JsonIgnore]
        [XmlIgnore]
        public TipoArchivo TipoArchivo { get; set; }

        [JsonIgnore]
        [XmlIgnore]
        public List<Prestamo> Prestamos { get; set; }

        [JsonIgnore]
        [XmlIgnore]
        public List<UnidadAdministrativa>? UnidadesAdministrativasTramite { get; set; }

        [JsonIgnore]
        [XmlIgnore]
        public List<UnidadAdministrativa>? UnidadesAdministrativasConcentracion { get; set; }

        [JsonIgnore]
        [XmlIgnore]
        public List<UnidadAdministrativa>? UnidadesAdministrativasHistorico { get; set; }

    }
}
