using Karellen.Data.Interface.UnitOfWork;
using Karellen.Negocio.Interface;
using System;

namespace Karellen.Negocio.Servico
{
    public class AppServico: IAppServico
    {
        private IUnitOfWork _unitOfWork;

        public AppServico(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public int CalcularTotalDeOcorrencias()
        {
            throw new NotImplementedException();
        }
    }
}
