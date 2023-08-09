using api.comunes.modelos.modelos;
using api.comunes.modelos.respuestas;
using api.comunes.modelos.servicios;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using pika.comun.metadatos;
using pika.modelo.gestiondocumental;
using pika.modelo.gestiondocumental.Archivos;
using pika.servicios.gestiondocumental.acervo;
using pika.servicios.gestiondocumental.cuadrosclasificacion;
using pika.servicios.gestiondocumental.dbcontext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pika.servicios.gestiondocumental.archivos
{
    public class ServicioArchivoLEgacy : IServicioArchivo
    {

        private readonly ILogger<ServicioArchivo> _logger;
        private readonly PIKADbContext _db;
        private ContextoUsuario _contextoUsuario;

        public ServicioArchivoLEgacy(ILogger<ServicioArchivo> logger, PIKADbContext PikaContext)
        {
            _logger = logger;
            _db = PikaContext;
        }

        public async Task<RespuestaPayload<Archivo>> Insertar(ArchivoInsertar data)
        {
            var respuesta = new RespuestaPayload<Archivo>();

            var resultadoValidacion = await ValidarInsertar(data);
            if (resultadoValidacion.Valido)
            {
                var entidad = ADTOFull(data);
                entidad.Id = Guid.NewGuid().ToString();
                _db.Archivos.Add(entidad);
                await _db.SaveChangesAsync();

                respuesta.HttpCode = HttpCode.Ok;
                respuesta.Payload = entidad;
            }
            else
            {
                respuesta.Error = resultadoValidacion.Error;
                respuesta.HttpCode = resultadoValidacion.Error?.HttpCode ?? HttpCode.None;
            }
            return respuesta;
        }

        public async Task<Respuesta> Actualizar(string id, ArchivoActualizar data)
        {
            var respuesta = new Respuesta();

            if (string.IsNullOrEmpty(id) || data == null)
            {
                respuesta.HttpCode = HttpCode.BadRequest;
                return respuesta;
            }

            Archivo actual = _db.Archivos.Find(id);
            if (actual == null)
            {
                respuesta.HttpCode = HttpCode.NotFound;
                return respuesta;
            }

            var resultadoValidacion = await ValidarActualizar(id, data, actual);
            if (resultadoValidacion.Valido)
            {
                var entidad = ADTOFull(data, actual);
                _db.Archivos.Update(entidad);
                await _db.SaveChangesAsync();

                respuesta.HttpCode = HttpCode.Ok;
            }
            else
            {
                respuesta.Error = resultadoValidacion.Error;
                respuesta.HttpCode = resultadoValidacion.Error?.HttpCode ?? HttpCode.None;
            }

            return respuesta;
        }

        public async Task<Respuesta> Eliminar(string id)
        {
            var respuesta = new Respuesta();

            if (string.IsNullOrEmpty(id))
            {
                respuesta.HttpCode = HttpCode.BadRequest;
                return respuesta;
            }

            Archivo actual = _db.Archivos.Find(id);
            if (actual == null)
            {
                respuesta.HttpCode = HttpCode.NotFound;
                return respuesta;
            }

            var resultadoValidacion = await ValidarEliminacion(id, actual);
            if (resultadoValidacion.Valido)
            {

                _db.Archivos.Remove(actual);
                await _db.SaveChangesAsync();

                respuesta.HttpCode = HttpCode.Ok;
            }
            else
            {
                respuesta.Error = resultadoValidacion.Error;
                respuesta.HttpCode = resultadoValidacion.Error?.HttpCode ?? HttpCode.None;
            }

            return respuesta;
        }

        public async Task<RespuestaPayload<Archivo>> UnicaPorId(string id)
        {
            var respuesta = new RespuestaPayload<Archivo>();
            Archivo actual = await _db.Archivos.FindAsync(id);
            if (actual == null)
            {
                respuesta.HttpCode = HttpCode.NotFound;
                return respuesta;
            } 

            respuesta.HttpCode =HttpCode.Ok;
            respuesta.Payload = actual;

            return respuesta;
        }

        public async Task<RespuestaPayload<PaginaGenerica<Archivo>>> Pagina(Consulta consulta)
        {
            RespuestaPayload<PaginaGenerica<Archivo>> respuesta = new ();

            var elementos = await _db.Archivos.ToListAsync();

            PaginaGenerica<Archivo> pagina = new()
            {
                ConsultaId = Guid.NewGuid().ToString(),
                Elementos = elementos,
                Milisegundos = 0,
                Paginado = new Paginado() { Indice = 0, Tamano = elementos.Count},
                Total = elementos.Count
            };

            respuesta.Payload = pagina;
            respuesta.Ok = true;

            return respuesta;
        }

        public void EstableceContextoUsuario(ContextoUsuario contexto)
        {
            _contextoUsuario = contexto;
        }

        public async Task<ResultadoValidacion> ValidarActualizar(string id, ArchivoActualizar actualizacion, Archivo original)
        {
            return new ResultadoValidacion() { Valido = true };
        }

        public async Task<ResultadoValidacion> ValidarEliminacion(string id, Archivo original)
        {
            return new ResultadoValidacion() { Valido = true };
        }

        public async Task<ResultadoValidacion> ValidarInsertar(ArchivoInsertar data)
        {
            return new ResultadoValidacion() { Valido = true };
        }


        public async Task<RespuestaPayload<ArchivoDespliegue>> UnicaPorIdDespliegue(string id)
        {
            RespuestaPayload<ArchivoDespliegue> respuesta = new RespuestaPayload<ArchivoDespliegue>();
            var resultado = await UnicaPorId(id);
            
            respuesta.Ok = resultado.Ok;

            if (resultado.Ok)
            {
                respuesta.Payload = ADTODespliegue((Archivo)resultado.Payload);
            }

            return respuesta;
        }

        public async Task<RespuestaPayload<PaginaGenerica<ArchivoDespliegue>>> PaginaDespliegue(Consulta consulta)
        {
            RespuestaPayload<PaginaGenerica<ArchivoDespliegue>> respuesta = new RespuestaPayload<PaginaGenerica<ArchivoDespliegue>>();
            var resultado = await Pagina(consulta);

            respuesta.Ok = resultado.Ok;

            if (resultado.Ok)
            {
                PaginaGenerica<ArchivoDespliegue> pagina = new()
                {
                    ConsultaId = Guid.NewGuid().ToString(),
                    Elementos = new List<ArchivoDespliegue>(),
                    Milisegundos = 0,
                    Paginado = new Paginado() { Indice = 0, Tamano = ((PaginaGenerica<Archivo>)resultado.Payload).Paginado.Tamano },
                    Total = ((PaginaGenerica<Archivo>)resultado.Payload).Total
                };

                foreach (Archivo item in ((PaginaGenerica<Archivo>)resultado.Payload).Elementos)
                {
                    pagina.Elementos.Add(ADTODespliegue(item));
                }
                respuesta.Payload = pagina;
            }

            return respuesta;
        }


        public Archivo ADTOFull(ArchivoInsertar data)
        {
            throw new NotImplementedException();
        }

        public Archivo ADTOFull(ArchivoActualizar actualizacion, Archivo actual)
        {
            throw new NotImplementedException();
        }

        

        public Entidad EntidadInsert()
        {
            throw new NotImplementedException();
        }

        public Entidad EntidadRepo()
        {
            throw new NotImplementedException();
        }

        public Entidad EntidadUpdate()
        {
            throw new NotImplementedException();
        }

        public Entidad EntidadDespliegue()
        {
            throw new NotImplementedException();
        }

 
        public ArchivoDespliegue ADTODespliegue(Archivo data)
        {
            throw new NotImplementedException();
        }

        Task<RespuestaPayload<ArchivoDespliegue>> IServicioEntidadGenerica<Archivo, ArchivoInsertar, ArchivoActualizar, ArchivoDespliegue, string>.Insertar(ArchivoInsertar data)
        {
            throw new NotImplementedException();
        }
    }
}
