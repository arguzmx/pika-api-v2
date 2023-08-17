using api.comunes.modelos.modelos;
using api.comunes.modelos.reflectores;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System.Text.Json;

namespace api.comunes;

/// <summary>
/// Controlador base para API de entidad genérica
/// </summary>
[ApiController]
public abstract class ControladorGenerico : ControllerBase
{
    private const string DOMINIOHEADER = "x-d-id";
    private const string UORGHEADER = "x-uo-id";

    protected IEntidadAPI entidadAPI;
    protected readonly IHttpContextAccessor _httpContextAccessor;
    protected readonly IConfiguracionAPIEntidades _configuracionAPI;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="httpContextAccessor"></param>
    /// <param name="configuracionAPI"></param>
    public ControladorGenerico(
        IHttpContextAccessor httpContextAccessor,
        IConfiguracionAPIEntidades configuracionAPI)
    {
        _configuracionAPI = configuracionAPI;
        _httpContextAccessor = httpContextAccessor;
    }

    protected string DominioId()
    {
        return _httpContextAccessor.HttpContext.Request.Headers?[DOMINIOHEADER];
    }

    protected string UnidadOrgId()
    {
        
        return _httpContextAccessor.HttpContext.Request.Headers?[UORGHEADER];
    }

    protected string UsuarioId()
    {
        return "u-id";
    }

    protected string Entidad()
    {
        var zz = this.Request.HttpContext.GetRouteData();
        return this.HttpContext.GetRouteData().Values["Entidad"].ToString();
    }

    [HttpPost("/api/{entidad}/entidad")]
    public async Task<IActionResult> POSTGenerico(string entidad, [FromBody] JsonElement dtoInsert, [FromHeader(Name = DOMINIOHEADER)] string dominioId, [FromHeader(Name = UORGHEADER)] string uOrgID)
    {
        var z = this.HttpContext.Items.Keys;
        var response = await entidadAPI.InsertarAPI(dtoInsert);
        return Ok(response.Payload);
    }

    [HttpPut("/api/{entidad}/entidad/{id}")]
    public async Task<IActionResult> PUTGenerico(string entidad, string id, [FromBody] JsonElement dtoUpdate, [FromHeader(Name = DOMINIOHEADER)] string dominioId, [FromHeader(Name = UORGHEADER)] string uOrgID)
    {
        var response = await entidadAPI.ActualizarAPI((object)id, dtoUpdate);
        return Ok();
    }

    [HttpGet("/api/{entidad}/entidad/{id}")]
    public async Task<IActionResult> UnicoPorId(string entidad, string id, [FromHeader(Name = DOMINIOHEADER)] string dominioId, [FromHeader(Name = UORGHEADER)] string uOrgID)
    {
        var response = await entidadAPI.UnicaPorIdAPI((object)id);
        return Ok(response.Payload);
    }

    [HttpGet("/api/{entidad}/entidad/despliegue/{id}")]
    public async Task<IActionResult> UnicoPorIdDespliegue(string entidad, string id, [FromHeader(Name = DOMINIOHEADER)] string dominioId, [FromHeader(Name = UORGHEADER)] string uOrgID)
    {
        var response = await entidadAPI.UnicaPorIdDespliegueAPI((object)id);
        return Ok(response.Payload);
    }

    [HttpGet("/api/{entidad}/entidad/pagina")]
    public async Task<IActionResult> Pagina(string entidad, Consulta consulta, [FromHeader(Name = DOMINIOHEADER)] string dominioId, [FromHeader(Name = UORGHEADER)] string uOrgID)
    {
        var response = await entidadAPI.PaginaAPI(consulta);
        return Ok(response.Payload);
    }

    [HttpGet("/api/{entidad}/entidad/despliegue/pagina")]
    public async Task<IActionResult> PaginaDespliegue(string entidad, Consulta consulta, [FromHeader(Name = DOMINIOHEADER)] string dominioId, [FromHeader(Name = UORGHEADER)] string uOrgID)
    {
        var response = await entidadAPI.PaginaDespliegueAPI(consulta);
        return Ok(response.Payload);
    }

    [HttpDelete("/api/{entidad}/entidad/{id}")]
    public async Task<IActionResult> EliminarUnico(string entidad, string id, [FromHeader(Name = DOMINIOHEADER)] string dominioId, [FromHeader(Name = UORGHEADER)] string uOrgID)
    {
        var response = await entidadAPI.EliminarAPI((object)id);
        return Ok();
    }



}