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
    public class ServicioAlmacenArchivo : IServicioAlmacenArchivo
    {

        private readonly ILogger<ServicioAlmacenArchivo> _logger;

        private readonly PIKADbContext PikaContext;

        public ServicioAlmacenArchivo(ILogger<ServicioAlmacenArchivo> logger, PIKADbContext PikaContext)
        {
            _logger = logger;
            this.PikaContext = PikaContext;
        }

        // Crear el CRUD de API utilizando context

        //Crear
        public async Task<string> Crear(AlmacenArchivo almacenarchivo)
        {
            var existeMismoId = await PikaContext.AlmacenArchivos.AnyAsync(x => x.Id == almacenarchivo.Id);

            if (existeMismoId)
            {
                return null;
            }

            PikaContext.AlmacenArchivos.Add(almacenarchivo);
            await PikaContext.SaveChangesAsync();
            return ($"+");
        }

        //Leer
        public async Task<ActionResult<List<AlmacenArchivo>>> Obtiener()
        {
            return await PikaContext.AlmacenArchivos.ToListAsync();
        }

        //Actualizar
        public async Task<String> Actualizar(string id, AlmacenArchivo almacenarchivo)
        {
            var existeMismoId = await PikaContext.AlmacenArchivos.AnyAsync(x => x.Id == almacenarchivo.Id);

            if (existeMismoId != null)
            {
                PikaContext.Entry(almacenarchivo).State = EntityState.Modified;
                await PikaContext.SaveChangesAsync();
                return ($"+");
            }
            return null;
        }

        //Eliminar

        public async Task<string> Eliminar(string id, AlmacenArchivo almacenarchivo)
        {
            var existeMismoId = await PikaContext.AlmacenArchivos.AnyAsync(x => x.Id == almacenarchivo.Id);
            if (existeMismoId)
            {
                PikaContext.Remove(new AlmacenArchivo() { Id = id });
                await PikaContext.SaveChangesAsync();
                return ($"+");
            }
            return null;
        }

    }
}
