using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace pika.api.gestiondocumental.Controllers
{
    [Route("/")]
    [ApiController]
    public class Generico : ControllerBase
    {

        [HttpPost("/{entidad}/entidad")]
        public async Task<IActionResult> POSTGenerico(string entidad) {
            return Ok();
        }


        [HttpPut("/{entidad}/entidad/{id}")]
        public async Task<IActionResult> PUTGenerico(string entidad, string id)
        {
            return Ok();
        }


    }
}
