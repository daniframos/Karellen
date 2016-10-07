using Karellen.Negocio.Util.DTO;
using System.Collections.Generic;

namespace Karellen.Negocio.Interface
{
    public interface ILogServico
    {
        IList<LogDTO> BuscarTodosLog();
    }
}