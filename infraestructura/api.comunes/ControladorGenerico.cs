using api.comunes.modelos.modelos;
using api.comunes.modelos.reflectores;
using Microsoft.AspNetCore.Mvc;

namespace api.comunes;


[ApiController]
public class ControladorGenerico : ControllerBase
{
    protected IEntidadAPI entidadAPI;
    public ControladorGenerico()
    {

    }

    [HttpPost("/gapi/{entidad}/entidad")]
    public async Task<IActionResult> POSTGenerico(string entidad, [FromBody] object dtoInsert)
    {
        var response = await entidadAPI.InsertarAPI(dtoInsert);
        return Ok(response.Payload);
    }

    [HttpPut("/gapi/{entidad}/entidad/{id}")]
    public async Task<IActionResult> PUTGenerico(string entidad, string id, [FromBody] object dtoUpdate)
    {
        var response = await entidadAPI.ActualizarAPI((object)id, dtoUpdate);
        return Ok();
    }

    [HttpGet("/gapi/{entidad}/entidad/{id}")]
    public async Task<IActionResult> UnicoPorId(string entidad, string id)
    {
        var response = await entidadAPI.UnicaPorIdAPI((object)id);
        return Ok(response.Payload);
    }

    [HttpGet("/gapi/{entidad}/entidad/despliegue/{id}")]
    public async Task<IActionResult> UnicoPorIdDespliegue(string entidad, string id)
    {
        var response = await entidadAPI.UnicaPorIdDespliegueAPI((object)id);
        return Ok(response.Payload);
    }

    [HttpGet("/gapi/{entidad}/entidad/pagina")]
    public async Task<IActionResult> Pagina(string entidad, Consulta consulta)
    {
        var response = await entidadAPI.PaginaAPI(consulta);
        return Ok(response.Payload);
    }

    [HttpGet("/gapi/{entidad}/entidad/despliegue/pagina")]
    public async Task<IActionResult> PaginaDespliegue(string entidad, Consulta consulta)
    {
        var response = await entidadAPI.PaginaDespliegueAPI(consulta);
        return Ok(response.Payload);
    }

    [HttpDelete("/gapi/{entidad}/entidad/{id}")]
    public async Task<IActionResult> EliminarUnico(string entidad, string id)
    {
        var response = await entidadAPI.EliminarAPI((object)id);
        return Ok();
    }



}