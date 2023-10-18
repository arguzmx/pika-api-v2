using api.comunes.modelos.servicios;
using pika.modelo.contenido.Contenido;

namespace pika.servicios.contenido.contenido;

/// <summary>
/// Interfaz para el servicio de Contenido
/// </summary>
public interface IServicioContenido : IServicioEntidadGenerica<Contenido, ContenidoInsertar, ContenidoActualizar, ContenidoDespliegue, string>
{
}