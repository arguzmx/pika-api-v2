using System.Text.Json.Serialization;

namespace pika.seguridad.modelo;

/// <summary>
/// Especifica las propiedades de seguridad de una aplicación
/// </summary>
public class Aplicacion
{

    /// <summary>
    /// Identificador único de la aplicación, este Id será propoerionado por un sistema externo
    /// </summary>
    public required Guid Id { get; set; }
    
    /// <summary>
    /// Nombre del módulo para la UI
    /// </summary>
    public required string Nombre { get; set; }

    /// <summary>
    /// Descripción del módulo para la UI
    /// </summary>
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
