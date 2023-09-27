using api.comunes.modelos.modelos;
using api.comunes.modelos.reflectores;
using api.comunes.modelos.respuestas;
using api.comunes.modelos.servicios;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using pika.comun.metadatos;
using pika.modelo.gestiondocumental;
using pika.modelo.gestiondocumental.Archivos;
using pika.modelo.gestiondocumental.Archivos.UnidadAdministrativa;
using pika.servicios.gestiondocumental.archivos;
using pika.servicios.gestiondocumental.dbcontext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace pika.servicios.gestiondocumental.unidadadministrativa;

[ServicioEntidadAPI(entidad: typeof(UnidadAdministrativa))]
public class ServicioUnidadAdministrativa : ServicioEntidadGenericaBase<UnidadAdministrativa, UnidadAdministrativaInsertar, UnidadAdministrativaActualizar, UnidadAdministrativaDespliegue, string>,
    IServicioEntidadAPI
{
    public ServicioUnidadAdministrativa(DbContextGestionDocumental context, ILogger<ServicioUnidadAdministrativa> logger) : base(context, context.UnidadesAdministrativas, logger)
    {
    }

    /// <summary>
    /// Acceso al repositorio de gestipon documental local
    /// </summary>
    private DbContextGestionDocumental DB { get { return (DbContextGestionDocumental)_db; } }

    public bool RequiereAutenticacion => true;

    public async Task<Respuesta> ActualizarAPI(object id, JsonElement data)
    {
        var update = data.Deserialize<UnidadAdministrativaActualizar>(JsonAPIDefaults());
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
        var add = data.Deserialize<UnidadAdministrativaInsertar>(JsonAPIDefaults());
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

    #region Overrides para la personalización de la entidad UnidadAdministrativa
    public override async Task<ResultadoValidacion> ValidarInsertar(UnidadAdministrativaInsertar data)
    {
        ResultadoValidacion resultado = new();
        bool encontrado = await DB.UnidadesAdministrativas.AnyAsync(a => a.UOrgId == _contextoUsuario.UOrgId
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


    public override async Task<ResultadoValidacion> ValidarEliminacion(string id, UnidadAdministrativa original)
    {
        ResultadoValidacion resultado = new();
        bool encontrado = await DB.UnidadesAdministrativas.AnyAsync(a => a.UOrgId == _contextoUsuario.UOrgId
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


    public override async Task<ResultadoValidacion> ValidarActualizar(string id, UnidadAdministrativaActualizar actualizacion, UnidadAdministrativa original)
    {
        ResultadoValidacion resultado = new();
        bool encontrado = await DB.UnidadesAdministrativas.AnyAsync(a => a.UOrgId == _contextoUsuario.UOrgId
                && a.DominioId == _contextoUsuario.DominioId
                && a.Id == id);

        if (!encontrado)
        {
            resultado.Error = "id".ErrorProcesoNoEncontrado();

        }
        else
        {

            bool duplicado = await DB.UnidadesAdministrativas.AnyAsync(a => a.UOrgId == _contextoUsuario.UOrgId
                && a.DominioId == _contextoUsuario.DominioId
                && a.Id != id
                && a.Nombre == actualizacion.Nombre);

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


    public override UnidadAdministrativa ADTOFull(UnidadAdministrativaActualizar actualizacion, UnidadAdministrativa actual)
    {
        actual.Nombre = actualizacion.Nombre;
        return actual;
    }

    public override UnidadAdministrativa ADTOFull(UnidadAdministrativaInsertar data)
    {
        UnidadAdministrativa unidadAdministrativa = new UnidadAdministrativa()
        {
            Id = Guid.NewGuid().ToString(),
            Nombre = data.Nombre,
            Responsable = data.Responsable,
            Cargo = data.Cargo,
            Telefono = data.Telefono,
            Email = data.Email,
            Domicilio = data.Domicilio,
            UbicacionFisica = data.UbicacionFisica,
            ArchivoTramiteId = data.ArchivoTramiteId,
            ArchivoConcentracionId = data.ArchivoConcentracionId,
            ArchivoHistoricoId = data.ArchivoHistoricoId,
            DominioId = _contextoUsuario.DominioId,
            UOrgId = _contextoUsuario.UOrgId,
        };
        return unidadAdministrativa;
    }

    public override UnidadAdministrativaDespliegue ADTODespliegue(UnidadAdministrativa data)
    {
        UnidadAdministrativaDespliegue unidadAdministrativa = new UnidadAdministrativaDespliegue()
        {
            Id = data.Id,
        };
        return unidadAdministrativa;
    }
    #endregion
}
