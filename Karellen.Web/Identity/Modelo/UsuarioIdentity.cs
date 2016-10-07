using Microsoft.AspNet.Identity;

namespace Karellen.Web.Identity.Modelo
{
    public class UsuarioIdentity: IUser<int>
    {
        public virtual int Id { get; set; }
        public virtual string Nome { get; set; }
        public virtual string Sobrenome { get; set; }
        public virtual string UserName { get; set; }
        public virtual string PasswordHash { get; set; }
        public virtual string Email { get; set; }
    }
}