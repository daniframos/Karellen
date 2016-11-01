using Karellen.Negocio.Operacao;
using Karellen.Negocio.Util.DTO;
using System;
using System.Collections.Generic;

namespace Karellen.Negocio.Interface
{
    public interface IOcorrenciaServico
    {
        List<OcorrenciaDTO> BuscarTodasOcorrencias();
        List<OcorrenciaDTO> BuscarTodasOcorrencias(int usuarioId);
        OperacaoResultado SalvarNovaOcorrencia(OcorrenciaDTO ocorrencia, object idoperacao);
        int SalvarOperacao(string userAgent, string usuario, string browser, string ip, string local, Guid sessaoId, string entidade, string entidadeId);
        OcorrenciaDTO BuscarOcorrencia(int id);
        void SolucionarOcorrencia(int id, string solucao);
        AutorDTO BuscarAutorOcorrencia(int id);
        void AtualizarOcorrencia(OcorrenciaDTO ocorrencia, object idOperacaoLog);
        void ExcluirOcorrencia(int id);
        EstatisticaDTO BuscarEstatisticas();
    }
}
