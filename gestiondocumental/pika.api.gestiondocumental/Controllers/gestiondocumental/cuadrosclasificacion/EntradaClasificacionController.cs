using Microsoft.AspNetCore.Mvc;
using pika.modelo.gestiondocumental;
using pika.servicios.gestiondocumental.cuadrosclasificacion;

namespace pika.api.gestiondocumental.Controllers.gestiondocumental.cuadrosclasificacion
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntradaClasificacionController : ControllerBase
    {

        private readonly IServicioEntradaClasificacion _servicioEntradaClasificacion;
        private readonly ILogger<EntradaClasificacionController> _logger;

        public EntradaClasificacionController(IServicioEntradaClasificacion servicioEntradaClasificacion, ILogger<EntradaClasificacionController> logger)
        {

           _servicioEntradaClasificacion = servicioEntradaClasificacion;
            _logger = logger;
        }
        // Crear el CRUD de API utilizando _servicioActivo

        // Crear
        [HttpPost()]

        public async Task<ActionResult<EntradaClasificacion>> CrearEntradaClasificacion([FromBody] EntradaClasificacion entradaclasificacion)
        {
            var resultado = await _servicioEntradaClasificacion.Crear(entradaclasificacion);

            if (resultado != null)
            {
                return Ok(resultado);
            }
            return BadRequest("Error Al Agregar");
        }


        // Leer
        [HttpGet()]
        public async Task<ActionResult<List<EntradaClasificacion>>> ObtienerEntradaClasificacion()
        {
            return await _servicioEntradaClasificacion.Obtiener();
        }

        //Actualizar
        [HttpPut("{id}")]
        public async Task<ActionResult<EntradaClasificacion>> ActualizarEntradaClasificacion([FromRoute] string id, [FromBody] EntradaClasificacion entradaclasificacion)
        {
            var resultado = await _servicioEntradaClasificacion.Actualizar(id, entradaclasificacion);

            if (resultado != null)
            {
                return Ok(resultado);
            }

            return BadRequest("Error Al Actualizar");
        }

        //Eliminar
        [HttpDelete("{id}")]

        public async Task<ActionResult<EntradaClasificacion>> EliminarEntradaClasificacion([FromRoute] string id, [FromBody] EntradaClasificacion entradaclasificacion)
        {
            var resultado = await _servicioEntradaClasificacion.Eliminar(id, entradaclasificacion);

            if (resultado != null)
            {
                return Ok();
            }
            return BadRequest("Error Al Eliminar");

        }

    }
}
