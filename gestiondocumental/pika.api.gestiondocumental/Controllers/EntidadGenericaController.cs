using api.comunes;
using api.comunes.metadatos;
using api.comunes.metadatos.validadores;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;


namespace pika.api.gestiondocumental.Controllers;

[ApiController]
public class EntidadGenericaController : ControladorEntidadGenerico
{
    private ILogger<EntidadGenericaController> _logger;
    public EntidadGenericaController(ILogger<EntidadGenericaController> logger, IHttpContextAccessor httpContextAccessor) : base (httpContextAccessor) {
        _logger = logger;
    }



    /// <summary>
    /// Obtiene los metadatos de una entidad
    /// </summary>
    /// <param name="entidad"></param>
    /// <returns></returns>
    [HttpGet("metadatos/demo")]
    [SwaggerOperation("Obtiene los Metadatos de una entidad del tipo especificado por el ruteo")]
    [SwaggerResponse(statusCode: 200, type: typeof(Entidad), description: "Metadatos de la entidad")]
    public async Task<ActionResult<Entidad>> DemoEntidad()
    {
        Entidad e = new Entidad()
        {
            EndpointAPI = null,
            Id = "demo",
            Nombre = "EntidadDemo",
            Propiedades = new List<Propiedad>()
                {
                     CreaPropiedad(TipoDatos.Hora),
                     CreaPropiedad(TipoDatos.FechaHora),
                     CreaPropiedad(TipoDatos.Fecha),
                     CreaPropiedad(TipoDatos.Logico),
                     CreaPropiedad(TipoDatos.Decimal),
                     CreaPropiedad(TipoDatos.Entero),
                     CreaPropiedad(TipoDatos.ListaSeleccionMultiple),
                     CreaPropiedad(TipoDatos.ListaSeleccionSimple ),
                     CreaPropiedad(TipoDatos.Texto),
                     CreaPropiedad(TipoDatos.TextoIndexado),
                }
        };

        ValidadoresYDefaults(e);
        return Ok(e);
    }


    private void ValidadoresYDefaults(Entidad e)
    {
        var p = e.Propiedades.First(x => x.Tipo == TipoDatos.Decimal);
        p.ValidadorEntero = new ValidadorEntero() { Maximo = 100, Minimo = -100 };
        p.ValorDefault = "1.1";


        p = e.Propiedades.First(x => x.Tipo == TipoDatos.ListaSeleccionSimple);
        p.Lista = new Lista()
        {
            DatosRemotos = false,
            Id = "simple",
            Ordenamiento = OrdenamientoLista.Alfabetico,
            Elementos = new List<ElementoLista>()
                {
                     new ElementoLista() { Id = "1", Nombre ="AAAA", Posicion = 0, Valor = "a"},
                     new ElementoLista() { Id = "2", Nombre ="BBBB", Posicion = 0, Valor = "b"},
                     new ElementoLista() { Id = "3", Nombre ="CCCC", Posicion = 0, Valor = "c"}
                }
        };
        p.ValorDefault = "b";


        p = e.Propiedades.First(x => x.Tipo == TipoDatos.ListaSeleccionSimple);
        p.Lista = new Lista()
        {
            DatosRemotos = false,
            Id = "simple",
            Ordenamiento = OrdenamientoLista.Alfabetico,
            Elementos = new List<ElementoLista>()
                {
                     new ElementoLista() { Id = "1", Nombre ="AAAA", Posicion = 0, Valor = "a"},
                     new ElementoLista() { Id = "2", Nombre ="BBBB", Posicion = 0, Valor = "b"},
                     new ElementoLista() { Id = "3", Nombre ="CCCC", Posicion = 0, Valor = "c"}
                }
        };


        p = e.Propiedades.First(x => x.Tipo == TipoDatos.Entero);
        p.ValidadorEntero = new ValidadorEntero() { Maximo = 50 };
        p.ValorDefault = "-10";

        p = e.Propiedades.First(x => x.Tipo == TipoDatos.Logico);
        p.ValorDefault = "true";

        p = e.Propiedades.First(x => x.Tipo == TipoDatos.Fecha);
        p.ValidadorFecha = new ValidadorFecha() { Minimo = DateTime.UtcNow.AddYears(-1), Maximo = DateTime.UtcNow.AddYears(5) };


        p = e.Propiedades.First(x => x.Tipo == TipoDatos.FechaHora);
        p.ValidadorFecha = new ValidadorFecha() { Minimo = null, Maximo = DateTime.UtcNow };


        p = e.Propiedades.First(x => x.Tipo == TipoDatos.Hora);
        p.ValidadorFecha = new ValidadorFecha() { Minimo = new DateTime(2000, 1, 1, 8, 0, 0), Maximo = new DateTime(2000, 1, 1, 23, 59, 59) };
        p.ValorDefault = new DateTime(2000, 1, 1, 13, 0, 0).ToString("o");

        p = e.Propiedades.First(x => x.Tipo == TipoDatos.Texto);
        p.ValidadorTexto = new ValidadorTexto() { LongitudMaxima = 200, LongitudMinima = 5 };
        p.ValorDefault = "Hola";
    }

    private Propiedad CreaPropiedad(TipoDatos tipo)
    {
        return new Propiedad()
        {
            Buscable = true,
            HabilitadoCrear = true,
            HabilitadoDespliegue = true,
            HabilitadoEditar = true,
            Id = $"{tipo.ToString()}Id",
            Nombre = tipo.ToString(),
            Requerida = new List<RequeridaOperacion>() {  RequeridaOperacion.Insertar},
            Tipo = tipo,
            Visible = true
        };
    }
}
