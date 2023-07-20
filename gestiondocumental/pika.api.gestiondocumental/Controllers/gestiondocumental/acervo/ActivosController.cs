using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using pika.modelo.gestiondocumental;
using pika.servicios.gestiondocumental.acervo;
using pika.servicios.gestiondocumental.dbcontext;
using System.Threading;

namespace pika.api.gestiondocumental.Controllers.gestiondocumental.acervo
{
    [Route("api/activos")]
    [ApiController]
    public class ActivosController : ControllerBase
    {
       
        private readonly IServicioActivo _servicioActivo;
        private readonly ILogger<ActivosController> _logger;
        
        public ActivosController(IServicioActivo servicioActivo, ILogger<ActivosController> logger)
        {
         
            _servicioActivo = servicioActivo;
            _logger = logger;
        }


       

        // Crear el CRUD de API utilizando _servicioActivo

         // Crear
        [HttpPost()]
      
        public async Task<ActionResult<Activo>> CrearActivo([FromBody] Activo activo)
        {
            var resultado = await _servicioActivo.Crear(activo);
         
            if (resultado!=null)
            {
               return Ok(resultado);
            }
             return BadRequest("Error Al Agregar");
        }

        
        // Leer
        [HttpGet]
        public async Task<ActionResult<List<Activo>>> ObtienerActivo()
        {
            return await _servicioActivo.Obtiener();
        }

        //Actualizar
        [HttpPut("{id}")]
        public async Task<ActionResult<Activo>> ActualizarActivo([FromRoute] string id, [FromBody] Activo activo)
        {
            var resultado = await _servicioActivo.Actualizar(id, activo);

            if (resultado!=null)
            {
                return Ok(resultado);
            }

            return BadRequest("Error Al Actualizar");
        }

        //Eliminar
        [HttpDelete("{id}")]
       
        public async Task<ActionResult<Activo>> EliminarActivo([FromRoute] string id ,[FromBody] Activo activo)
        {
            var resultado = await _servicioActivo.Eliminar(id, activo);

            if (resultado!=null)
            {
                return Ok();
            }
            return BadRequest("Error Al Eliminar");

        }




    }
    }
