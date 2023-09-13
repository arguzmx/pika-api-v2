namespace pika.modelo.gestiondocumental
{
    public class ActivoSeleccionado
    {
        public string  UsuarioId { get; set; }
        public string TemaId { get; set; }
        public string Id { get; set; }
        public Activo  Activo { get; set; }
        public TemaActivos TemaActivos { get; set; }
    }
}
