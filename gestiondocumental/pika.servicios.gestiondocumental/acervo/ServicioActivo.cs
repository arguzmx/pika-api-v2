using Microsoft.Extensions.Logging;
using pika.servicios.gestiondocumental.dbcontext;

namespace pika.servicios.gestiondocumental.acervo;

public class ServicioActivo : IServicioActivo
{

    private readonly ILogger<ServicioActivo> _logger;
    private readonly PIKADbContext _context;

    public ServicioActivo(ILogger<ServicioActivo> logger, PIKADbContext context)
    {
        _logger = logger;
        _context = context;
    }

    // Crear el CRUD de API utilizando context

}
