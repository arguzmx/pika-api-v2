using Microsoft.AspNetCore.Mvc;
using pika.modelo.gestiondocumental;
using pika.servicios.gestiondocumental.prestamo;

namespace pika.api.gestiondocumental.Controllers.gestiondocumental.prestamo
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrestamoController : ControllerBase
    {

        private readonly IServicioPrestamo _servicioPrestamo;
        private readonly ILogger<PrestamoController> _logger;
        public PrestamoController(IServicioPrestamo servicioPrestamo, ILogger<PrestamoController> logger)
        {
            _servicioPrestamo = servicioPrestamo;
            _logger = logger;
        }




        // Crear el CRUD de API utilizando _servicioActivo

        // Crear
        [HttpPost()]

        public async Task<ActionResult<Prestamo>> CrearPrestamo([FromBody] Prestamo prestamo)
        {
            var resultado = await _servicioPrestamo.Crear(prestamo);

            if (resultado != null)
            {
                return Ok(resultado);
            }
            return BadRequest("Error Al Agregar");
        }


        // Leer
        [HttpGet]
        public async Task<ActionResult<List<Prestamo>>> ObtenerPrestamo()
        {
            return await _servicioPrestamo.Obtiener();
        }

        //Actualizar
        [HttpPut("{id}")]
        public async Task<ActionResult<Prestamo>> ActualizarPrestamo([FromRoute] string id, [FromBody] Prestamo prestamo)
        {
            var resultado = await _servicioPrestamo.Actualizar(id, prestamo);

            if (resultado != null)
            {
                return Ok(resultado);
            }

            return BadRequest("Error Al Actualizar");
        }

        //Eliminar
        [HttpDelete("{id}")]

        public async Task<ActionResult<Activo>> EliminarPrestamo([FromRoute] string id, [FromBody] Prestamo prestamo)
        {
            var resultado = await _servicioPrestamo.Eliminar(id, prestamo);

            if (resultado != null)
            {
                return Ok();
            }
            return BadRequest("Error Al Eliminar");

        }
    }
}
