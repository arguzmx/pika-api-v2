using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace pika.modelo.contenido;

/// <summary>
/// Representa un repositorio para el almacenamiento y clasificación de contenido
/// </summary>
public class Repositorio
{
    /// <summary>
    ///  Identificdor únio del repositorio
    ///  Se obtiene con GUID new
    /// </summary>
    public string Id { get; set; }
    // [a] [d] 
    // R 128

    /// <summary>
    /// Dominio al que pertenece el repositorio
    /// </summary>
    public string DominioId { get; set; }
    // Este valor simpre viene del contexto
    // R 128

    /// <summary>
    /// Unidad organizacional a la que pertenece el repositorio
    /// </summary>
    public string UOrgId { get; set; }
    //  Este valor simpre viene del contexto
    // R 128

    /// <summary>
    /// Nombre del repositorio 
    /// </summary>
    public string Nombre { get; set; }
    // [i] [a] [d]
    // R 500


    /// <summary>
    /// Volumen para almacenar los archivos relacionado con el contenido
    /// </summary>
    public string VolumenId { get; set; }
    // [i] [a] [d]
    // R 500


    ///// <summary>
    ///// Propiedad de navegacion para el volumen del repositorio
    ///// </summary>
    //[XmlIgnore]
    //[JsonIgnore]
    //public Volumen Volumen { get; set; }

}
