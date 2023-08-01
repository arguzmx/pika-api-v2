using Microsoft.AspNetCore.Mvc;
using pika.modelo.gestiondocumental;
using pika.servicios.gestiondocumental.dbcontext;
using pika.servicios.gestiondocumental.transferencias;

namespace pika.api.gestiondocumental.Controllers.gestiondocumental.transferencias
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventoTransferenciaController : ControllerBase
    {

        private readonly IServicioEventoTransferencia _servicioEventoTransferencia;
        private readonly ILogger<EventoTransferenciaController> _logger;
        public EventoTransferenciaController(IServicioEventoTransferencia servicioEventoTransferencia, ILogger<EventoTransferenciaController> logger)
        {
            _servicioEventoTransferencia = servicioEventoTransferencia;
            _logger = logger;
        }




        // Crear el CRUD de API utilizando _servicioActivo

        // Crear
        [HttpPost()]

        public async Task<ActionResult<EventoTransferencia>> CrearEventoTransferencia([FromBody] EventoTransferencia eventotransferencia)
        {
            var resultado = await _servicioEventoTransferencia.Crear(eventotransferencia);

            if (resultado != null)
            {
                return Ok(resultado);
            }
            return BadRequest("Error Al Agregar");
        }


        // Leer
        [HttpGet]
        public async Task<ActionResult<List<EventoTransferencia>>> ObtenerEventoTransferencia()
        {
            return await _servicioEventoTransferencia.Obtiener();
        }

        //Actualizar
        [HttpPut("{id}")]
        public async Task<ActionResult<EventoTransferencia>> ActualizarEventoTransferencia([FromRoute] string id, [FromBody] EventoTransferencia eventotransferencia)
        {
            var resultado = await _servicioEventoTransferencia.Actualizar(id, eventotransferencia);

            if (resultado != null)
            {
                return Ok(resultado);
            }

            return BadRequest("Error Al Actualizar");
        }

        //Eliminar
        [HttpDelete("{id}")]

        public async Task<ActionResult<Activo>> EliminarEventoTransferencia([FromRoute] string id, [FromBody] EventoTransferencia eventotransferencia)
        {
            var resultado = await _servicioEventoTransferencia.Eliminar(id, eventotransferencia);

            if (resultado != null)
            {
                return Ok();
            }
            return BadRequest("Error Al Eliminar");

        }

    }
}
