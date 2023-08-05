using api.comunes;
using api.comunes.modelos.reflectores;
using api.comunes.modelos.servicios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using pika.servicios.gestiondocumental.archivos;
using pika.servicios.gestiondocumental.dbcontext;
using System.Runtime.CompilerServices;
using comunes = api.comunes;

namespace pika.api.gestiondocumental.Controllers;

[Route("/")]
[ApiController]
public class Generico : ControladorGenerico
{
    private ILogger<Generico> _logger;
    public Generico(ILogger<Generico> logger) : base () {
        _logger = logger;
        this.entidadAPI = ObtieneEntidad();
    }

    private IEntidadAPI ObtieneEntidad()
    {
        var context = (PIKADbContext)this.HttpContext.RequestServices.GetService(typeof(PIKADbContext));
        var s =  new ServicioArchivo(_logger, context);
        s.EstableceContextoUsuario(new comunes.modelos.modelos.ContextoUsuario()
        {
             DominioId = "dominio-id", UOrgId ="uo-id", UsuarioId = "u-id"
        });
        return s;
    }

}
