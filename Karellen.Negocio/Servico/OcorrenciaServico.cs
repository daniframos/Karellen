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
using Karellen.Negocio.Util.Extensao;

namespace Karellen.Negocio.Servico
{
    public class OcorrenciaServico: IOcorrenciaServico
    {
        private readonly string _masculino = "masculino";
        private readonly IUnitOfWork _unitOfWork;
        private readonly OperacaoResultado _resultado;
        private readonly string _feminino;

        public OcorrenciaServico(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _resultado = new OperacaoResultado();
        }

        public List<OcorrenciaDTO> BuscarTodasOcorrencias()
        {
            var o = _unitOfWork.RepositorioOcorrencia
                .BuscarTodos()
                .Where(oc => oc.DataResolucao == null && oc.Excluida == false)
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

        public void SolucionarOcorrencia(int id, string solucao)
        {
            var ocorrencia = _unitOfWork.RepositorioOcorrencia.BuscarPorId(id);
            ocorrencia.DataResolucao = DateTime.Now;
            ocorrencia.Resolucao = solucao;

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

        public void AtualizarOcorrencia(OcorrenciaDTO ocorrencia, object idOperacaoLog)
        {
            var tipos = _unitOfWork.RepositorioTipoOcorrencia.Buscar(t => t.OcorrenciaId == ocorrencia.Id);
            var ocorrenciaOriginal = _unitOfWork.RepositorioOcorrencia.BuscarPorId(ocorrencia.Id);
            foreach (var tipoOcorrencia in tipos)
            {
                _unitOfWork.RepositorioTipoOcorrencia.Remover(tipoOcorrencia);
            }
            _unitOfWork.RepositorioOcorrencia.Remover(ocorrenciaOriginal);
            _unitOfWork.SaveChanges();

            var o = Mapper.Map<OcorrenciaDTO, Ocorrencia>(ocorrencia);
            o.DataAcontecimento = ocorrenciaOriginal.DataAcontecimento;
            o.DataCriacao = ocorrenciaOriginal.DataCriacao;
            o.Id = 0;
            o.Excluida = false;
            

            _unitOfWork.RepositorioOcorrencia.Adicionar(o);
            _unitOfWork.SaveChanges();

            var st = new StackTrace();
            var sf = st.GetFrame(0);
            var methodName = sf.GetMethod().Name;

            var logOperacao = _unitOfWork.RepositorioLog.BuscarPorId(idOperacaoLog);
            logOperacao.EntidadeId = Convert.ToString(o.Id);
            logOperacao.Acao = methodName;
            logOperacao.EntidadeNome = nameof(Ocorrencia);

            _unitOfWork.RepositorioLog.Atualizar(logOperacao);
            _unitOfWork.SaveChanges();
        }

        public void ExcluirOcorrencia(int id)
        {
            var o = _unitOfWork.RepositorioOcorrencia.BuscarPorId(id);
            o.Excluida = true;

            _unitOfWork.RepositorioOcorrencia.Atualizar(o);
            _unitOfWork.SaveChanges();
        }

        public EstatisticaDTO BuscarEstatisticas()
        {
            var r = new EstatisticaDTO
            {
                QuantidadeOcorrencias = BuscarTodasOcorrenciasJaCadastradas(),
                OcorrenciasUltimos6Meses = BuscarOcorrenciasRecentes(6),
                QuantidadeOcorrenciasAnonimas = BuscarOcorrenciaAnonimas(),
                QuantidadeOcorrenciasNaoAnonimas = BuscarOcorrenciasNaoAnonimas(),
                QuantidadeOcorrenciasSexoFeminino = BuscarOCorrenciasSexoFeminino(),
                QuantidadeOcorrenciasSexoMasculino = BuscarOcorrenciasSexoMasculino()
            };

            return r;
        }

        private int BuscarTodasOcorrenciasJaCadastradas()
        {
            return _unitOfWork.RepositorioOcorrencia.BuscarTodos().Count;
        }

        private int BuscarOcorrenciasSexoMasculino()
        {
            var c = (from o in _unitOfWork.RepositorioOcorrencia.BuscarTodos()
                     group o.SexoVitima by o.SexoVitima into ocorrenciaGroup
                     select new
                     {
                         Sexo = ocorrenciaGroup.Key == 0 ? _masculino : _feminino,
                         Total = ocorrenciaGroup.Count()
                     }).ToList();

            var resultado = c.FirstOrDefault(o => o.Sexo == _masculino);
            return resultado == null ? 0 : resultado.Total;
        }

        private int BuscarOCorrenciasSexoFeminino()
        {
            var c = (from o in _unitOfWork.RepositorioOcorrencia.BuscarTodos()
                     group o.SexoVitima by o.SexoVitima into ocorrenciaGroup
                     select new
                     {
                         Sexo = ocorrenciaGroup.Key == 0 ? _masculino : _feminino,
                         Total = ocorrenciaGroup.Count()
                     }).ToList();


            var resultado = c.FirstOrDefault(o => o.Sexo == _feminino);
            return resultado == null ? 0 : resultado.Total;
        }

        private int BuscarOcorrenciaAnonimas()
        {
            var r = from o in _unitOfWork.RepositorioOcorrencia.BuscarTodos()
                    group o by o.UsuarioId.HasValue into ocorrenciaGroup
                    select new
                    {
                        Anonima = !ocorrenciaGroup.Key,
                        Total = ocorrenciaGroup.Count()
                    };

            var resultado = r.FirstOrDefault(o => o.Anonima);
            return resultado == null ? 0 : resultado.Total;
        }

        private int BuscarOcorrenciasNaoAnonimas()
        {
            var r = from o in _unitOfWork.RepositorioOcorrencia.BuscarTodos()
                    group o by o.UsuarioId.HasValue into ocorrenciaGroup
                    select new
                    {
                        Anonima = !ocorrenciaGroup.Key,
                        Total = ocorrenciaGroup.Count()
                    };

            var resultado = r.FirstOrDefault(o => o.Anonima == false);
            return resultado == null ? 0 : resultado.Total;
        }

        private ICollection<OcorrenciaMensalDTO> BuscarOcorrenciasRecentes(int meses)
        {
            var ocorrenciasRecentes = _unitOfWork.RepositorioOcorrencia.Buscar(o => o.DataAcontecimento > DateTime.UtcNow.AddMonths(-6));

            var grupoOcorrencias = from o in ocorrenciasRecentes
                                   group o by new { o.DataAcontecimento.Month, o.DataAcontecimento.Year } into oGroup
                                   select new
                                   {
                                       Data = new DateTime(oGroup.Key.Year, oGroup.Key.Month, DateTime.Now.Day),
                                       Ocorrencias = oGroup.ToList()
                                   };

            var ultimosMeses = new List<DateTime>();
            for (int i = 0; i < meses; i++)
            {
                ultimosMeses.Add(new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day).AddMonths(-i));
            }

            var resultado = (from u in ultimosMeses
                      join o in grupoOcorrencias on u equals o.Data into ocorrenciaGroup
                      from o in ocorrenciaGroup.DefaultIfEmpty()
                      select new OcorrenciaMensalDTO()
                      {
                          Mes = u.ToString("MMMM/yy").ToPrimeiraLetraUpper(),
                          Quantidade = o == null ? 0 : o.Ocorrencias.Count()
                      }).ToList();

            return resultado;
        }
    }
}
