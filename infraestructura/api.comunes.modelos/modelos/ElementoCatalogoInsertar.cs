namespace api.comunes.modelos.modelos;

/// <summary>
/// Clase para la inserción de elementos al catálogo
/// </summary>
public class ElementoCatalogoInsertar
{

    /// <summary>
    /// Clave de identidad del catálogo
    /// </summary>
    public virtual string Clave { get; set; }

    /// <summary>
    /// Texto para la entrada de catálogo
    /// </summary>
    public virtual string Texto { get; set; }

    /// <summary>
    /// Idioma para el teto descriptivo
    /// </summary>
    public virtual string Idioma { get; set; }

}
