using api.comunes.metadatos;
using api.comunes.modelos.modelos;
using api.comunes.modelos.respuestas;
using System.Text.Json;

namespace api.comunes.modelos.reflectores;

/// <summary>
/// Iinterfaz para marcar las etidades que deben rutearse a través de la API genérica
/// </summary>
public interface IServicioEntidadAPI
{

    /// <summary>
    /// Determina si el servicio requiere de autenticación
    /// </summary>
    bool RequiereAutenticacion { get; } 

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
    /// Otiene los datos del contexto de ejecución del usuario en sesión
    /// </summary>
    /// <returns></returns>
    ContextoUsuario? ObtieneContextoUsuarioAPI();

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


    /// <summary>
    /// Obtiene una lista de elementos hijos de la entidad padre en base a la configuración de la consulta y su paginado
    /// </summary>
    /// <param name="consulta"></param>
    /// <returns></returns>
    Task<RespuestaPayload<PaginaGenerica<object>>> PaginaHijoAPI(Consulta consulta, string tipoPadre, string id);

    /// <summary>
    /// Obtiene una lista de elementos hijos de la entidad padre para el despliegue en base a la configuración de la consulta y su paginado
    /// </summary>
    /// <param name="consulta"></param>
    /// <returns></returns>
    Task<RespuestaPayload<PaginaGenerica<object>>> PaginaHijosDespliegueAPI(Consulta consulta, string tipoPadre, string id);

    /// <summary>
    /// Obtiene los nodos raíz de una estructura jerárquica 
    /// </summary>
    /// <param name="contextoId">Identificador opcional de contexto</param>
    /// <returns></returns>
    Task<RespuestaPayload<List<ParClaveTexto>>> Raices(string? contextoId);

    /// <summary>
    /// Obtiene los nodos hijos de un nodo en base al ID para una estructura jerárquica 
    /// </summary>
    /// <param name="id">Identificador único del nodo padre</param>
    /// <param name="contextoId">Identificador opcional de contexto</param>
    /// <returns></returns>
    Task<RespuestaPayload<List<ParClaveTexto>>> Hijos(string id, string? contextoId);

    /// <summary>
    /// Obtiene una lista de nodos en forma de un árbol aplanado para una estructura jerárquica
    /// </summary>
    /// <param name="contextoId">Identificador opcional de contexto</param>
    /// <returns></returns>
    Task<RespuestaPayload<List<ParClaveTextoNodoArbol<string>>>> Arbol(string? contextoId);

    /// <summary>
    /// DEvulver la conjunción de DTOFull, DTOInsert y DTOUpdate para la entidad con el tipo
    /// </summary>
    /// <param name="Tipo"></param>
    /// <returns></returns>
    Task<Entidad>? Metadatos(string Tipo);
}
