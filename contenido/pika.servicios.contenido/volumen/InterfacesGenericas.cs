using api.comunes.modelos.reflectores;
using api.comunes.modelos.servicios;
using pika.modelo.contenido;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pika.servicios.contenido.volumen;


/// <summary>
/// Interface servicio volumen
/// </summary>
public interface IServicioVolumen : IServicioEntidadGenerica<Volumen, VolumenInsertar, VolumenActualizar, VolumenDespliegue, string>
{
}

public interface IServicioTipoGestorES : IServicioCatalogoAPI
{ }

