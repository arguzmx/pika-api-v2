using api.comunes.modelos.servicios;
using pika.modelo.contenido;

namespace pika.servicios.contenido.carpeta;

/// <summary>
/// Interface servicio carpeta
/// </summary>
public interface IServicioCarpeta : IServicioEntidadGenerica<Carpeta, CarpetaInsertar, CarpetaActualizar, CarpetaDespliegue, string>
{
}
