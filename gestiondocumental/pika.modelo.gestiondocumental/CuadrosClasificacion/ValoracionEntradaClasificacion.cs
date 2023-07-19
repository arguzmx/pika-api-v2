namespace pika.modelo.gestiondocumental
{
    public class ValoracionEntradaClasificacion
    {
        /// <summary>
        /// Identificaor único de la entrada del clasificación
        /// </summary>
        public string EntradaClasificacionId { get; set; }

        /// <summary>
        /// Identificaor único del tipo de valoraión para la entarda
        /// </summary>
        public string TipoValoracionDocumentalId { get; set; }

        public EntradaClasificacion EntradaClasificacion { get; set; }

        public TipoValoracionDocumental TipoValoracionDocumental { get; set; }
    }
}
