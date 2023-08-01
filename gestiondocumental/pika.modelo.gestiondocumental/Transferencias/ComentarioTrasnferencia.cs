﻿namespace pika.modelo.gestiondocumental
{

    /// <summary>
    /// PErmite la adición de comenatrios a la trasnferencia
    /// </summary>

    //public class ComentarioTransferencia: Entidad<string>, IEntidadUsuario
    public class ComentarioTransferencia
    {
        public string Id { get; set; }

        /// <summary>
        /// Identificador único de la transferencia relacionada
        /// </summary>
        public string TransferenciaId { get; set; }

        /// <summary>
        /// Identificador único del usuario que lo creó
        /// </summary>
        public string UsuarioId { get; set; }

        /// <summary>
        /// Fecha del comentario UTC
        /// </summary>
        public DateTime Fecha { get; set; }


        /// <summary>
        /// Comentario realizado
        /// </summary>
        public string Comentario { get; set; }

        /// <summary>
        /// Indica si el comenatrio pueden visualizarlo otros usuarios del sistema
        /// </summary>
        public bool Publico { get; set; }

     //   public Transferencia Transferencia { get; set; }

    }
}
