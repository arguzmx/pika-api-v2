using Microsoft.AspNetCore.Mvc;
using pika.modelo.gestiondocumental;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pika.servicios.gestiondocumental.acervo
{
    public interface IServicioAmpliacion
    {
        Task<string> Crear(Ampliacion ampliacion);
        Task<List<Ampliacion>> Obtiener();
        Task<String> Actualizar(string id, Ampliacion ampliacion);
        Task<string> Eliminar(string id, Ampliacion ampliacion);
    }
}
