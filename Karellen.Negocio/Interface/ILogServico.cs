using Karellen.Negocio.Util.DTO;
using System;
using System.Collections.Generic;

namespace Karellen.Negocio.Interface
{
    public interface ILogServico
    {
        IList<LogDTO> BuscarTodosLog();
        LogDTO BuscarLog(int id);
        int QuantidadeDeLog(DateTime dataInicio);
    }
}