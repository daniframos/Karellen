using Karellen.Data.Entidade;
using System.Data.Entity.ModelConfiguration;

namespace Karellen.Data.Mapeamento
{
    public class GrupoEntityMapping : EntityTypeConfiguration<Grupo>
    {
        public GrupoEntityMapping()
        {
            ToTable("TBGrupo");

            HasKey(x => x.Id)
                .Property(x => x.Id)
                .IsRequired();

            Property(x => x.Nome)
                .HasMaxLength(256)
                .IsRequired();

            HasMany(x => x.Usuarios)
                .WithMany(x => x.Grupos)
                .Map(x =>
                {
                    x.ToTable("TBUsuarioGrupo");
                    x.MapLeftKey("GrupoId");
                    x.MapRightKey("UsuarioId");
                });
        }
    }
}
