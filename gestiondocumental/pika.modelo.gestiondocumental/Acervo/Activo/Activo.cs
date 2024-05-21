#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
using api.comunes.metadatos.atributos;
using pika.modelo.gestiondocumental.UnidadesAdministrativas;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace pika.modelo.gestiondocumental;

/// <summary>
/// Activo del acervo de una unidad adminitrativa gestionado por un archivo
/// </summary>
 [Entidad()]
public class Activo
{

    /// <summary>
    /// Identificador único del activo, se genera al insertar
    /// </summary>
    [Id]
    [Formulario(indice: 1, visible: false)]
    [Tabla(indice: 0, visible: false)]
    public string Id { get; set; }
    // [a] [d] 
    // R 128

    /// <summary>
    /// Identificador único del cuadro de clasificación, 
    /// Este se llena del lado del servidor
    /// </summary>
    [Tabla(indice: 0, visible: true)]
    [UsoCatalogoAttribute("CuadroClasificacion", true)]
    public string CuadroClasificacionId { get; set; }
    // [i] [a] [d]
    // R 128

    /// <summary>
    /// Identificador único de la serie doccumental
    /// </summary>
    public string SerieDocumentalId { get; set; }
    // [i] [a] [d]
    // R 128

    /// <summary>
    /// Establece el archivo en el que fue originado el activo, generalmente es un archivo de trámite
    /// </summary>
    public string ArchivoOrigenId { get; set; }
    // [i] [a]  [d]
    // R 128

    /// <summary>
    /// Identificador único del archivo actual del activo, esta propiedad se asigna automáticamente an la creación
    /// y es idéntica al archivo de origen y se ajusta cuando ocurre una transferencia
    /// </summary>
    public string ArchivoActualId { get; set; } //preguntar como proceder
    // [i] [a]  [d]
    // R 128

    /// <summary>
    /// Propiedad para determinar el tipo de archivo en el que se encuenra el activo, 
    /// esta propiedad se calcula de manera automática al establecer el archivo actual id
    /// </summary>
    public string TipoArchivoActualId { get; set; }
    // [d]
    // R 128

    /// <summary>
    /// Establece la undiad administrativa a la que pertenece el activo
    /// </summary>
    public string UnidadAdministrativaId { get; set; }
    // [i] [a] [d]
    // R 128

    /// <summary>
    /// Nombre de la entrada de inventario por ejemplo el número de expediente
    /// </summary>
    [Nombre]
    [Formulario(indice: 1, ancho: 100)]
    [Tabla(indice: 1)]
    public string Nombre { get; set; }
    // [i] [a] [d]
    // R 500


    /// <summary>
    /// ID de maenjo interno de la entrada de inventario en el acervo por ejemplo 
    /// el folio de un sistema de gestión interna
    /// </summary>
    public string? IdentificadorInterno { get; set; }
    // [i] [a] [d]
    // 500


    /// <summary>
    /// Fecha de apertura UTC del activo
    /// </summary>
    public DateTime FechaApertura { get; set; }
    // [i] [a] [d]
    // R

    /// <summary>
    /// Fecha opcional de ciere del activo
    /// </summary>
    public DateTime? FechaCierre { get; set; }
    // [i] [a] [d]


    /// <summary>
    /// Asunto de la entrada de inventario
    /// </summary>
    public string? Asunto { get; set; }
    // [i] [a] [d]
    // 2000


    /// <summary>
    /// Código de barras o QR de la entrada para ser leído por un scanner 
    /// </summary>
    public string? CodigoOptico { get; set; }
    // [i] [a] [d]
    // 500

    /// <summary>
    /// Código electrónico de acceso al elemento por ejemplo RFID
    /// </summary>
    public string? CodigoElectronico { get; set; }
    // [i] [a] [d]
    // 500

    /// <summary>
    /// Indica que el elemento se encuentra en formato electrónico desde su creación
    /// </summary>
    public bool EsElectronico { get; set; } = false;
    // [i] [a] [d]
    // R

    /// <summary>
    /// Especifica si el activo se encuentra marcado como en reserva, esta campo se activa automáticamente cuando el activo
    /// tiene al menos una reserva y se inactiva cuando no tiene reservas o las fechas de reserva han sido excedidas
    /// </summary>
    public bool Reservado { get; set; } = false;
    // [d]
    // R


    /// <summary>
    /// Especifica si el activo se encuentra marcado como confidenxia, se calcula al ingresar el Id del activo 
    /// a la lista de activos confidenciales
    /// </summary>
    public bool Confidencial { get; set; } = false;
    // [d]
    // R

    /// <summary>
    /// Ubicación de la caja que contiene al activo  en la ubicación de creación antes de ser movido al archivo de trámite
    /// Este valor se asigna como nulos cuando el activo se añade a una ubicación en un archivo fisico
    /// </summary>
    public string? UbicacionCaja { get; set; }
    // [i] [a] [d]
    // 200

    /// <summary>
    /// Ubicación del rack que contiene al activo  en la ubicación de creación antes de ser movido al archivo de,
    /// Este valor se asigna como nulos cuando el activo se añade a una ubicación en un archivo fisico
    /// </summary>
    public string? UbicacionRack { get; set; }
    // [i] [a] [d]
    // 200


    /// <summary>
    /// Determina si el activo se ecnuentra en préstamo
    /// </summary>
    public bool EnPrestamo { get; set; } = false;
    //  [d]
    // R

    /// <summary>
    /// Especifica si el activo se encuentra involucrado en una transferencia
    /// </summary>
    public bool EnTransferencia { get; set; } = false;
    // [d]
    // R

    /// <summary>
    /// Especifica si el activo tiene ampliaciones vigentes
    /// </summary>
    public bool Ampliado { get; set; } = false;
    //  [d]
    // R


    /// <summary>
    /// Fecha límite de retención calculada al cierre para el archivo de trámite
    /// </summary>
    public DateTime? FechaRetencionAT { get; set; }
    // [d]

    /// <summary>
    /// Fecha límite de retención calculada al cierre para el archivo de concentracion
    /// </summary>
    public DateTime? FechaRetencionAC { get; set; }
    // [d]

    /// <summary>
    /// Especifica si el archivo se encuentra asociado a un almacen físico
    /// </summary>
    public string? AlmacenArchivoId { get; set; }
    // [d]
    // 128

    /// <summary>
    /// Zona del almacén físico donde se ubica el activo
    /// </summary>
    public string? ZonaAlmacenId { get; set; }
    // [d]
    // 128

    /// <summary>
    /// Contenedor del almacén fisico donde se ubica el activo
    /// </summary>
    public string? ContenedorAlmacenId { get; set; }
    // [d]
    // 128

    /// <summary>
    /// FEcha de creacion del activo
    /// </summary>
    public DateTime FechaCreacion { get; set; } = DateTime.UtcNow;
    // [d]
    // R

    /// <summary>
    /// USuario creador del activo
    /// </summary>
    public string UsuarioId { get; set; }
    // [d]
    // R 128

    /// <summary>
    /// Identificador único de la unidad organizacional a la que pertenece el activo
    /// </summary>
    [Protegido]
    public string UnidadOrganizacionalId { get; set; }
    // R 128

    /// <summary>
    /// Identificador único del dominio al que pertenece el activo
    /// </summary>
    [Protegido]
    public string DominioId { get; set; }
    // R 128

    /// <summary>
    /// Días de vencimineto restantes para la trasnferenia del archivo actual, se calcula
    /// en base a la feha actual cuntroa la fecha de cierre
    /// </summary>
    [NotMapped]
    public int? DiasTransferir { get; set; }


    /// <summary>
    /// Indica si ela activo tiene contenido asociado, por ejemplo imágemes digitalizadas
    /// </summary>
    public bool TieneContenido { get; set; } = false;
    // R

    /// <summary>
    /// Identificador del elemento de contenido asociado al activo en caso de existir
    /// Este id se vincula con el microservicio de administración de contenido
    /// </summary>
    public string? ContenidoId { get; set; }
    // 128


    [JsonIgnore]
    [XmlIgnore]
    public UnidadAdministrativa UnidadAdministrativa { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public TipoArchivo TipoArchivoActual { get; set; }


    [JsonIgnore]
    [XmlIgnore]
    public Archivo ArchivoActual { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public Archivo ArchivoOrigen { get; set; }


    [JsonIgnore]
    [XmlIgnore]
    public SerieDocumental SerieDocumental { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public CuadroClasificacion CuadroClasificacion { get; set; }

}
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.