using api.comunes.modelos.servicios;
using pika.modelo.contenido.Version;

namespace pika.servicios.contenido.version;

public interface IServicioVersion : IServicioEntidadGenerica<modelo.contenido.Version.Version, VersionInsertar, VersionActualizar, VersionDespliegue, string>
{
}