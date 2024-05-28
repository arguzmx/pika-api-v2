using System.Text.Json.Serialization;

namespace pika.seguridad.modelo;


/// <summary>
/// Módulo de una aplicacion
/// </summary>
public class Modulo
{
    /// <summary>
    /// Identificador único del módulo
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Identificador único de la aplicación a la que pertenece el módulo
    /// </summary>
    public Guid AplicacionId { get; set; }

    /// <summary>
    /// Nombre del módulo para la UI, esto será calcolado en base al idioa
    /// </summary>
    public required string Nombre { get; set; }

    /// <summary>
    /// Descripción del módulo para la UI, esto será calcolado en base al idioa
    /// </summary>
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
