namespace pika.modelo.gestiondocumental
{
    public class EventoContenedorAlmacenMover
    {
        /// <summary>
        /// Identificaodr único del archivo origen del evento
        /// </summary>
        public string ArchivoOrigenId { get; set; }

        /// <summary>
        /// Identificador unico del almacen origen del evento
        /// </summary>
        public string AlmacenArchivoOrigenId { get; set; }

        /// <summary>
        /// Identificador unico de la zona origen del evento
        /// La zona del contenedor es opcional
        /// </summary>
        public string ZonaAlmacenOrigenId { get; set; }

        /// <summary>
        /// Identificador unico de la posición origen del evento
        /// </summary>
        public string PosicionAlmacenOrigenId { get; set; }

        /// <summary>
        /// Identificaodr único del archivo origen del evento
        /// </summary>
        public string ArchivoDestinoId { get; set; }

        /// <summary>
        /// Identificador unico del almacen origen del evento
        /// </summary>
        public string AlmacenArchivoDestinoId { get; set; }

        /// <summary>
        /// Identificador unico de la zona origen del evento
        /// La zona del contenedor es opcional
        /// </summary>
        public string ZonaAlmacenDestinoId { get; set; }

        /// <summary>
        /// Identificador unico de la posición origen del evento
        /// </summary>
        public string PosicionAlmacenDestinoId { get; set; }
    }
}
