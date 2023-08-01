using Microsoft.AspNetCore.Mvc;
using pika.modelo.gestiondocumental;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pika.servicios.gestiondocumental.archivos
{
    public interface IServicioUnidadAdministrativaArchivo
    {
        Task<string> Crear(UnidadAdministrativaArchivo unidadadministrativaarchivo);
        Task<ActionResult<List<UnidadAdministrativaArchivo>>> Obtiener();
        Task<String> Actualizar(string id, UnidadAdministrativaArchivo unidadadministrativaarchivo);
        Task<string> Eliminar(string id, UnidadAdministrativaArchivo unidadadministrativaarchivo);
    }
}
