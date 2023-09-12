﻿
using api.comunes.modelos.modelos;
using api.comunes.modelos.respuestas;

namespace api.comunes.modelos.reflectores;

/// <summary>
/// Interfaz para el servicio de enntidades de APi genéricos
/// </summary>
public interface IServicioCatalogoAPI
{

    /// <summary>
    /// Especifica si el servicio require autenticacion
    /// </summary>
    public bool RequiereAutenticacion { get; set; }

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
    /// DEvuelve el idioma por defecto del catálogo
    /// </summary>
    public string IdiomaDefault { get; }

    /// <summary>
    /// Devuelve la lista completa de elemntos del catálogo en base al idioma
    /// </summary>
    /// <param name="Idioma">Idioma del catálogo</param>
    /// <returns></returns>
    Task<RespuestaPayload<List<ParClaveTexto>>> Todo(string? idioma);


    /// <summary>
    /// Devuelve una lista de entradas que contienen el texto buscad
    /// </summary>
    /// <param name="idioma">Idioma del catálogo</param>
    /// <param name="buscar">Texto a buscar</param>
    /// <returns></returns>
    Task<RespuestaPayload<List<ParClaveTexto>>> PorTexto(string? idioma, string? buscar);


    /// <summary>
    /// Crea una nueva entrada nueva en el catálogo
    /// </summary>
    /// <param name="elemento"></param>
    /// <returns></returns>
    Task<RespuestaPayload<ElementoCatalogo>> CreaEntrada(ElementoCatalogoInsertar elemento);

    /// <summary>
    /// Elimina una entrada del catálogo para todos los idiomas
    /// </summary>
    /// <param name="Id">Identificador único de la entrada</param>
    /// <returns></returns>
    Task<Respuesta> EliminaEntrada(string Id);


    /// <summary>
    /// Actualiza una entrada en el catálogo por idioma
    /// </summary>
    /// <param name="Id">Identificador único de la entrada</param>
    /// <param name="idioma">Idioma de la entrada</param>
    /// <param name="texto">texto para la enrada</param>
    /// <returns></returns>
    Task<Respuesta> ActualizaEntrada(string Id, ElementoCatalogoActualizar elemento);


    /// <summary>
    /// Devuelve la lista de idiomas disponibles para el catálogo
    /// </summary>
    /// <returns></returns>
    List<string> Idiomas();

    /// <summary>
    /// Lista de elementos del catálogo por defecto, sirve para poblar el repositorio inicial
    /// </summary>
    /// <returns></returns>
    List<ElementoCatalogo> ElementosDefault();
}