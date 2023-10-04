using api.comunes.modelos.modelos;
using api.comunes.modelos.reflectores;
using api.comunes.modelos.respuestas;
using api.comunes.modelos.servicios;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using pika.comun.metadatos;
using pika.modelo.gestiondocumental;
using pika.modelo.gestiondocumental.Archivos;
using pika.modelo.gestiondocumental.CuadrosClasificacion.CuadroClasificacion;
using pika.servicios.gestiondocumental.archivos;
using pika.servicios.gestiondocumental.dbcontext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace pika.servicios.gestiondocumental.cuadrosclasificacion
{

    [ServicioEntidadAPI(entidad: typeof(CuadroClasificacion))]
    public class ServicioCuadroClasificacion : ServicioEntidadGenericaBase<CuadroClasificacion, CuadroClasificacionInsertar, CuadroClasificacionActualizar, CuadroClasificacionDespliegue, string>,
        IServicioEntidadAPI, IServicioCuadroClasificacion
    {
        public ServicioCuadroClasificacion(DbContextGestionDocumental context, ILogger<ServicioCuadroClasificacion> logger) : base(context, context.CuadrosClasificacion, logger)
        {
        }

        /// <summary>
        /// Acceso al repositorio de gestipon documental local
        /// </summary>
        private DbContextGestionDocumental DB { get { return (DbContextGestionDocumental)_db; } }


        public bool RequiereAutenticacion => true;



        public async Task<Respuesta> ActualizarAPI(object id, JsonElement data)
        {
            var update = data.Deserialize<CuadroClasificacionActualizar>(JsonAPIDefaults());
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
            var add = data.Deserialize<CuadroClasificacionInsertar>(JsonAPIDefaults());
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











        public override async Task<ResultadoValidacion> ValidarInsertar(CuadroClasificacionInsertar data)
        {
            ResultadoValidacion resultado = new ();
            bool encontrado = await DB.CuadrosClasificacion.AnyAsync(a => a.UOrgId == _contextoUsuario.UOrgId
                    && a.DominioId == _contextoUsuario.DominioId
                    && a.Nombre==data.Nombre);

            if (encontrado)
            {
                resultado.Error = "Nombre".ErrorProcesoDuplicado();

            } else
            {
                resultado.Valido = true;
            }

            return resultado;
        }


        public override async Task<ResultadoValidacion> ValidarEliminacion(string id, CuadroClasificacion original)
        {
            ResultadoValidacion resultado = new();
            bool encontrado = await DB.CuadrosClasificacion.AnyAsync(a => a.UOrgId == _contextoUsuario.UOrgId
                    && a.DominioId == _contextoUsuario.DominioId
                    && a.Id == id);

            if(!encontrado)
            {
                resultado.Error = "id".ErrorProcesoNoEncontrado();

            } else
            {
                resultado.Valido = true;
            }

            return resultado;
        }


        public override async Task<ResultadoValidacion> ValidarActualizar(string id, CuadroClasificacionActualizar actualizacion, CuadroClasificacion original)
        {
            ResultadoValidacion resultado = new();
            bool encontrado = await DB.CuadrosClasificacion.AnyAsync(a => a.UOrgId == _contextoUsuario.UOrgId
                    && a.DominioId == _contextoUsuario.DominioId
                    && a.Id == id);

            if (!encontrado)
            {
                resultado.Error = "id".ErrorProcesoNoEncontrado();

            }
            else
            {

                bool duplicado = await DB.CuadrosClasificacion.AnyAsync(a => a.UOrgId == _contextoUsuario.UOrgId
                    && a.DominioId == _contextoUsuario.DominioId
                    && a.Id != id 
                    && a.Nombre==actualizacion.Nombre);

                if (duplicado)
                {
                    resultado.Error = "Nombre".ErrorProcesoDuplicado();

                } else
                {
                    resultado.Valido = true;
                }
            }

            return resultado;
        }


        public override CuadroClasificacion ADTOFull(CuadroClasificacionActualizar actualizacion, CuadroClasificacion actual)
        {
            actual.Nombre = actualizacion.Nombre;
            return actual;
        }

        public override CuadroClasificacion ADTOFull(CuadroClasificacionInsertar data)
        {
            CuadroClasificacion cuadroclasificacion = new CuadroClasificacion()
            {
                Id = Guid.NewGuid().ToString(),
                Nombre = data.Nombre,
                UOrgId = _contextoUsuario.UOrgId,
                DominioId = _contextoUsuario.DominioId,
            };
            return cuadroclasificacion;
        }

        public override CuadroClasificacionDespliegue ADTODespliegue(CuadroClasificacion data)
        {
            CuadroClasificacionDespliegue cuadroclasificacion = new CuadroClasificacionDespliegue()
            {
                Id = data.Id,
                Nombre = data.Nombre,
                
            };
            return cuadroclasificacion;
        }

        public Task<RespuestaPayload<PaginaGenerica<object>>> PaginaHijoAPI(Consulta consulta, string tipoPadre, string id)
        {
            throw new NotImplementedException();
        }

        public Task<RespuestaPayload<PaginaGenerica<object>>> PaginaHijosDespliegueAPI(Consulta consulta, string tipoPadre, string id)
        {
            throw new NotImplementedException();
        }
    }
}
