using api.comunes.modelos.modelos;
using Microsoft.AspNetCore.Mvc;

namespace api.comunes;


[ApiController]
public class ControladorGenerico : ControllerBase
{

    public ControladorGenerico()
    {

    }

    [HttpPost("/{entidad}/entidad")]
    public async Task<IActionResult> POSTGenerico(string entidad, [FromBody] object dtoInsert)
    {
        return Ok();
    }


    [HttpPut("/{entidad}/entidad/{id}")]
    public async Task<IActionResult> PUTGenerico(string entidad, string id, [FromBody] object dtoUpdate)
    {
        return Ok();
    }

    [HttpGet("/{entidad}/entidad/{id}")]
    public async Task<IActionResult> UnicoPorId(string entidad, string id)
    {
        return Ok();
    }

    [HttpGet("/{entidad}/entidad")]
    public async Task<IActionResult> Pagina(string entidad, Consulta consulta)
    {
        return Ok();
    }

    [HttpDelete("/{entidad}/entidad/{id}")]
    public async Task<IActionResult> EliminarUnico(string entidad, string id)
    {
        return Ok();
    }

    [HttpPost("/{entidad}/entidad/eliminar")]
    public async Task<IActionResult> EliminarVarios(string entidad, [FromBody] string[] ids)
    {
        return Ok();
    }


}