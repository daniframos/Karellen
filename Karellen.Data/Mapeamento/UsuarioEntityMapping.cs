using Karellen.Data.Entidade;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Karellen.Data.Mapeamento
{
    internal class UsuarioEntityMapping : EntityTypeConfiguration<Usuario>
    {
        internal UsuarioEntityMapping()
        {
            ToTable("TBUsuario");

            Ignore(u => u.NomeCompleto);

            HasKey(x => x.Id)
                .Property(x => x.Id)
                .HasColumnName("Id")
                .HasColumnType("int")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .IsRequired();

            Property(u => u.Nome)
                .HasColumnName("Nome")
                .HasMaxLength(50)
                .IsRequired();

            Property(u => u.SobreNome)
                .HasColumnName("Sobrenome")
                .HasMaxLength(100);

            Property(u => u.Email)
                .HasColumnName("Email")
                .HasMaxLength(50)
                .IsRequired();

            Property(u => u.UserName)
                .HasColumnName("Username")
                .IsRequired();

            Property(u => u.SenhaHash)
                .HasColumnName("Senha");

            HasMany(u => u.Ocorrencias);
        }
    }
}
