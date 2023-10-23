using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace pika.modelo.gestiondocumental;

public class ActivoInsertar
{
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

    public string TipoArchivoActualId { get; set; }
    public string UnidadOrganizacionalId { get; set; }

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
    /// Ubicación de la caja que contiene al activo  en la ubicación de creación antes de ser movido al archivo de trámite
    /// Este valor se asigna como nulos cuando el activo se añade a una ubicación en un archivo fisico
    /// </summary>
    public string? UbicacionCaja { get; set; }

    /// <summary>
    /// Ubicación del rack que contiene al activo  en la ubicación de creación antes de ser movido al archivo de,
    /// Este valor se asigna como nulos cuando el activo se añade a una ubicación en un archivo fisico
    /// </summary>
    public string? UbicacionRack { get; set; }
}
