using MongoDB.Bson.Serialization.Attributes;
using pika.comun.metadatos.atributos;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace pika.seguridad.modelo;

/// <summary>
/// Define un periso aplicable 
/// </summary>
[Entidad()]
[ExcludeFromCodeCoverage]
public class Permiso
{
    /// <summary>
    /// Identificador único del permido
    /// </summary>
    [Id]
    [Formulario(indice: 1, visible: false)]
    [Tabla(indice: 0, visible: false)]
    public Guid Id { get; set; }

    /// <summary>
    /// Identificador único del módulo al que pertenece el permiso
    /// </summary>
    [Formulario(visible: false)]
    [Tabla(indice: 1, visible: false)]
    public Guid ModuloId { get; set; }

    /// <summary>
    /// Identificador único de la aplicación del módulo con el permiso
    /// </summary>
    [Formulario(visible: false)]
    [Tabla(indice: 2, visible: false)]
    public Guid AplicacionId { get; set; }

    /// <summary>
    /// Nombre del permiso para la UI, esto será calcolado en base al idioa
    /// </summary>
    [Nombre]
    [Formulario(indice: 1, ancho: 100)]
    [Tabla(indice: 3)]
    public required string Nombre { get; set; }


    /// <summary>
    /// Descripción del permiso para la UI, esto será calcolado en base al idioa
    /// </summary>
    [Formulario(indice: 2, ancho: 100)]
    [Tabla(indice: 4)]
    public string? Descripcion { get; set; }


    /// <summary>
    /// Determina el ámbito de apliación del permiso
    /// </summary>
    [Formulario(indice: 3, ancho: 50)]
    [Tabla(indice: 5)]
    public AmbitoPermiso Ambito { get; set; }


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
