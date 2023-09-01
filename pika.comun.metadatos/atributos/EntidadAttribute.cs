using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pika.comun.metadatos.atributos;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
public class EntidadAttribute: Attribute
{
    private readonly string _nombre;
    private readonly string? _endpoint;

    /// <summary>
    /// Crea una instancia del atributo de entidades
    /// </summary>
    /// <param name="nombre">Nombre asociado a la entidad si al valor no se especifica se toma el del ensamblado</param>
    /// <param name="endpoint">Ruta en el controlador para la API genérica si el valor no se especifica se toma el del nombre del servicio por default</param>
    public EntidadAttribute(string? nombre = null, string? endpoint = null)
    {
        _nombre = nombre;
        _endpoint = endpoint;
    }

    /// <summary>
    /// Nombre de la identidad para ser utilziado como base para la I18N
    /// </summary>
    public virtual string Nombre
    {
        get { return _nombre; }
    }

    /// <summary>
    /// Enpoint opcional en la API si no e utiliza la ruta genérica
    /// </summary>
    public virtual string Endpoint
    {
        get { return _endpoint; }
    }
}
