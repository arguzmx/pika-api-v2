namespace api.comunes.modelos.modelos;

/// <summary>
/// DTO Para la creación de un elemento de catálog
/// </summary>
public class ElementoCatalogoInsertar
{    /// <summary>
     /// Identificador único de la entrade del catálogo
     /// si el Id no tiene un valos el Id es calculado del lado del servidor
     /// </summary>
    public virtual string? Id { get; set; }

    /// <summary>
    /// Idioma para el teto descriptivo
    /// </summary>
    public virtual string Idioma { get; set; }

    /// <summary>
    /// Texto para la entrada de catálogo
    /// </summary>
    public virtual string Texto { get; set; }
}
