using pika.comun.metadatos.atributos;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace pika.modelo.gestiondocumental
{

    /// <summary>
    /// Cuadro de clasificación 
    /// </summary>
    
    /// <summary>
    /// DEfine un archivo para la gestión documental de su acervo
    /// </summary>
    [Entidad()]
    public class CuadroClasificacion 
    {
        /// <summary>
        /// Identificador únioc del cuadro de clasificación
        /// </summary>
        public string Id { get; set; }
        // [a] [d] 
        // R 128

        /// <summary>
        /// Nombre único del cuadro de clasificación
        /// </summary>
        public string Nombre { get ; set ; }
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

    }
}
