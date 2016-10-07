using Karellen.Core.Dominio.Entidade;
using System.Data.Entity.ModelConfiguration;

namespace Karellen.Data.Mapeamento
{
    public class LogEntityMapping: EntityTypeConfiguration<Log>
    {
        public LogEntityMapping()
        {
            ToTable("TBLog");
        }
    }
}
