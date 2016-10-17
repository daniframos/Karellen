using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Karellen.Data.Entidade;

namespace Karellen.Data.Mapeamento
{
    public class TipoOcorrenciaEntityMapping: EntityTypeConfiguration<TipoOcorrencia>
    {
        public TipoOcorrenciaEntityMapping()
        {
            ToTable("TBTipoOcorrencia");
            HasKey(x => new { x.OcorrenciaId, x.Tipo });

            Property(x => x.OcorrenciaId)
                .HasColumnName("OcorrenciaId");
        }
    }
}
