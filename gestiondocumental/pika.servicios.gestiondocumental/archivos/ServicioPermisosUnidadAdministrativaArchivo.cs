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
    public class ServicioPermisosUnidadAdministrativaArchivo : IServicioPermisosUnidadAdministrativaArchivo
    {
        private readonly ILogger<ServicioPermisosUnidadAdministrativaArchivo> _logger;
        private readonly PIKADbContext PikaContext;

        public ServicioPermisosUnidadAdministrativaArchivo(ILogger<ServicioPermisosUnidadAdministrativaArchivo> logger, PIKADbContext PikaContext)
        {
            _logger = logger;
            this.PikaContext = PikaContext;
        }


        public async Task<string> Crear(PermisosUnidadAdministrativaArchivo permisosunidadadministrativaarchivo)
        {
            var existeMismoId = await PikaContext.PermisosUnidadAdministrativaArchivos.AnyAsync(x => x.Id == permisosunidadadministrativaarchivo.Id);

            if (existeMismoId)
            {
                return null;
            }

            PikaContext.PermisosUnidadAdministrativaArchivos.Add(permisosunidadadministrativaarchivo);
            await PikaContext.SaveChangesAsync();
            return ($"+");
        }


        public async Task<ActionResult<List<PermisosUnidadAdministrativaArchivo>>> Obtiener()
        {
            return await PikaContext.PermisosUnidadAdministrativaArchivos.ToListAsync();
        }


        public async Task<String> Actualizar(string id, PermisosUnidadAdministrativaArchivo permisosunidadadministrativaarchivo)
        {
            var existeMismoId = await PikaContext.PermisosUnidadAdministrativaArchivos.AnyAsync(x => x.Id == permisosunidadadministrativaarchivo.Id);
            if (existeMismoId != null)
            {
                PikaContext.Entry(permisosunidadadministrativaarchivo).State = EntityState.Modified;
                await PikaContext.SaveChangesAsync();
                return ($"+");
            }
            return null;
        }


        public async Task<String> Eliminar(string id, PermisosUnidadAdministrativaArchivo permisosunidadadministrativaarchivo)
        {
            var existeMismoId = await PikaContext.PermisosUnidadAdministrativaArchivos.AnyAsync(x => x.Id == permisosunidadadministrativaarchivo.Id);
            if (existeMismoId)
            {
                PikaContext.Remove(new PermisosUnidadAdministrativaArchivo() { Id = id });
                await PikaContext.SaveChangesAsync();
                return ($"+");
            }
            return null;
        }


    }
}
