
using api.comunes.modelos.modelos;
using api.comunes.modelos.respuestas;

namespace api.comunes.modelos.reflectores;

public interface IServicioCatalogoAPI
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
    /// DEvuelve el idioma por defecto del catálogo
    /// </summary>
    public string IdiomaDefault { get; }

    /// <summary>
    /// Devuelve la lista completa de elemntos del catálogo en base al idioma
    /// </summary>
    /// <param name="Idioma">Idioma del catálogo</param>
    /// <returns></returns>
    Task<RespuestaPayload<List<ParClaveTexto>>> Todo(string? idioma, string? dominioId, string? unidadOrgId);


    /// <summary>
    /// Devuelve una lista de entradas que contienen el texto buscad
    /// </summary>
    /// <param name="idioma">Idioma del catálogo</param>
    /// <param name="buscar">Texto a buscar</param>
    /// <returns></returns>
    Task<RespuestaPayload<List<ParClaveTexto>>> PorTexto(string? idioma, string? buscar, string? dominioId, string? unidadOrgId);


    /// <summary>
    /// Crea una nueva entrada nueva en el catálogo
    /// </summary>
    /// <param name="elemento"></param>
    /// <returns></returns>
    Task<RespuestaPayload<ElementoCatalogo>> CreaEntrada(ElementoCatalogo elemento, string? dominioId, string? unidadOrgId);

    /// <summary>
    /// Elimina una entrada del catálogo para todos los idiomas
    /// </summary>
    /// <param name="Id">Identificador único de la entrada</param>
    /// <returns></returns>
    Task<Respuesta> EliminaEntrada(string Id, string? dominioId, string? unidadOrgId);


    /// <summary>
    /// Actualiza una entrada en el catálogo por idioma
    /// </summary>
    /// <param name="Id">Identificador único de la entrada</param>
    /// <param name="idioma">Idioma de la entrada</param>
    /// <param name="texto">texto para la enrada</param>
    /// <returns></returns>
    Task<Respuesta> ActualizaEntrada(string Id, string? idioma, string texto, string? dominioId, string? unidadOrgId);


    /// <summary>
    /// Devuelve la lista de idiomas disponibles para el catálogo
    /// </summary>
    /// <returns></returns>
    List<string> Idiomas(string? dominioId, string? unidadOrgId);

    /// <summary>
    /// Lista de elementos del catálogo por defecto, sirve para poblar el repositorio inicial
    /// </summary>
    /// <returns></returns>
    List<ElementoCatalogo> ElementosDefault();

}
