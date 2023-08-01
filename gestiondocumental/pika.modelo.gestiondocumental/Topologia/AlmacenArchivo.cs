namespace pika.modelo.gestiondocumental
{
    /// <summary>
    /// Define un espacio físico asociado al archivo donde se almacenan los activo físicos
    /// </summary>

    //public class AlmacenArchivo : Entidad<string>, IEntidadNombrada
    public class AlmacenArchivo 
    {
        public AlmacenArchivo()
        {
            /*
            Zonas = new List<ZonaAlmacen>();
            Posiciones = new List<PosicionAlmacen>();
            Contenedores = new List<ContenedorAlmacen>();
            */
        }


        public string Id { get; set; }

        /// <summary>
        /// Nombre único del almacén
        /// </summary>
        public string Nombre { get; set; }

        /// <summary>
        /// Clave asociada al arhchvi en la organización
        /// </summary>
        public string Clave { get; set; }

        /// <summary>
        /// Identificador único del archivo al qu pertenece el almacen
        /// </summary>
        public string ArchivoId { get; set; }

        /// <summary>
        /// Ubicación física del archivo por ejemplo una dirección
        /// </summary>
        public string  Ubicacion { get; set; }


        /// <summary>
        /// Folio actual para la creacion de contenedores
        /// </summary>
        public int FolioActualContenedor { get; set; }

        /// <summary>
        /// Cadena para la generación automática de contenedores
        /// </summary>
        public string  MacroFolioContenedor { get; set; }

        /// <summary>
        /// Determina si el foliado esta atcivo al crear contenedores en el almacen
        /// </summary>
        public bool HabilitarFoliado { get; set; }

       /*
        public Archivo Archivo { get; set; }


        public List<ZonaAlmacen> Zonas { get; set; }


        public List<PosicionAlmacen> Posiciones { get; set; }


        public List<ContenedorAlmacen> Contenedores { get; set; }
       */
    }
}
