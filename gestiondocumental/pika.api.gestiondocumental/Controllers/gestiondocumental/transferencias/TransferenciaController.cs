using Microsoft.AspNetCore.Mvc;
using pika.modelo.gestiondocumental;
using pika.servicios.gestiondocumental.transferencias;

namespace pika.api.gestiondocumental.Controllers.gestiondocumental.transferencias
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransferenciaController : ControllerBase
    {
        private readonly IServicioTransferencia _servicioTransferencia;
        private readonly ILogger<TransferenciaController> _logger;
        public TransferenciaController(IServicioTransferencia servicioTransferencia, ILogger<TransferenciaController> logger)
        {
            _servicioTransferencia = servicioTransferencia;
            _logger = logger;
        }




        // Crear el CRUD de API utilizando _servicioActivo

        // Crear
        [HttpPost()]

        public async Task<ActionResult<Transferencia>> CrearTransferencia([FromBody] Transferencia transferencia)
        {
            var resultado = await _servicioTransferencia.Crear(transferencia);

            if (resultado != null)
            {
                return Ok(resultado);
            }
            return BadRequest("Error Al Agregar");
        }


        // Leer
        [HttpGet]
        public async Task<ActionResult<List<Transferencia>>> ObtenerTransferencia()
        {
            return await _servicioTransferencia.Obtiener();
        }

        //Actualizar
        [HttpPut("{id}")]
        public async Task<ActionResult<Transferencia>> ActualizarTransferencia([FromRoute] string id, [FromBody] Transferencia transferencia)
        {
            var resultado = await _servicioTransferencia.Actualizar(id, transferencia);

            if (resultado != null)
            {
                return Ok(resultado);
            }

            return BadRequest("Error Al Actualizar");
        }

        //Eliminar
        [HttpDelete("{id}")]

        public async Task<ActionResult<Activo>> EliminarTransferencia([FromRoute] string id, [FromBody] Transferencia transferencia)
        {
            var resultado = await _servicioTransferencia.Eliminar(id, transferencia);

            if (resultado != null)
            {
                return Ok();
            }
            return BadRequest("Error Al Eliminar");

        }
    }
}
