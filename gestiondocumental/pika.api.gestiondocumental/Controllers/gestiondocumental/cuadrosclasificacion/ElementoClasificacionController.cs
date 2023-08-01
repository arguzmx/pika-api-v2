using Microsoft.AspNetCore.Mvc;
using pika.modelo.gestiondocumental;
using pika.servicios.gestiondocumental.cuadrosclasificacion;

namespace pika.api.gestiondocumental.Controllers.gestiondocumental.cuadrosclasificacion
{
    [Route("api/[controller]")]
    [ApiController]
    public class ElementoClasificacionController : ControllerBase
    {

        private readonly IServicioElementoClasificacion _servicioElementoClasificacion;
        private readonly ILogger<ElementoClasificacionController> _logger;

        public ElementoClasificacionController(IServicioElementoClasificacion servicioElementoClasificacion, ILogger<ElementoClasificacionController> logger)
        {

            _servicioElementoClasificacion = servicioElementoClasificacion;
            _logger = logger;
        }




        // Crear el CRUD de API utilizando _servicioActivo

        // Crear
        [HttpPost()]

        public async Task<ActionResult<ElementoClasificacion>> CrearElementoClasificacion([FromBody] ElementoClasificacion elementoclasificacion)
        {
            var resultado = await _servicioElementoClasificacion.Crear(elementoclasificacion);

            if (resultado != null)
            {
                return Ok(resultado);
            }
            return BadRequest("Error Al Agregar");
        }


        // Leer
        [HttpGet()]
        public async Task<ActionResult<List<ElementoClasificacion>>> ObtienerElementoClasificacion()
        {
            return await _servicioElementoClasificacion.Obtiener();
        }

        //Actualizar
        [HttpPut("{id}")]
        public async Task<ActionResult<ElementoClasificacion>> ActualizarElementoClasificacion([FromRoute] string id, [FromBody] ElementoClasificacion elementoclasificacion)
        {
            var resultado = await _servicioElementoClasificacion.Actualizar(id, elementoclasificacion);

            if (resultado != null)
            {
                return Ok(resultado);
            }

            return BadRequest("Error Al Actualizar");
        }

        //Eliminar
        [HttpDelete("{id}")]

        public async Task<ActionResult<ElementoClasificacion>> EliminarElementoClasificacion([FromRoute] string id, [FromBody] ElementoClasificacion elementoclasificacion)
        {
            var resultado = await _servicioElementoClasificacion.Eliminar(id, elementoclasificacion);

            if (resultado != null)
            {
                return Ok();
            }
            return BadRequest("Error Al Eliminar");

        }

    }
}
