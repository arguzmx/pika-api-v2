using System.Diagnostics.CodeAnalysis;

namespace api.comunes.metadatos.atributos;


/// <summary>
/// Configura los detalles de una propieda de tipo lista
/// </summary>
/// <param name="multiple">Determina si la lista es de selección múltiple</param>
/// <param name="remota">Espefica si lso datos deben obtenersse manera remota</param>
/// <param name="endpoint">Endpoint para obeteners la lista completa</param>
/// <param name="endpointBusqueda">Endpoint para obtener la lista por busquseda parcial</param>
/// <param name="claveLocal">Clave única o identificador de la lista para obtener los datos localmente vía el servicio de la entidad</param>
[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
[ExcludeFromCodeCoverage]
public class ListaAtttribute(bool multiple = false, OrdenamientoLista Ordenamiento = OrdenamientoLista.Alfabetico, bool remota = false, 
    string? endpoint= null, string? endpointBusqueda = null, string? claveLocal = null) : Attribute
{

    private readonly OrdenamientoLista _ordenamiento = Ordenamiento;
    private readonly bool _multiple = multiple;
    private readonly bool _remota = remota;
    private readonly string? _endpoint = endpoint;
    private readonly string? _endpointBusqueda = endpointBusqueda;
    private readonly string? _claveLocal = claveLocal;

    /// <summary>
    /// Determian si la lista es de selección múltiple
    /// </summary>
    public virtual bool Multiple
    {
        get { return _multiple; }
    }

    /// <summary>
    /// Método de ordenamiento de la lista en base al nombre para desplieguw
    /// </summary>
    public virtual OrdenamientoLista OrdenamientoLista
    {
        get { return _ordenamiento; }
    }

    /// <summary>
    /// Especifica si la lista debe obtenerse de manera remota
    /// </summary>
    public virtual bool Remota
    {
        get { return _remota; }
    }

    /// <summary>
    /// Ruta del endpoint de la lista para busquedas parciales
    /// </summary>
    public virtual string? EndpointBusqueda
    {
        get { return _endpointBusqueda; }
    }

    /// <summary>
    /// Ruta del endpoint de la lista
    /// </summary>
    public virtual string? Endpoint
    {
        get { return _endpoint; }
    }

    /// <summary>
    /// Clave única o identificador para obtener los miembros de la lista 
    /// desde el servicio de datos asociado a la entidad
    /// </summary>
    public virtual string? ClaveLocal
    {
        get { return _claveLocal; }
    }
}
