using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using pika.modelo.gestiondocumental;
using pika.servicios.gestiondocumental.cuadrosclasificacion;
using pika.servicios.gestiondocumental.dbcontext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pika.servicios.gestiondocumental.archivos
{
    public class ServicioArchivo : IServicioArchivo
    {

        private readonly ILogger<ServicioArchivo> _logger;

        private readonly PIKADbContext PikaContext;

        public ServicioArchivo(ILogger<ServicioArchivo> logger, PIKADbContext PikaContext)
        {
            _logger = logger;
            this.PikaContext = PikaContext;
        }

        // Crear el CRUD de API utilizando context

        //Crear
        public async Task<string> Crear(Archivo archivo)
        {
            var existeMismoId = await PikaContext.Archivos.AnyAsync(x => x.Id == archivo.Id);

            if (existeMismoId)
            {
                return null;
            }

            PikaContext.Archivos.Add(archivo);
            await PikaContext.SaveChangesAsync();
            return ($"+");
        }

        //Leer
        public async Task<ActionResult<List<Archivo>>> Obtiener()
        {
            return await PikaContext.Archivos.ToListAsync();
        }

        //Actualizar
        public async Task<String> Actualizar(string id, Archivo archivo)
        {
            var MismoId = await PikaContext.Archivos.AnyAsync(x => x.Id == archivo.Id);

            if (MismoId != null)
            {
                PikaContext.Entry(archivo).State = EntityState.Modified;
                await PikaContext.SaveChangesAsync();
                return ($"+");
            }
            return null;
        }

        //Eliminar

        public async Task<string> Eliminar(string id, Archivo archivo)
        {
            var MismoId = await PikaContext.Archivos.AnyAsync(x => x.Id == archivo.Id);
            if (MismoId)
            {
                PikaContext.Remove(new Archivo() { Id = id });
                await PikaContext.SaveChangesAsync();
                return ($"+");
            }
            return null;
        }

    }
}
