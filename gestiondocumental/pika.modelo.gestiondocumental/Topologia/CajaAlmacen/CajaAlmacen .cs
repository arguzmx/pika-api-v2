using api.comunes.metadatos.atributos;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace pika.modelo.gestiondocumental;

/// <summary>
/// Define una caja o contenedor para la guarda de los activos del acervo por ejemplo una caja de archivo o un rack
/// </summary>
[Entidad()]
public class CajaAlmacen 
{
    /// <summary>
    /// IDentificador único de la caja
    /// </summary>
    [Id]
    [Formulario(indice: 1, visible: false)]
    [Tabla(indice: 0, visible: false)]
    public string Id { get; set; }
    // [a] [d] 
    // R 128


    /// <summary>
    /// Nomnbre del contenedor para refeencia humana puede ser el mismo que la clave
    /// </summary>
    [Nombre]
    [Formulario(indice: 1, ancho: 100)]
    [Tabla(indice: 1)]
    public string Nombre { get; set; }
    // [i] [a] [d] 
    // R 500


    /// <summary>
    /// Codigo de barras asociado a la caja
    /// </summary>
    public string? CodigoBarras { get; set; }
    // [i] [a] [d]
    // 
    /// <summary>
    /// Codigo electrónico asociado a la caja
    /// </summary>
    public string? CodigoElectronico { get; set; }
    // [i] [a] [d] 

    /// <summary>
    /// Porcentaje de ocupación del contenedor
    /// </summary>
    public decimal Ocupacion { get; set; } = 0;
    // [i] [a] [d] 

    /// <summary>
    /// Identificador unico del almacen en el que se ubica el contenedor
    /// </summary>
    [Tabla(indice: 0, visible: true)]
    [UsoCatalogoAttribute("AlmacenArchivo", true)]
    public string AlmacenArchivoId { get; set; }
    // [i] [d] 
    // R 128

    /// <summary>
    /// Identificador unico de la zona en el que se ubica el contenedor
    /// La zona del contenedor es opcional
    /// </summary>
    [Tabla(indice: 0, visible: true)]
    [UsoCatalogoAttribute("ZonaAlmacen", true)]
    public string ZonaAlmacenId { get; set; }
    // [i] [d] 
    // R 128

    /// <summary>
    /// Identificador unico de la posición en la que se ubica el contenedor
    /// EL contenedor puede no estar asociado a una posición puede esta solamente en una zona por ejemplo FUMIGACION
    /// </summary>
    /// [Tabla(indice: 0, visible: true)]
    [UsoCatalogoAttribute("PosicionAlmacen", true)]
    public string PosicionAlmacenId { get; set; }
    // [i] [d] 
    // R 128

    /// <summary>
    /// Identificaodr único del archivo en el que se ubica el contenedor
    /// </summary>
    [Tabla(indice: 0, visible: true)]
    [UsoCatalogoAttribute("Archivo", true)]
    public string ArchivoId { get; set; }
    // [i] [d] 
    // R 128

    [XmlIgnore]
    [JsonIgnore]
    public PosicionAlmacen Posicion { get; set; }


    [XmlIgnore]
    [JsonIgnore]
    public ZonaAlmacen Zona { get; set; }

    [XmlIgnore]
    [JsonIgnore]
    public AlmacenArchivo Almacen { get; set; }


    [XmlIgnore]
    [JsonIgnore]
    public Archivo Archivo { get; set; }

}
