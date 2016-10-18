using AutoMapper;
using Karellen.Core.Dominio.Entidade;
using Karellen.Data.Entidade;
using Karellen.Data.Interface.UnitOfWork;
using Karellen.Negocio.Interface;
using Karellen.Negocio.Operacao;
using Karellen.Negocio.Util.DTO;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Karellen.Negocio.Servico
{
    public class OcorrenciaServico: IOcorrenciaServico
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly OperacaoResultado _resultado;

        public OcorrenciaServico(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _resultado = new OperacaoResultado();
        }

        public List<OcorrenciaDTO> BuscarTodasOcorrencias()
        {
            var o = _unitOfWork.RepositorioOcorrencia
                .BuscarTodos()
                .Where(oc => oc.DataResolucao == null)
                .OrderByDescending(oc => oc.DataAcontecimento).ToList();
            var resultado = Mapper.Map<List<Ocorrencia>, List<OcorrenciaDTO>>(o);
            return resultado;
        }

        public List<OcorrenciaDTO> BuscarTodasOcorrencias(int usuarioId)
        {
            var o = _unitOfWork.RepositorioOcorrencia
                .BuscarTodos()
                .Where(oc => oc.UsuarioId == usuarioId)
                .OrderByDescending(oc => oc.DataAcontecimento).ToList();
            var resultado = Mapper.Map<List<Ocorrencia>, List<OcorrenciaDTO>>(o);
            return resultado;
        }

        public OperacaoResultado SalvarNovaOcorrencia(OcorrenciaDTO ocorrencia, object idOperacao)
        {
            var o = Mapper.Map<OcorrenciaDTO, Ocorrencia>(ocorrencia);
            o.DataCriacao = DateTime.Now;
            o.Excluida = false;
            
            _unitOfWork.RepositorioOcorrencia.Adicionar(o);
            _unitOfWork.SaveChanges();

            var st = new StackTrace();
            var sf = st.GetFrame(0);
            var methodName = sf.GetMethod().Name;

            var logOperacao = _unitOfWork.RepositorioLog.BuscarPorId(idOperacao);
            logOperacao.EntidadeId = Convert.ToString(o.Id);
            logOperacao.Acao = methodName;
            logOperacao.EntidadeNome = nameof(Ocorrencia);

            _unitOfWork.RepositorioLog.Atualizar(logOperacao);
            _unitOfWork.SaveChanges();
            return _resultado;
        }

        public int SalvarOperacao(string userAgent, string usuario, string browser, string ip, string local, Guid sessaoId,
            string entidade, string entidadeId)
        {
            var log = new Log()
            {
                Browser = browser,
                UserAgent = userAgent,
                Data = DateTime.Now,
                EntidadeNome = entidade,
                EntidadeId = entidadeId,
                Ip = ip,
                Local = local,
                SessaoId = sessaoId
            };

            _unitOfWork.RepositorioLog.Adicionar(log);
            _unitOfWork.SaveChanges();

            return log.Id;
        }

        public OcorrenciaDTO BuscarOcorrencia(int id)
        {
            var ocorrencia = _unitOfWork.RepositorioOcorrencia.BuscarPorId(id);
            ocorrencia.TipoOcorrencias =
                _unitOfWork.RepositorioTipoOcorrencia.Buscar(t => t.OcorrenciaId == ocorrencia.Id);
            var resultado = Mapper.Map<Ocorrencia, OcorrenciaDTO>(ocorrencia);

            return resultado;
        }

        public void SolucionarOcorrencia(int id)
        {
            var ocorrencia = _unitOfWork.RepositorioOcorrencia.BuscarPorId(id);
            ocorrencia.DataResolucao = DateTime.Now;

            _unitOfWork.SaveChanges();
        }

        public AutorDTO BuscarAutorOcorrencia(int id)
        {
            var ocorrencia = _unitOfWork.RepositorioOcorrencia.BuscarPorId(id);
            if (ocorrencia.UsuarioId == null)
                return null;

            var usuario = _unitOfWork.RepositorioUsuario.BuscarPorId(ocorrencia.UsuarioId);
            return new AutorDTO()
            {
                Id = ocorrencia.UsuarioId,
                NomeCompleto = usuario.NomeCompleto
            };
        }
    }
}
