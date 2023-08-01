using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using pika.modelo.gestiondocumental;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pika.servicios.gestiondocumental.dbcontext.configuraciones
{
    public class ConfiguracionEstadoTransferencia : IEntityTypeConfiguration<EstadoTransferencia>
    {
        public void Configure(EntityTypeBuilder<EstadoTransferencia> builder)
        {
            throw new NotImplementedException();
        }
    }
}
