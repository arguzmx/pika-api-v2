using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace pika.modelo.contenido.Permisos;

public class AsignacionPermiso
{
    /// <summary>
    /// Identificador único de la asignación del permiso
    /// </summary>
    public string Id { get; set; }

    /// <summary>
    /// Rol a quien aplica el permiso
    /// </summary>
    public string RolId { get; set; }

    /// <summary>
    /// Usuario al que aplica el permiso
    /// </summary>
    public string UsuarioId { get; set; }

    /// <summary>
    /// Identificador del permiso
    /// </summary>
    public string PermisoId { get; set; }


    [XmlIgnore, JsonIgnore]
    public Permiso Permiso { get; set; }
}
