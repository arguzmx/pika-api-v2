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

namespace pika.servicios.gestiondocumental.archivos
{
    public class ServicioUnidadAdministrativaArchivo : IServicioUnidadAdministrativaArchivo
    {


        private readonly ILogger<ServicioUnidadAdministrativaArchivo> _logger;

        private readonly PIKADbContext PikaContext;

        public ServicioUnidadAdministrativaArchivo(ILogger<ServicioUnidadAdministrativaArchivo> logger, PIKADbContext PikaContext)
        {
            _logger = logger;
            this.PikaContext = PikaContext;
        }

        // Crear el CRUD de API utilizando context

        //Crear
        public async Task<string> Crear(UnidadAdministrativaArchivo unidadadministrativaarchivo)
        {
            var existeMismoId = await PikaContext.UnidadAdministrativaArchivos.AnyAsync(x => x.Id == unidadadministrativaarchivo.Id);

            if (existeMismoId)
            {
                return null;
            }

            PikaContext.UnidadAdministrativaArchivos.Add(unidadadministrativaarchivo);
            await PikaContext.SaveChangesAsync();
            return ($"+");
        }

        //Leer
        public async Task<ActionResult<List<UnidadAdministrativaArchivo>>> Obtiener()
        {
            return await PikaContext.UnidadAdministrativaArchivos.ToListAsync();
        }

        //Actualizar
        public async Task<String> Actualizar(string id, UnidadAdministrativaArchivo unidadadministrativaarchivo)
        {
            var MismoId = await PikaContext.UnidadAdministrativaArchivos.AnyAsync(x => x.Id == unidadadministrativaarchivo.Id);

            if (MismoId != null)
            {
                PikaContext.Entry(unidadadministrativaarchivo).State = EntityState.Modified;
                await PikaContext.SaveChangesAsync();
                return ($"+");
            }
            return null;
        }

        //Eliminar

        public async Task<string> Eliminar(string id, UnidadAdministrativaArchivo unidadadministrativaarchivo)
        {
            var MismoId = await PikaContext.UnidadAdministrativaArchivos.AnyAsync(x => x.Id == unidadadministrativaarchivo.Id);
            if (MismoId)
            {
                PikaContext.Remove(new UnidadAdministrativaArchivo() { Id = id });
                await PikaContext.SaveChangesAsync();
                return ($"+");
            }
            return null;
        }

    }
}
