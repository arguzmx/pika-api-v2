using api.comunes.consultas.dto;
using api.comunes.modelos.respuestas;
using pika.comun.metadatos;

namespace api.comunes.modelos.servicios;

/// <summary>
/// Define los métodos comunes al servicio de entidades pika
/// </summary>
/// <typeparam name="Store"></typeparam>
/// <typeparam name="DTOInsert"></typeparam>
/// <typeparam name="DTOUpdate"></typeparam>
/// <typeparam name="TipoId"></typeparam>
public interface IServicioEntidadGenerica<DTOFull, DTOInsert, DTOUpdate, TipoId> where DTOFull: class
{

    /// <summary>
    /// Devuelve los metadatos de la entidad completa tal como se almacena en el repositorio
    /// </summary>
    /// <returns></returns>
    Entidad EntidadFull();

    /// <summary>
    /// Devuelve los datos de la entidad para realizar la inserción al repositorio
    /// </summary>
    /// <returns></returns>
    Entidad EntidadInsert();


    /// <summary>
    /// DEvulve los metadatos de la entidad para realizar la actualización al repositorio
    /// </summary>
    /// <returns></returns>
    Entidad EntidadUpdate();


    /// <summary>
    /// Método para insertar una entidad nueva en el repositorio
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    Task<RespuestaPayload<DTOFull>> Insertar(DTOInsert data);


    /// <summary>
    /// Actualiza el contenido de una entidad en el repositorio 
    /// </summary>
    /// <param name="id"></param>
    /// <param name="data"></param>
    /// <returns></returns>
    Task<Respuesta> Actualizar(TipoId id, DTOUpdate data);


    /// <summary>
    /// Elimina una entidad del repositorio eb base a su Id único
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<Respuesta> Eliminar(TipoId id);


    /// <summary>
    /// Obtiene una entidad del repositorio por Id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<RespuestaPayload<DTOFull>> UnicaPorId(TipoId id);


    /// <summary>
    /// Obtiene una lista de elementos en base a la configuración de la consulta y su paginado
    /// </summary>
    /// <param name="consulta"></param>
    /// <returns></returns>
    Task<PaginaGenerica<DTOFull>> Pagina(Consulta consulta);    

}
