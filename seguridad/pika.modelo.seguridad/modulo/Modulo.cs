using api.comunes.metadatos.atributos;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace pika.modelo.seguridad;


/// <summary>
/// Módulo de una aplicacion
/// </summary>
[Entidad()]
[ExcludeFromCodeCoverage]
public class Modulo
{
    /// <summary>
    /// Identificador único del módulo
    /// </summary>
    [Id]
    [Formulario(visible: false)]
    [Tabla(indice: 0, visible: false)]
    public string Id { get; set; }

    /// <summary>
    /// Identificador único de la aplicación a la que pertenece el módulo
    /// </summary>
    [Id]
    [Formulario(visible: false)]
    [Tabla(indice:1, visible: false)]
    public string AplicacionId { get; set; }

    /// <summary>
    /// Nombre del módulo para la UI, esto será calcolado en base al idioa
    /// </summary>
    [Nombre]
    [Formulario(indice: 1, ancho: 100)]
    [Tabla(indice: 2)]
    public required string Nombre { get; set; }

    /// <summary>
    /// Descripción del módulo para la UI, esto será calcolado en base al idioa
    /// </summary>
    [Formulario(indice: 2, ancho: 100)]
    [Tabla(indice: 3)]
    public string? Descripcion { get; set; }


    /// <summary>
    /// Aplciació a la que perenece el módulo
    /// </summary>
    [JsonIgnore]
    public Aplicacion Aplicacion { get; set; }


    /// <summary>
    /// Lista de permisos asociados al modulo
    /// </summary>
    [JsonIgnore]
    public List<Permiso> Permisos { get; set; } = [];

    /// <summary>
    /// Roles definidos para el módulo asociados a un conjunto de permisos
    /// </summary>
    [JsonIgnore]
    public List<Rol> RolesPredefinidos { get; set; } = [];


}
