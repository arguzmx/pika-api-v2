namespace api.comunes.metadatos;

public class Lista
{
    /// <summary>
    /// IDentificador único de la lista
    /// </summary>
    public string Id { get; set; }

    /// <summary>
    /// MEtodo de ordenamiento de la lista en base al nombre para desplieguw
    /// </summary>
    public OrdenamientoLista Ordenamiento { get; set; } = OrdenamientoLista.Ninguno;


    /// <summary>
    /// Espedifica si los datos deben obtenerse remotemente desde el servidor
    /// </summary>
    public bool DatosRemotos { get; set; } = false;


    /// <summary>
    /// Endpoint en la api para obtener lso elementos de la lista desde el servidor mediante busqueda parcial de texto
    /// </summary>
    public string? EndpointBusqueda { get; set; } = null;

    /// <summary>
    /// Endpoint en la api para obtener lso elementos de la lista desde el servidor
    /// </summary>
    public string? Endpoint { get; set; } = null;

    /// <summary>
    /// Elementos de la lista
    /// </summary>
    public List<ElementoLista> Elementos { get; set; } = new List<ElementoLista>();
}
