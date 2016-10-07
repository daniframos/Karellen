using Karellen.Data.Entidade;
using System.Data.Entity.ModelConfiguration;

namespace Karellen.Data.Mapeamento
{
    public class LoginExternoEntityMapping: EntityTypeConfiguration<LoginExterno>
    {
        public LoginExternoEntityMapping()
        {
            ToTable("TBLoginExterno");

            HasKey(x => new { x.LoginProvedor, x.KeyProvedor, x.UsuarioId });

            Property(x => x.LoginProvedor)
                .HasMaxLength(128)
                .IsRequired();

            Property(x => x.KeyProvedor)
                .HasMaxLength(128)
                .IsRequired();

            Property(x => x.UsuarioId)
                .HasColumnName("UsuarioId")
                .IsRequired();

            HasRequired(x => x.Usuario)
                .WithMany(x => x.Logins)
                .HasForeignKey(x => x.UsuarioId);
        }
    }
}
