using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace pika.modelo.contenido;

/// <summary>
/// Representa una carpeta para el arrglo lógico del conteido
/// </summary>
public class Carpeta
{
    /// <summary>
    ///  Identificdor únio del volumen
    ///  Se obtiene con GUID new
    /// </summary>
    public string Id { get; set; }
    // [a] [d] 
    // R 128

    /// <summary>
    /// Identificador del punto de montaje asociado a la carpeta
    /// </summary>
    public string RepositorioId { get; set; }
    // [i] 
    // R 128

    /// <summary>
    /// Identificador único del creador de la carpeta
    /// </summary>
    public string CreadorId { get; set; }
    // [d] Este valor simpre viene del contexto del id en el JWT
    // R 128

    /// <summary>
    /// FEcha de creación en formato UTC
    /// </summary>
    public DateTime FechaCreacion { get; set; }
    // [d]
    // Este valor simpre viene del contexto se crea de la fecha del sistema al insertar y sólo se despliega


    /// <summary>
    /// Nombre para la carpeta 
    /// </summary>
    public string Nombre { get; set; }
    // [i] [a] [d]
    // R 512

    /// <summary>
    /// Identificador de la carpeta padre de la actual 
    /// </summary>
    public string? CarpetaPadreId { get; set; }
    // [i] [a] [d]
    // 128 

    /// <summary>
    /// Determina si la carpeta es un nodo raíz
    /// </summary>
    public bool EsRaiz { get; set; }
    // Se calcula automaticamente, si carpeta padre id es nulo entonces EsRaiz = true, false en caso contrario


    /// <summary>
    /// Popieadd de navegacion para RepositorioId
    /// </summary>
    [XmlIgnore]
    [JsonIgnore]
    public Repositorio Repositorio { get; set; }

}
