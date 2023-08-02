namespace pika.modelo.gestiondocumental
{
    /// <summary>
    /// Vincula a los usuarios con los diferentes roles
    /// </summary>

    public class ActivoContenedorAlmacen
    {
        public ActivoContenedorAlmacen()
        {

        }
        /// <summary>
        /// Identificador único del rol
        /// </summary>
        public string ContenedorAlmacenId { get; set; }

        /// <summary>
        /// Identificador único del usuario
        /// </summary>
        public string ActivoId { get; set; }

       // public ContenedorAlmacen ContenedorAlmacen { get; set; }

    }
}
