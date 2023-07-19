namespace pika.modelo.gestiondocumental
{
    // public class TipoDisposicionDocumental : EntidadCatalogo<string, TipoDisposicionDocumental>
    public class TipoDisposicionDocumental 
    {
        public TipoDisposicionDocumental()
        {
           // EntradaClasificacion = new HashSet<EntradaClasificacion>();
        }

        public const string SELECCION_COMPLETA = "seleccion-completa";
        public const string ELIMINACION_COMPLETA = "eliminacion-completa";
        public const string MUESTREO = "muestreo";
        public const string CAMBIO_SOPORTE = "cambio-soporte";


        public string Id { get; set; }

        public string Nombre { get; set; }

        /// <summary>
        /// Identificaor único del dominio al que pertenece el catáloco
        /// </summary>
        public string DominioId { get; set; }

        /// <summary>
        /// Identificaor único de la unidad  organizacional al que pertenece el catáloco
        /// </summary>
        public string UOId { get; set; }

        public  List<TipoDisposicionDocumental> Seed()
        {
            List<TipoDisposicionDocumental> lista = new List<TipoDisposicionDocumental>();

            lista.Add(new TipoDisposicionDocumental() { Id = SELECCION_COMPLETA, Nombre = "Selección completa para histórico" });
            lista.Add(new TipoDisposicionDocumental() { Id = ELIMINACION_COMPLETA, Nombre = "Eliminación completa del acervo" });
            lista.Add(new TipoDisposicionDocumental() { Id = MUESTREO, Nombre = "Muestreo para conservación histórica" });
            lista.Add(new TipoDisposicionDocumental() { Id = CAMBIO_SOPORTE, Nombre = "Cambio de medio de soporte, microfilmación o digitalización" });

            return lista;
        }

        public ICollection<EntradaClasificacion> EntradaClasificacion { get; set; }
    }
}
