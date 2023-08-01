using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using pika.modelo.gestiondocumental;
using pika.servicios.gestiondocumental.dbcontext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pika.servicios.gestiondocumental.topologia
{
    public class ServicioZonaAlmacen : IServicioZonaAlmacen
    {

        private readonly ILogger<ServicioZonaAlmacen> _logger;

        private readonly PIKADbContext PikaContext;

        public ServicioZonaAlmacen(ILogger<ServicioZonaAlmacen> logger, PIKADbContext PikaContext)
        {
            _logger = logger;
            this.PikaContext = PikaContext;
        }

        // Crear el CRUD de API utilizando context

        //Crear
        public async Task<string> Crear(ZonaAlmacen zonaalmacen)
        {
            var existeMismoId = await PikaContext.ZonaAlmacens.AnyAsync(x => x.Id == zonaalmacen.Id);

            if (existeMismoId)
            {
                return null;
            }

            PikaContext.ZonaAlmacens.Add(zonaalmacen);
            await PikaContext.SaveChangesAsync();
            return ($"+");
        }

        //Leer
        public async Task<ActionResult<List<ZonaAlmacen>>> Obtiener()
        {
            return await PikaContext.ZonaAlmacens.ToListAsync();
        }

        //Actualizar
        public async Task<String> Actualizar(string id, ZonaAlmacen zonaalmacen)
        {
            var existeMismoId = await PikaContext.ZonaAlmacens.AnyAsync(x => x.Id == zonaalmacen.Id);

            if (existeMismoId != null)
            {
                PikaContext.Entry(zonaalmacen).State = EntityState.Modified;
                await PikaContext.SaveChangesAsync();
                return ($"+");
            }
            return null;
        }

        //Eliminar

        public async Task<string> Eliminar(string id, ZonaAlmacen zonaalmacen)
        {
            var existeMismoId = await PikaContext.ZonaAlmacens.AnyAsync(x => x.Id == zonaalmacen.Id);
            if (existeMismoId)
            {
                PikaContext.Remove(new ZonaAlmacen() { Id = id });
                await PikaContext.SaveChangesAsync();
                return ($"+");
            }
            return null;
        }

    }
}
