using api.comunes.modelos.reflectores;
using api.comunes.modelos.servicios;
using pika.modelo.organizacion;
using pika.modelo.organizacion.Contacto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pika.servicios.organizacion.contacto.redsocial;

public interface IServicioRedSocial : IServicioEntidadGenerica<RedSocial, RedSocialInsertar, RedSocialActualizar, RedSocialDespliegue, string>
{
}

public interface IServicioTipoRedSocial : IServicioCatalogoAPI
{

}
