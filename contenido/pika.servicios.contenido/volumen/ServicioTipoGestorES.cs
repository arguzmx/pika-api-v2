using api.comunes.modelos.modelos;
using api.comunes.modelos.reflectores;
using api.comunes.modelos.respuestas;
using api.comunes.modelos.servicios;
using Microsoft.Extensions.Logging;
using pika.modelo.contenido;
using pika.servicios.contenido.dbcontext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pika.servicios.contenido.volumen
{
    [ServicioCatalogoEntidadAPI(typeof(TipoGestorES))]
    public class ServicioTipoGestorES : ServicioCatalogoGenericoBase, IServicioCatalogoAPI, IServicioTipoGestorES
    {

        public ServicioTipoGestorES(ILogger<ServicioTipoGestorES> logger, DbContextContenido context) : base(context, context.TipoGestorES, logger)
        {
        }

        public bool RequiereAutenticacion => true;

        public string IdiomaDefault => "es-MX";

        public List<ElementoCatalogo> ElementosDefault()
        {
            return new List<ElementoCatalogo>()
            {

            };
        }

        #region Override

        private DbContextContenido DB { get { return (DbContextContenido)_db; } }

        public override async Task<ResultadoValidacion> ValidarEliminacion(string id, ElementoCatalogo original)
        {
            ResultadoValidacion resultado = new();

            resultado.Valido = true;
            // Verifica que el Id no esté en uso en la tabla de Volumenes
            if (DB.Volumenes.Any(
                a => a.TipoGestorESId == id
                && a.DominioId == _contextoUsuario.DominioId
                && a.UOrgId == _contextoUsuario.UOrgId))
            {
                resultado.Valido = false;
            }

            return resultado;
        }

        #endregion

    }
}
