namespace pika.modelo.gestiondocumental
{

    /// <summary>
    /// Corresponde a una instacia que permite la clasificación documental
    /// </summary>
    /*
     public class EntradaClasificacion : Entidad<string>, IEntidadNombrada,
        IEntidadEliminada
    */

    public class EntradaClasificacion 
    {

        public EntradaClasificacion()
        {
            /*
            ValoracionesEntrada = new HashSet<ValoracionEntradaClasificacion>();
            Activos = new HashSet<Activo>();
            */
        }

        /// <summary>
        ///  Identificador único del la entrada del cuadro de clasificación
        /// </summary>
        public  string Id { get; set; }



        /// <summary>
        /// Clave para la entrada del cuandro, generalmente comienza con la del elemento de clasificación
        /// </summary>
        public string Clave { get; set; }

        /// <summary>
        /// Nombre de la entrada
        /// </summary>
        public string Nombre { get; set; }

        /// <summary>
        /// Especifica los meses que debe permanecer el expediente o documento en el archivo de trámite una vez que ha sido cerrado
        /// </summary>
        public int VigenciaTramite { get; set; }


        /// <summary>
        /// Especifica los meses que debe permanecer el expediente o documento en el archivo de concentración una vez que ha sido cerrado
        /// </summary>
        public int VigenciaConcentracion { get; set; }



        /// <summary>
        /// La Descripcion para la entrada del cuandro, generalmente es el contenido de la entrada
        /// </summary>
        public string Descripcion { get; set; }


        public string AbreCon { get; set; }



        public string CierraCon { get; set; }


        public string Contiene { get; set; }


        public string InstruccionFinal { get; set; }

        /// <summary>
        /// Identificador único del tipo de disposición documental para la entrada
        /// </summary>
        public string TipoDisposicionDocumentalId { get; set; }

        /// <summary>
        /// Identificador único del elemento de clasificación al que pertenece la entrada
        /// </summary>
        public string ElementoClasificacionId { get; set; }



        /// <summary>
        /// Determina si la entrada del cuadro ha sido eliminada
        /// </summary>
        public bool Eliminada { get; set; }

        /// <summary>
        /// Determina la posición relativa del elemento en relación con los elementos del mismo nivle
        /// </summary>
        public int Posicion { get; set; }

        public string CuadroClasifiacionId { get; set; }

        
        public string NombreCompleto { get { return $"{Clave} {Nombre}"; } }

        /// <summary>
        /// propiedad receptora para el arreglo de ids de valoración documental
        /// </summary>
        
        public string[] TipoValoracionDocumentalId { get; set; }


        //[XmlIgnore]
        //[JsonIgnore]
        //public string[] Valoracionids { get; set; }
        public ICollection<ValoracionEntradaClasificacion> ValoracionesEntrada { get; set; }

        /// <summary>
        /// Activos del elemento clasificacion
        /// </summary>

        public virtual ICollection<Activo> Activos { get; set; }



        public List<Transferencia> Transferencias { get; set; }
        public virtual TipoDisposicionDocumental DisposicionEntrada { get; set; }


        public List<EstadisticaClasificacionAcervo> EstadisticasClasificacionAcervo { get; set; }
    }
}
