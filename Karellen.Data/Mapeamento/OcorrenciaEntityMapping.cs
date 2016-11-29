using Karellen.Data.Entidade;
using System.Data.Entity.ModelConfiguration;

namespace Karellen.Data.Mapeamento
{
    public class OcorrenciaEntityMapping : EntityTypeConfiguration<Ocorrencia>
    {
        public OcorrenciaEntityMapping()
        {
            ToTable("TBOcorrencia");

            Property(o => o.UsuarioId)
                .HasColumnName("UsuarioId");

            Property(o => o.Titulo)
                .IsRequired();

            Property(o => o.Latitude)
                .IsRequired();

            Property(o => o.Longitude)
                .IsRequired();
        }
    }
}
