using Karellen.Core.Dominio.Entidade;
using Karellen.Data.Entidade;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Karellen.Data.Contexto
{
    public class KarellenContexto : DbContext
    {
        public virtual IDbSet<Usuario> Usuarios { get; set; }
        public virtual IDbSet<Grupo> Grupos { get; set; }
        public virtual IDbSet<LoginExterno> LoginsExternos { get; set; }
        public virtual IDbSet<Ocorrencia> Ocorrencias { get; set; }
        public virtual IDbSet<Log> Logs { get; set; }
        public virtual IDbSet<TipoOcorrencia> TipoOcorrencias { get; set; }

        public KarellenContexto() : base("KarellenConnectionString")
        {

        }

        public KarellenContexto(string nomeOrConnectionString) : base(nomeOrConnectionString)
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Configurations.AddFromAssembly(typeof(KarellenContexto).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
