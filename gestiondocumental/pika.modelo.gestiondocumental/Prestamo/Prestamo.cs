namespace pika.modelo.gestiondocumental
{
    // public class Prestamo: Entidad<string>, IEntidadEliminada, IEntidadReportes
    public class Prestamo
    {

       // public List<IProveedorReporte> Reportes { get; set; }

        public Prestamo() {
            /*
            ActivosRelacionados = new HashSet<ActivoPrestamo>();
            Comentarios = new HashSet<ComentarioPrestamo>();
            this.Reportes = new List<IProveedorReporte>();
            this.Reportes.Add(new ReportePrestamo());
            */
        }


        public string Id { get; set; }

        /// <summary>
        /// FEcha de creación del regiustro debe ser la fecha del sistema UTC, sin intervención del usuario
        /// </summary>
        public DateTime FechaCreacion { get; set; }

        /// <summary>
        /// Número de fplio del préstamo
        /// </summary>
        public string Folio { get; set; }

        /// <summary>
        ///  Número de elementos involucrados en el préstamo
        /// </summary>
        public int CantidadActivos { get; set; }


        /// <summary>
        /// Identificador del usuario destinatario del préstamo
        /// </summary>
        public string UsuarioDestinoId { get; set; }


        /// <summary>
        /// Fecha programda parala devolucion del preátsmo en formato UTC
        /// </summary>
        public DateTime FechaProgramadaDevolucion { get; set; }

        /// <summary>
        /// Fecha de devolución real del préstamo, este valor se establece sin intervención del  usuario 
        /// </summary>
        public DateTime? FechaDevolucion { get; set; }

        public string Descripcion { get; set; }


        /// <summary>
        /// ESTOS VALORES SE CALCULAR POR SISTEMA  EN BASE AL CONTROL DE PRESTAMO
        /// </summary>
        public bool Entregado { get; set; }

        /// <summary>
        /// Estupila si el préstamo ha sico devuelto en su totalidad
        /// </summary>
        public bool Devuelto { get; set; }

        /// <summary>
        /// Indica si ha habido devoluciones parciales del préstamo, sin intervención del usuario
        /// </summary>
        public bool TieneDevolucionesParciales { get; set; }


        /// <summary>
        /// Identificador único del usuario origen del prestamo
        /// </summary>
        public string UsuarioOrigenId { get; set; }


        public string TemaId { get; set; }


        /// <summary>
        /// Identificador único del archivo actual del activo
        /// ESTOS VALORES SE CALCULAR POR SISTEMA  EN BASE AL LOS PROCESOS DE TRASNFENRENCIA
        /// </summary>
        public string ArchivoId { get; set; }


        public bool Eliminada { get; set; }


        /*
        public Archivo Archivo { get; set; }

        public virtual ICollection<ActivoPrestamo> ActivosRelacionados { get; set; }


        public virtual ICollection<ComentarioPrestamo> Comentarios { get; set; }
        */
    }
}
