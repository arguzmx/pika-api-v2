using Microsoft.AspNetCore.Mvc;
using pika.modelo.gestiondocumental;
using pika.servicios.gestiondocumental.archivos;

namespace pika.api.gestiondocumental.Controllers.gestiondocumental.archivos
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnidadAdministrativaArchivoController : ControllerBase
    {

        private readonly IServicioUnidadAdministrativaArchivo _servicioUnidadAdministrativaArchivo;
        private readonly ILogger<UnidadAdministrativaArchivoController> _logger;

        public UnidadAdministrativaArchivoController(IServicioUnidadAdministrativaArchivo servicioUnidadAdministrativaArchivo, ILogger<UnidadAdministrativaArchivoController> logger)
        {

            _servicioUnidadAdministrativaArchivo = servicioUnidadAdministrativaArchivo;
            _logger = logger;
        }




        // Crear el CRUD de API utilizando _servicioActivo

        // Crear
        [HttpPost()]

        public async Task<ActionResult<UnidadAdministrativaArchivo>> CrearUnidadAdministrativaArchivo([FromBody] UnidadAdministrativaArchivo unidadadministrativaarchivo)
        {
            var resultado = await _servicioUnidadAdministrativaArchivo.Crear(unidadadministrativaarchivo);

            if (resultado != null)
            {
                return Ok(resultado);
            }
            return BadRequest("Error Al Agregar");
        }


        // Leer
        [HttpGet()]
        public async Task<ActionResult<List<UnidadAdministrativaArchivo>>> ObtienerUnidadAdministrativaArchivo()
        {
            return await _servicioUnidadAdministrativaArchivo.Obtiener();
        }

        //Actualizar
        [HttpPut("{id}")]
        public async Task<ActionResult<UnidadAdministrativaArchivo>> ActualizarUnidadAdministrativaArchivo([FromRoute] string id, [FromBody] UnidadAdministrativaArchivo unidadadministrativaarchivo)
        {
            var resultado = await _servicioUnidadAdministrativaArchivo.Actualizar(id, unidadadministrativaarchivo);

            if (resultado != null)
            {
                return Ok(resultado);
            }

            return BadRequest("Error Al Actualizar");
        }

        //Eliminar
        [HttpDelete("{id}")]

        public async Task<ActionResult<UnidadAdministrativaArchivo>> EliminarUnidadAdministrativaArchivo([FromRoute] string id, [FromBody] UnidadAdministrativaArchivo unidadadministrativaarchivo)
        {
            var resultado = await _servicioUnidadAdministrativaArchivo.Eliminar(id, unidadadministrativaarchivo);

            if (resultado != null)
            {
                return Ok();
            }
            return BadRequest("Error Al Eliminar");

        }

    }
}
