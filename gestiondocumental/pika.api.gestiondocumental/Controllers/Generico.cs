using api.comunes;
using Microsoft.AspNetCore.Mvc;

namespace pika.api.gestiondocumental.Controllers;

[ApiController]
public class Generico : ControladorEntidadGenerico
{
    private ILogger<Generico> _logger;
    public Generico(ILogger<Generico> logger, IHttpContextAccessor httpContextAccessor) : base (httpContextAccessor) {
        _logger = logger;
    }
}
