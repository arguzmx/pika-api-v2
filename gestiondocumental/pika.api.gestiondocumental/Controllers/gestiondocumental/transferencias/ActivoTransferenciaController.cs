using Microsoft.AspNetCore.Mvc;
using pika.api.gestiondocumental.Controllers.gestiondocumental.acervo;
using pika.modelo.gestiondocumental;
using pika.servicios.gestiondocumental.acervo;
using pika.servicios.gestiondocumental.transferencias;

namespace pika.api.gestiondocumental.Controllers.gestiondocumental.transferencias
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivoTransferenciaController : ControllerBase
    {

        private readonly IServicioActivoTranferencia _servicioActivoTransferencia;
        private readonly ILogger<ActivoTransferenciaController> _logger;

        public ActivoTransferenciaController(IServicioActivoTranferencia servicioActivoTransferencia, ILogger<ActivoTransferenciaController> logger)
        {

            _servicioActivoTransferencia = servicioActivoTransferencia;
            _logger = logger;
        }




        // Crear el CRUD de API utilizando _servicioActivo

        // Crear
        [HttpPost()]

        public async Task<ActionResult<ActivoTransferencia>> CrearActivoTransferencia([FromBody] ActivoTransferencia activotransferencia)
        {
            var resultado = await _servicioActivoTransferencia.Crear(activotransferencia);

            if (resultado != null)
            {
                return Ok(resultado);
            }
            return BadRequest("Error Al Agregar");
        }


        // Leer
        [HttpGet]
        public async Task<ActionResult<List<ActivoTransferencia>>> ObtenerActivoTransferencia()
        {
            return await _servicioActivoTransferencia.Obtiener();
        }

        //Actualizar
        [HttpPut("{id}")]
        public async Task<ActionResult<ActivoTransferencia>> ActualizarActivoTransferencia([FromRoute] string id, [FromBody] ActivoTransferencia activotransferencia)
        {
            var resultado = await _servicioActivoTransferencia.Actualizar(id, activotransferencia);

            if (resultado != null)
            {
                return Ok(resultado);
            }

            return BadRequest("Error Al Actualizar");
        }

        //Eliminar
        [HttpDelete("{id}")]

        public async Task<ActionResult<Activo>> EliminarActivoTransferencia([FromRoute] string id, [FromBody] ActivoTransferencia activotransferencia)
        {
            var resultado = await _servicioActivoTransferencia.Eliminar(id, activotransferencia);

            if (resultado != null)
            {
                return Ok();
            }
            return BadRequest("Error Al Eliminar");

        }

    }
}
