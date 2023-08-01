namespace pika.modelo.gestiondocumental
{
    // public class EventoTransferencia: Entidad<string>
    public class EventoTransferencia
    {
        /// <summary>
        /// Identificado único de la trásnferencia
        /// </summary>
        public string TransferenciaId { get; set; }

        /// <summary>
        /// Fecha de registro del estado UTC
        /// </summary>
        public DateTime Fecha { get; set; }

        /// <summary>
        /// IDentificador único del estado para el evento
        /// </summary>
        public string EstadoTransferenciaId { get; set; }

        /// <summary>
        /// Comentarios relacionados con el estado
        /// </summary>
        public string Comentario { get; set; }

        /// <summary>
        /// Identificador del usuario responsable del evento
        /// </summary>
        public string UsuarioId { get; set; }

        /*
        public EstadoTransferencia Estado { get; set; }

        public Transferencia Transferencia { get; set; }
        */
    }
}
