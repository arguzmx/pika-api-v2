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
    public class ServicioComentarioPrestamo : IServicioComentarioPrestamo
    {
        private readonly ILogger<ServicioComentarioPrestamo> _logger;
        private readonly PIKADbContext PikaContext;

        public ServicioComentarioPrestamo(ILogger<ServicioComentarioPrestamo> logger, PIKADbContext PikaContext)
        {
            _logger = logger;
            this.PikaContext = PikaContext;
        }


        public async Task<string> Crear(ComentarioPrestamo comentarioprestamo)
        {
            var existeMismoId = await PikaContext.ComentarioPrestamos.AnyAsync(x => x.PrestamoId == comentarioprestamo.PrestamoId);

            if (existeMismoId)
            {
                return null;
            }

            PikaContext.ComentarioPrestamos.Add(comentarioprestamo);
            await PikaContext.SaveChangesAsync();
            return ($"+");
        }


        public async Task<ActionResult<List<ComentarioPrestamo>>> Obtiener()
        {
            return await PikaContext.ComentarioPrestamos.ToListAsync();
        }


        public async Task<String> Actualizar(string id, ComentarioPrestamo comentarioprestamo)
        {
            var existeMismoId = await PikaContext.ComentarioPrestamos.AnyAsync(x => x.PrestamoId == comentarioprestamo.PrestamoId);
            if (existeMismoId != null)
            {
                PikaContext.Entry(comentarioprestamo).State = EntityState.Modified;
                await PikaContext.SaveChangesAsync();
                return ($"+");
            }
            return null;
        }


        public async Task<String> Eliminar(string id, ComentarioPrestamo comentarioprestamo)
        {
            var existeMismoId = await PikaContext.ComentarioPrestamos.AnyAsync(x => x.PrestamoId == comentarioprestamo.PrestamoId);
            if (existeMismoId)
            {
                PikaContext.Remove(new ComentarioPrestamo() { PrestamoId = id });
                await PikaContext.SaveChangesAsync();
                return ($"+");
            }
            return null;
        }
    }
}
