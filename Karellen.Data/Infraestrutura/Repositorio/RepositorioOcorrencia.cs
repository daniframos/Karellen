using Karellen.Data.Contexto;
using Karellen.Data.Entidade;
using Karellen.Data.Interface.Repositorio;

namespace Karellen.Data.Infraestrutura.Repositorio
{
    internal class RepositorioOcorrencia: Repositorio<Ocorrencia>, IRepositorioOcorrencia
    {
        public RepositorioOcorrencia(KarellenContexto contexto) : base(contexto)
        {
        }
    }
}
