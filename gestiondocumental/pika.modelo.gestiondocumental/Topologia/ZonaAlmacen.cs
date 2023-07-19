namespace pika.modelo.gestiondocumental
{
    //   public class ZonaAlmacen : Entidad<string>, IEntidadNombrada
    public class ZonaAlmacen 
    {

        public ZonaAlmacen()
        {
            /*
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
        /// Identificaodr único del archivo al qu pertenece la zona
        /// </summary>
        public string ArchivoId { get; set; }


        /// <summary>
        /// Identificador unico del almacen al que pertenece la zona
        /// </summary>
        public string AlmacenArchivoId { get; set; }



        public AlmacenArchivo Almacen { get; set; }


        public Archivo Archivo { get; set; }

     
        public List<PosicionAlmacen> Posiciones { get; set; }


        public List<ContenedorAlmacen> Contenedores { get; set; }
    }
}
