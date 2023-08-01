using Microsoft.AspNetCore.Mvc;
using pika.modelo.gestiondocumental;
using pika.servicios.gestiondocumental.topologia;

namespace pika.api.gestiondocumental.Controllers.gestiondocumental.topologia
{
    [Route("api/[controller]")]
    [ApiController]
    public class ZonaAlmacenController : ControllerBase
    {
        private readonly IServicioZonaAlmacen _servicioZonaAlmacen;
        private readonly ILogger<ZonaAlmacenController> _logger;

        public ZonaAlmacenController(IServicioZonaAlmacen servicioZonaAlmacen, ILogger<ZonaAlmacenController> logger)
        {

            _servicioZonaAlmacen = servicioZonaAlmacen;
            _logger = logger;
        }

        // Crear el CRUD de API utilizando _servicioActivo

        // Crear
        [HttpPost()]

        public async Task<ActionResult<ZonaAlmacen>> CrearZonaAlmacen([FromBody] ZonaAlmacen zonaalmacen)
        {
            var resultado = await _servicioZonaAlmacen.Crear(zonaalmacen);

            if (resultado != null)
            {
                return Ok(resultado);
            }
            return BadRequest("Error Al Agregar");
        }

        // Leer
        [HttpGet]
        public async Task<ActionResult<List<ZonaAlmacen>>> ObtienerZonaAlmacen()
        {
            return await _servicioZonaAlmacen.Obtiener();
        }

        //Actualizar
        [HttpPut("{id}")]
        public async Task<ActionResult<ZonaAlmacen>> ActualizarZonaAlmacen([FromRoute] string id, [FromBody] ZonaAlmacen zonaalmacen)
        {
            var resultado = await _servicioZonaAlmacen.Actualizar(id, zonaalmacen);

            if (resultado != null)
            {
                return Ok(resultado);
            }

            return BadRequest("Error Al Actualizar");
        }

        //Eliminar
        [HttpDelete("{id}")]

        public async Task<ActionResult<ZonaAlmacen>> EliminarZonaAlmacen([FromRoute] string id, [FromBody] ZonaAlmacen zonaalmacen)
        {
            var resultado = await _servicioZonaAlmacen.Eliminar(id, zonaalmacen);

            if (resultado != null)
            {
                return Ok();
            }
            return BadRequest("Error Al Eliminar");

        }
    }
}
