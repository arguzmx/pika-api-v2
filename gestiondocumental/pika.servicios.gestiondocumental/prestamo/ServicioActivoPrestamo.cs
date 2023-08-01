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

namespace pika.servicios.gestiondocumental.prestamo
{
    public class ServicioActivoPrestamo : IServicioActivoPrestamo
    {

        private readonly ILogger<ServicioActivoPrestamo> _logger;
        private readonly PIKADbContext PikaContext;

        public ServicioActivoPrestamo(ILogger<ServicioActivoPrestamo> logger, PIKADbContext PikaContext)
        {
            _logger = logger;
            this.PikaContext = PikaContext;
        }


        public async Task<string> Crear(ActivoPrestamo activoprestamo)
        {
            var existeMismoId = await PikaContext.ActivoPrestamos.AnyAsync(x => x.Id == activoprestamo.Id);

            if (existeMismoId)
            {
                return null;
            }

            PikaContext.ActivoPrestamos.Add(activoprestamo);
            await PikaContext.SaveChangesAsync();
            return ($"+");
        }


        public async Task<ActionResult<List<ActivoPrestamo>>> Obtiener()
        {
            return await PikaContext.ActivoPrestamos.ToListAsync();
        }


        public async Task<String> Actualizar(string id, ActivoPrestamo activoprestamo)
        {
            var existeMismoId = await PikaContext.ActivoPrestamos.AnyAsync(x => x.Id == activoprestamo.Id);
            if (existeMismoId != null)
            {
                PikaContext.Entry(activoprestamo).State = EntityState.Modified;
                await PikaContext.SaveChangesAsync();
                return ($"+");
            }
            return null;
        }


        public async Task<String> Eliminar(string id, ActivoPrestamo activoprestamo)
        {
            var existeMismoId = await PikaContext.ActivoPrestamos.AnyAsync(x => x.Id == activoprestamo.Id);
            if (existeMismoId)
            {
                PikaContext.Remove(new ActivoPrestamo() { Id = id });
                await PikaContext.SaveChangesAsync();
                return ($"+");
            }
            return null;
        }

    }
}
