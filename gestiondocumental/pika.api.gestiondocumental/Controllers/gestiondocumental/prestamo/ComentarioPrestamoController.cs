using Microsoft.AspNetCore.Mvc;
using pika.modelo.gestiondocumental;
using pika.servicios.gestiondocumental.prestamo;

namespace pika.api.gestiondocumental.Controllers.gestiondocumental.prestamo
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComentarioPrestamoController : ControllerBase
    {
        private readonly IServicioComentarioPrestamo _servicioComentarioPrestamo;
        private readonly ILogger<ComentarioPrestamoController> _logger;
        public ComentarioPrestamoController(IServicioComentarioPrestamo servicioComentarioPrestamo, ILogger<ComentarioPrestamoController> logger)
        {
            _servicioComentarioPrestamo = servicioComentarioPrestamo;
            _logger = logger;
        }




        // Crear el CRUD de API utilizando _servicioActivo

        // Crear
        [HttpPost()]

        public async Task<ActionResult<ComentarioPrestamo>> CrearComentarioPrestamo([FromBody] ComentarioPrestamo comentarioprestamo)
        {
            var resultado = await _servicioComentarioPrestamo.Crear(comentarioprestamo);

            if (resultado != null)
            {
                return Ok(resultado);
            }
            return BadRequest("Error Al Agregar");
        }


        // Leer
        [HttpGet]
        public async Task<ActionResult<List<ComentarioPrestamo>>> ObtenerComentarioPrestamo()
        {
            return await _servicioComentarioPrestamo.Obtiener();
        }

        //Actualizar
        [HttpPut("{id}")]
        public async Task<ActionResult<ComentarioPrestamo>> ActualizarComentarioPrestamo([FromRoute] string id, [FromBody] ComentarioPrestamo comentarioprestamo)
        {
            var resultado = await _servicioComentarioPrestamo.Actualizar(id, comentarioprestamo);

            if (resultado != null)
            {
                return Ok(resultado);
            }

            return BadRequest("Error Al Actualizar");
        }

        //Eliminar
        [HttpDelete("{id}")]

        public async Task<ActionResult<Activo>> EliminarComentarioPrestamo([FromRoute] string id, [FromBody] ComentarioPrestamo comentarioprestamo)
        {
            var resultado = await _servicioComentarioPrestamo.Eliminar(id, comentarioprestamo);

            if (resultado != null)
            {
                return Ok();
            }
            return BadRequest("Error Al Eliminar");

        }
    }
}
