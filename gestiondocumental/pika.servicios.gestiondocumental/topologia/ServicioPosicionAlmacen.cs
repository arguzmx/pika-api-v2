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
    public class ServicioPosicionAlmacen : IServicioPosicionAlmacen
    {

        private readonly ILogger<ServicioPosicionAlmacen> _logger;

        private readonly PIKADbContext PikaContext;

        public ServicioPosicionAlmacen(ILogger<ServicioPosicionAlmacen> logger, PIKADbContext PikaContext)
        {
            _logger = logger;
            this.PikaContext = PikaContext;
        }

        // Crear el CRUD de API utilizando context

        //Crear
        public async Task<string> Crear(PosicionAlmacen posicionalmacen)
        {
            var existeMismoId = await PikaContext.PosicionAlmacens.AnyAsync(x => x.Id == posicionalmacen.Id);

            if (existeMismoId)
            {
                return null;
            }

            PikaContext.PosicionAlmacens.Add(posicionalmacen);
            await PikaContext.SaveChangesAsync();
            return ($"+");
        }

        //Leer
        public async Task<ActionResult<List<PosicionAlmacen>>> Obtiener()
        {
            return await PikaContext.PosicionAlmacens.ToListAsync();
        }

        //Actualizar
        public async Task<String> Actualizar(string id, PosicionAlmacen posicionalmacen)
        {
            var existeMismoId = await PikaContext.PosicionAlmacens.AnyAsync(x => x.Id == posicionalmacen.Id);

            if (existeMismoId != null)
            {
                PikaContext.Entry(posicionalmacen).State = EntityState.Modified;
                await PikaContext.SaveChangesAsync();
                return ($"+");
            }
            return null;
        }

        //Eliminar

        public async Task<string> Eliminar(string id, PosicionAlmacen posicionalmacen)
        {
            var existeMismoId = await PikaContext.PosicionAlmacens.AnyAsync(x => x.Id == posicionalmacen.Id);
            if (existeMismoId)
            {
                PikaContext.Remove(new PosicionAlmacen() { Id = id });
                await PikaContext.SaveChangesAsync();
                return ($"+");
            }
            return null;
        }

    }
}
