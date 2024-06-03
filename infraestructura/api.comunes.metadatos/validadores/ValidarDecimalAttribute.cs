namespace api.comunes.metadatos.validadores;

[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
public class ValidarDecimalAttribute(decimal? minimo = null, decimal? maximo = null) : Attribute
{
    private readonly decimal? _minimo = minimo;
    private readonly decimal? _maximo = maximo;

    /// <summary>
    /// Valor mínimo aceptable, si es nulo no se valúa
    /// </summary>
    public decimal? Minimo { get { return _minimo; } }

    /// <summary>
    /// Valor máximo aceptable, si es nulo no se valúa
    /// </summary>
    public decimal? Maximo { get { return _maximo; } }
}

