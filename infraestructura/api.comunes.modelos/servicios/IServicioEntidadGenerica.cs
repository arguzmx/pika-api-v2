using api.comunes.modelos.modelos;
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
    Entidad EntidadRepo();

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
    /// Establece el contexto de ejecución del usuario 
    /// </summary>
    /// <param name="contexto"></param>
    void EstableceContextoUsuario(ContextoUsuario contexto);


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

    /// <summary>
    /// Ejecuta la validación para un proceso de inserción
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    Task<ResultadoValidacion> ValidarInsertar(DTOInsert data);


    /// <summary>
    /// Ejecuta la validación para un proceso de actiualización
    /// </summary>
    /// <param name="id"></param>
    /// <param name="data"></param>
    /// <returns></returns>
    Task<ResultadoValidacion> ValidarActualizar(TipoId id,  DTOUpdate data);


    /// <summary>
    /// Ejecuta la validación para un proceso de eliminación
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<ResultadoValidacion> ValidarEliminacion(TipoId id);

    /// <summary>
    /// Convierte un DTO de inserción a la versión de entidad en el repositorio
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    DTOFull ADTOFull(DTOInsert data);

    /// <summary>
    /// Actualza un DTO vigente con lso datos de un DTO de actualizacion
    /// </summary>
    /// <param name="actualizacion"></param>
    /// <param name="actual"></param>
    /// <returns></returns>
    DTOFull ADTOFull(DTOUpdate actualizacion, DTOFull actual);

}
