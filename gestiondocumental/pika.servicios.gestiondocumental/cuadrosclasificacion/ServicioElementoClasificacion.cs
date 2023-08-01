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

namespace pika.servicios.gestiondocumental.cuadrosclasificacion
{
    public class ServicioElementoClasificacion : IServicioElementoClasificacion
    {

        private readonly ILogger<ServicioElementoClasificacion> _logger;

        private readonly PIKADbContext PikaContext;

        public ServicioElementoClasificacion(ILogger<ServicioElementoClasificacion> logger, PIKADbContext PikaContext)
        {
            _logger = logger;
            this.PikaContext = PikaContext;
        }

        // Crear el CRUD de API utilizando context

        //Crear
        public async Task<string> Crear(ElementoClasificacion elementoclasificacion)
        {
            var existeMismoId = await PikaContext.ElementoClasificacions.AnyAsync(x => x.Id == elementoclasificacion.Id);

            if (existeMismoId)
            {
                return null;
            }

            PikaContext.ElementoClasificacions.Add(elementoclasificacion);
            await PikaContext.SaveChangesAsync();
            return ($"+");
        }

        //Leer
        public async Task<ActionResult<List<ElementoClasificacion>>> Obtiener()
        {
            return await PikaContext.ElementoClasificacions.ToListAsync();
        }

        //Actualizar
        public async Task<String> Actualizar(string id, ElementoClasificacion elementoclasificacion)
        {
            var MismoId = await PikaContext.ElementoClasificacions.AnyAsync(x => x.Id == elementoclasificacion.Id);

            if (MismoId != null)
            {
                PikaContext.Entry(elementoclasificacion).State = EntityState.Modified;
                await PikaContext.SaveChangesAsync();
                return ($"+");
            }
            return null;
        }

        //Eliminar

        public async Task<string> Eliminar(string id, ElementoClasificacion elementoclasificacion)
        {
            var MismoId = await PikaContext.ElementoClasificacions.AnyAsync(x => x.Id == elementoclasificacion.Id);
            if (MismoId)
            {
                PikaContext.Remove(new ElementoClasificacion() { Id = id });
                await PikaContext.SaveChangesAsync();
                return ($"+");
            }
            return null;
        }

    }
}
