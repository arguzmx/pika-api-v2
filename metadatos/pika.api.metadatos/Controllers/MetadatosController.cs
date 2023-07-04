using api.comunes.consultas.dto;
using Microsoft.AspNetCore.Mvc;
using pika.api.metadatos.mock;
using pika.comun.metadatos;
using pika.comun.metadatos.configuraciones;
using pika.comun.metadatos.validadores;
using System.Net;
using System.Text.Json;

namespace pika.api.metadatos.Controllers
{
    [Route("metadatos")]
    [ApiController]
    public class MetadatosController : ControllerBase
    {

        private IServicioMock servicioMock;
        public MetadatosController(IServicioMock servicioMock)
        {
            this.servicioMock = servicioMock;
        }


        [HttpGet("metadata")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(Entidad), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<Entidad>> MetadatosEntidad()
        {
            string id = "entidad-ejemplo";
            var e = Mock(id);
            return Ok(e);
        }

        [HttpPost("buscar")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(Entidad), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<Pagina<EntidadMock>>> MetadatosEntidad([FromBody] Consulta consulta)
        {
            var e = servicioMock.LaLista().Skip(consulta.Paginado.Indice * consulta.Paginado.Tamano).
                Take(consulta.Paginado.Tamano).ToList();

            Pagina<EntidadMock> p = new Pagina<EntidadMock>()
            {
                ConsultaId = "001",
                Elementos = e,
                Paginado = consulta.Paginado,
                Total = servicioMock.LaLista().Count
            };

            return Ok(p);
        }


        private Entidad Mock(string id)
        {
            Entidad e = new() { EndpointAPI = "", Id = id, Nombre = $"i18-{id}" };
            
            var c = MockP("id", "i18n-id", TipoDatos.Texto, 0);
            c.HabilitadoCrear = false;
            c.HabilitadoEditar = false;
            c.TipoDespliegue = TipoDespliegue.Oculto;

            e.Propiedades.Add(c);
            e.Propiedades.Add(MockP("idLogico", "i18n-Logico", TipoDatos.Logico, 0));
            e.Propiedades.Add(MockP("idListaSeleccionSimple", "i18n-ListaSeleccionSimple", TipoDatos.ListaSeleccionSimple, 1));
            e.Propiedades.Add(MockP("idFecha", "i18n-Fecha", TipoDatos.Fecha, 2));
            e.Propiedades.Add(MockP("idFechaHora", "i18n-FechaHora", TipoDatos.FechaHora, 3));
            e.Propiedades.Add(MockP("idDecimal", "i18n-Decimal", TipoDatos.Decimal, 4));
            e.Propiedades.Add(MockP("idEntero", "i18n-Entero", TipoDatos.Entero, 5));
            e.Propiedades.Add(MockP("idHora", "i18n-Hora", TipoDatos.Hora, 6));
            e.Propiedades.Add(MockP("idListaSeleccionMultiple", "i18n-ListaSeleccionMultiple", TipoDatos.ListaSeleccionMultiple, 7));
            e.Propiedades.Add(MockP("idTexto", "i18n-Texto", TipoDatos.Texto, 8));

            c = MockP("idTextoIndexado", "i18n-TextoIndexado", TipoDatos.TextoIndexado, 9);
            c.HabilitadoCrear = false;
            c.HabilitadoEditar = false;
            e.Propiedades.Add(c);

            e.I18n = new List<comun.metadatos.i18n.I18n>();
            e.I18n.Add(new comun.metadatos.i18n.I18n()
            {
                Idioma = "es",
                 Traducciones  = new List<comun.metadatos.i18n.ElementoI18n>()
                 {
                     new comun.metadatos.i18n.ElementoI18n()
                     {
                          Clave = "id", Traduccion = "Identificador único"
                     },
                     new comun.metadatos.i18n.ElementoI18n()
                     {
                          Clave = "idLogico", Traduccion = "Campo lógiso"
                     },
                     new comun.metadatos.i18n.ElementoI18n()
                     {
                          Clave = "idListaSeleccionSimple", Traduccion = "Campo lista simple"
                     },
                     new comun.metadatos.i18n.ElementoI18n()
                     {
                          Clave = "idFecha", Traduccion = "Campo fecha"
                     },
                     new comun.metadatos.i18n.ElementoI18n()
                     {
                          Clave = "idFechaHora", Traduccion = "Campo fecha/hora"
                     },
                     new comun.metadatos.i18n.ElementoI18n()
                     {
                          Clave = "idEntero", Traduccion = "Campo entero"
                     },
                     new comun.metadatos.i18n.ElementoI18n()
                     {
                          Clave = "idDecimal", Traduccion = "Campo decimal"
                     },
                     new comun.metadatos.i18n.ElementoI18n()
                     {
                          Clave = "idListaSeleccionMultiple", Traduccion = "Campo lista múltiple"
                     },
                     new comun.metadatos.i18n.ElementoI18n()
                     {
                          Clave = "idTexto", Traduccion = "Campo texto"
                     },
                     new comun.metadatos.i18n.ElementoI18n()
                     {
                          Clave = "idTextoIndexado", Traduccion = "Campo texto indexado"
                     }
                 }
            });

            e.I18n.Add(new comun.metadatos.i18n.I18n()
            {
                Idioma = "en",
                Traducciones = new List<comun.metadatos.i18n.ElementoI18n>()
                 {
                     new comun.metadatos.i18n.ElementoI18n()
                     {
                          Clave = "id", Traduccion = "* Identificador único"
                     },
                    new comun.metadatos.i18n.ElementoI18n()
                     {
                          Clave = "idLogico", Traduccion = "* Campo lógico"
                     },
                     new comun.metadatos.i18n.ElementoI18n()
                     {
                          Clave = "idListaSeleccionSimple", Traduccion = "* Campo lista simple"
                     },
                     new comun.metadatos.i18n.ElementoI18n()
                     {
                          Clave = "idFecha", Traduccion = "* Campo fecha"
                     },
                     new comun.metadatos.i18n.ElementoI18n()
                     {
                          Clave = "idFechaHora", Traduccion = "* Campo fecha/hora"
                     },
                     new comun.metadatos.i18n.ElementoI18n()
                     {
                          Clave = "idEntero", Traduccion = "* Campo entero"
                     },
                     new comun.metadatos.i18n.ElementoI18n()
                     {
                          Clave = "idDecimal", Traduccion = "* Campo decimal"
                     },
                     new comun.metadatos.i18n.ElementoI18n()
                     {
                          Clave = "idListaSeleccionMultiple", Traduccion = "* Campo lista múltiple"
                     },
                     new comun.metadatos.i18n.ElementoI18n()
                     {
                          Clave = "idTexto", Traduccion = "* Campo texto"
                     },
                     new comun.metadatos.i18n.ElementoI18n()
                     {
                          Clave = "idTextoIndexado", Traduccion = "* Campo texto indexado"
                     }
                 }
            });

            return e;
        }


        private Propiedad MockP(string id, string nombre, TipoDatos tipo, int indiceTabular, 
            bool requerida = true)
        {
            var p = new Propiedad()
            {
                Buscable = true,
                Id = id,
                Nombre = nombre,
                Ordenable = true,
                Requerida = requerida,
                Tipo = tipo,
                UrlMacroCliente = "./macro",
                Visible = true,
                ConfiguracionTabular = new ConfiguracionTabular()
                {
                    AlternarEnTabla = true,
                    Indice = indiceTabular,
                    MostrarEnTabla = true
                }
            };

            p.HabilitadoEditar = true;
            p.HabilitadoCrear = false;
            p.TipoDespliegue = TipoDespliegue.Default;

            if (id != "id")
            {


                switch (tipo)
                {
                    case TipoDatos.Hora:
                        p.ValidadorFecha = new ValidadorFecha() { Maximo = new DateTime(2001, 1, 1, 18, 30, 0), Minimo = new DateTime(2001, 1, 1, 8, 0, 0) };
                        p.ValorDefault = JsonSerializer.Serialize(new DateTime(2001, 1, 1, 12, 30, 00));
                        break;

                    case TipoDatos.FechaHora:
                        p.ValidadorFecha = new ValidadorFecha() { Maximo = new DateTime(2028, 12, 31, 23, 29, 59), Minimo = new DateTime(2001, 1, 1, 0, 0, 0) };
                        p.ValorDefault = JsonSerializer.Serialize(new DateTime(2010, 1, 1, 12, 00, 00));
                        break;

                    case TipoDatos.Fecha:
                        p.ValidadorFecha = new ValidadorFecha() { Maximo = new DateTime(2028, 12, 31, 0, 0, 0), Minimo = new DateTime(2001, 1, 1, 0, 0, 0) };
                        p.ValorDefault = JsonSerializer.Serialize(new DateTime(2010, 2, 2, 0, 0, 00));
                        break;

                    case TipoDatos.TextoIndexado:
                        p.ValorDefault = "...";
                        break;

                    case TipoDatos.Texto:
                        p.ValidadorTexto = new ValidadorTexto() { LongitudMinima = 1, LongitudMaxima = 10, RegExp = null };
                        p.ValorDefault = "sorpresa!";
                        break;

                    case TipoDatos.Decimal:
                        p.ValidadorNumerico = new ValidadorNumerico() { Maximo = (decimal)100.1, Minimo = (decimal)-100.1 };
                        p.ValorDefault = "10";
                        break;

                    case TipoDatos.Entero:
                        p.ValidadorNumerico = new ValidadorNumerico() { Maximo = (decimal)10, Minimo = (decimal)-10 };
                        p.ValorDefault = "-1";
                        break;

                    case TipoDatos.ListaSeleccionMultiple:
                    case TipoDatos.ListaSeleccionSimple:
                        p.Lista = new();
                        p.Lista.Elementos.Add(new ElementoLista() { Id = "1", Nombre = "Elemento A", Valor = "A", Posicion = 1 });
                        p.Lista.Elementos.Add(new ElementoLista() { Id = "2", Nombre = "Elemento B", Valor = "B", Posicion = 2 });
                        p.Lista.Elementos.Add(new ElementoLista() { Id = "3", Nombre = "Elemento C", Valor = "C", Posicion = 0 });
                        p.Lista.Elementos.Add(new ElementoLista() { Id = "4", Nombre = "Elemento D", Valor = "D", Posicion = 3 });
                        p.ValorDefault = "B";
                        break;

                    case TipoDatos.Logico:
                        p.ValorDefault = "true";
                        break;
                }
            }
            return p;
        }
    }
}
