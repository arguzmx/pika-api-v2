using api.comunes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace pika.api.seguridad.Controllers
{

    [ApiController]
    public class EntidadGenericaController : ControladorEntidadGenerico
    {
        private ILogger<EntidadGenericaController> _logger;

        public EntidadGenericaController(ILogger<EntidadGenericaController> logger, IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            _logger = logger;
        }
    }
}
