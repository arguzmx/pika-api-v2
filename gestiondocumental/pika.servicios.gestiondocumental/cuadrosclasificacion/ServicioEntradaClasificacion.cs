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
    public class ServicioEntradaClasificacion : IServicioEntradaClasificacion
    {

        private readonly ILogger<ServicioEntradaClasificacion> _logger;

        private readonly PIKADbContext PikaContext;

        public ServicioEntradaClasificacion(ILogger<ServicioEntradaClasificacion> logger, PIKADbContext PikaContext)
        {
            _logger = logger;
            this.PikaContext = PikaContext;
        }

        // Crear el CRUD de API utilizando context

        //Crear
        public async Task<string> Crear(EntradaClasificacion entradaclasificacion)
        {
            var existeMismoId = await PikaContext.EntradaClasificacions.AnyAsync(x => x.Id == entradaclasificacion.Id);

            if (existeMismoId)
            {
                return null;
            }

            PikaContext.EntradaClasificacions.Add(entradaclasificacion);
            await PikaContext.SaveChangesAsync();
            return ($"+");
        }

        //Leer
        public async Task<ActionResult<List<EntradaClasificacion>>> Obtiener()
        {
            return await PikaContext.EntradaClasificacions.ToListAsync();
        }

        //Actualizar
        public async Task<String> Actualizar(string id, EntradaClasificacion entradaclasificacion)
        {
            var MismoId = await PikaContext.EntradaClasificacions.AnyAsync(x => x.Id == entradaclasificacion.Id);

            if (MismoId != null)
            {
                PikaContext.Entry(entradaclasificacion).State = EntityState.Modified;
                await PikaContext.SaveChangesAsync();
                return ($"+");
            }
            return null;
        }

        //Eliminar

        public async Task<string> Eliminar(string id, EntradaClasificacion entradaclasificacion)
        {
            var MismoId = await PikaContext.EntradaClasificacions.AnyAsync(x => x.Id == entradaclasificacion.Id);
            if (MismoId)
            {
                PikaContext.Remove(new EntradaClasificacion() { Id = id });
                await PikaContext.SaveChangesAsync();
                return ($"+");
            }
            return null;
        }

    }
}
