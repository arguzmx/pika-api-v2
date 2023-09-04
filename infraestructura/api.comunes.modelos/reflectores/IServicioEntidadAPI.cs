using api.comunes.modelos.modelos;
using api.comunes.modelos.respuestas;
using pika.comun.metadatos;
using System.Text.Json;

namespace api.comunes.modelos.reflectores;

/// <summary>
/// Iinterfaz para marcar las etidades que deben rutearse a través de la API genérica
/// </summary>
public interface IServicioEntidadAPI
{

    /// <summary>
    /// Idioma del request desde Accept-Language
    /// </summary>
    public string? Idioma { get; set; }

    /// <summary>
    /// Id del usaurio en sesion
    /// </summary>
    public string? UsuarioId { get; set; }

    /// <summary>
    /// Id del dominio para el usuario en sesión
    /// </summary>
    public string? DominioId { get; set; }

    /// <summary>
    /// Id de la unidad organizacional para el usuario en sesión
    /// </summary>
    public string? UnidadOrganizacionalId { get; set; }

    /// <summary>
    /// Devuelve los metadatos de la entidad completa tal como se almacena en el repositorio
    /// </summary>
    /// <returns></returns>
    Entidad EntidadRepoAPI();

    /// <summary>
    /// Devuelve los datos de la entidad para realizar la inserción al repositorio
    /// </summary>
    /// <returns></returns>
    Entidad EntidadInsertAPI();


    /// <summary>
    /// Devuelve los metadatos de la entidad para realizar la actualización al repositorio
    /// </summary>
    /// <returns></returns>
    Entidad EntidadUpdateAPI();

    /// <summary>
    /// Devuelve los metadatos de la entidad para el despliegue
    /// </summary>
    /// <returns></returns>
    Entidad EntidadDespliegueAPI();


    /// <summary>
    /// Establece el contexto de ejecución del usuario 
    /// </summary>
    /// <param name="contexto"></param>
    void EstableceContextoUsuarioAPI(ContextoUsuario contexto);


    /// <summary>
    /// Método para insertar una entidad nueva en el repositorio
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    Task<RespuestaPayload<object>> InsertarAPI(JsonElement data);


    /// <summary>
    /// Actualiza el contenido de una entidad en el repositorio 
    /// </summary>
    /// <param name="id"></param>
    /// <param name="data"></param>
    /// <returns></returns>
    Task<Respuesta> ActualizarAPI(object id, JsonElement data);


    /// <summary>
    /// Elimina una entidad del repositorio eb base a su Id único
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<Respuesta> EliminarAPI(object id);


    /// <summary>
    /// Obtiene una entidad del repositorio por Id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<RespuestaPayload<object>> UnicaPorIdAPI(object  id);

    /// <summary>
    /// Obtiene una entidad para despliegue del repositorio por Id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<RespuestaPayload<object>> UnicaPorIdDespliegueAPI(object id);


    /// <summary>
    /// Obtiene una lista de elementos en base a la configuración de la consulta y su paginado
    /// </summary>
    /// <param name="consulta"></param>
    /// <returns></returns>
    Task<RespuestaPayload<PaginaGenerica<object>>> PaginaAPI(Consulta consulta);

    /// <summary>
    /// Obtiene una lista de elementos para el despliegue en base a la configuración de la consulta y su paginado
    /// </summary>
    /// <param name="consulta"></param>
    /// <returns></returns>
    Task<RespuestaPayload<PaginaGenerica<object>>> PaginaDespliegueAPI(Consulta consulta);


}
