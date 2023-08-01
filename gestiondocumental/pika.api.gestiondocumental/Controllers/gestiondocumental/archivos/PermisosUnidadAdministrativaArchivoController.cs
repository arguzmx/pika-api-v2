using Microsoft.AspNetCore.Mvc;
using pika.modelo.gestiondocumental;
using pika.servicios.gestiondocumental.archivos;

namespace pika.api.gestiondocumental.Controllers.gestiondocumental.archivos
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermisosUnidadAdministrativaArchivoController : ControllerBase
    {
        private readonly IServicioPermisosUnidadAdministrativaArchivo _servicioPermisosUnidadAdministrativaArchivo;
        private readonly ILogger<PermisosUnidadAdministrativaArchivoController> _logger;
        public PermisosUnidadAdministrativaArchivoController(IServicioPermisosUnidadAdministrativaArchivo servicioPermisosUnidadAdministrativaArchivo, ILogger<PermisosUnidadAdministrativaArchivoController> logger)
        {
            _servicioPermisosUnidadAdministrativaArchivo = servicioPermisosUnidadAdministrativaArchivo;
            _logger = logger;
        }


        // Crear el CRUD de API utilizando _servicioActivo

        // Crear
        [HttpPost()]

        public async Task<ActionResult<PermisosUnidadAdministrativaArchivo>> CrearPermisosUnidadAdministrativaArchivo([FromBody] PermisosUnidadAdministrativaArchivo permisosunidadadministrativaarchivo)
        {
            var resultado = await _servicioPermisosUnidadAdministrativaArchivo.Crear(permisosunidadadministrativaarchivo);

            if (resultado != null)
            {
                return Ok(resultado);
            }
            return BadRequest("Error Al Agregar");
        }


        // Leer
        [HttpGet()]
        public async Task<ActionResult<List<PermisosUnidadAdministrativaArchivo>>> ObtenerPermisosUnidadAdministrativaArchivo()
        {
            return await _servicioPermisosUnidadAdministrativaArchivo.Obtiener();
        }

        //Actualizar
        [HttpPut("{id}")]
        public async Task<ActionResult<PermisosUnidadAdministrativaArchivo>> ActualizarPermisosUnidadAdministrativaArchivo([FromRoute] string id, [FromBody] PermisosUnidadAdministrativaArchivo permisosunidadadministrativaarchivo)
        {
            var resultado = await _servicioPermisosUnidadAdministrativaArchivo.Actualizar(id, permisosunidadadministrativaarchivo);

            if (resultado != null)
            {
                return Ok(resultado);
            }

            return BadRequest("Error Al Actualizar");
        }

        //Eliminar
        [HttpDelete("{id}")]

        public async Task<ActionResult<Activo>> EliminarPermisosUnidadAdministrativaArchivo([FromRoute] string id, [FromBody] PermisosUnidadAdministrativaArchivo permisosunidadadministrativaarchivo)
        {
            var resultado = await _servicioPermisosUnidadAdministrativaArchivo.Eliminar(id, permisosunidadadministrativaarchivo);

            if (resultado != null)
            {
                return Ok();
            }
            return BadRequest("Error Al Eliminar");

        }
    }
}
