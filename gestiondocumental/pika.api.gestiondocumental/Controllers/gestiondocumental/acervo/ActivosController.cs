using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using pika.servicios.gestiondocumental.acervo;

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
    }
}
