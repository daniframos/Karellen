using Karellen.Core.Dominio.Entidade;
using Karellen.Data.Contexto;
using Karellen.Data.Interface.Repositorio;

namespace Karellen.Data.Infraestrutura.Repositorio
{
    internal class RepositorioLog : Repositorio<Log>, IRepositorioLog
    {
        public RepositorioLog(KarellenContexto contexto) : base(contexto)
        {
        }
    }
}
