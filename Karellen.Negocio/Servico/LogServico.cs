using AutoMapper;
using Karellen.Core.Dominio.Entidade;
using Karellen.Data.Interface.UnitOfWork;
using Karellen.Negocio.Interface;
using Karellen.Negocio.Util.DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Karellen.Negocio.Servico
{
    public class LogServico: ILogServico
    {
        private readonly IUnitOfWork _unitOfWork;

        public LogServico(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IList<LogDTO> BuscarTodosLog()
        {
            var logs = _unitOfWork.RepositorioLog.BuscarTodos().OrderByDescending(l => l.Data).ToList();
            var resultado = Mapper.Map<List<Log>, List<LogDTO>>(logs);

            return resultado;
        }

        public LogDTO BuscarLog(int id)
        {
            var log = _unitOfWork.RepositorioLog.Buscar(l => l.Id == id).FirstOrDefault();
            var resultado = Mapper.Map<Log, LogDTO>(log);

            return resultado;
        }

        public int QuantidadeDeLog(DateTime dataInicio)
        {
            var logs = _unitOfWork.RepositorioLog.Buscar(l => l.Data > dataInicio);
            return logs.Count;
        }
    }
}
