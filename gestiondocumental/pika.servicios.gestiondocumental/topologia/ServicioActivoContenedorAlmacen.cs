using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using pika.modelo.gestiondocumental;
using pika.servicios.gestiondocumental.acervo;
using pika.servicios.gestiondocumental.dbcontext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pika.servicios.gestiondocumental.topologia
{
    public class ServicioActivoContenedorAlmacen : IServicioActivoContenedorAlmacen
    {

        private readonly ILogger<ServicioActivoContenedorAlmacen> _logger;

        private readonly PIKADbContext PikaContext;

        public ServicioActivoContenedorAlmacen(ILogger<ServicioActivoContenedorAlmacen> logger, PIKADbContext PikaContext)
        {
            _logger = logger;
            this.PikaContext = PikaContext;
        }

        // Crear el CRUD de API utilizando context

        //Crear
        public async Task<string> Crear(ActivoContenedorAlmacen activocontenedoralmacen)
        {
            var existeMismoId = await PikaContext.ActivoContenedorAlmacens.AnyAsync(x => x.ContenedorAlmacenId == activocontenedoralmacen.ContenedorAlmacenId);

            if (existeMismoId)
            {
                return null;
            }

            PikaContext.ActivoContenedorAlmacens.Add(activocontenedoralmacen);
            await PikaContext.SaveChangesAsync();
            return ($"+");
        }

        //Leer
        public async Task<ActionResult<List<ActivoContenedorAlmacen>>> Obtiener()
        {
            return await PikaContext.ActivoContenedorAlmacens.ToListAsync();
        }

        //Actualizar
        public async Task<String> Actualizar(string id, ActivoContenedorAlmacen activocontenedoralmacen)
        {
            var existeMismoId = await PikaContext.ActivoContenedorAlmacens.AnyAsync(x => x.ContenedorAlmacenId == activocontenedoralmacen.ContenedorAlmacenId);

            if (existeMismoId != null)
            {
                PikaContext.Entry(activocontenedoralmacen).State = EntityState.Modified;
                await PikaContext.SaveChangesAsync();
                return ($"+");
            }
            return null;
        }

        //Eliminar

        public async Task<string> Eliminar(string id, ActivoContenedorAlmacen activocontenedoralmacen)
        {
            var existeMismoId = await PikaContext.ActivoContenedorAlmacens.AnyAsync(x => x.ContenedorAlmacenId == activocontenedoralmacen.ContenedorAlmacenId);
            if (existeMismoId)
            {
                PikaContext.Remove(new ActivoContenedorAlmacen() { ContenedorAlmacenId = id });
                await PikaContext.SaveChangesAsync();
                return ($"+");
            }
            return null;
        }

    }
}
