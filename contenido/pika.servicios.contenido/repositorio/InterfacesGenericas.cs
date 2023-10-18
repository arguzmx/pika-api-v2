using api.comunes.modelos.servicios;
using pika.modelo.contenido.Repositorio;

namespace pika.servicios.contenido.repositorio;

/// <summary>
/// Interfaz para el servicio de Repositorio
/// </summary>
public interface IServicioRepositorio : IServicioEntidadGenerica<Repositorio, RepositorioInsertar, RepositorioActualizar, RepositorioDespliegue, string>
{
}