using Microsoft.AspNetCore.Mvc;
using pika.api.gestiondocumental.Controllers.gestiondocumental.acervo;
using pika.modelo.gestiondocumental;
using pika.servicios.gestiondocumental.acervo;
using pika.servicios.gestiondocumental.topologia;

namespace pika.api.gestiondocumental.Controllers.gestiondocumental.topologia
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivoContenedorAlmacenController : ControllerBase
    {
        private readonly IServicioActivoContenedorAlmacen _servicioActivoContenedorAlmacen;
        private readonly ILogger<ActivoContenedorAlmacenController> _logger;

        public ActivoContenedorAlmacenController(IServicioActivoContenedorAlmacen servicioActivoContenedorAlmacen, ILogger<ActivoContenedorAlmacenController> logger)
        {

            _servicioActivoContenedorAlmacen = servicioActivoContenedorAlmacen;
            _logger = logger;
        }

        // Crear el CRUD de API utilizando _servicioActivo

        // Crear
        [HttpPost()]

        public async Task<ActionResult<ActivoContenedorAlmacen>> CrearActivoContenedorAlmacen([FromBody] ActivoContenedorAlmacen activocontenedoralmacen)
        {
            var resultado = await _servicioActivoContenedorAlmacen.Crear(activocontenedoralmacen);

            if (resultado != null)
            {
                return Ok(resultado);
            }
            return BadRequest("Error Al Agregar");
        }

        // Leer
        [HttpGet]
        public async Task<ActionResult<List<ActivoContenedorAlmacen>>> ObtienerActivoContenedorAlmacen()
        {
            return await _servicioActivoContenedorAlmacen.Obtiener();
        }

        //Actualizar
        [HttpPut("{id}")]
        public async Task<ActionResult<ActivoContenedorAlmacen>> ActualizarActivoContenedorAlmacen([FromRoute] string id, [FromBody] ActivoContenedorAlmacen activocontenedoralmacen)
        {
            var resultado = await _servicioActivoContenedorAlmacen.Actualizar(id, activocontenedoralmacen);

            if (resultado != null)
            {
                return Ok(resultado);
            }

            return BadRequest("Error Al Actualizar");
        }

        //Eliminar
        [HttpDelete("{id}")]

        public async Task<ActionResult<ActivoContenedorAlmacen>> EliminarActivoContenedorAlmacen([FromRoute] string id, [FromBody] ActivoContenedorAlmacen activocontenedoralmacen)
        {
            var resultado = await _servicioActivoContenedorAlmacen.Eliminar(id, activocontenedoralmacen);

            if (resultado != null)
            {
                return Ok();
            }
            return BadRequest("Error Al Eliminar");

        }
    }
}
