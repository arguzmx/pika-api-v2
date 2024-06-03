namespace api.comunes.metadatos.atributos;

/// <summary>
/// Especifica si la propiedad debe pertenecer a un tipo de datos especifico
/// Por ejemplo en el caso donde hay subtipos fecha, hora, fechahora
/// 
/// Y determina también si al UI debe tener un tipo de despliegue específico, 
/// por ejemplo para tipos booleanos puedes ser un checkbox o un switch
/// </summary>
[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
public class PropiedadAttribute : Attribute
{
    private TipoDatos _tipoDatos = TipoDatos.SinAsignar;
    private TipoDespliegue _tipoDespliegue = TipoDespliegue.Default;
    private bool _buscable = true;
    private bool _visible = true;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="tipoDato">Tipo de datos asignado</param>
    /// <param name="tipoDespliegue">Tipo de despliegue por defecto</param>
    /// <param name="buscable">Especifica si la propiedad puede utilziare para búsquedas</param>
    /// /// <param name="visible">Especifica si la propiedad es visuble para el usuario</param>
    public PropiedadAttribute(
        TipoDatos tipoDato = TipoDatos.SinAsignar, 
        TipoDespliegue tipoDespliegue = TipoDespliegue.Default,
        bool buscable = true, bool visible = true)
    {
        _tipoDatos = tipoDato;
        _tipoDespliegue = tipoDespliegue;
        _buscable = buscable;
        _visible = visible;
    }


    /// <summary>
    /// Determina la posición relativa a otras propiedades
    /// </summary>
    public virtual TipoDespliegue TipoDespliegue
    {
        get { return _tipoDespliegue; }
    }

    /// <summary>
    /// Especifica el tipo de datos
    /// </summary>
    public virtual TipoDatos TipoDatos
    {
        get { return _tipoDatos; }
    }

    /// <summary>
    /// determina si la propiedad puede utilizarse para búsquedas
    /// </summary>
    public virtual bool Buscable
    {
        get { return _buscable; }
    }


    /// <summary>
    /// Determina si la propiedad es visible para el usuario
    /// </summary>
    public virtual bool Visible
    {
        get { return _visible; }
    }
}
