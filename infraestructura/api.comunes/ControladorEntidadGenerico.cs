﻿using api.comunes.modelos.modelos;
using api.comunes.modelos.reflectores;
using api.comunes.modelos.respuestas;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Text.Json;

namespace api.comunes;


/// La api generica utiliza el parámetro {entidad} con propósitos asignación de servicion el em Middleware
#pragma warning disable IDE0060 // Quitar el parámetro no utilizado

/// <summary>
/// Controlador base para API de entidad genérica
/// </summary>
[ApiController]
[SwaggerTag(description: "Controlador Genérico Entidad")]
public abstract class ControladorEntidadGenerico : ControladorBaseGenerico
{
    /// <summary>
    /// Servicio para el CRUD de la entidad
    /// </summary>
    protected IServicioEntidadAPI entidadAPI;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="httpContextAccessor"></param>
    /// <param name="configuracionAPI"></param>
#pragma warning disable CS8618 // Un campo que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de declararlo como que admite un valor NULL.
    public ControladorEntidadGenerico(IHttpContextAccessor httpContextAccessor):  base(httpContextAccessor)
#pragma warning restore CS8618 // Un campo que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de declararlo como que admite un valor NULL.
    {
#pragma warning disable CS8600 // Se va a convertir un literal nulo o un posible valor nulo en un tipo que no acepta valores NULL
#pragma warning disable CS8601 // Posible asignación de referencia nula
#pragma warning disable CS8602 // Desreferencia de una referencia posiblemente NULL.
        entidadAPI = (IServicioEntidadAPI)httpContextAccessor.HttpContext.Items[EntidadAPIMiddleware.GenericAPIServiceKey];
#pragma warning restore CS8602 // Desreferencia de una referencia posiblemente NULL.
#pragma warning restore CS8601 // Posible asignación de referencia nula
#pragma warning restore CS8600 // Se va a convertir un literal nulo o un posible valor nulo en un tipo que no acepta valores NULL
    }


    /// <summary>
    /// Crea una entidad del tipo especificado por el ruteo
    /// </summary>
    /// <param name="entidad">Tipo de entidad en base al ruteo</param>
    /// <param name="dtoInsert">DTO para inserción de la entidad, no debe incluir el Id</param>
    /// <param name="dominioId">Id del sominio del usuario en sesión</param>
    /// <param name="uOrgID">Id de la unidad organizacional del usuario en sesión</param>
    /// <returns></returns>
    [HttpPost("/api/{entidad}/entidad")]
    [SwaggerOperation("Crea una entidad del tipo especificado por el ruteo")]
    [SwaggerResponse(statusCode: 200, description: "La entidad ha sido creada")]
    [SwaggerResponse(statusCode: 400, type: typeof(ErrorProceso), description: "Los datos proporcionados no son válidos")]
    [SwaggerResponse(statusCode: 409, type: typeof(ErrorProceso), description: "Los datos proporcionados causan conflictos en el repositorio")]
    [SwaggerResponse(statusCode: 403, description: "El usuario en sesión no tiene acceso a la operación")]
    [SwaggerResponse(statusCode: 401, description: "Usuario no autenticado")]
    public async Task<IActionResult> POSTGenerico(string entidad, [FromBody] JsonElement dtoInsert, [FromHeader(Name = DOMINIOHEADER)] string dominioId, [FromHeader(Name = UORGHEADER)] string uOrgID)
    {
        var response = await entidadAPI.InsertarAPI(dtoInsert);
        if(response.Ok)
        {
            return Ok(response.Payload);
        }
        return StatusCode(response.HttpCode.GetHashCode(), response.Error);
    }

    /// <summary>
    /// Actualiza una entidad del tipo especificado por el ruteo
    /// </summary>
    /// <param name="entidad">Tipo de entidad en base al ruteo</param>
    /// <param name="id">Identificador único de la entidad</param>
    /// <param name="dtoUpdate">DTO para la actualización</param>
    /// <param name="dominioId">Id del sominio del usuario en sesión</param>
    /// <param name="uOrgID">Id de la unidad organizacional del usuario en sesión</param>
    /// <returns></returns>
    [HttpPut("/api/{entidad}/entidad/{id}")]
    [SwaggerOperation("Actualiza una entidad del tipo especificado por el ruteo")]
    [SwaggerResponse(statusCode: 204, description: "La entidad ha sido actualizada")]
    [SwaggerResponse(statusCode: 400, type: typeof(ErrorProceso), description: "Los datos proporcionados no son válidos")]
    [SwaggerResponse(statusCode: 404, description: "Entidad no localizada o inexistente")]
    [SwaggerResponse(statusCode: 409, type: typeof(ErrorProceso), description: "Los datos proporcionados causan conflictos en el repositorio")]
    [SwaggerResponse(statusCode: 403, description: "El usuario en sesión no tiene acceso a la operación")]
    [SwaggerResponse(statusCode: 401, description: "Usuario no autenticado")]
    public async Task<IActionResult> PUTGenerico(string entidad, string id, [FromBody] JsonElement dtoUpdate, [FromHeader(Name = DOMINIOHEADER)] string dominioId, [FromHeader(Name = UORGHEADER)] string uOrgID)
    {
        var response = await entidadAPI.ActualizarAPI((object)id, dtoUpdate);
        if (response.Ok)
        {
            return NoContent();
        }
        return StatusCode(response.HttpCode.GetHashCode(), response.Error);
    }


    /// <summary>
    /// Obtiene una entidad tal como se almacena en el repositorio en base a su identificador único
    /// </summary>
    /// <param name="entidad">Tipo de entidad en base al ruteo</param>
    /// <param name="id">Identificador único de la entidad</param>
    /// <param name="dominioId">Id del sominio del usuario en sesión</param>
    /// <param name="uOrgID">Id de la unidad organizacional del usuario en sesión</param>
    /// <returns></returns>
    [HttpGet("/api/{entidad}/entidad/{id}")]
    [SwaggerOperation("Obtiene una entidad en base a su identificador único")]
    [SwaggerResponse(statusCode: 200, description: "Entidad localizada")]
    [SwaggerResponse(statusCode: 404, description: "Entidad no localizada o inexistente")]
    [SwaggerResponse(statusCode: 403, description: "El usuario en sesión no tiene acceso a la operación")]
    [SwaggerResponse(statusCode: 401, description: "Usuario no autenticado")]
    public async Task<IActionResult> UnicoPorId(string entidad, string id, [FromHeader(Name = DOMINIOHEADER)] string dominioId, [FromHeader(Name = UORGHEADER)] string uOrgID)
    {
        var response = await entidadAPI.UnicaPorIdAPI((object)id);
        if (response.Ok)
        {
            return Ok(response.Payload);
        }
        return StatusCode(response.HttpCode.GetHashCode(), response.Error);
    }


    /// <summary>
    /// Obtiene una entidad para despliegue en base a su identificador único
    /// </summary>
    /// <param name="entidad">Tipo de entidad en base al ruteo</param>
    /// <param name="id">Identificador único de la entidad</param>
    /// <param name="dominioId">Id del sominio del usuario en sesión</param>
    /// <param name="uOrgID">Id de la unidad organizacional del usuario en sesión</param>
    /// <returns></returns>
    [HttpGet("/api/{entidad}/entidad/despliegue/{id}")]
    [SwaggerOperation("Obtiene una entidad en base a su identificador único")]
    [SwaggerResponse(statusCode: 200, description: "Entidad localizada")]
    [SwaggerResponse(statusCode: 404, description: "Entidad no localizada o inexistente")]
    [SwaggerResponse(statusCode: 403, description: "El usuario en sesión no tiene acceso a la operación")]
    [SwaggerResponse(statusCode: 401, description: "Usuario no autenticado")]
    public async Task<IActionResult> UnicoPorIdDespliegue(string entidad, string id, [FromHeader(Name = DOMINIOHEADER)] string dominioId, [FromHeader(Name = UORGHEADER)] string uOrgID)
    {
        var response = await entidadAPI.UnicaPorIdDespliegueAPI((object)id);
        if (response.Ok)
        {
            return Ok(response.Payload);
        }
        return StatusCode(response.HttpCode.GetHashCode(), response.Error);
    }

    /// <summary>
    /// Obtiene una página de entidades tal como se almacena en el repositorio en base a la consulta
    /// </summary>
    /// <param name="entidad">Tipo de entidad en base al ruteo</param>
    /// <param name="consulta">Configuración para la consulta</param>
    /// <param name="dominioId">Id del sominio del usuario en sesión</param>
    /// <param name="uOrgID">Id de la unidad organizacional del usuario en sesión</param>
    /// <returns></returns>
    [HttpGet("/api/{entidad}/entidad/pagina")]
    [SwaggerOperation("Obtiene una página de entidades tal como se almacena en el repositorio en base a la consulta")]
    [SwaggerResponse(statusCode: 200, type: typeof(PaginaGenerica<object>),  description: "Página de datos de entidad")]
    [SwaggerResponse(statusCode: 400, description: "Datos de consulta incorrectos")]
    [SwaggerResponse(statusCode: 403, description: "El usuario en sesión no tiene acceso a la operación")]
    [SwaggerResponse(statusCode: 401, description: "Usuario no autenticado")]
    public async Task<ActionResult<PaginaGenerica<object>>> Pagina(string entidad, Consulta consulta, [FromHeader(Name = DOMINIOHEADER)] string dominioId, [FromHeader(Name = UORGHEADER)] string uOrgID)
    {
        var response = await entidadAPI.PaginaAPI(consulta);
        if (response.Ok)
        {
            return Ok(response.Payload);
        }
        return StatusCode(response.HttpCode.GetHashCode(), response.Error);
    }


    /// <summary>
    /// Obtiene una página de entidades para despliegue en base a la consulta
    /// </summary>
    /// <param name="entidad">Tipo de entidad en base al ruteo</param>
    /// <param name="consulta">Configuración para la consulta</param>
    /// <param name="dominioId">Id del sominio del usuario en sesión</param>
    /// <param name="uOrgID">Id de la unidad organizacional del usuario en sesión</param>
    /// <returns></returns>
    [HttpGet("/api/{entidad}/entidad/despliegue/pagina")]
    [SwaggerOperation("Obtiene una página de entidades para despliegue en base a la consulta")]
    [SwaggerResponse(statusCode: 200, type: typeof(PaginaGenerica<object>), description: "Página de datos de entidad")]
    [SwaggerResponse(statusCode: 400, description: "Datos de consulta incorrectos")]
    [SwaggerResponse(statusCode: 403, description: "El usuario en sesión no tiene acceso a la operación")]
    [SwaggerResponse(statusCode: 401, description: "Usuario no autenticado")]
    public async Task<IActionResult> PaginaDespliegue(string entidad, Consulta consulta, [FromHeader(Name = DOMINIOHEADER)] string dominioId, [FromHeader(Name = UORGHEADER)] string uOrgID)
    {
        var response = await entidadAPI.PaginaDespliegueAPI(consulta);
        if (response.Ok)
        {
            return Ok(response.Payload);
        }
        return StatusCode(response.HttpCode.GetHashCode(), response.Error);
    }

    /// <summary>
    /// Elimina una entidad en base a su identificador único
    /// </summary>
    /// <param name="entidad">Tipo de entidad en base al ruteo</param>
    /// <param name="id">Identificador único de la entidad</param>
    /// /// <param name="dominioId">Id del sominio del usuario en sesión</param>
    /// <param name="uOrgID">Id de la unidad organizacional del usuario en sesión</param>
    /// <returns></returns>
    [HttpDelete("/api/{entidad}/entidad/{id}")]
    [SwaggerOperation("Elimina una entidad en base a su identificador único")]
    [SwaggerResponse(statusCode: 204, description: "Laentidad ha sido eliminada")]
    [SwaggerResponse(statusCode: 404, description: "Entidad inexistente o no localizada")]
    [SwaggerResponse(statusCode: 403, description: "El usuario en sesión no tiene acceso a la operación")]
    [SwaggerResponse(statusCode: 401, description: "Usuario no autenticado")]
    public async Task<IActionResult> EliminarUnico(string entidad, string id, [FromHeader(Name = DOMINIOHEADER)] string dominioId, [FromHeader(Name = UORGHEADER)] string uOrgID)
    {
        var response = await entidadAPI.EliminarAPI((object)id);
        if (response.Ok)
        {
            return NoContent();
        }
        return StatusCode(response.HttpCode.GetHashCode(), response.Error);
    }
}

#pragma warning disable IDE0060 // Quitar el parámetro no utilizado