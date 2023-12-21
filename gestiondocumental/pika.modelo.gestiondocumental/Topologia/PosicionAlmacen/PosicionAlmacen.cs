using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace pika.modelo.gestiondocumental.Topologia;

/// <summary>
/// DEfine una posición física dentro de una  zona del almacen
/// </summary>
public class PosicionAlmacen 
{


    /// <summary>
    /// Identificador único de la posición
    /// </summary>
    public string Id { get ; set ; }
    // [a] [d] 
    // R 128

    /// <summary>
    /// Nombre único de la posición de almacén
    /// </summary>
    public string Nombre { get; set; }
    // [i] [a] [d] 
    // R 500

    /// <summary>
    /// Indice de la posicion en la posición padre, 
    /// esta es útil cuando un rack tiene varias posiciones el nombre permanece constante y sólo cambia el indice
    /// </summary>
    public int Indice { get; set; } = 0;
    // [i] [a] [d] 
    

    /// <summary>
    /// Localización de la posición de almacén
    /// </summary>
    public string? Localizacion { get; set; }
    // [i] [a] [d] 


    /// <summary>
    /// Codigo de barras asociado
    /// </summary>
    public string? CodigoBarras { get; set; }
    // [i] [a] [d] 


    /// <summary>
    /// Codigo electrónico asociado
    /// </summary>
    public string? CodigoElectronico { get; set; }
    // [i] [a] [d] 


    /// <summary>
    /// Porcentaje de ocupación de la posición
    /// </summary>
    public decimal Ocupacion { get; set; } = 0;
    // [i] [a] [d] 

    /// <summary>
    /// Incremento automático de porcentaje de ocupación de la posición al adiconar o remover un contenedor
    /// </summary>
    public decimal IncrementoContenedor { get; set; } = 0;
    // [i] [a] [d] 


    /// <summary>
    /// Identificaodr único del archivo al qu pertenece la posición
    /// </summary>
    public string ArchivoId { get; set; }
    // [i] [d] 
    // R 128

    /// <summary>
    /// Identificador unico del almacen al que pertenece la posición
    /// </summary>
    public string AlmacenArchivoId { get; set; }
    // [i] [d] 
    // R 128

    /// <summary>
    /// Identificador unico de la zona a la que pertenece la posición
    /// </summary>
    public string ZonaAlmacenId { get; set; }
    // [i] [d] 
    // R 128


    [XmlIgnore]
    [JsonIgnore]
    public ZonaAlmacen Zona { get; set; }

    [XmlIgnore]
    [JsonIgnore]
    public AlmacenArchivo Almacen { get; set; }


    [XmlIgnore]
    [JsonIgnore]
    public Archivo Archivo { get; set; }

    [XmlIgnore]
    [JsonIgnore]
    public List<CajaAlmacen> Cajas { get; set; }
}
