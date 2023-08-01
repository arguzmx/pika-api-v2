using Microsoft.AspNetCore.Mvc;
using pika.modelo.gestiondocumental;
using pika.servicios.gestiondocumental.acervo;

namespace pika.api.gestiondocumental.Controllers.gestiondocumental.acervo
{
    [Route("api/[controller]")]
    [ApiController]
    public class AmpliacionController : ControllerBase
    {

        private readonly IServicioAmpliacion _servicioAmpliacion;
        private readonly ILogger<AmpliacionController> _logger;
        public AmpliacionController(IServicioAmpliacion servicioAmpliacion, ILogger<AmpliacionController> logger)
        {
            _servicioAmpliacion = servicioAmpliacion;
            _logger = logger;
        }




        // Crear el CRUD de API utilizando _servicioActivo

        // Crear
        [HttpPost()]

        public async Task<ActionResult<Ampliacion>> CrearAmpliacion([FromBody] Ampliacion ampliacion)
        {
            var resultado = await _servicioAmpliacion.Crear(ampliacion);

            if (resultado != null)
            {
                return Ok(resultado);
            }
            return BadRequest("Error Al Agregar");
        }


        // Leer
        [HttpGet]
        public async Task<ActionResult<List<Ampliacion>>> ObtenerAmpliacion()
        {
            return await _servicioAmpliacion.Obtiener();
        }

        //Actualizar
        [HttpPut("{id}")]
        public async Task<ActionResult<Ampliacion>> ActualizarAmpliacion([FromRoute] string id, [FromBody] Ampliacion ampliacion)
        {
            var resultado = await _servicioAmpliacion.Actualizar(id, ampliacion);

            if (resultado != null)
            {
                return Ok(resultado);
            }

            return BadRequest("Error Al Actualizar");
        }

        //Eliminar
        [HttpDelete("{id}")]

        public async Task<ActionResult<Activo>> EliminarAmpliacion([FromRoute] string id, [FromBody] Ampliacion ampliacion)
        {
            var resultado = await _servicioAmpliacion.Eliminar(id, ampliacion);

            if (resultado != null)
            {
                return Ok();
            }
            return BadRequest("Error Al Eliminar");

        }

    }
}
