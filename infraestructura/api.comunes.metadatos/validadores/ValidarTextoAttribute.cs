namespace api.comunes.metadatos.validadores;

[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
public class ValidarTextoAttribute(int? longitudMinima = null, int? longitudMaxima = null, string? regexp = null): Attribute
{
    private readonly int? _longitudMinima = longitudMinima;

    private readonly int? _longitudMaxima = longitudMaxima;

    private readonly string? _regExp = regexp;

    /// <summary>
    /// Longitud mínima del texto de la propiedad, si es nulo no se evalúa
    /// </summary>
    public virtual int? LongitudMinima
    {
        get { return _longitudMinima; }
    }

    /// <summary>
    /// Longitud máxima del texto de la propiedad, si es nulo no se evalúa
    /// </summary>
    public virtual int? LongitudMaxima
    {
        get { return _longitudMaxima; }
    }

    /// <summary>
    /// Expresión regular para validar, si es nulo no se evalúa
    /// </summary>
    public virtual string? RegExp
    {
        get { return _regExp; }
    }

}
