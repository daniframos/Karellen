using Karellen.Core.Dominio.Entidade;
using System.Collections.Generic;

namespace Karellen.Data.Entidade
{
    public class Grupo
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        #region Propriedade de navegação
        private ICollection<Usuario> _usuarios;
        public ICollection<Usuario> Usuarios
        {
            get { return _usuarios ?? (_usuarios = new List<Usuario>()); }
            set { _usuarios = value; }
        }
        #endregion
    }
}
