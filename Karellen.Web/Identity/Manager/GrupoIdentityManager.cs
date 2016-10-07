using Karellen.Web.Identity.Modelo;
using Microsoft.AspNet.Identity;

namespace Karellen.Web.Identity.Manager
{
    public class GrupoIdentityManager : RoleManager<GrupoIdentity, int>
    {
        public GrupoIdentityManager(IRoleStore<GrupoIdentity, int> store) : base(store)
        {
            
        }
    }
}