using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace pika.seguridad.modelo;

/// <summary>
/// Rol de seguridad asociado a una apliación
/// </summary>
public class Rol
{
    /// <summary>
    /// Identificador único del rol
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Identificador único del módulo al que pertenece el rol 
    /// </summary>
    public Guid ModuloId { get; set; }

    /// <summary>
    /// Identificador único de la aplicación del módulo con el rol 
    /// </summary>
    public Guid AplicacionId { get; set; }

    /// <summary>
    /// Nombre del rol para la UI, esto será calcolado en base al idioma o bien al crear roles personalizados
    /// </summary>
    public required string Nombre { get; set; }

    /// <summary>
    /// Descripción del rol para la UI, esto será calcolado en base al idioma o bien al crear roles personalizados
    /// </summary>
    public string? Descripcion { get; set; }

    /// <summary>
    /// Lista de los identificadores de permisos asociados al rol
    /// </summary>
    public List<string> Permisos { get; set; } = [];

    /// <summary>
    /// DEfine si un rol ha sido creado por el administrador de sistema
    /// </summary>
    public bool Personalizado { get; set; }


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
