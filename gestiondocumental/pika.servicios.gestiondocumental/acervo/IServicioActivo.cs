using api.comunes.modelos.servicios;
using Microsoft.AspNetCore.Mvc;
using pika.modelo.gestiondocumental;
using pika.modelo.gestiondocumental.Acervo;
using System.Threading;

namespace pika.servicios.gestiondocumental.acervo;

public interface IServicioActivo : IServicioEntidadGenerica<Activo, ActivoInsertar, ActivoActualizar, string>
{
    // NAda aqui
}
