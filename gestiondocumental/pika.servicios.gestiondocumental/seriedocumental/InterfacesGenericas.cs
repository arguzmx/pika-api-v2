using api.comunes.modelos.reflectores;
using api.comunes.modelos.servicios;
using pika.modelo.gestiondocumental.SerieDocumental;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pika.servicios.gestiondocumental.seriedocumental
{
    public interface IServicioSerieDocumental : IServicioEntidadGenerica<SerieDocumental, SerieDocumentalInsertar, SerieDocumentalActualizar, SerieDocumentalDespliegue, string>
    {

    }

    public interface IServicioTipoDisposicionDocumental : IServicioCatalogoAPI
    {

    }

    public interface IServicioTipoValoracionDocumental : IServicioCatalogoAPI 
    {
        
    }

}
