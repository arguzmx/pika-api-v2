namespace pika.modelo.gestiondocumental
{
    //  public class TipoAmpliacion: EntidadCatalogo<string, TipoAmpliacion>
    public class TipoAmpliacion
    {
        public TipoAmpliacion() {
           // this.Ampliaciones = new HashSet<Ampliacion>();
        }
        public const string RESERVA = "reserva";
        public const string CONFIDENCIALIDAD = "confidencialidad";
        public const string SOLICITUD_INFORMACION = "solicitud-informacion";
       
        public  string Id { get; set; }
       
        public  string Nombre { get; set; }

        /// <summary>
        /// Identificaor único del dominio al que pertenece el catáloco
        /// </summary>
        public string DominioId { get; set; }

        /// <summary>
        /// Identificaor único de la unidad  organizacional al que pertenece el catáloco
        /// </summary>
        public string UOId { get; set; }

        public List<TipoAmpliacion> Seed()
        {
            List<TipoAmpliacion> lista = new List<TipoAmpliacion>();
            lista.Add(new TipoAmpliacion() { Id = RESERVA, Nombre = "Reserva" });
            lista.Add(new TipoAmpliacion() { Id = CONFIDENCIALIDAD, Nombre = "Confidencialidad" });
            lista.Add(new TipoAmpliacion() { Id = SOLICITUD_INFORMACION, Nombre = "Solicitud de información" });
            return lista;
        }

        public ICollection<Ampliacion> Ampliaciones { get; set; }
    }
}
