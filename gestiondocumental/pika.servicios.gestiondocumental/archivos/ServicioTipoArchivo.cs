using api.comunes.modelos.reflectores;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using pika.modelo.gestiondocumental;
using pika.servicios.gestiondocumental.dbcontext;

namespace pika.servicios.gestiondocumental.archivos
{
    [ServicioCatalogoEntidadAPI(typeof(TipoArchivo))]
    public class ServicioTipoArchivo 
    {

        private readonly ILogger<ServicioTipoArchivo> _logger;

        private readonly PIKADbContext PikaContext;

        public ServicioTipoArchivo(ILogger<ServicioTipoArchivo> logger, PIKADbContext PikaContext)
        {
            _logger = logger;
            this.PikaContext = PikaContext;
        }

        // Crear el CRUD de API utilizando context

        //Crear
        public async Task<string> Crear(TipoArchivo tipoarchivo)
        {
            var existeMismoId = await PikaContext.TipoArchivos.AnyAsync(x => x.Id == tipoarchivo.Id);

            if (existeMismoId)
            {
                return null;
            }

            PikaContext.TipoArchivos.Add(tipoarchivo);
            await PikaContext.SaveChangesAsync();
            return ($"+");
        }

        //Leer
        public async Task<ActionResult<List<TipoArchivo>>> Obtiener()
        {
            return await PikaContext.TipoArchivos.ToListAsync();
        }

        //Actualizar
        public async Task<String> Actualizar(string id, TipoArchivo tipoarchivo)
        {
            var MismoId = await PikaContext.TipoArchivos.AnyAsync(x => x.Id == tipoarchivo.Id);

            if (MismoId != null)
            {
                PikaContext.Entry(tipoarchivo).State = EntityState.Modified;
                await PikaContext.SaveChangesAsync();
                return ($"+");
            }
            return null;
        }

        //Eliminar

        public async Task<string> Eliminar(string id, TipoArchivo tipoarchivo)
        {
            var MismoId = await PikaContext.TipoArchivos.AnyAsync(x => x.Id == tipoarchivo.Id);
            if (MismoId)
            {
                PikaContext.Remove(new TipoArchivo() { Id = id });
                await PikaContext.SaveChangesAsync();
                return ($"+");
            }
            return null;
        }

    }
}
