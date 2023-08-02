using Microsoft.AspNetCore.Mvc;
using pika.modelo.gestiondocumental;
using System.Threading;

namespace pika.servicios.gestiondocumental.acervo;

public interface IServicioActivo
{
    Task<string> Crear(Activo activo);
    Task<List<Activo>> Obtiener();
    Task<String> Actualizar(string id, Activo activo);
    Task<string> Eliminar(string id, Activo activo);


}
