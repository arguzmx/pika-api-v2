using pika.modelo.contenido.Permisos;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace pika.modelo.contenido;

public class Permiso
{
    /// <summary>
    /// Identificador único del permiso
    /// </summary>
    public string Id { get; set; }

    /// <summary>
    /// PErmiso lectura sobre el elemento
    /// </summary>
    public bool Leer { get; set; }

    /// <summary>
    /// PErmiso escritura sobre el elemento
    /// </summary>
    public bool Escribir { get; set; }

    /// <summary>
    /// PErmiso de creación sobre el elemento
    /// </summary>
    public bool Crear { get; set; }

    /// <summary>
    /// PErmiso eliminación sobre el elemento
    /// </summary>
    public bool Eliminar { get; set; }


    [XmlIgnore, JsonIgnore]
    public List<AsignacionPermiso> Asignaciones { get; set; }

    [XmlIgnore, JsonIgnore]
    public List<Carpeta.Carpeta> Carpetas { get; set; }

    
    [XmlIgnore, JsonIgnore]
    public List<Contenido.Contenido> Contenidos { get; set; }
}
