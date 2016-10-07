using AutoMapper;
using Karellen.Core.Dominio.Entidade;
using Karellen.Data.Interface.UnitOfWork;
using Karellen.Negocio.Interface;
using Karellen.Negocio.Util.DTO;
using System.Collections.Generic;

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
            var logs = _unitOfWork.RepositorioLog.BuscarTodos();
            var resultado = Mapper.Map<List<Log>, List<LogDTO>>(logs);

            return resultado;
        }
    }
}
