namespace pika.modelo.gestiondocumental
{
    //public class Activo : Entidad<string>, IEntidadRelacionada, IEntidadIdElectronico,
    //IEntidadEliminada, IEntidadReportes
    public class Activo 
    {
        public Activo()
        {
            //TipoOrigenId = TipoOrigenDefault;
            //HistorialArchivosActivo = new HashSet<HistorialArchivoActivo>();
            //Ampliaciones = new HashSet<Ampliacion>();
            //PrestamosRelacionados = new HashSet<ActivoPrestamo>();
            //TransferenciasRelacionados = new HashSet<ActivoTransferencia>();
            //this.Reportes = new List<IProveedorReporte>();
            //this.Reportes.Add(new ReporteCaratulaActivo());
        }

        public string Id { get; set ; }

        /// <summary>
        /// Identificador único del cuadro de clasificación, 
        /// Este se llena del lado del servidor
        /// </summary>
        public string CuadroClasificacionId { get; set; }

        /// <summary>
        /// Identificador único de la etraada de clasificación
        /// </summary>
        public string EntradaClasificacionId { get; set; }

        /// <summary>
        /// Nombre de la entrada de inventario por ejemplo el número de expediente
        /// </summary>
        public string Nombre { get; set; }

        /// <summary>
        /// ID Unico de la entrada de inventario por ejemplo el número de expediente
        /// </summary>
        public string IDunico { get; set; }

        /// <summary>
        /// Fecha de apertura UTC del activo
        /// </summary>
        public DateTime FechaApertura { get; set; }

        /// <summary>
        /// Fecha opcional de ciere del activo
        /// </summary>
        public DateTime? FechaCierre { get; set; }

        /// <summary>
        /// Asunto de la entrada de inventario
        /// </summary>
        public string Asunto { get; set; }

        /// <summary>
        /// Código de barras o QR de la entrada para ser leído por un scanner 
        /// </summary>
        public string CodigoOptico { get; set; }

        /// <summary>
        /// Código electrónico de acceso al elemento por ejemplo RFID
        /// </summary>
        public string CodigoElectronico { get; set; }

        /// <summary>
        /// Indica que el elemento se encuentra en formato electrónico desde su creación
        /// </summary>
        public bool EsElectronico { get; set; }

        /// <summary>
        /// Especifica si el activo se encuentra marcado como en reserva
        /// </summary>
        public bool Reservado { get; set; }

        /// <summary>
        /// Especifica si el activo se encuentra marcado como confidenxial
        /// </summary>
        public bool Confidencial { get; set; }

        public bool Eliminada { get; set; }
        
        public string UbicacionCaja { get; set; }

        public string UbicacionRack { get; set; }

        /// <summary>
        /// Establece el archivo en el que fue originado el activo
        /// </summary>
        public string ArchivoOrigenId { get; set; }

        /// <summary>
        /// Identificador único del archivo actual del activo
        /// ESTOS VALORES SE CALCULAR POR SISTEMA  EN BASE AL LOS PROCESOS DE TRASNFENRENCIA
        /// </summary>
        public string ArchivoId { get; set; }

        /// <summary>
        /// Establece la undiad administrativa a la que pertenece el activo
        /// </summary>
        
        // Para las unidades administrativas esta entidad no se despliega
      
        public string UnidadAdministrativaArchivoId { get; set; }

        /// <summary>
        /// ESTOS VALORES SE CALCULAR POR SISTEMA  EN BASE AL CONTROL DE PRESTAMO
        /// </summary>
        public bool EnPrestamo { get; set; }

        /// <summary>
        /// Especifica si el activo se encuentra marcado como en reserva
        /// </summary>
        public bool EnTransferencia { get; set; }

        /// <summary>
        /// Especifica si el activo tiene ampliaciones vigentes
        /// ESTOS VALORES SE CALCULAR POR SISTEMA  EN BASE A SI TIENE AMPLIACIONES ACTIVAS
        /// </summary>
        public bool Ampliado { get; set; }

        /// <summary>
        /// Fecha límite de retención calculada al cierre para el archivo de trámite
        /// ESTOS VALORES SE CALCULAR POR SISTEMA CUANDO SE ESTABLECE LA FECHA DE CIERRE
        /// </summary>
        public DateTime? FechaRetencionAT { get; set; }

        /// <summary>
        /// Fecha límite de retención calculada al cierre para el archivo de concentracion
        /// ESTOS VALORES SE CALCULAR POR SISTEMA CUANDO SE ESTABLECE LA FECHA DE CIERRE
        /// </summary>
        public DateTime? FechaRetencionAC { get; set; }
        
        public string AlmacenArchivoId { get; set; }

        public string ZonaAlmacenId { get; set; }
        
        public string ContenedorAlmacenId { get; set; }

        public DateTime?  FechaCreacion { get; set; }
       
        public string UsuarioId { get; set; }

        /// <summary>
        /// Los activos del inventario son propiedad de las unidades oragnizacionales
        /// y éstas a su vez pertenecen a un dominio lo que garantiza la cobertura de movivimentos
        /// </summary>
        // public string TipoOrigenDefault => ConstantesModelo.IDORIGEN_UNIDAD_ORGANIZACIONAL;

        /// <summary>
        /// En este ID 
        /// </summary>
        public string TipoOrigenId { get; set; }

        /// <summary>
        /// Alamcena el ID de la unidad organizaciónal creadora de la entrada
        public string OrigenId { get; set; }


        /// <summary>
        /// Propiedad para detrminar el tipo de archivo en el que se encuenra el activo
        /// </summary>
        public string TipoArchivoId { get; set; }
      
        public int? Vencidos { get; set; }

        public bool TieneContenido{ get; set; }
        
        public string ElementoId { get; set; }

        public CuadroClasificacion CuadroClasificacion { get; set; }
      
        public EntradaClasificacion EntradaClasificacion { get; set; }

        public Archivo ArchivoActual { get; set; }

        public Archivo ArchivoOrigen { get; set; }

        /// <summary>
        /// Historial de archivos por los que ha pasado el activo
        /// </summary>
        public virtual ICollection<HistorialArchivoActivo> HistorialArchivosActivo { get; set; }

        public virtual TipoArchivo TipoArchivo { get; set; }
        
        public virtual ICollection<Ampliacion> Ampliaciones { get; set; }
       
        public virtual ICollection<ActivoPrestamo> PrestamosRelacionados { get; set; }

        public virtual ICollection<ActivoTransferencia> TransferenciasRelacionados { get; set; }
        
        public virtual ICollection<ActivoSeleccionado> ActivosSeleccionados { get; set; }

        // public List<IProveedorReporte> Reportes { get; set; }

        public UnidadAdministrativaArchivo UnidadAdministrativa { get; set; }
    }
}
