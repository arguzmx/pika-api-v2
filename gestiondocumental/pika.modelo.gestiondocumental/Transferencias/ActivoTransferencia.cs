namespace pika.modelo.gestiondocumental
{

    /// <summary>
    /// Mantien las relaciómn da activos incluidos en una transferenci
    /// </summary>
    /// 
    public class ActivoTransferencia
    {
        /// <summary>
        /// Identtificaor unico del reistro
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Identificador único del activo
        /// </summary>
        public string ActivoId { get; set; }

        /// <summary>
        /// Identificador único del activo
        /// </summary>
        public string Notas { get; set; }

        /// <summary>
        /// Identificador único de la trasnfernecia
        /// </summary>
        public string TransferenciaId { get; set; }


        /// <summary>
        /// Especifica si un activo es declinado en la transferencia
        /// </summary>
        public bool Declinado { get; set; }


        /// <summary>
        /// Especifica si un activo es aceptado por el archivo receptor 
        /// </summary>
        public bool Aceptado { get; set; }


        /// <summary>
        /// Fecha en la que se emitió el voto para aceptar o declinar
        /// </summary>
        public DateTime? FechaVoto { get; set; }

        /// <summary>
        /// Fecha en la que se emitió el voto para aceptar o declinar
        /// </summary>
        public DateTime FechaRetencion { get; set; }



        public string CuadroClasificacionId { get; set; }



        public string EntradaClasificacionId { get; set; }

        /// <summary>
        /// Especifica si un activo es declinado en la transferencia
        /// </summary>
        public string MotivoDeclinado { get; set; }


        /// <summary>
        /// Identificador único del usuario que añadió el activo
        /// </summary>
        public string UsuarioId{ get; set; }

        /// <summary>
        /// Identificador único del usuario que acepta o declina el activos
        /// </summary
        public string UsuarioReceptorId { get; set; }



        public Activo Activo { get; set; }

        public Transferencia Transferencia { get; set; }
    }
}
