namespace pika.comun.metadatos.atributos;


/// <summary>
/// Especifica la propiedad que debe utilizarse como nombre para el despliegue en la UI
/// </summary>
[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
public class NombreAttribute : Attribute
{
    /// <summary>
    /// 
    /// </summary>
    public NombreAttribute()
    {
    }
}
