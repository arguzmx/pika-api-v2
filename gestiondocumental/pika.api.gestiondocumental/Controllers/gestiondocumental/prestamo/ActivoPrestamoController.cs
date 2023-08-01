using Microsoft.AspNetCore.Mvc;
using pika.api.gestiondocumental.Controllers.gestiondocumental.acervo;
using pika.modelo.gestiondocumental;
using pika.servicios.gestiondocumental.acervo;
using pika.servicios.gestiondocumental.prestamo;

namespace pika.api.gestiondocumental.Controllers.gestiondocumental.prestamo
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivoPrestamoController : ControllerBase
    {

        private readonly IServicioActivoPrestamo _servicioActivoPrestamo;
        private readonly ILogger<ActivoPrestamoController> _logger;
        public ActivoPrestamoController(IServicioActivoPrestamo servicioActivoPrestamo, ILogger<ActivoPrestamoController> logger)
        {
            _servicioActivoPrestamo = servicioActivoPrestamo;
            _logger = logger;
        }




        // Crear el CRUD de API utilizando _servicioActivo

        // Crear
        [HttpPost()]

        public async Task<ActionResult<ActivoPrestamo>> CrearActivoPrestamo([FromBody] ActivoPrestamo activoprestamo)
        {
            var resultado = await _servicioActivoPrestamo.Crear(activoprestamo);

            if (resultado != null)
            {
                return Ok(resultado);
            }
            return BadRequest("Error Al Agregar");
        }


        // Leer
        [HttpGet]
        public async Task<ActionResult<List<ActivoPrestamo>>> ObtenerActivoPrestamo()
        {
            return await _servicioActivoPrestamo.Obtiener();
        }

        //Actualizar
        [HttpPut("{id}")]
        public async Task<ActionResult<ActivoPrestamo>> ActualizarActivoPrestamo([FromRoute] string id, [FromBody] ActivoPrestamo activoprestamo)
        {
            var resultado = await _servicioActivoPrestamo.Actualizar(id, activoprestamo);

            if (resultado != null)
            {
                return Ok(resultado);
            }

            return BadRequest("Error Al Actualizar");
        }

        //Eliminar
        [HttpDelete("{id}")]

        public async Task<ActionResult<Activo>> EliminarActivoPrestamo([FromRoute] string id, [FromBody] ActivoPrestamo activoprestamo)
        {
            var resultado = await _servicioActivoPrestamo.Eliminar(id, activoprestamo);

            if (resultado != null)
            {
                return Ok();
            }
            return BadRequest("Error Al Eliminar");

        }
    }
}
