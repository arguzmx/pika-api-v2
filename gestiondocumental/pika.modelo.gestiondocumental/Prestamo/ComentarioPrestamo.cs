namespace pika.modelo.gestiondocumental
{
    //  public class ComentarioPrestamo : Entidad<string>
    public class ComentarioPrestamo 
    {


        /// <summary>
        /// FEcha de creación del comentario
        /// </summary>
        public DateTime Fecha { get; set; }

        /// <summary>
        /// TExto del Comentario
        /// </summary>
        public string  Comentario { get; set; }
        //# lungitod 2048


        /// <summary>
        /// Identificador del préstamo al que pertenece el comentario
        /// </summary>
        public string PrestamoId { get; set; }


        /// <summary>
        /// Préstamo al que pertenece el comentario
        /// </summary>

       // public Prestamo Prestamo { get; set; }
    }
}
