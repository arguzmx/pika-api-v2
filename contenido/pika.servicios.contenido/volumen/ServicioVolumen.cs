﻿
using api.comunes.modelos.modelos;
using api.comunes.modelos.reflectores;
using api.comunes.modelos.respuestas;
using api.comunes.modelos.servicios;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using pika.comun.metadatos;
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
