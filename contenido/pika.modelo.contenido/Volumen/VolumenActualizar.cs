namespace pika.modelo.contenido.Volumen;

public class VolumenActualizar
{
    /// <summary>
    ///  Identificdor únio del volumen
    ///  Se obtiene con GUID new
    /// </summary>
    public string Id { get; set; }

    /// <summary>
    /// Nombre único del volumen
    /// </summary>
    public string Nombre { get; set; }

    /// <summary>
    /// Identificador único del  tipo de gestor, es necesario para la configuración
    /// </summary>
    public string TipoGestorESId { get; set; }

    /// <summary>
    /// Tamaño maximo del volumen en bytes, 0 indidica ilimitado
    /// </summary>
    public long TamanoMaximo { get; set; }

    /// <summary>
    /// Indica si el volumen se encuentra activo 
    /// </summary>
    public bool Activo { get; set; }

    /// <summary>
    /// Especifica si el volumen se encuntra habilitado para escritura
    /// </summary>
    public bool EscrituraHabilitada { get; set; }

}
