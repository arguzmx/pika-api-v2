using api.comunes.metadatos;
using api.comunes.modelos.modelos;
using api.comunes.modelos.reflectores;
using api.comunes.modelos.respuestas;
using api.comunes.modelos.servicios;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using pika.modelo.organizacion;
using pika.servicios.organizacion.dbcontext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;


namespace pika.servicios.organizacion.dominio
{


    [ServicioEntidadAPI(entidad: typeof(Dominio))]
    public class ServicioDominio : ServicioEntidadGenericaBase<Dominio, DominioInsertar, DominioActualizar, DominioDespliegue, string>,
        IServicioEntidadAPI, IServicioDominio
    {

        public ServicioDominio(DbContextOrganizacion context, ILogger<ServicioDominio> logger) : base(context, context.Dominios, logger)
        {
        }


        /// <summary>
        /// Acceso al repositorio de gestipon documental local
        /// </summary>
        private DbContextOrganizacion DB { get { return (DbContextOrganizacion)_db; } }

        public bool RequiereAutenticacion => true;

        public Task<Respuesta> ActualizarAPI(object id, JsonElement data)
        {
            throw new NotImplementedException();
        }

        public Task<Respuesta> EliminarAPI(object id)
        {
            throw new NotImplementedException();
        }

        public Entidad EntidadDespliegueAPI()
        {
            throw new NotImplementedException();
        }

        public Entidad EntidadInsertAPI()
        {
            throw new NotImplementedException();
        }

        public Entidad EntidadRepoAPI()
        {
            throw new NotImplementedException();
        }

        public Entidad EntidadUpdateAPI()
        {
            throw new NotImplementedException();
        }

        public void EstableceContextoUsuarioAPI(ContextoUsuario contexto)
        {
            throw new NotImplementedException();
        }

        public Task<RespuestaPayload<object>> InsertarAPI(JsonElement data)
        {
            throw new NotImplementedException();
        }

        public ContextoUsuario? ObtieneContextoUsuarioAPI()
        {
            throw new NotImplementedException();
        }

        public Task<RespuestaPayload<PaginaGenerica<object>>> PaginaAPI(Consulta consulta)
        {
            throw new NotImplementedException();
        }

        public Task<RespuestaPayload<PaginaGenerica<object>>> PaginaDespliegueAPI(Consulta consulta)
        {
            throw new NotImplementedException();
        }

        public Task<RespuestaPayload<PaginaGenerica<object>>> PaginaHijoAPI(Consulta consulta, string tipoPadre, string id)
        {
            throw new NotImplementedException();
        }

        public Task<RespuestaPayload<PaginaGenerica<object>>> PaginaHijosDespliegueAPI(Consulta consulta, string tipoPadre, string id)
        {
            throw new NotImplementedException();
        }

        public Task<RespuestaPayload<object>> UnicaPorIdAPI(object id)
        {
            throw new NotImplementedException();
        }

        public Task<RespuestaPayload<object>> UnicaPorIdDespliegueAPI(object id)
        {
            throw new NotImplementedException();
        }



        #region Overrides para la personalizacion de la entidad dominio

        public override async Task<ResultadoValidacion> ValidarInsertar(DominioInsertar data)
        {
            ResultadoValidacion resultado = new();
            bool encontrado = await DB.Dominios.AnyAsync(a =>  a.Nombre == data.Nombre);

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


        public override async Task<ResultadoValidacion> ValidarEliminacion(string id, Dominio original)
        {
            ResultadoValidacion resultado = new();
            bool encontrado = await DB.Dominios.AnyAsync(a => a.Id == id);

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


        public override async Task<ResultadoValidacion> ValidarActualizar(string id, DominioActualizar actualizacion, Dominio original)
        {
            ResultadoValidacion resultado = new();
            bool encontrado = await DB.Dominios.AnyAsync(a => a.Id == id);

            if (!encontrado)
            {
                resultado.Error = "id".ErrorProcesoNoEncontrado();

            }
            else
            {

                bool duplicado = await DB.Dominios.AnyAsync(a => a.Id== id
               );

                if (duplicado)
                {
                    resultado.Error = "Id".ErrorProcesoDuplicado();

                }
                else
                {
                    resultado.Valido = true;
                }
            }

            return resultado;
        }


        public override Dominio ADTOFull(DominioActualizar actualizacion, Dominio actual)
        {
            actual.Nombre = actualizacion.Nombre;
            return actual;
        }

        public override Dominio ADTOFull(DominioInsertar data)
        {
            Dominio archivo = new Dominio()
            {
                Id = Guid.NewGuid().ToString(),
                Nombre = data.Nombre,
                Activo = data.Activo,
            };
            return archivo;
        }

        public override DominioDespliegue ADTODespliegue(Dominio data)
        {
            DominioDespliegue archivo = new DominioDespliegue()
            {
                Id = data.Id,
            };
            return archivo;
        }

        #endregion

    }
}
