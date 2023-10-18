using api.comunes.modelos.servicios;
using pika.modelo.contenido.Carpeta;

namespace pika.servicios.contenido.carpeta;

/// <summary>
/// Interfaz para el servicio de carpeta
/// </summary>
public interface IServicioCarpeta : IServicioEntidadGenerica<Carpeta, CarpetaInsertar, CarpetaActualizar, CarpetaDespliegue, string>
{
}