using Microsoft.AspNetCore.Mvc;
using pika.modelo.gestiondocumental;
using pika.servicios.gestiondocumental.transferencias;

namespace pika.api.gestiondocumental.Controllers.gestiondocumental.transferencias
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComentarioTrasnferenciaController : ControllerBase
    {
        private readonly IServicioComentarioTrasnferencia _servicioComentarioTransferencia;
        private readonly ILogger<ComentarioTrasnferenciaController> _logger;

        public ComentarioTrasnferenciaController(IServicioComentarioTrasnferencia servicioComentarioTransferencia, ILogger<ComentarioTrasnferenciaController> logger)
        {

            _servicioComentarioTransferencia = servicioComentarioTransferencia;
            _logger = logger;
        }




        // Crear el CRUD de API utilizando _servicioActivo

        // Crear
        [HttpPost()]

        public async Task<ActionResult<ComentarioTransferencia>> CrearComentarioTransferencia([FromBody] ComentarioTransferencia comentariotransferencia)
        {
            var resultado = await _servicioComentarioTransferencia.Crear(comentariotransferencia);

            if (resultado != null)
            {
                return Ok(resultado);
            }
            return BadRequest("Error Al Agregar");
        }


        // Leer
        [HttpGet]
        public async Task<ActionResult<List<ComentarioTransferencia>>> ObtenerComentarioTransferencia()
        {
            return await _servicioComentarioTransferencia.Obtiener();
        }

        //Actualizar
        [HttpPut("{id}")]
        public async Task<ActionResult<ComentarioTransferencia>> ActualizarComentarioTransferencia([FromRoute] string id, [FromBody] ComentarioTransferencia comentariotransferencia)
        {
            var resultado = await _servicioComentarioTransferencia.Actualizar(id, comentariotransferencia);

            if (resultado != null)
            {
                return Ok(resultado);
            }

            return BadRequest("Error Al Actualizar");
        }

        //Eliminar
        [HttpDelete("{id}")]

        public async Task<ActionResult<ComentarioTransferencia>> EliminarComentarioTransferencia([FromRoute] string id, [FromBody] ComentarioTransferencia comentariotransferencia)
        {
            var resultado = await _servicioComentarioTransferencia.Eliminar(id, comentariotransferencia);

            if (resultado != null)
            {
                return Ok();
            }
            return BadRequest("Error Al Eliminar");

        }
    }
}
