﻿using api.comunes.metadatos;
using api.comunes.modelos.modelos;
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
    /// Obtiene los metadatos de una entidad
    /// </summary>
    /// <param name="entidad"></param>
    /// <returns></returns>
    [HttpGet("/api/{entidad}/metadatos")]
    [SwaggerOperation("Obtiene los Metadatos de una entidad del tipo especificado por el ruteo")]
    [SwaggerResponse(statusCode: 200, type: typeof(Entidad),  description: "Metadatos de la entidad")]
    [SwaggerResponse(statusCode: 404, description: "Entidad no localizada o inexistente")]
    public async Task<IActionResult> DefinicionEntidad(string entidad)
    {
        // calcula la Entidad desde el servico y s ni devuelve null devolver 404
        var resultado = await entidadAPI.Metadatos(entidad);
        if(resultado== null) {
            return NotFound(entidad);
        }
        return Ok(resultado);
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
    [SwaggerResponse(statusCode: 405, description: "Método no implementado")]
    public async Task<IActionResult> POSTGenerico(string entidad, [FromBody] JsonElement dtoInsert, [FromHeader(Name = DOMINIOHEADER)] string? dominioId, [FromHeader(Name = UORGHEADER)] string? uOrgID )
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
    [SwaggerResponse(statusCode: 405, description: "Método no implementado")]
    public async Task<IActionResult> PUTGenerico(string entidad, string id, [FromBody] JsonElement dtoUpdate, [FromHeader(Name = DOMINIOHEADER)] string? dominioId, [FromHeader(Name = UORGHEADER)] string? uOrgID)
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
    [SwaggerResponse(statusCode: 405, description: "Método no implementado")]
    public async Task<IActionResult> UnicoPorId(string entidad, string id, [FromHeader(Name = DOMINIOHEADER)] string? dominioId, [FromHeader(Name = UORGHEADER)] string? uOrgID)
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
    [SwaggerResponse(statusCode: 405, description: "Método no implementado")]
    public async Task<IActionResult> UnicoPorIdDespliegue(string entidad, string id, [FromHeader(Name = DOMINIOHEADER)] string? dominioId, [FromHeader(Name = UORGHEADER)] string? uOrgID)
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
    [HttpPost("/api/{entidad}/entidad/pagina")]
    [SwaggerOperation("Obtiene una página de entidades tal como se almacena en el repositorio en base a la consulta")]
    [SwaggerResponse(statusCode: 200, type: typeof(PaginaGenerica<object>),  description: "Página de datos de entidad")]
    [SwaggerResponse(statusCode: 400, description: "Datos de consulta incorrectos")]
    [SwaggerResponse(statusCode: 403, description: "El usuario en sesión no tiene acceso a la operación")]
    [SwaggerResponse(statusCode: 401, description: "Usuario no autenticado")]
    [SwaggerResponse(statusCode: 405, description: "Método no implementado")]
    public async Task<ActionResult<PaginaGenerica<object>>> Pagina(string entidad, [FromBody] Consulta consulta, [FromHeader(Name = DOMINIOHEADER)] string? dominioId, [FromHeader(Name = UORGHEADER)] string? uOrgID)
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
    [HttpPost("/api/{entidad}/entidad/pagina/despliegue")]
    [SwaggerOperation("Obtiene una página de entidades para despliegue en base a la consulta")]
    [SwaggerResponse(statusCode: 200, type: typeof(PaginaGenerica<object>), description: "Página de datos de entidad")]
    [SwaggerResponse(statusCode: 400, description: "Datos de consulta incorrectos")]
    [SwaggerResponse(statusCode: 403, description: "El usuario en sesión no tiene acceso a la operación")]
    [SwaggerResponse(statusCode: 401, description: "Usuario no autenticado")]
    [SwaggerResponse(statusCode: 405, description: "Método no implementado")]
    public async Task<IActionResult> PaginaDespliegue(string entidad, [FromBody] Consulta consulta, [FromHeader(Name = DOMINIOHEADER)] string? dominioId, [FromHeader(Name = UORGHEADER)] string? uOrgID)
    {
        var response = await entidadAPI.PaginaDespliegueAPI(consulta);
        if (response.Ok)
        {
            return Ok(response.Payload);
        }
        return StatusCode(response.HttpCode.GetHashCode(), response.Error);
    }

    /// <summary>
    /// Obtiene una página de entidades hijos de la entidad padre tal como se almacena en el repositorio en base a la consulta
    /// </summary>
    /// <param name="entidad">Tipo de entidad en base al ruteo</param>
    /// <param name="entidadPadre">Tipo de la entidad padre</param>
    /// <param name="padreId">Identificador único del padre</param>
    /// <param name="consulta">Configuración para la consulta</param>
    /// <param name="dominioId">Id del sominio del usuario en sesión</param>
    /// <param name="uOrgID">Id de la unidad organizacional del usuario en sesión</param>
    /// <returns></returns>
    [HttpPost("/api/{entidad}/hijos/{entidadPadre}/{padreId}/pagina")]
    [SwaggerOperation("Obtiene una página de entidades tal como se almacena en el repositorio en base a la consulta")]
    [SwaggerResponse(statusCode: 200, type: typeof(PaginaGenerica<object>), description: "Página de datos de entidad")]
    [SwaggerResponse(statusCode: 400, description: "Datos de consulta incorrectos")]
    [SwaggerResponse(statusCode: 403, description: "El usuario en sesión no tiene acceso a la operación")]
    [SwaggerResponse(statusCode: 401, description: "Usuario no autenticado")]
    [SwaggerResponse(statusCode: 405, description: "Método no implementado")]
    public async Task<ActionResult<PaginaGenerica<object>>> PaginaHijos(string entidad, string entidadPadre, string padreId, 
        [FromBody] Consulta consulta, [FromHeader(Name = DOMINIOHEADER)] string? dominioId, [FromHeader(Name = UORGHEADER)] string? uOrgID)
    {
        var response = await entidadAPI.PaginaHijoAPI(consulta, entidadPadre, padreId);
        if (response.Ok)
        {
            return Ok(response.Payload);
        }
        return StatusCode(response.HttpCode.GetHashCode(), response.Error);
    }


    /// <summary>
    /// Obtiene una página de entidades hijos de la entidad padre de entidades para despliegue en base a la consulta
    /// </summary>
    /// <param name="entidad">Tipo de entidad en base al ruteo</param>
    /// <param name="entidadPadre">Tipo de la entidad padre</param>
    /// <param name="padreId">Identificador único del padre</param>
    /// <param name="consulta">Configuración para la consulta</param>
    /// <param name="dominioId">Id del sominio del usuario en sesión</param>
    /// <param name="uOrgID">Id de la unidad organizacional del usuario en sesión</param>
    /// <returns></returns>
    [HttpPost("/api/{entidad}/hijos/{entidadPadre}/{padreId}/pagina/despliegue")]
    [SwaggerOperation("Obtiene una página de entidades para despliegue en base a la consulta")]
    [SwaggerResponse(statusCode: 200, type: typeof(PaginaGenerica<object>), description: "Página de datos de entidad")]
    [SwaggerResponse(statusCode: 400, description: "Datos de consulta incorrectos")]
    [SwaggerResponse(statusCode: 403, description: "El usuario en sesión no tiene acceso a la operación")]
    [SwaggerResponse(statusCode: 401, description: "Usuario no autenticado")]
    [SwaggerResponse(statusCode: 405, description: "Método no implementado")]
    public async Task<IActionResult> PaginaDespliegueHijos(string entidad, string entidadPadre, string padreId,
        [FromBody] Consulta consulta, [FromHeader(Name = DOMINIOHEADER)] string? dominioId, [FromHeader(Name = UORGHEADER)] string? uOrgID)
    {
        var response = await entidadAPI.PaginaHijosDespliegueAPI(consulta, entidadPadre, padreId);
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
    [SwaggerResponse(statusCode: 405, description: "Método no implementado")]
    public async Task<IActionResult> EliminarUnico(string entidad, string id, [FromHeader(Name = DOMINIOHEADER)] string? dominioId, [FromHeader(Name = UORGHEADER)] string? uOrgID)
    {
        var response = await entidadAPI.EliminarAPI((object)id);
        if (response.Ok)
        {
            return NoContent();
        }
        return StatusCode(response.HttpCode.GetHashCode(), response.Error);
    }

    [HttpGet("/api/{entidad}/entidad/arbol/raices", Name = "RaicesArbolEntidad")]
    [SwaggerOperation("Obtiene una lista de pares ValorTetxo que representan las raíces de una estructura de árbol", OperationId = "RaicesArbolEntidad")]
    [SwaggerResponse(statusCode: 200, type: typeof(List<ParClaveTexto>), description: "Raices")]
    [SwaggerResponse(statusCode: 403, description: "El usuario en sesión no tiene acceso a la operación")]
    [SwaggerResponse(statusCode: 401, description: "Usuario no autenticado")]
    [SwaggerResponse(statusCode: 400, description: "Datos incorrectos")]
    [SwaggerResponse(statusCode: 405, description: "Método no implementado")]
    public async Task<IActionResult> RaicesArbolEntidad(string entidad, [FromHeader(Name = DOMINIOHEADER)] string dominioId, [FromHeader(Name = UORGHEADER)] string uOrgID)
    {
        var response = await entidadAPI.Raices(null);
        if (response.Ok)
        {
            return Ok(response.Payload);
        }
        return StatusCode(response.HttpCode.GetHashCode(), response.Error);
    }

    [HttpGet("/api/{entidad}/entidad/{id}/arbol/raices", Name = "RaicesArbolEntidadContextual")]
    [SwaggerOperation("Obtiene una lista de pares ValorTetxo que representan las raíces de una estructura de árbol", OperationId = "RaicesArbolEntidadContextual")]
    [SwaggerResponse(statusCode: 200, type: typeof(List<ParClaveTexto>), description: "Raices")]
    [SwaggerResponse(statusCode: 403, description: "El usuario en sesión no tiene acceso a la operación")]
    [SwaggerResponse(statusCode: 401, description: "Usuario no autenticado")]
    [SwaggerResponse(statusCode: 400, description: "Datos incorrectos")]
    [SwaggerResponse(statusCode: 405, description: "Método no implementado")]
    public async Task<IActionResult> RaicesArbolEntidadContextual(string entidad, string id, [FromHeader(Name = DOMINIOHEADER)] string dominioId, [FromHeader(Name = UORGHEADER)] string uOrgID)
    {
        var response = await entidadAPI.Raices(id);
        if (response.Ok)
        {
            return Ok(response.Payload);
        }
        return StatusCode(response.HttpCode.GetHashCode(), response.Error);
    }


    [HttpGet("/api/{entidad}/entidad/arbol/raices/{nodoId}", Name = "HijosArbolEntidad")]
    [SwaggerOperation("Obtiene una lista de pares ValorTetxo que representan los hijos de un nodo de una estructura de árbol", OperationId = "HijosArbolEntidad")]
    [SwaggerResponse(statusCode: 200, type: typeof(List<ParClaveTexto>), description: "Raices")]
    [SwaggerResponse(statusCode: 403, description: "El usuario en sesión no tiene acceso a la operación")]
    [SwaggerResponse(statusCode: 401, description: "Usuario no autenticado")]
    [SwaggerResponse(statusCode: 400, description: "Datos incorrectos")]
    [SwaggerResponse(statusCode: 405, description: "Método no implementado")]
    public async Task<IActionResult> HijosArbolEntidad(string entidad, string nodoId, [FromHeader(Name = DOMINIOHEADER)] string dominioId, [FromHeader(Name = UORGHEADER)] string uOrgID)
    {
        var response = await entidadAPI.Hijos(nodoId, null);
        if (response.Ok)
        {
            return Ok(response.Payload);
        }
        return StatusCode(response.HttpCode.GetHashCode(), response.Error);
    }

    [HttpGet("/api/{entidad}/entidad/{id}/arbol/raices/{nodoId}", Name = "HijosArbolEntidadContextual")]
    [SwaggerOperation("Obtiene una lista de pares ValorTetxo que representan los hijos de un nodo de una estructura de árbol", OperationId = "HijosArbolEntidadContextual")]
    [SwaggerResponse(statusCode: 200, type: typeof(List<ParClaveTexto>), description: "Raices")]
    [SwaggerResponse(statusCode: 403, description: "El usuario en sesión no tiene acceso a la operación")]
    [SwaggerResponse(statusCode: 401, description: "Usuario no autenticado")]
    [SwaggerResponse(statusCode: 400, description: "Datos incorrectos")]
    [SwaggerResponse(statusCode: 405, description: "Método no implementado")]
    public async Task<IActionResult> HijosArbolEntidadContextual(string entidad, string id, string nodoId,[FromHeader(Name = DOMINIOHEADER)] string dominioId, [FromHeader(Name = UORGHEADER)] string uOrgID)
    {
        var response = await entidadAPI.Hijos(nodoId, id);
        if (response.Ok)
        {
            return Ok(response.Payload);
        }
        return StatusCode(response.HttpCode.GetHashCode(), response.Error);
    }

    [HttpGet("/api/{entidad}/entidad/arbol/raices", Name = "ArbolEntidad")]
    [SwaggerOperation("Obtiene una lista de todos los nodos de una estructura de árbol en formato aplanado", OperationId = "ArbolEntidad")]
    [SwaggerResponse(statusCode: 200, type: typeof(List<ParClaveTextoNodoArbol<string>>), description: "Raices")]
    [SwaggerResponse(statusCode: 403, description: "El usuario en sesión no tiene acceso a la operación")]
    [SwaggerResponse(statusCode: 401, description: "Usuario no autenticado")]
    [SwaggerResponse(statusCode: 400, description: "Datos incorrectos")]
    [SwaggerResponse(statusCode: 405, description: "Método no implementado")]
    public async Task<IActionResult> ArbolEntidad(string entidad, string nodoId, [FromHeader(Name = DOMINIOHEADER)] string dominioId, [FromHeader(Name = UORGHEADER)] string uOrgID)
    {
        var response = await entidadAPI.Arbol(null);
        if (response.Ok)
        {
            return Ok(response.Payload);
        }
        return StatusCode(response.HttpCode.GetHashCode(), response.Error);
    }

    [HttpGet("/api/{entidad}/entidad/{id}/arbol", Name = "ArbolEntidadContextual")]
    [SwaggerOperation("Obtiene una lista de todos los nodos de una estructura de árbol en formato aplanado", OperationId = "ArbolEntidadContextual")]
    [SwaggerResponse(statusCode: 200, type: typeof(List<ParClaveTextoNodoArbol<string>>), description: "Raices")]
    [SwaggerResponse(statusCode: 403, description: "El usuario en sesión no tiene acceso a la operación")]
    [SwaggerResponse(statusCode: 401, description: "Usuario no autenticado")]
    [SwaggerResponse(statusCode: 400, description: "Datos incorrectos")]
    [SwaggerResponse(statusCode: 405, description: "Método no implementado")]
    public async Task<IActionResult> ArbolEntidadContextual(string entidad, string id, [FromHeader(Name = DOMINIOHEADER)] string dominioId, [FromHeader(Name = UORGHEADER)] string uOrgID)
    {
        var response = await entidadAPI.Arbol(id);
        if (response.Ok)
        {
            return Ok(response.Payload);
        }
        return StatusCode(response.HttpCode.GetHashCode(), response.Error);
    }
}

#pragma warning disable IDE0060 // Quitar el parámetro no utilizado