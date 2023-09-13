namespace pika.modelo.gestiondocumental
{
    public class TemaActivos
    {
        public TemaActivos() {
           // ActivosSeleccionados = new HashSet<ActivoSeleccionado>();
        }

        public string Id { get; set; }
        public string UsuarioId { get; set; }
        public string Nombre { get; set; }
        public virtual IEnumerable<ActivoSeleccionado> ActivosSeleccionados { get; set; }
    }
}
