namespace api.comunes.metadatos.validadores;


/// <summary>
/// Permite estabkecer valos mínimos ymáximos para las fechas, en el caso de fecha y hora sólo se toma la porción adecuada
/// En el caso de valores FechaHora se toma el valor completo especificado como UTC
/// </summary>
/// <remarks>
/// 
/// </remarks>
/// <param name="minimo"></param>
/// <param name="maximo"></param>
[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
public class ValidarFechaAttribute(DateTime? minimo = null, DateTime? maximo = null) : Attribute
{

    private readonly DateTime? _minimo = minimo;
    private readonly DateTime? _maximo = maximo;


    /// <summary>
    /// Valor mínimo aceptable, si es nulo no se valúa
    /// </summary>
    public DateTime? Minimo { get { return _minimo; } }

    /// <summary>
    /// Valor máximo aceptable, si es nulo no se valúa
    /// </summary>
    public DateTime? Maximo { get { return _maximo;  } }
}
