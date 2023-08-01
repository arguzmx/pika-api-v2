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

namespace pika.servicios.gestiondocumental.cuadrosclasificacion
{
    public class ServicioCuadroClasificacion : IServicioCuadroClasificacion
    {
        private readonly ILogger<ServicioCuadroClasificacion> _logger;

        private readonly PIKADbContext PikaContext;

        public ServicioCuadroClasificacion(ILogger<ServicioCuadroClasificacion> logger, PIKADbContext PikaContext)
        {
            _logger = logger;
            this.PikaContext = PikaContext;
        }

        // Crear el CRUD de API utilizando context

        //Crear
        public async Task<string> Crear(CuadroClasificacion cuadroclasificacion)
        {
            var existeMismoId = await PikaContext.CuadroClasificacions.AnyAsync(x => x.Id == cuadroclasificacion.Id);

            if (existeMismoId)
            {
                return null;
            }

            PikaContext.CuadroClasificacions.Add(cuadroclasificacion);
            await PikaContext.SaveChangesAsync();
            return ($"+");
        }

        //Leer
        public async Task<ActionResult<List<CuadroClasificacion>>> Obtiener()
        {
            return await PikaContext.CuadroClasificacions.ToListAsync();
        }

        //Actualizar
        public async Task<String> Actualizar(string id, CuadroClasificacion cuadroclasificacion)
        {
            var MismoId = await PikaContext.CuadroClasificacions.AnyAsync(x => x.Id == cuadroclasificacion.Id);

            if (MismoId != null)
            {
                PikaContext.Entry(cuadroclasificacion).State = EntityState.Modified;
                await PikaContext.SaveChangesAsync();
                return ($"+");
            }
            return null;
        }

        //Eliminar

        public async Task<string> Eliminar(string id, CuadroClasificacion cuadroclasificacion)
        {
            var MismoId = await PikaContext.CuadroClasificacions.AnyAsync(x => x.Id == cuadroclasificacion.Id);
            if (MismoId)
            {
                PikaContext.Remove(new CuadroClasificacion() { Id = id });
                await PikaContext.SaveChangesAsync();
                return ($"+");
            }
            return null;
        }
    }
}
