using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace pika.modelo.organizacion;

/// <summary>
/// Relaciona un usuario con su dominio
/// </summary>
public class UsuarioDominio
{

    /// <summary>
    /// Identificador único de la relacióm
    /// </summary>
    public string Id { get; set; }
    // [d]
    // R [128]

    /// <summary>
    /// Identificador único del usuario, este viene del servicio de identidad
    /// </summary>
    public string UsuarioId { get; set; }
    // [i] [d]
    // R [128]

    /// <summary>
    /// Identificador único del dominio
    /// </summary>
    public string DominioId { get; set; }
    // [i] [d]
    // R [128]

    [JsonIgnore]
    [XmlIgnore]
    public Dominio Dominio { get; set; }

    // PAra esta entidad el método UPDATE no debe implmentarse

}
