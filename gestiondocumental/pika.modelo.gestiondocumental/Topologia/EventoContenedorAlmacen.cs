namespace pika.modelo.gestiondocumental
{
    // public class EventoContenedorAlmacen: Entidad<long>
    public class EventoContenedorAlmacen
    {
        public long Id { get; set; }
        public string UsuarioId { get; set; }
        public string ProcesoId { get; set; }
        public bool EsAccionUsuario { get; set; }
        public DateTime Fecha { get; set; }
        public TipEventoContenedorAlmacen TipoEvento { get; set; }
        public string ContenedorAlmacenId { get; set; }
        public string Payload { get; set; }

        public ContenedorAlmacen ContenedorAlmacen { get; set; }

    }
}
