using api.comunes.modelos.respuestas;
using Microsoft.AspNetCore.Mvc;

namespace api.comunes;


[Route("/")]
[ApiController]
public class ControladorGenerico : ControllerBase
{

    public ControladorGenerico()
    {

    }

    [HttpPost("/{entidad}/entidad")]
    public async Task<IActionResult> POSTGenerico(string entidad, [FromBody] object dto)
    {
        return Ok();
    }


    [HttpPut("/{entidad}/entidad/{id}")]
    public async Task<IActionResult> PUTGenerico(string entidad, string id, [FromBody] object dto)
    {
        return Ok();
    }

    [HttpGet("/{entidad}/entidad/{id}")]
    public async Task<IActionResult> UnicoPorId(string entidad, string id)
    {
        return Ok();
    }

    [HttpGet("/{entidad}/entidad")]
    public async Task<IActionResult> Pagina(string entidad, SolicitudPaginado paginado)
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