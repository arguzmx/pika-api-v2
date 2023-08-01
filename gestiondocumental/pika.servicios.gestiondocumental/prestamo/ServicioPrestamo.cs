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
    public class ServicioPrestamo
    {
        private readonly ILogger<ServicioPrestamo> _logger;
        private readonly PIKADbContext PikaContext;

        public ServicioPrestamo(ILogger<ServicioPrestamo> logger, PIKADbContext PikaContext)
        {
            _logger = logger;
            this.PikaContext = PikaContext;
        }


        public async Task<string> Crear(Prestamo prestamo)
        {
            var existeMismoId = await PikaContext.Prestamos.AnyAsync(x => x.Id == prestamo.Id);

            if (existeMismoId)
            {
                return null;
            }

            PikaContext.Prestamos.Add(prestamo);
            await PikaContext.SaveChangesAsync();
            return ($"+");
        }


        public async Task<ActionResult<List<Prestamo>>> Obtiener()
        {
            return await PikaContext.Prestamos.ToListAsync();
        }


        public async Task<String> Actualizar(string id, Prestamo prestamo)
        {
            var existeMismoId = await PikaContext.Prestamos.AnyAsync(x => x.Id == prestamo.Id);
            if (existeMismoId != null)
            {
                PikaContext.Entry(prestamo).State = EntityState.Modified;
                await PikaContext.SaveChangesAsync();
                return ($"+");
            }
            return null;
        }


        public async Task<String> Eliminar(string id, Prestamo prestamo)
        {
            var existeMismoId = await PikaContext.Prestamos.AnyAsync(x => x.Id == prestamo.Id);
            if (existeMismoId)
            {
                PikaContext.Remove(new Prestamo() { Id = id });
                await PikaContext.SaveChangesAsync();
                return ($"+");
            }
            return null;
        }

    }
}
