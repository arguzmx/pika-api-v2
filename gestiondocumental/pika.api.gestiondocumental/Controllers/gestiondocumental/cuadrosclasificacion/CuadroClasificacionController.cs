using Microsoft.AspNetCore.Mvc;
using pika.api.gestiondocumental.Controllers.gestiondocumental.acervo;
using pika.modelo.gestiondocumental;
using pika.servicios.gestiondocumental.cuadrosclasificacion;


namespace pika.api.gestiondocumental.Controllers.gestiondocumental.cuadrosclasificacion
{
    [Route("api/[controller]")]
    [ApiController]
    public class CuadroClasificacionController : ControllerBase
    {

        private readonly IServicioCuadroClasificacion _servicioCuadroClasificacion;
        private readonly ILogger<CuadroClasificacionController> _logger;

        public CuadroClasificacionController(IServicioCuadroClasificacion servicioCuadroClasificacion, ILogger<CuadroClasificacionController> logger)
        {

            _servicioCuadroClasificacion = servicioCuadroClasificacion;
            _logger = logger;
        }




        // Crear el CRUD de API utilizando _servicioActivo

        // Crear
        [HttpPost()]

        public async Task<ActionResult<CuadroClasificacion>> CrearCuadroClasificacion([FromBody] CuadroClasificacion cuadroclasificacion)
        {
            var resultado = await _servicioCuadroClasificacion.Crear(cuadroclasificacion);

            if (resultado != null)
            {
                return Ok(resultado);
            }
            return BadRequest("Error Al Agregar");
        }


        // Leer
        [HttpGet()]
        public async Task<ActionResult<List<CuadroClasificacion>>> ObtienerCuadroClasificacion()
        {
            return await _servicioCuadroClasificacion.Obtiener();
        }

        //Actualizar
        [HttpPut("{id}")]
        public async Task<ActionResult<CuadroClasificacion>> ActualizarCuadroClasificacion([FromRoute] string id, [FromBody] CuadroClasificacion cuadroclasificacion)
        {
            var resultado = await _servicioCuadroClasificacion.Actualizar(id, cuadroclasificacion);

            if (resultado != null)
            {
                return Ok(resultado);
            }

            return BadRequest("Error Al Actualizar");
        }

        //Eliminar
        [HttpDelete("{id}")]

        public async Task<ActionResult<CuadroClasificacion>> EliminarCuadroClasificacion([FromRoute] string id, [FromBody] CuadroClasificacion cuadroclasificacion)
        {
            var resultado = await _servicioCuadroClasificacion.Eliminar(id, cuadroclasificacion);

            if (resultado != null)
            {
                return Ok();
            }
            return BadRequest("Error Al Eliminar");

        }

    }
}
