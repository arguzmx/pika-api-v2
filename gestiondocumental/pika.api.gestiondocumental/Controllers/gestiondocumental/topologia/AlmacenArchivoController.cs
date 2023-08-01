using Microsoft.AspNetCore.Mvc;
using pika.modelo.gestiondocumental;
using pika.servicios.gestiondocumental.topologia;

namespace pika.api.gestiondocumental.Controllers.gestiondocumental.topologia
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlmacenArchivoController : ControllerBase
    {

        private readonly IServicioAlmacenArchivo _servicioAlmacenArchivo;
        private readonly ILogger<AlmacenArchivoController> _logger;

        public AlmacenArchivoController(IServicioAlmacenArchivo servicioAlmacenArchivo, ILogger<AlmacenArchivoController> logger)
        {

            _servicioAlmacenArchivo = servicioAlmacenArchivo;
            _logger = logger;
        }

        // Crear el CRUD de API utilizando _servicioActivo

        // Crear
        [HttpPost()]

        public async Task<ActionResult<AlmacenArchivo>> CrearAlmacenArchivo([FromBody] AlmacenArchivo almacenarchivo)
        {
            var resultado = await _servicioAlmacenArchivo.Crear(almacenarchivo);

            if (resultado != null)
            {
                return Ok(resultado);
            }
            return BadRequest("Error Al Agregar");
        }

        // Leer
        [HttpGet]
        public async Task<ActionResult<List<AlmacenArchivo>>> ObtienerAlmacenArchivo()
        {
            return await _servicioAlmacenArchivo.Obtiener();
        }

        //Actualizar
        [HttpPut("{id}")]
        public async Task<ActionResult<AlmacenArchivo>> ActualizarAlmacenArchivo([FromRoute] string id, [FromBody] AlmacenArchivo almacenarchivo)
        {
            var resultado = await _servicioAlmacenArchivo.Actualizar(id, almacenarchivo);

            if (resultado != null)
            {
                return Ok(resultado);
            }

            return BadRequest("Error Al Actualizar");
        }

        //Eliminar
        [HttpDelete("{id}")]

        public async Task<ActionResult<AlmacenArchivo>> EliminarAlmacenArchivo([FromRoute] string id, [FromBody] AlmacenArchivo almacenarchivo)
        {
            var resultado = await _servicioAlmacenArchivo.Eliminar(id, almacenarchivo);

            if (resultado != null)
            {
                return Ok();
            }
            return BadRequest("Error Al Eliminar");

        }

    }
}
