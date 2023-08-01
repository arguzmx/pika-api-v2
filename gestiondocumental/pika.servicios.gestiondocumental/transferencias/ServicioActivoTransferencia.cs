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

namespace pika.servicios.gestiondocumental.transferencias
{
    public class ServicioActivoTransferencia : IServicioActivoTranferencia
    {
        private readonly ILogger<ServicioActivoTransferencia> _logger;
        private readonly PIKADbContext PikaContext;

        public ServicioActivoTransferencia(ILogger<ServicioActivoTransferencia> logger, PIKADbContext PikaContext)
        {
            _logger = logger;
            this.PikaContext = PikaContext;
        }


        public async Task<string> Crear(ActivoTransferencia activotransferencia)
        {
            var existeMismoId = await PikaContext.ActivoTransferencias.AnyAsync(x => x.Id == activotransferencia.Id);

            if (existeMismoId)
            {
                return null;
            }

            PikaContext.ActivoTransferencias.Add(activotransferencia);
            await PikaContext.SaveChangesAsync();
            return ($"+");
        }


        public async Task<ActionResult<List<ActivoTransferencia>>> Obtiener()
        {
            return await PikaContext.ActivoTransferencias.ToListAsync();
        }


        public async Task<String> Actualizar(string id, ActivoTransferencia activotransferencia)
        {
            var existeMismoId = await PikaContext.ActivoTransferencias.AnyAsync(x => x.Id == activotransferencia.Id);
            if (existeMismoId != null)
            {
                PikaContext.Entry(activotransferencia).State = EntityState.Modified;
                await PikaContext.SaveChangesAsync();
                return ($"+");
            }
            return null;
        }


        public async Task<String> Eliminar(string id, ActivoTransferencia activotransferencia)
        {
            var existeMismoId = await PikaContext.ActivoTransferencias.AnyAsync(x => x.Id == activotransferencia.Id);
            if (existeMismoId)
            {
                PikaContext.Remove(new ActivoTransferencia() { Id = id });
                await PikaContext.SaveChangesAsync();
                return ($"+");
            }
            return null;
        }
    }
}
