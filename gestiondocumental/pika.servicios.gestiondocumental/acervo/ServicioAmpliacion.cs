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

namespace pika.servicios.gestiondocumental.acervo
{
    public class ServicioAmpliacion : IServicioAmpliacion
    {
        private readonly ILogger<ServicioAmpliacion> _logger;
        private readonly PIKADbContext PikaContext;

        public ServicioAmpliacion(ILogger<ServicioAmpliacion> logger, PIKADbContext PikaContext)
        {
            _logger = logger;
            this.PikaContext = PikaContext;
        }


        public async Task<string> Crear(Ampliacion ampliacion)
        {
            var existeMismoId = await PikaContext.Ampliacions.AnyAsync(x => x.Id == ampliacion.Id);

            if (existeMismoId)
            {
                return null;
            }

            PikaContext.Ampliacions.Add(ampliacion);
            await PikaContext.SaveChangesAsync();
            return ($"+");
        }


        public async Task<ActionResult<List<Ampliacion>>> Obtiener()
        {
            return await PikaContext.Ampliacions.ToListAsync();
        }


        public async Task<String> Actualizar(string id, Ampliacion ampliacion)
        {
            var existeMismoId = await PikaContext.Ampliacions.AnyAsync(x => x.Id == ampliacion.Id);
            if (existeMismoId != null)
            {
                PikaContext.Entry(ampliacion).State = EntityState.Modified;
                await PikaContext.SaveChangesAsync();
                return ($"+");
            }
            return null;
        }


        public async Task<String> Eliminar(string id, Ampliacion ampliacion)
        {
            var existeMismoId = await PikaContext.Ampliacions.AnyAsync(x => x.Id == ampliacion.Id);
            if (existeMismoId)
            {
                PikaContext.Remove(new Ampliacion() { Id = id });
                await PikaContext.SaveChangesAsync();
                return ($"+");
            }
            return null;
        }

    }
}
