using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Karellen.Data.Contexto;
using Karellen.Data.Entidade;
using Karellen.Data.Interface.Repositorio;
using Karellen.Data.Interface.UnitOfWork;

namespace Karellen.Data.Infraestrutura.Repositorio
{
    internal class RepositorioTipoOcorrencia : Repositorio<TipoOcorrencia>, IRepositorioTipoOcorrencia
    {
        public RepositorioTipoOcorrencia(KarellenContexto contexto) : base(contexto)
        {
        }
    }
}
