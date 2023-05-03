namespace pika.comun.metadatos.i18n;

/// <summary>
/// Elemenentos para internacionalizacion
/// </summary>
public class ElementoI18n
{
    /// <summary>
    /// Clave del texto
    /// </summary>
    public string Clave { get; set; }
    
    /// <summary>
    /// Texto traducio para el idioma especificado
    /// </summary>
    public string Traduccion { get; set; }

    /// <summary>
    /// Subelemento de I18n
    /// </summary>
    public List<ElementoI18n> ? SubElementos { get; set; }
}
