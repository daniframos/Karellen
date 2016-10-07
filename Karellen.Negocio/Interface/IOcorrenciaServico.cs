using Karellen.Negocio.Operacao;
using Karellen.Negocio.Util.DTO;
using System;
using System.Collections.Generic;

namespace Karellen.Negocio.Interface
{
    public interface IOcorrenciaServico
    {
        List<OcorrenciaDTO> BuscarTodasOcorrencias();
        OperacaoResultado SalvarNovaOcorrencia(OcorrenciaDTO ocorrencia, object idoperacao);
        int SalvarOperacao(string userAgent, string usuario, string browser, string ip, string local, Guid sessaoId, string entidade, string entidadeId);
    }
}
