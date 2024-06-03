namespace api.comunes.metadatos.validadores;

[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
public class ValidarEnteroAttribute(int? minimo = null, int? maximo = null) : Attribute
{
    private readonly int? _minimo = minimo;
    private readonly int? _maximo = maximo;

    /// <summary>
    /// Valor mínimo aceptable, si es nulo no se valúa
    /// </summary>
    public int? Minimo { get { return _minimo; } }

    /// <summary>
    /// Valor máximo aceptable, si es nulo no se valúa
    /// </summary>
    public int? Maximo { get { return _maximo; } }
}

