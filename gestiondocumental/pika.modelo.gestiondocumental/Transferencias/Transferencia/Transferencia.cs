using api.comunes.metadatos.atributos;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace pika.modelo.gestiondocumental;

[Entidad()]
public class Transferencia
{
    /// <summary>
    /// Identificador único interno para la transferencia
    /// </summary>
    public string Id { get; set; }
    // [a] [d] 
    // R 128


    /// <summary>
    /// Nombre asociado a la transferencia
    /// </summary>
    public string Nombre { get; set; }
    // [i] [a] [d] 
    // R 500

    /// <summary>
    /// Número de folio de la trasnferenci
    /// </summary>
    public string Folio { get; set; }
    // [i] [a] [d] 
    // 500

    /// <summary>
    /// Identificador único del árchivo origen
    /// </summary>
    public string ArchivoOrigenId { get; set; }
    // [i] [a] [d] 
    // R 128

    /// <summary>
    /// Identificador único del árchivo destino
    /// </summary>
    public string ArchivoDestinoId { get; set; }
    // [i] [a] [d] 
    // R 128

    /// <summary>
    /// Identificador del cuadro de clasificación asociado a la transferencia
    /// </summary>
    public string? CuadroClasificacionId { get; set; }
    // [i] [a] [d] 
    // 128

    /// <summary>
    /// Identificador único de la serie documental para la transferencia
    /// </summary>
    public string? SerieDocumentalId { get; set; }
    // [i] [a] [d] 
    // 128

    /// <summary>
    /// Número de días de vencimiento para permitir la adición de activos
    /// </summary>
    public int? RangoDias { get; set; }
    // [i] [a] [d] 


    /// <summary>
    ///  Número de elementos involucrados en la trasnferencia, este vlor se actualiza por el sistema
    /// </summary>
    public int CantidadActivos { get; set; } = 0;
    // [d] 

    /// <summary>
    /// Fechas de creación de la trasnfenrecia, este valor se calcula por el sistema
    /// </summary>
    public DateTime FechaCreacion { get; set; } = DateTime.UtcNow;
    // [d] 

    /// <summary>
    /// Estado actual de la trasnferencia, este valor se actualzia por el sistema
    /// </summary>
    public string EstadoTransferenciaId { get; set; }
    // [d] [i]
    // R 128

    /// <summary>
    /// Identificador único del usuario creador, este valor viene del contexto de datos de la transferencia
    /// </summary>
    public string UsuarioId { get; set; }
    // [d] 
    // R 128


    [XmlIgnore]
    [JsonIgnore]
    public virtual SerieDocumental SerieDocumental { get; set; }

    [XmlIgnore]
    [JsonIgnore]
    public virtual CuadroClasificacion CuadroClasificacion { get; set; }

    [XmlIgnore]
    [JsonIgnore]
    public virtual EstadoTransferencia Estado { get; set; }

    [XmlIgnore]
    [JsonIgnore]
    public virtual Archivo ArchivoOrigen { get; set; }

    [XmlIgnore]
    [JsonIgnore]
    public virtual Archivo ArchivoDestino { get; set; }

}
