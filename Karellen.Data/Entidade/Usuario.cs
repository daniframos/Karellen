using System.Collections.Generic;

namespace Karellen.Data.Entidade
{
    public class Usuario
    {
        public virtual int Id { get; set; }
        public virtual string Nome { get; set; }
        public virtual string SobreNome { get; set; }
        public virtual string UserName { get; set; }
        public virtual string Email { get; set; }
        public virtual string SenhaHash
        {
            get { return _senhaHash; }
            set
            {
                if (value != null)
                {
                    _senhaHash = value;
                }
            }
        }

        #region Propriedades de navegação
        public virtual ICollection<LoginExterno> Logins
        {
            get
            {
                return _loginsExternos ?? (_loginsExternos = new List<LoginExterno>());
            }
            set { _loginsExternos = value; }
        }
        public virtual ICollection<Grupo> Grupos
        {
            get
            {
                return _grupos ?? (_grupos = new List<Grupo>());
            }
            set { _grupos = value; }
        }

        public virtual ICollection<Ocorrencia> Ocorrencias
        {
            get
            {
                return _ocorrencias ?? (_ocorrencias = new List<Ocorrencia>());
            }
            set { _ocorrencias = value; }
        }

        private ICollection<Ocorrencia> _ocorrencias;
        private ICollection<LoginExterno> _loginsExternos;
        private ICollection<Grupo> _grupos;
        private string _senhaHash;

        #endregion

        #region Nao Mapeado
        public string NomeCompleto => SobreNome == null ? Nome : $"{Nome} {SobreNome}";

        #endregion
    }
}
