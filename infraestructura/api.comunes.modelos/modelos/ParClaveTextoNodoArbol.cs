namespace api.comunes.modelos.modelos;


/// <summary>
/// Elemento base para un árbol aplanado
/// </summary>
/// <typeparam name="T"></typeparam>
public class ParClaveTextoNodoArbol<T>: ParClaveTexto
{
    /// <summary>
    /// Identificador único del nodo padre
    /// </summary>
    public T? PadreId { get; set; }
}
