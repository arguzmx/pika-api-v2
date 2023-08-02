using Microsoft.AspNetCore.Mvc;
using pika.modelo.gestiondocumental;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pika.servicios.gestiondocumental.transferencias
{
    public interface IServicioComentarioTrasnferencia
    {
        Task<string> Crear(ComentarioTransferencia comentariotransferencia);
        Task<List<ComentarioTransferencia>> Obtiener();
        Task<String> Actualizar(string id, ComentarioTransferencia comentariotransferencia);
        Task<string> Eliminar(string id, ComentarioTransferencia comentariotransferencia);
    }
}
