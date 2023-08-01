using Microsoft.AspNetCore.Mvc;
using pika.modelo.gestiondocumental;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pika.servicios.gestiondocumental.topologia
{
    public interface IServicioZonaAlmacen
    {
        Task<string> Crear(ZonaAlmacen zonaalmacen);
        Task<ActionResult<List<ZonaAlmacen>>> Obtiener();
        Task<String> Actualizar(string id, ZonaAlmacen zonaalmacen);
        Task<string> Eliminar(string id, ZonaAlmacen zonaalmacen);
    }
}
