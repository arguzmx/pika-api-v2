using api.comunes.modelos.servicios;
using pika.modelo.contenido;

namespace pika.servicios.contenido.repositorio;

/// <summary>
/// Interface servicio repositorio
/// </summary>
public interface IServicioRepositorio : IServicioEntidadGenerica<Repositorio, RepositorioInsertar, RepositorioActualizar, RepositorioDespliegue, string>
{
}