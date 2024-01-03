﻿using api.comunes;
using Microsoft.AspNetCore.Mvc;

namespace pika.api.contenido.Controllers
{

    [ApiController]
    public class CatalogoGenericoController : ControladorCatalogoGenerico
    {
        private ILogger<CatalogoGenericoController> _logger;
        public CatalogoGenericoController(ILogger<CatalogoGenericoController> logger, IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor) { 
               
                  _logger= logger;
               }
    }
}
