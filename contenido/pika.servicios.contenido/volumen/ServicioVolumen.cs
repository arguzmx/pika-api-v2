
using api.comunes.metadatos;
using api.comunes.modelos.modelos;
using api.comunes.modelos.reflectores;
using api.comunes.modelos.respuestas;
using api.comunes.modelos.servicios;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using pika.modelo.contenido.Volumen;
using pika.servicios.contenido.dbcontext;
using System.Text.Json;

namespace pika.servicios.contenido.volumen;

/// <summary>
/// Servicio de datos para la entidad archivo
/// </summary>
[ServicioEntidadAPI(entidad: typeof(Volumen))]
public class ServicioVolumen : ServicioEntidadGenericaBase<Volumen, VolumenInsertar, VolumenActualizar, VolumenDespliegue, string>,
    IServicioEntidadAPI, IServicioVolumen
{

    public ServicioVolumen(DbContextContenido context, ILogger<ServicioVolumen> logger) : base(context, context.Volumen, logger)
    {
    }


    /// <summary>
    /// Acceso al repositorio de gestipon documental local
    /// </summary>
    private DbContextContenido DB { get { return (DbContextContenido)_db; } }


    public bool RequiereAutenticacion => true;

    public async Task<Respuesta> ActualizarAPI(object id, JsonElement data)
    {
        var update = data.Deserialize<VolumenActualizar>(JsonAPIDefaults());
        return await this.Actualizar((string)id, update);
    }

    public async Task<Respuesta> EliminarAPI(object id)
    {
        return await this.Eliminar((string)id);
    }

    public Entidad EntidadDespliegueAPI()
    {
        return this.EntidadDespliegue();
    }

    public Entidad EntidadInsertAPI()
    {
        return this.EntidadInsert();
    }

    public Entidad EntidadRepoAPI()
    {
        return this.EntidadRepo();
    }

    public Entidad EntidadUpdateAPI()
    {
        return this.EntidadUpdate();
    }

    public void EstableceContextoUsuarioAPI(ContextoUsuario contexto)
    {
        this.EstableceContextoUsuario(contexto);
    }

    public ContextoUsuario? ObtieneContextoUsuarioAPI()
    {
        return this._contextoUsuario;
    }

    public async Task<RespuestaPayload<object>> InsertarAPI(JsonElement data)
    {
        var add = data.Deserialize<VolumenInsertar>(JsonAPIDefaults());
        var temp = await this.Insertar(add);
        RespuestaPayload<object> respuesta = JsonSerializer.Deserialize<RespuestaPayload<object>>(JsonSerializer.Serialize(temp));
        return respuesta;
    }

    public async Task<RespuestaPayload<PaginaGenerica<object>>> PaginaAPI(Consulta consulta)
    {


        RespuestaPayload<PaginaGenerica<Volumen>> respuesta = new RespuestaPayload<PaginaGenerica<Volumen>>();


        string consultaBaseSQL = "SELECT * FROM contenido$volumen";
        string condicionSQL = consulta.Filtros.SQL();
        if (!string.IsNullOrEmpty(condicionSQL))
        {
            consultaBaseSQL += $" WHERE {condicionSQL}";
        }
        PaginaGenerica<object> paginado = (PaginaGenerica<object>)respuesta.Payload;
        string consultaQuery = $"{consultaBaseSQL} {consulta.OrdenarConsulta()} {paginado.PaginarConsulta(consulta)};";
        var resultadoConsulta = DB.Volumen.FromSqlRaw(consultaQuery).ToList();

        PaginaGenerica<Volumen> pagina = (PaginaGenerica<Volumen>)(respuesta.Payload = new PaginaGenerica<Volumen>
        {
            ConsultaId = Guid.NewGuid().ToString(),
            Elementos = resultadoConsulta,
            Milisegundos = 0L,
            Paginado = new Paginado
            {
                Indice = consulta.Paginado.Indice,
                Tamano = consulta.Paginado.Tamano,
                Ordenamiento = consulta.Paginado.Ordenamiento,
                ColumnaOrdenamiento = consulta.Paginado.ColumnaOrdenamiento
            },
            Total = resultadoConsulta.Count

        });
        respuesta.Payload = pagina;
        respuesta.Ok = true;
        respuesta.HttpCode = HttpCode.Ok;

        RespuestaPayload<PaginaGenerica<object>> r = JsonSerializer.Deserialize<RespuestaPayload<PaginaGenerica<object>>>(JsonSerializer.Serialize(respuesta));
        return r;


        //var temp = await this.pagina(consulta);
        //respuestapayload<paginagenerica<object>> respuesta = jsonserializer.deserialize<respuestapayload<paginagenerica<object>>>(jsonserializer.serialize(temp));

        //return respuesta;
    }

    public async Task<RespuestaPayload<PaginaGenerica<object>>> PaginaDespliegueAPI(Consulta consulta)
    {
        var temp = await this.PaginaDespliegue(consulta);
        RespuestaPayload<PaginaGenerica<object>> respuesta = JsonSerializer.Deserialize<RespuestaPayload<PaginaGenerica<object>>>(JsonSerializer.Serialize(temp));
        return respuesta;
    }

    public async Task<RespuestaPayload<PaginaGenerica<object>>> PaginaHijoAPI(Consulta consulta, string tipoPadre, string id)
    {
        var temp = await this.PaginaHijo(consulta, tipoPadre, id);
        RespuestaPayload<PaginaGenerica<object>> respuesta = JsonSerializer.Deserialize<RespuestaPayload<PaginaGenerica<object>>>(JsonSerializer.Serialize(temp));
        return respuesta;
    }

    public async Task<RespuestaPayload<PaginaGenerica<object>>> PaginaHijosDespliegueAPI(Consulta consulta, string tipoPadre, string id)
    {
        var temp = await this.PaginaHijosDespliegue(consulta, tipoPadre, id);
        RespuestaPayload<PaginaGenerica<object>> respuesta = JsonSerializer.Deserialize<RespuestaPayload<PaginaGenerica<object>>>(JsonSerializer.Serialize(temp));
        return respuesta;
    }


    public async Task<RespuestaPayload<object>> UnicaPorIdAPI(object id)
    {
        var temp = await this.UnicaPorId((string)id);
        RespuestaPayload<object> respuesta = JsonSerializer.Deserialize<RespuestaPayload<object>>(JsonSerializer.Serialize(temp));
        return respuesta;
    }

    public async Task<RespuestaPayload<object>> UnicaPorIdDespliegueAPI(object id)
    {
        var temp = await this.UnicaPorIdDespliegue((string)id);

        RespuestaPayload<object> respuesta = JsonSerializer.Deserialize<RespuestaPayload<object>>(JsonSerializer.Serialize(temp));
        return respuesta;
    }



    #region Overrides para la personalziación de la entidad Archivo

    public override async Task<ResultadoValidacion> ValidarInsertar(VolumenInsertar data)
    {
        ResultadoValidacion resultado = new();
        bool encontrado = await DB.Volumen.AnyAsync(a => a.UOrgId == _contextoUsuario.UOrgId
                && a.DominioId == _contextoUsuario.DominioId
                && a.Nombre == data.Nombre);

        if (encontrado)
        {
            resultado.Error = "Nombre".ErrorProcesoDuplicado();

        }
        else
        {
            resultado.Valido = true;
        }

        return resultado;
    }


    public override async Task<ResultadoValidacion> ValidarEliminacion(string id, Volumen original)
    {
        ResultadoValidacion resultado = new();
        bool encontrado = await DB.Volumen.AnyAsync(a => a.UOrgId == _contextoUsuario.UOrgId
                && a.DominioId == _contextoUsuario.DominioId
                && a.Id == id);

        if (!encontrado)
        {
            resultado.Error = "id".ErrorProcesoNoEncontrado();

        }
        else
        {
            resultado.Valido = true;
        }

        return resultado;
    }


    public override async Task<ResultadoValidacion> ValidarActualizar(string id, VolumenActualizar actualizacion, Volumen original)
    {
        ResultadoValidacion resultado = new();
        bool encontrado = await DB.Volumen.AnyAsync(a => a.UOrgId == _contextoUsuario.UOrgId
                && a.DominioId == _contextoUsuario.DominioId
                && a.Id == id);

        if (!encontrado)
        {
            resultado.Error = "id".ErrorProcesoNoEncontrado();

        }
        else
        {

            bool duplicado = await DB.Volumen.AnyAsync(a => a.UOrgId == _contextoUsuario.UOrgId
                && a.DominioId == _contextoUsuario.DominioId
                && a.Id != id
                && a.Nombre==actualizacion.Nombre);

            if (duplicado)
            {
                resultado.Error = "Nombre".ErrorProcesoDuplicado();

            }
            else
            {
                resultado.Valido = true;
            }
        }

        return resultado;
    }


    public override Volumen ADTOFull(VolumenActualizar actualizacion, Volumen actual)
    {
        actual.Id = actualizacion.Id;
        actual.Nombre = actualizacion.Nombre;
        actual.TipoGestorESId = actualizacion.TipoGestorESId;
        actual.TamanoMaximo = actualizacion.TamanoMaximo;
        actual.Activo=actualizacion.Activo;
        actual.EscrituraHabilitada = actualizacion.EscrituraHabilitada;
        return actual;
    }

    public override Volumen ADTOFull(VolumenInsertar data)
    {
        Volumen archivo = new Volumen()
        {
            Id = Guid.NewGuid().ToString(),
            UOrgId = _contextoUsuario.UOrgId,
            DominioId = _contextoUsuario.DominioId,
            Nombre = data.Nombre,
            TipoGestorESId=data.TipoGestorESId,
            TamanoMaximo=data.TamanoMaximo,
            Activo=data.Activo,
            EscrituraHabilitada=data.EscrituraHabilitada,           
        };
        return archivo;
    }

    public override VolumenDespliegue ADTODespliegue(Volumen data)
    {
        VolumenDespliegue archivo = new VolumenDespliegue()
        {
            Id = data.Id,
            Nombre = data.Nombre
        };
        return archivo;
    }

    #endregion
}

#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
#pragma warning restore CS8603 // Possible null reference return.

