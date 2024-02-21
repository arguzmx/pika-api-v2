using api.comunes.metadatos.atributos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace pika.modelo.gestiondocumental;

/// <summary>
/// Zonas de las que se compone un almacén
/// </summary>
 [Entidad()]
public class ZonaAlmacen
{

    /// <summary>
    /// Identificador único de la zona
    /// </summary>
    [Id]
    [Formulario(indice: 1, visible: false)]
    [Tabla(indice: 0, visible: false)]
    public string Id { get; set ; }
    // [a] [d] 
    // R 128


    /// <summary>
    /// Nombre único de la zona
    /// </summary>
    [Nombre]
    [Formulario(indice: 1, ancho: 100)]
    [Tabla(indice: 1)]
    public string Nombre { get; set; }
    // [i] [a] [d] 
    // R 500

    /// <summary>
    /// Identificaodr único del archivo al que pertenece la zona
    /// </summary>
    [Tabla(indice: 0, visible: true)]
    [UsoCatalogoAttribute("Archivo", true)]
    public string ArchivoId { get; set; }
    // [i] [a] [d]
    // R 128

    /// <summary>
    /// Identificador unico del almacen al que pertenece la zona
    /// </summary>
    [Tabla(indice: 0, visible: true)]
    [UsoCatalogoAttribute("AlmacenArchivo", true)]
    public string AlmacenArchivoId { get; set; }
    // [i] [a] [d]
    // R 128

    [XmlIgnore]
    [JsonIgnore]
    public AlmacenArchivo Almacen { get; set; }


    [XmlIgnore]
    [JsonIgnore]
    public Archivo Archivo { get; set; }


    [XmlIgnore]
    [JsonIgnore]
    public List<PosicionAlmacen> Posiciones { get; set; }


    [XmlIgnore]
    [JsonIgnore]
    public List<CajaAlmacen> Cajas { get; set; }

}
