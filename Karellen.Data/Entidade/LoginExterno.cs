namespace Karellen.Data.Entidade
{
    public class LoginExterno
    {
        public virtual int UsuarioId { get; set; }
        public virtual string LoginProvedor { get; set; }
        public virtual string KeyProvedor { get; set; }

        #region Propriedades de navegação
        private Usuario _usuario;
        public virtual Usuario Usuario
        {
            get { return _usuario; }
            set
            {
                if (value != null)
                {
                    _usuario = value;
                    UsuarioId = value.Id;
                }
            }
        }
        #endregion
    }
}
