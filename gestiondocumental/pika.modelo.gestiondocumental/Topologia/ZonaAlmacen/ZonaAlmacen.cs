using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace pika.modelo.gestiondocumental.Topologia;

/// <summary>
/// Zonas de las que se compone un almacén
/// </summary>
public class ZonaAlmacen
{
    
    /// <summary>
    /// Identificador único de la zona
    /// </summary>
    public string Id { get; set ; }
    // [a] [d] 
    // R 128


    /// <summary>
    /// Nombre único de la zona
    /// </summary>
    public string Nombre { get; set; }
    // [i] [a] [d] 
    // R 500

    /// <summary>
    /// Identificaodr único del archivo al que pertenece la zona
    /// </summary>
    public string ArchivoId { get; set; }
    // [i] [a] [d]
    // R 128

    /// <summary>
    /// Identificador unico del almacen al que pertenece la zona
    /// </summary>
    public string AlmacenArchivoId { get; set; }
    // [i] [a] [d]
    // R 128

    [XmlIgnore]
    [JsonIgnore]
    public AlmacenArchivo Almacen { get; set; }


    [XmlIgnore]
    [JsonIgnore]
    public Archivo Archivo { get; set; }
    
}
