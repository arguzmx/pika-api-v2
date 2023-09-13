namespace pika.modelo.gestiondocumental
{
    public class ActivoPrestamo
    {

        public ActivoPrestamo() { }

        /// <summary>
        /// Identtificaor unico del reistros
        /// </summary>
        public string Id { get; set; }


        /// <summary>
        /// Clave principal
        /// </summary>
        public string PrestamoId { get; set; }

        /// <summary>
        /// Clave principal
        /// </summary>
        public string ActivoId { get; set; }

        /// <summary>
        /// Indica si el elemento de prestamo ha sido devuelto
        /// ESTOS VALORES SE CALCULAR POR SISTEMA  EN BASE AL CONTROL DE PRESTAMO
        /// </summary>
        public bool Devuelto { get; set; }

        /// <summary>
        /// Fecha en la que el elemento fue devuelto en formato UTC
        /// </summary>
        /// 

        /*
        public DateTime? FechaDevolucion { get; set; }

        public Activo Activo { get; set; }

        public Prestamo Prestamo { get; set; }
        */

    }
}
