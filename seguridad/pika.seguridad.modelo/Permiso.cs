using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace pika.seguridad.modelo;

/// <summary>
/// Define un periso aplicable 
/// </summary>
public class Permiso
{
    /// <summary>
    /// Identificador único del permido
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Identificador único del módulo al que pertenece el permiso
    /// </summary>
    public Guid ModuloId { get; set; }

    /// <summary>
    /// Identificador único de la aplicación del módulo con el permiso
    /// </summary>
    public Guid AplicacionId { get; set; }

    /// <summary>
    /// Determina el ámbito de apliación del permiso
    /// </summary>
    public AmbitoPermiso Ambito { get; set; }


    /// <summary>
    /// Nombre del permiso para la UI, esto será calcolado en base al idioa
    /// </summary>
    public required string Nombre { get; set; }

    /// <summary>
    /// Descripción del permiso para la UI, esto será calcolado en base al idioa
    /// </summary>
    public string? Descripcion { get; set; }


    /// <summary>
    /// Aplciació a la que perenece el módulo
    /// </summary>
    [JsonIgnore]
    public Aplicacion Aplicacion { get; set; }

    /// <summary>
    /// Módulo al que perenece el permiso
    /// </summary>
    [JsonIgnore]
    public Modulo Modulo { get; set; }

}
