using Microsoft.AspNetCore.Mvc;
using pika.api.gestiondocumental.Controllers.gestiondocumental.acervo;
using pika.modelo.gestiondocumental;
using pika.servicios.gestiondocumental.acervo;
using pika.servicios.gestiondocumental.archivos;

namespace pika.api.gestiondocumental.Controllers.gestiondocumental.archivos
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArchivoController : ControllerBase
    {

        private readonly IServicioArchivo _servicioArchivo;
        private readonly ILogger<ArchivoController> _logger;

        public ArchivoController(IServicioArchivo servicioArchivo, ILogger<ArchivoController> logger)
        {

            _servicioArchivo = servicioArchivo;
            _logger = logger;
        }




        // Crear el CRUD de API utilizando _servicioActivo

        // Crear
        [HttpPost()]

        public async Task<ActionResult<Archivo>> CrearArchivo([FromBody] Archivo archivo)
        {
            //var resultado = await _servicioArchivo.Crear(archivo);

            //if (resultado != null)
            //{
            //    return Ok(resultado);
            //}
            return BadRequest("Error Al Agregar");
        }


        // Leer
        [HttpGet()]
        public async Task<ActionResult<List<Archivo>>> ObtienerArchivo()
        {
            // return await _servicioArchivo.Obtiener();
            return Ok();
        }

        //Actualizar
        [HttpPut("{id}")]
        public async Task<ActionResult<Archivo>> ActualizarArchivo([FromRoute] string id, [FromBody] Archivo archivo)
        {
            //var resultado = await _servicioArchivo.Actualizar(id, archivo);

            //if (resultado != null)
            //{
            //    return Ok(resultado);
            //}

            return BadRequest("Error Al Actualizar");
        }

        //Eliminar
        [HttpDelete("{id}")]

        public async Task<ActionResult<Archivo>> EliminarArchivo([FromRoute] string id, [FromBody] Archivo archivo)
        {
            //var resultado = await _servicioArchivo.Eliminar(id, archivo);

            //if (resultado != null)
            //{
            //    return Ok();
            //}
            return BadRequest("Error Al Eliminar");

        }

    }
}
