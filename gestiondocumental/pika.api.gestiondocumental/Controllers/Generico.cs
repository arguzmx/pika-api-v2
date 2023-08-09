using api.comunes;
using api.comunes.modelos.reflectores;
using Microsoft.AspNetCore.Mvc;
using pika.servicios.gestiondocumental.archivos;
using pika.servicios.gestiondocumental.dbcontext;
using comunes = api.comunes;

namespace pika.api.gestiondocumental.Controllers;

[ApiController]
public class Generico : ControladorGenerico
{
    private ILogger<Generico> _logger;
    private DbContextGestionDocumental _dbContext;
    public Generico(ILogger<Generico> logger, DbContextGestionDocumental dbContext, IHttpContextAccessor httpContextAccessor) : base (httpContextAccessor) {
        _logger = logger;
        _dbContext = dbContext;
        this.entidadAPI = ObtieneEntidad();
    }

    private IEntidadAPI ObtieneEntidad()
    {
        var s =  new ServicioArchivo(_dbContext);

        var a = this.UnidadOrgId();

        s.EstableceContextoUsuario(new comunes.modelos.modelos.ContextoUsuario()
        {
             DominioId = this.DominioId(), UOrgId = this.UnidadOrgId(), UsuarioId = this.UsuarioId()
        });
        return s;
    }

}
