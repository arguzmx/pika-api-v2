namespace pika.modelo.gestiondocumental
{
    /// <summary>
    /// Define un contenedor para la guarda de los activos del acervo por ejemplo una caja de archivo
    /// </summary>

    // public class ContenedorAlmacen : Entidad<string>, IEntidadNombrada, IEntidadReportes
    public class ContenedorAlmacen 
    {
      
        //public List<IProveedorReporte> Reportes { get; set; }
        public ContenedorAlmacen()
        {
            /*
            EventosContenedor = new List<EventoContenedorAlmacen>();
            this.Reportes = new List<IProveedorReporte>();
            this.Reportes.Add(new ReporteCaratulaContenedorAlmacen());
            */
        }
        
 
        public string Id { get; set; }

        /// <summary>
        /// Nomnbre del contenedor para refeencia humana puede ser el mismo que la clave
        /// </summary>
        public string Nombre { get; set; }

        /// <summary>
        /// Codigo de barras asociado
        /// </summary>
        public string CodigoBarras { get; set; }

        /// <summary>
        /// Codigo electrónico asociado
        /// </summary>
        public string CodigoElectronico { get; set; }

        /// <summary>
        /// Porcentaje de ocupación del contenedor
        /// </summary>
        public decimal Ocupacion { get; set; }

        /// <summary>
        /// Identificador unico de la zona en el que se ubica el contenedor
        /// La zona del contenedor es opcional
        /// </summary>
        public string ZonaAlmacenId { get; set; }

        /// <summary>
        /// Identificador unico de la posición en la que se ubica el contenedor
        /// EL contenedor puede no estar asociado a una posición puede esta solamente en una zona por ejemplo FUMIGACION
        /// </summary>
        public string PosicionAlmacenId { get; set; }

        /// <summary>
        /// Identificaodr único del archivo en el que se ubica el contenedor
        /// </summary>
        public string ArchivoId { get; set; }

        /// <summary>
        /// Identificador unico del almacen en el que se ubica el contenedor
        /// </summary>
        public string AlmacenArchivoId { get; set; }

        /*
        public PosicionAlmacen Posicion { get; set; }



        public ZonaAlmacen Zona { get; set; }


        public AlmacenArchivo Almacen { get; set; }



        public Archivo Archivo { get; set; }


        public List<EventoContenedorAlmacen> EventosContenedor { get; set; }


        public List<ActivoContenedorAlmacen> Activos { get; set; }
        */
    }
}
