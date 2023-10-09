using pika.modelo.gestiondocumental.Acervo;
using api.comunes.modelos.reflectores;
using api.comunes.modelos.servicios;
using Microsoft.Extensions.Logging;
using pika.servicios.gestiondocumental.dbcontext;
using api.comunes.modelos.respuestas;
using System.Text.Json;
using pika.comun.metadatos;
using api.comunes.modelos.modelos;
using pika.modelo.gestiondocumental.Archivos;
using Microsoft.EntityFrameworkCore;
using pika.modelo.gestiondocumental;

namespace pika.servicios.gestiondocumental.Activo;

/// <summary>
/// Servicio de datos para la entidad Activo
/// </summary>
[ServicioEntidadAPI(entidad: typeof(modelo.gestiondocumental.Activo))]
public class ServicioActivo : ServicioEntidadGenericaBase<modelo.gestiondocumental.Activo, ActivoInsertar, ActivoActualizar, ActivoDespliegue, string>,
        IServicioEntidadAPI, IServicoActivo
{
    public ServicioActivo(DbContextGestionDocumental context, ILogger<ServicioActivo> logger) : base(context, context.Activo, logger)
    {
    }

    /// <summary>
    /// Acceso al repositorio de gestipon documental local
    /// </summary>
    private DbContextGestionDocumental DB { get { return (DbContextGestionDocumental)_db; } }


    public bool RequiereAutenticacion => true;

    public async Task<Respuesta> ActualizarAPI(object id, JsonElement data)
    {
        var update = data.Deserialize<ActivoActualizar>(JsonAPIDefaults());
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
        var add = data.Deserialize<ActivoInsertar>(JsonAPIDefaults());
        var temp = await this.Insertar(add);
        RespuestaPayload<object> respuesta = JsonSerializer.Deserialize<RespuestaPayload<object>>(JsonSerializer.Serialize(temp));
        return respuesta;
    }

    public async Task<RespuestaPayload<PaginaGenerica<object>>> PaginaAPI(Consulta consulta)
    {
        var temp = await this.Pagina(consulta);
        RespuestaPayload<PaginaGenerica<object>> respuesta = JsonSerializer.Deserialize<RespuestaPayload<PaginaGenerica<object>>>(JsonSerializer.Serialize(temp));

        return respuesta;
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



    #region Overrides para la personalziación de la entidad Activo

    public override async Task<ResultadoValidacion> ValidarInsertar(ActivoInsertar data)
    {
        ResultadoValidacion resultado = new();
        bool encontrado = await DB.Activo.AnyAsync(a => a.DominioId == _contextoUsuario.DominioId && a.Nombre==data.Nombre);

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


    public override async Task<ResultadoValidacion> ValidarEliminacion(string id, modelo.gestiondocumental.Activo original)
    {
        ResultadoValidacion resultado = new();
        bool encontrado = await DB.Activo.AnyAsync(a =>a.DominioId == _contextoUsuario.DominioId && a.Id == id);

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


    public override async Task<ResultadoValidacion> ValidarActualizar(string id, ActivoActualizar actualizacion, modelo.gestiondocumental.Activo original)
    {
        ResultadoValidacion resultado = new();
        bool encontrado = await DB.Activo.AnyAsync(a =>a.DominioId == _contextoUsuario.DominioId  && a.Id == id);

        if (!encontrado)
        {
            resultado.Error = "id".ErrorProcesoNoEncontrado();

        }
        else
        {

            bool duplicado = await DB.Activo.AnyAsync(a =>a.DominioId == _contextoUsuario.DominioId
                && a.Id == id && a.Nombre == actualizacion.Nombre);

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


    public override modelo.gestiondocumental.Activo ADTOFull(ActivoActualizar actualizacion, modelo.gestiondocumental.Activo actual)
    {
        actual.CuadroClasificacionId = actualizacion.CuadroClasificacionId;
        actual.SerieDocumentalId = actualizacion.SerieDocumentalId;
        actual.ArchivoOrigenId = actualizacion.ArchivoOrigenId;
        actual.ArchivoActualId = actualizacion.ArchivoActualId;
        actual.UnidadAdministrativaId = actualizacion.UnidadAdministrativaId;
        actual.Nombre = actualizacion.Nombre;
        actual.IdentificadorInterno = actualizacion.IdentificadorInterno;
        actual.FechaApertura = actualizacion.FechaApertura;
        actual.FechaCierre = actualizacion.FechaCierre;
        actual.Asunto= actualizacion.Asunto;
        actual.CodigoOptico= actualizacion.CodigoOptico;
        actual.CodigoElectronico = actualizacion.CodigoElectronico;
        actual.EsElectronico= actualizacion.EsElectronico;
        actual.UbicacionCaja=actualizacion.UbicacionCaja;
        actual.UbicacionRack = actualizacion.UbicacionRack;
        return actual;
    }

    public override modelo.gestiondocumental.Activo ADTOFull(ActivoInsertar data)
    {
        modelo.gestiondocumental.Activo activo = new modelo.gestiondocumental.Activo()
        {
            Id = Guid.NewGuid().ToString(),
            CuadroClasificacionId = data.CuadroClasificacionId,
            SerieDocumentalId = data.SerieDocumentalId,
            ArchivoOrigenId = data.ArchivoOrigenId,
            ArchivoActualId = data.ArchivoActualId,
            UnidadAdministrativaId = data.UnidadAdministrativaId,
            Nombre = data.Nombre,
            IdentificadorInterno = data.IdentificadorInterno,
            FechaApertura = data.FechaApertura,
            FechaCierre = data.FechaCierre,
            Asunto = data.Asunto,
            CodigoOptico = data.CodigoOptico,
            CodigoElectronico = data.CodigoElectronico,
            EsElectronico = data.EsElectronico,
            UbicacionCaja = data.UbicacionCaja,
            UbicacionRack = data.UbicacionRack,
            DominioId = _contextoUsuario.DominioId,
            TipoArchivoActualId = "tipo",
            UnidadOrganizacionalId = _contextoUsuario.UOrgId,
            UsuarioId = _contextoUsuario.UsuarioId,
        };
        return activo;
    }

    public override ActivoDespliegue ADTODespliegue(modelo.gestiondocumental.Activo data)
    {
        ActivoDespliegue archivo = new ActivoDespliegue()
        {
            Id=data.Id,
            CuadroClasificacionId = data.CuadroClasificacionId,
            SerieDocumentalId = data.SerieDocumentalId,
            ArchivoOrigenId = data.ArchivoOrigenId,
            ArchivoActualId = data.ArchivoActualId,
            TipoArchivoActualId = data.TipoArchivoActualId,
            UnidadAdministrativaId = data.UnidadAdministrativaId,
            Nombre = data.Nombre,
            IdentificadorInterno = data.IdentificadorInterno,
            FechaApertura = data.FechaApertura,
            FechaCierre = data.FechaCierre,
            Asunto = data.Asunto,
            CodigoOptico = data.CodigoOptico,
            CodigoElectronico = data.CodigoElectronico,
            EsElectronico = data.EsElectronico,
            Reservado = data.Reservado,
            Confidencial = data.Confidencial,
            UbicacionCaja = data.UbicacionCaja,
            UbicacionRack = data.UbicacionRack,
            EnPrestamo = data.EnPrestamo,
            EnTransferencia = data.EnTransferencia,
            Ampliado = data.Ampliado,
            FechaRetencionAT = data.FechaRetencionAT,
            FechaRetencionAC = data.FechaRetencionAC,
            AlmacenArchivoId = data.AlmacenArchivoId,
            ZonaAlmacenId = data.ZonaAlmacenId,
            ContenedorAlmacenId = data.ContenedorAlmacenId,
            FechaCreacion = data.FechaCreacion,
            UsuarioId = data.UsuarioId
        };
        return archivo;
    }

    #endregion

}
