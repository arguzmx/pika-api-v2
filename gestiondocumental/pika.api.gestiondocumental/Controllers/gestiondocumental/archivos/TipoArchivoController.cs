using Microsoft.AspNetCore.Mvc;
using pika.modelo.gestiondocumental;
using pika.servicios.gestiondocumental.archivos;
using pika.api.gestiondocumental.Controllers.gestiondocumental.archivos;
using pika.servicios.gestiondocumental.archivos;

namespace pika.api.gestiondocumental.Controllers.gestiondocumental.archivos
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoArchivoController : ControllerBase
    {

        private readonly IServicioTipoArchivo _servicioTipoArchivo;
        private readonly ILogger<TipoArchivoController> _logger;

        public TipoArchivoController(IServicioTipoArchivo servicioTipoArchivo, ILogger<TipoArchivoController> logger)
        {

            _servicioTipoArchivo = servicioTipoArchivo;
            _logger = logger;
        }




        // Crear el CRUD de API utilizando _servicioActivo

        // Crear
        [HttpPost()]

        public async Task<ActionResult<TipoArchivo>> CrearTipoArchivo([FromBody] TipoArchivo tipoarchivo)
        {
            var resultado = await _servicioTipoArchivo.Crear(tipoarchivo);

            if (resultado != null)
            {
                return Ok(resultado);
            }
            return BadRequest("Error Al Agregar");
        }


        // Leer
        [HttpGet()]
        public async Task<ActionResult<List<TipoArchivo>>> ObtienerTipoArchivo()
        {
            return await _servicioTipoArchivo.Obtiener();
        }

        //Actualizar
        [HttpPut("{id}")]
        public async Task<ActionResult<TipoArchivo>> ActualizarTipoArchivo([FromRoute] string id, [FromBody] TipoArchivo tipoarchivo)
        {
            var resultado = await _servicioTipoArchivo.Actualizar(id, tipoarchivo);

            if (resultado != null)
            {
                return Ok(resultado);
            }

            return BadRequest("Error Al Actualizar");
        }

        //Eliminar
        [HttpDelete("{id}")]

        public async Task<ActionResult<TipoArchivo>> EliminarTipoArchivo([FromRoute] string id, [FromBody] TipoArchivo tipoarchivo)
        {
            var resultado = await _servicioTipoArchivo.Eliminar(id, tipoarchivo);

            if (resultado != null)
            {
                return Ok();
            }
            return BadRequest("Error Al Eliminar");

        }

    }
}
