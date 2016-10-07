using System;

namespace Karellen.Negocio.Operacao
{
    public class OperacaoResultado
    {
        private bool _sucesso;

        public bool Sucesso
        {
            get
            {
                return string.IsNullOrEmpty(Mensagem) && Exception == null && InnerException == null;
            }
            set { _sucesso = value; }
        }

        public string Mensagem { get; private set; }
        public Exception Exception { get; private set; }
        public Exception InnerException { get; private set; }
    }
}
