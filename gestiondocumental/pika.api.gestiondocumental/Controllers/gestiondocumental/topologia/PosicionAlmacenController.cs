using Microsoft.AspNetCore.Mvc;
using pika.modelo.gestiondocumental;
using pika.servicios.gestiondocumental.topologia;

namespace pika.api.gestiondocumental.Controllers.gestiondocumental.topologia
{
    [Route("api/[controller]")]
    [ApiController]
    public class PosicionAlmacenController : ControllerBase
    {

        private readonly IServicioPosicionAlmacen _servicioPosicionAlmacen;
        private readonly ILogger<PosicionAlmacenController> _logger;

        public PosicionAlmacenController(IServicioPosicionAlmacen servicioPosicionAlmacen, ILogger<PosicionAlmacenController> logger)
        {

            _servicioPosicionAlmacen = servicioPosicionAlmacen;
            _logger = logger;
        }

        // Crear el CRUD de API utilizando _servicioActivo

        // Crear
        [HttpPost()]

        public async Task<ActionResult<PosicionAlmacen>> CrearPosicionAlmacen([FromBody] PosicionAlmacen posicionalmacen)
        {
            var resultado = await _servicioPosicionAlmacen.Crear(posicionalmacen);

            if (resultado != null)
            {
                return Ok(resultado);
            }
            return BadRequest("Error Al Agregar");
        }

        // Leer
        [HttpGet]
        public async Task<ActionResult<List<PosicionAlmacen>>> ObtienerPosicionAlmacen()
        {
            return await _servicioPosicionAlmacen.Obtiener();
        }

        //Actualizar
        [HttpPut("{id}")]
        public async Task<ActionResult<PosicionAlmacen>> ActualizarPosicionAlmacen([FromRoute] string id, [FromBody] PosicionAlmacen posicionalmacen)
        {
            var resultado = await _servicioPosicionAlmacen.Actualizar(id, posicionalmacen);

            if (resultado != null)
            {
                return Ok(resultado);
            }

            return BadRequest("Error Al Actualizar");
        }

        //Eliminar
        [HttpDelete("{id}")]

        public async Task<ActionResult<PosicionAlmacen>> EliminarPosicionAlmacen([FromRoute] string id, [FromBody] PosicionAlmacen posicionalmacen)
        {
            var resultado = await _servicioPosicionAlmacen.Eliminar(id, posicionalmacen);

            if (resultado != null)
            {
                return Ok();
            }
            return BadRequest("Error Al Eliminar");

        }

    }
}
