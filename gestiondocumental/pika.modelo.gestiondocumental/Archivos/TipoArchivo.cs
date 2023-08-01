namespace pika.modelo.gestiondocumental
{

    public enum ArchivoTipo
    {
        otro = 0, tramite =1, concentracion=2, historico=3
    }

    // public class TipoArchivo : EntidadCatalogo<string, TipoArchivo> 
    public class TipoArchivo 
    {
        
        public const string IDARCHIVO_TRAMITE = "a-tra";
        public const string IDARCHIVO_CONCENTRACION = "a-con";
        public const string IDARCHIVO_HISTORICO = "a-his";
        public const string IDARCHIVO_CORRESPONDENCIA = "a-cor";
        public TipoArchivo()
        {
          //  Archivos = new HashSet<Archivo>();
        }

      
        public  string Id { get; set; }

      
        public  string Nombre { get; set; }

   
       // public ArchivoTipo? Tipo { get; set; }


        /// <summary>
        /// Identificaor único del dominio al que pertenece el catáloco
        /// </summary>
        public string DominioId { get; set; }

        /// <summary>
        /// Identificaor único de la unidad  organizacional al que pertenece el catáloco
        /// </summary>
        public string UOId { get; set; }

        /*
        public  List<TipoArchivo> Seed()
        {
            List<TipoArchivo> l = new List<TipoArchivo>();
            // l.Add(new TipoArchivo() { Id = IDARCHIVO_CORRESPONDENCIA, Nombre = "Correspondencoia"});
            l.Add(new TipoArchivo() { Id = IDARCHIVO_TRAMITE, Nombre = "Trámite", Tipo = ArchivoTipo.tramite });
            l.Add(new TipoArchivo() { Id = IDARCHIVO_HISTORICO  , Nombre = "Histórico", Tipo = ArchivoTipo.historico});
            l.Add(new TipoArchivo() { Id = IDARCHIVO_CONCENTRACION , Nombre = "Concentración", Tipo = ArchivoTipo.concentracion });
            return l;
        }

      

        public IEnumerable<Archivo> Archivos { get; set; }

        
        public IEnumerable<Activo> Activos { get; set; }
        */
    }
}
