using api.comunes.modelos.servicios;
using pika.modelo.contenido;
using pika.modelo.contenido.Permisos;

namespace pika.servicios.contenido.permisos;

public interface IServicioPermiso : IServicioEntidadGenerica<Permiso, Permiso, Permiso, Permiso, string>
{
}
public interface IServicioAsignacionPermiso : IServicioEntidadGenerica<AsignacionPermiso, AsignacionPermiso, AsignacionPermiso, AsignacionPermiso, string>
{
}