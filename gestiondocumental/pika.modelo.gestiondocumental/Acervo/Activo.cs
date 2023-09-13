#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
namespace pika.modelo.gestiondocumental
{
    //public class Activo : Entidad<string>, IEntidadRelacionada, IEntidadIdElectronico,
    //IEntidadEliminada, IEntidadReportes

    public class Activo
    {

        /// <summary>
        /// Identificador único del activo, se genera al insertar
        /// </summary>
        public string Id { get; set; }
        // [A]

        /// <summary>
        /// Identificador único del cuadro de clasificación, 
        /// Este se llena del lado del servidor
        /// </summary>

        public string CuadroClasificacionId { get; set; }
                              // [I] [A]

        /// <summary>
        /// Identificador único de la serie doccumental
        /// </summary>
        public string SerieDocumentalId { get; set; }
        // [I] [A]


        /// <summary>
        /// Nombre de la entrada de inventario por ejemplo el número de expediente
        /// </summary>
        public string Nombre { get; set; }
        // [I] [A]


        /// <summary>
        /// ID Unico de la entrada de inventario por ejemplo el número de expediente
        /// </summary>
        public string? IDunico { get; set; }
        // [I] [A]


        /// <summary>
        /// Fecha de apertura UTC del activo
        /// </summary>
        public DateTime FechaApertura { get; set; }
        // [I] [A]


        /// <summary>
        /// Fecha opcional de ciere del activo
        /// </summary>
        public DateTime? FechaCierre { get; set; }
        // [I] [A]


        /// <summary>
        /// Asunto de la entrada de inventario
        /// </summary>
        public string? Asunto { get; set; }
        // [I] [A]


        /// <summary>
        /// Código de barras o QR de la entrada para ser leído por un scanner 
        /// </summary>
        public string? CodigoOptico { get; set; }
        // [I] [A]


        /// <summary>
        /// Código electrónico de acceso al elemento por ejemplo RFID
        /// </summary>
        public string? CodigoElectronico { get; set; }
        // [I] [A]


        /// <summary>
        /// Indica que el elemento se encuentra en formato electrónico desde su creación
        /// </summary>
        public bool EsElectronico { get; set; } = false;
        // [I] [A]


        /// <summary>
        /// Especifica si el activo se encuentra marcado como en reserva, esta campo se activa automáticamente cuando el activo
        /// tiene al menos una reserva y se inactiva cuando no tiene reservas o las fechas de reserva han sido excedidas
        /// </summary>
        public bool Reservado { get; set; } = false;
        


        /// <summary>
        /// Especifica si el activo se encuentra marcado como confidenxial
        /// </summary>
        public bool Confidencial { get; set; } = false;
        // [I] [A]


        /// <summary>
        /// Ubicación de la caja que contiene al activo  en la ubicación de creación antes de ser movido al archivo de trámite
        /// Este valor se asigna como nulos cuando el activo se añade a una ubicación en un archivo fisico
        /// </summary>
        public string? UbicacionCaja { get; set; }
        // [I] [A]


        /// <summary>
        /// Ubicación del rack que contiene al activo  en la ubicación de creación antes de ser movido al archivo de,
        /// Este valor se asigna como nulos cuando el activo se añade a una ubicación en un archivo fisico
        /// </summary>
        public string? UbicacionRack { get; set; }
        // [I] [A]


        /// <summary>
        /// Establece el archivo en el que fue originado el activo, generalmente es un archivo de trámite
        /// </summary>
        public string ArchivoOrigenId { get; set; }
        // [I] [A] 


        /// <summary>
        /// Identificador único del archivo actual del activo, esta propiedad se asigna automáticamente an la creación
        /// y es idéntica al archivo de origen y se ajusta cuando ocurre una transferencia
        /// </summary>
        public string ArchivoActualId { get; set; }


        /// <summary>
        /// Establece la undiad administrativa a la que pertenece el activo
        /// </summary>
        public string UnidadAdministrativaArchivoId { get; set; }


        /// <summary>
        /// Determina si el activo se ecnuentra en préstamo
        /// </summary>
        public bool EnPrestamo { get; set; } = false;

        /// <summary>
        /// Especifica si el activo se encuentra involucrado en una transferencia
        /// </summary>
        public bool EnTransferencia { get; set; } = false;

        /// <summary>
        /// Especifica si el activo tiene ampliaciones vigentes
        /// </summary>
        public bool Ampliado { get; set; } = false;

        /// <summary>
        /// Fecha límite de retención calculada al cierre para el archivo de trámite
        /// </summary>
        public DateTime? FechaRetencionAT { get; set; }

        /// <summary>
        /// Fecha límite de retención calculada al cierre para el archivo de concentracion
        /// </summary>
        public DateTime? FechaRetencionAC { get; set; }

        /// <summary>
        /// Especifica si el archivo se encuentra asociado a un almacen físico
        /// </summary>
        public string? AlmacenArchivoId { get; set; }

        /// <summary>
        /// Zona del almacén físico donde se ubica el activo
        /// </summary>
        public string? ZonaAlmacenId { get; set; }

        /// <summary>
        /// Contenedor del almacén fisico donde se ubica el activo
        /// </summary>
        public string? ContenedorAlmacenId { get; set; }

        /// <summary>
        /// FEcha de creacion del activo
        /// </summary>
        public DateTime FechaCreacion { get; set; }

        /// <summary>
        /// USuario creador del activo
        /// </summary>
        public string UsuarioId { get; set; }

        /// <summary>
        /// Identificador único de la unidad organizacional a la que pertenece el activo
        /// </summary>
        public string UnidadOrganizacionalId { get; set; }

        /// <summary>
        /// Identificador único del dominio al que pertenece el activo
        /// </summary>
        public string DominioId { get; set; }

        /// <summary>
        /// Propiedad para detrminar el tipo de archivo en el que se encuenra el activo
        /// </summary>
        public string TipoArchivoActualId { get; set; }

        /// <summary>
        /// Días vendidos del activo
        /// </summary>
        public int? Vencidos { get; set; }

        /// <summary>
        /// Indica si ela activo tiene contenido asociado
        /// </summary>
        public bool TieneContenido { get; set; } = false;

        /// <summary>
        /// Identificador del elemento de contenido asociado al activo en caso de existir
        /// </summary>
        public string? ElementoId { get; set; }
   



        //public CuadroClasificacion CuadroClasificacion { get; set; }
      
        //public EntradaClasificacion EntradaClasificacion { get; set; }

        //public Archivo ArchivoActual { get; set; }

        //public Archivo ArchivoOrigen { get; set; }

        ///// <summary>
        ///// Historial de archivos por los que ha pasado el activo
        ///// </summary>
        //public virtual ICollection<HistorialArchivoActivo> HistorialArchivosActivo { get; set; }

        //public virtual TipoArchivo TipoArchivo { get; set; }
        
        //public virtual ICollection<Ampliacion> Ampliaciones { get; set; }
       
        //public virtual ICollection<ActivoPrestamo> PrestamosRelacionados { get; set; }

        //public virtual ICollection<ActivoTransferencia> TransferenciasRelacionados { get; set; }
        
        //public virtual ICollection<ActivoSeleccionado> ActivosSeleccionados { get; set; }

        //// public List<IProveedorReporte> Reportes { get; set; }

        //public UnidadAdministrativaArchivo UnidadAdministrativa { get; set; }
    }
}
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.