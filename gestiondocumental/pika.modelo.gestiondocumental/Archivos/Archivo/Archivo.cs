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

        /// <summary>
        /// Nombre del archivo
        /// </summary>
        [Nombre]
        [Formulario(indice: 1, ancho: 100)]
        [Tabla(indice: 1)]
        public string Nombre { get; set; }

        /// <summary>
        /// Dominio al que pertenece el archivo
        /// </summary>
        [Protegido]
        public string DominioId { get; set; }

        /// <summary>
        /// Unidad organizacional a la que pertenece el archivo
        /// </summary>
        [Protegido]
        public string UOrgId { get; set; }

        /// <summary>
        /// Tipo de archivo del catálogo
        /// </summary>
        [UsoCatalogo(idCatalogo: nameof(TipoArchivo))]
        public string TipoArchivoId { get; set; }


        /// <summary>
        /// Propiedades de navegacion
        /// </summary>

        [JsonIgnore]
        [XmlIgnore]
        public TipoArchivo TipoArchivo { get; set; }
    }
}
