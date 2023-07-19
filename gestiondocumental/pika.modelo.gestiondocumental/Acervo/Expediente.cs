namespace pika.modelo.gestiondocumental
{
    public class Expediente
    {
        public Expediente() {
          //  Documentos = new HashSet<Documento>();
        }

        public ICollection<Documento> Documentos { get; set; }
    }
}
