using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;
using pika.comun.metadatos.atributos;

namespace pika.seguridad.modelo;

/// <summary>
/// Especifica las propiedades de seguridad de una aplicación
/// </summary>
[Entidad()]
[ExcludeFromCodeCoverage]
public class Aplicacion
{

    /// <summary>
    /// Identificador único de la aplicación, este Id será propoerionado por un sistema externo
    /// </summary>
    [Id]
    [Formulario(indice: 1, visible: false)]
    [Tabla(indice: 0, visible: false)]
    public required Guid Id { get; set; }

    /// <summary>
    /// Nombre del módulo para la UI
    /// </summary>
    [Nombre]
    [Formulario(indice: 1, ancho: 100)]
    [Tabla(indice: 1)]
    public required string Nombre { get; set; }

    /// <summary>
    /// Descripción del módulo para la UI
    /// </summary>
    [Nombre]
    [Formulario(indice: 2, ancho: 100)]
    [Tabla(indice: 2)]
    public string? Descripcion { get; set; }


    /// <summary>
    /// Modulos de una aplicacion
    /// </summary>
    [JsonIgnore]
    public List<Modulo> Modulos { get; set; } = [];

    /// <summary>
    /// Lista de permisos asociados al modulo
    /// </summary>
    [JsonIgnore]
    public List<Permiso> Permisos { get; set; } = [];


    /// <summary>
    /// Lista de roles asociados al modulo
    /// </summary>
    [JsonIgnore]
    public List<Rol> Roles { get; set; } = [];
}
