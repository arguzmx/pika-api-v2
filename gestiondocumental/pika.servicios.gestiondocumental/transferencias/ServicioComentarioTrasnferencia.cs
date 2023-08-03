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
    public class ServicioComentarioTrasnferencia : IServicioComentarioTrasnferencia
    {
        private readonly ILogger<ServicioComentarioTrasnferencia> _logger;
        private readonly PIKADbContext PikaContext;

        public ServicioComentarioTrasnferencia(ILogger<ServicioComentarioTrasnferencia> logger, PIKADbContext PikaContext)
        {
            _logger = logger;
            this.PikaContext = PikaContext;
        }


        public async Task<string> Crear(ComentarioTransferencia comentariotransferencia)
        {
            var existeMismoId = await PikaContext.ComentarioTransferencias.AnyAsync(x => x.Id == comentariotransferencia.Id);

            if (existeMismoId)
            {
                return null;
            }

            PikaContext.ComentarioTransferencias.Add(comentariotransferencia);
            await PikaContext.SaveChangesAsync();
            return ($"+");
        }


        public async Task<List<ComentarioTransferencia>> Obtiener()
        {
            return await PikaContext.ComentarioTransferencias.ToListAsync();
        }


        public async Task<String> Actualizar(string id, ComentarioTransferencia comentariotransferencia)
        {
            var existeMismoId = await PikaContext.ComentarioTransferencias.AnyAsync(x => x.Id == comentariotransferencia.Id);
            if (existeMismoId != null)
            {
                PikaContext.Entry(comentariotransferencia).State = EntityState.Modified;
                await PikaContext.SaveChangesAsync();
                return ($"+");
            }
            return null;
        }


        public async Task<String> Eliminar(string id, ComentarioTransferencia comentariotransferencia)
        {
            var existeMismoId = await PikaContext.ComentarioTransferencias.AnyAsync(x => x.Id == comentariotransferencia.Id);
            if (existeMismoId)
            {
                PikaContext.Remove(new ComentarioTransferencia() { Id = id });
                await PikaContext.SaveChangesAsync();
                return ($"+");
            }
            return null;
        }
    }
}
