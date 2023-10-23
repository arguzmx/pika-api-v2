using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pika.modelo.gestiondocumental;

public class ActivoDespliegue
{
    /// <summary>
    /// Identificador único del activo, se genera al insertar
    /// </summary>
    public string Id { get; set; }

    /// <summary>
    /// Identificador único del cuadro de clasificación, 
    /// Este se llena del lado del servidor
    /// </summary>
    public string CuadroClasificacionId { get; set; }

    /// <summary>
    /// Identificador único de la serie doccumental
    /// </summary>
    public string SerieDocumentalId { get; set; }

    /// <summary>
    /// Establece el archivo en el que fue originado el activo, generalmente es un archivo de trámite
    /// </summary>
    public string ArchivoOrigenId { get; set; }

    /// <summary>
    /// Identificador único del archivo actual del activo, esta propiedad se asigna automáticamente an la creación
    /// y es idéntica al archivo de origen y se ajusta cuando ocurre una transferencia
    /// </summary>
    public string ArchivoActualId { get; set; } 

    /// <summary>
    /// Propiedad para determinar el tipo de archivo en el que se encuenra el activo, 
    /// esta propiedad se calcula de manera automática al establecer el archivo actual id
    /// </summary>
    public string TipoArchivoActualId { get; set; }

    /// <summary>
    /// Establece la undiad administrativa a la que pertenece el activo
    /// </summary>
    public string UnidadAdministrativaId { get; set; }

    /// <summary>
    /// Nombre de la entrada de inventario por ejemplo el número de expediente
    /// </summary>
    public string Nombre { get; set; }

    /// <summary>
    /// ID de maenjo interno de la entrada de inventario en el acervo por ejemplo 
    /// el folio de un sistema de gestión interna
    /// </summary>
    public string? IdentificadorInterno { get; set; }

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
    public string? Asunto { get; set; }

    /// <summary>
    /// Código de barras o QR de la entrada para ser leído por un scanner 
    /// </summary>
    public string? CodigoOptico { get; set; }

    /// <summary>
    /// Código electrónico de acceso al elemento por ejemplo RFID
    /// </summary>
    public string? CodigoElectronico { get; set; }

    /// <summary>
    /// Indica que el elemento se encuentra en formato electrónico desde su creación
    /// </summary>
    public bool EsElectronico { get; set; } = false;

    /// <summary>
    /// Especifica si el activo se encuentra marcado como en reserva, esta campo se activa automáticamente cuando el activo
    /// tiene al menos una reserva y se inactiva cuando no tiene reservas o las fechas de reserva han sido excedidas
    /// </summary>
    public bool Reservado { get; set; } = false;

    /// <summary>
    /// Especifica si el activo se encuentra marcado como confidenxia, se calcula al ingresar el Id del activo 
    /// a la lista de activos confidenciales
    /// </summary>
    public bool Confidencial { get; set; } = false;

    /// <summary>
    /// Ubicación de la caja que contiene al activo  en la ubicación de creación antes de ser movido al archivo de trámite
    /// Este valor se asigna como nulos cuando el activo se añade a una ubicación en un archivo fisico
    /// </summary>
    public string? UbicacionCaja { get; set; }

    /// <summary>
    /// Ubicación del rack que contiene al activo  en la ubicación de creación antes de ser movido al archivo de,
    /// Este valor se asigna como nulos cuando el activo se añade a una ubicación en un archivo fisico
    /// </summary>
    public string? UbicacionRack { get; set; }

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
    public DateTime FechaCreacion { get; set; } = DateTime.UtcNow;

    /// <summary>
    /// USuario creador del activo
    /// </summary>
    public string UsuarioId { get; set; }
}
