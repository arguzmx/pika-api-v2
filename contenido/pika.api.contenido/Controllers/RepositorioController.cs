using api.comunes.modelos.modelos;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using api.comunes;
using pika.servicios.contenido.repositorio;
using api.comunes.modelos.reflectores;

namespace pika.api.contenido.Controllers
{
    [Route("api/repositorio")]
    [ApiController]
    public class RepositorioController : ControladorBaseGenerico
    {
        private readonly ILogger<RepositorioController> _logger;
        private readonly IServicioEntidadAPI entidadAPI;
        public RepositorioController(ILogger<RepositorioController> logger, IServicioRepositorio servicioRepositorioI,IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor) { 
        
            _logger = logger;
            entidadAPI = (IServicioEntidadAPI)servicioRepositorioI;
        }

        [HttpGet]
        public ActionResult Get() {
            return Ok("aaa");
        }

        [HttpGet("{id}/arbol/carpeta/raices", Name = "RaicesArbolCarpetas")]
        [SwaggerOperation("Obtiene una lista de pares ValorTetxo que representan las raíces de una estructura de árbol", OperationId = "RaicesArbolCarpetas")]
        [SwaggerResponse(statusCode: 200, type: typeof(List<ParClaveTexto>), description: "Nodos raíz del árbol de carpetas")]
        [SwaggerResponse(statusCode: 403, description: "El usuario en sesión no tiene acceso a la operación")]
        [SwaggerResponse(statusCode: 401, description: "Usuario no autenticado")]
        [SwaggerResponse(statusCode: 400, description: "Datos incorrectos")]
        [SwaggerResponse(statusCode: 405, description: "Método no implementado")]
        public async Task<IActionResult> RaicesArbolCarpetas(string id, [FromHeader(Name = DOMINIOHEADER)] string dominioId, [FromHeader(Name = UORGHEADER)] string uOrgID)
        {
            var response = await entidadAPI.Raices(id);
            if (response.Ok)
            {
                return Ok(response.Payload);
            }
            return StatusCode(response.HttpCode.GetHashCode(), response.Error);
        }


        [HttpGet("{id}/arbol/carpeta/{nodoId}/hijos", Name = "HijosNodoArbolCarpetas")]
        [SwaggerOperation("Obtiene una lista de pares ValorTetxo que representan los hijos de un nodo de una estructura de árbol", OperationId = "HijosNodoArbolCarpetas")]
        [SwaggerResponse(statusCode: 200, type: typeof(List<ParClaveTexto>), description: "Hijos de un nodo árbol de carpetas")]
        [SwaggerResponse(statusCode: 403, description: "El usuario en sesión no tiene acceso a la operación")]
        [SwaggerResponse(statusCode: 401, description: "Usuario no autenticado")]
        [SwaggerResponse(statusCode: 400, description: "Datos incorrectos")]
        [SwaggerResponse(statusCode: 405, description: "Método no implementado")]
        public async Task<IActionResult> HijosNodoArbolCarpetas(string id, string nodoId, [FromHeader(Name = DOMINIOHEADER)] string dominioId, [FromHeader(Name = UORGHEADER)] string uOrgID)
        {
            var response = await entidadAPI.Hijos(nodoId, id);
            if (response.Ok)
            {
                return Ok(response.Payload);
            }
            return StatusCode(response.HttpCode.GetHashCode(), response.Error);
        }

        [HttpGet("{id}/arbol/carpeta", Name = "ArbolCarpetas")]
        [SwaggerOperation("Obtiene una lista de todos los nodos de una estructura de árbol en formato aplanado", OperationId = "ArbolCarpetas")]
        [SwaggerResponse(statusCode: 200, type: typeof(List<ParClaveTextoNodoArbol<string>>), description: "Arbol de carpetas")]
        [SwaggerResponse(statusCode: 403, description: "El usuario en sesión no tiene acceso a la operación")]
        [SwaggerResponse(statusCode: 401, description: "Usuario no autenticado")]
        [SwaggerResponse(statusCode: 400, description: "Datos incorrectos")]
        [SwaggerResponse(statusCode: 405, description: "Método no implementado")]
        public async Task<IActionResult> ArbolCarpetas(string id, [FromHeader(Name = DOMINIOHEADER)] string dominioId, [FromHeader(Name = UORGHEADER)] string uOrgID)
        {
            var response = await entidadAPI.Arbol(id);
            if (response.Ok)
            {
                return Ok(response.Payload);
            }
            return StatusCode(response.HttpCode.GetHashCode(), response.Error);
        }

    }
}
