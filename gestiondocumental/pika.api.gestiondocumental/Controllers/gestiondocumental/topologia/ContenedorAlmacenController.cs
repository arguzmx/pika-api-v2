using Microsoft.AspNetCore.Mvc;
using pika.modelo.gestiondocumental;
using pika.servicios.gestiondocumental.topologia;

namespace pika.api.gestiondocumental.Controllers.gestiondocumental.topologia
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContenedorAlmacenController : ControllerBase
    {

        private readonly IServicioContenedorAlmacen _servicioContenedorAlmacen;
        private readonly ILogger<ContenedorAlmacenController> _logger;

        public ContenedorAlmacenController(IServicioContenedorAlmacen servicioContenedorAlmacen, ILogger<ContenedorAlmacenController> logger)
        {

            _servicioContenedorAlmacen = servicioContenedorAlmacen;
            _logger = logger;
        }

        // Crear el CRUD de API utilizando _servicioActivo

        // Crear
        [HttpPost()]

        public async Task<ActionResult<ContenedorAlmacen>> CrearContenedorAlmacen([FromBody] ContenedorAlmacen contenedoralmacen)
        {
            var resultado = await _servicioContenedorAlmacen.Crear(contenedoralmacen);

            if (resultado != null)
            {
                return Ok(resultado);
            }
            return BadRequest("Error Al Agregar");
        }

        // Leer
        [HttpGet]
        public async Task<ActionResult<List<ContenedorAlmacen>>> ObtienerContenedorAlmacen()
        {
            return await _servicioContenedorAlmacen.Obtiener();
        }

        //Actualizar
        [HttpPut("{id}")]
        public async Task<ActionResult<ContenedorAlmacen>> ActualizarContenedorAlmacen([FromRoute] string id, [FromBody] ContenedorAlmacen contenedoralmacen)
        {
            var resultado = await _servicioContenedorAlmacen.Actualizar(id, contenedoralmacen);

            if (resultado != null)
            {
                return Ok(resultado);
            }

            return BadRequest("Error Al Actualizar");
        }

        //Eliminar
        [HttpDelete("{id}")]

        public async Task<ActionResult<ContenedorAlmacen>> EliminarContenedorAlmacen([FromRoute] string id, [FromBody] ContenedorAlmacen contenedoralmacen)
        {
            var resultado = await _servicioContenedorAlmacen.Eliminar(id, contenedoralmacen);

            if (resultado != null)
            {
                return Ok();
            }
            return BadRequest("Error Al Eliminar");

        }

    }
}
