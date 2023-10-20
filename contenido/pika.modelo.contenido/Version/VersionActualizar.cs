namespace pika.modelo.contenido.Version;

public  class VersionActualizar
{
    /// <summary>
    /// Identificador único de la version
    /// </summary>
    public string Id { get; set; }
   
    /// <summary>
    /// Indica si la versión es la activa, sólo pude existir una versión activa por elemento
    /// </summary>
    public bool Activa { get; set; } = true;

}
