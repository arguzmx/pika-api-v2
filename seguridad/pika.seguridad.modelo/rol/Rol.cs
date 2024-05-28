using pika.comun.metadatos.atributos;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace pika.seguridad.modelo;

/// <summary>
/// Rol de seguridad asociado a una apliación
/// </summary>
[Entidad()]
[ExcludeFromCodeCoverage]
public class Rol
{
    /// <summary>
    /// Identificador único del rol
    /// </summary>
    [Id]
    [Formulario(indice: 1, visible: false)]
    [Tabla(indice: 0, visible: false)]
    public Guid Id { get; set; }

    /// <summary>
    /// Identificador único del módulo al que pertenece el rol 
    /// </summary>
    [Formulario(visible: false)]
    [Tabla(indice: 1, visible: false)]
    public Guid ModuloId { get; set; }

    /// <summary>
    /// Identificador único de la aplicación del módulo con el rol 
    /// </summary>
    [Formulario(visible: false)]
    [Tabla(indice: 2, visible: false)]
    public Guid AplicacionId { get; set; }

    /// <summary>
    /// Nombre del rol para la UI, esto será calcolado en base al idioma o bien al crear roles personalizados
    /// </summary>
    [Nombre]
    [Formulario(indice: 1, ancho: 100)]
    [Tabla(indice: 3)]
    public required string Nombre { get; set; }

    /// <summary>
    /// Descripción del rol para la UI, esto será calcolado en base al idioma o bien al crear roles personalizados
    /// </summary>
    [Formulario(indice: 2, ancho: 100)]
    [Tabla(indice: 4)]
    public string? Descripcion { get; set; }

    /// <summary>
    /// Lista de los identificadores de permisos asociados al rol
    /// </summary>
    [Protegido]
    public List<string> Permisos { get; set; } = [];
    // Esta propiedad tendrá un crud especializado para su llenado

    /// <summary>
    /// Define si un rol ha sido creado por el administrador de sistema
    /// </summary>
    [Protegido]
    public bool Personalizado { get; set; }
    // Esta propiedad se llenará desde el controlador cuando sea necesario

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
