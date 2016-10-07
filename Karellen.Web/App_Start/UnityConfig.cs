using Karellen.Data.Infraestrutura.UnitOfWork;
using Karellen.Data.Interface.UnitOfWork;
using Karellen.Web.Identity.Modelo;
using Karellen.Web.Identity.Servico;
using Karellen.Web.Identity.Store;
using Microsoft.AspNet.Identity;
using Microsoft.Practices.Unity;
using System;

namespace Karellen.Web.App_Start
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container = new Lazy<IUnityContainer>(() =>
        {
            var container = new UnityContainer();
            RegisterTypes(container);
            return container;
        });

        /// <summary>
        /// Gets the configured Unity container.
        /// </summary>
        public static IUnityContainer GetConfiguredContainer()
        {
            return container.Value;
        }
        #endregion

        /// <summary>Registers the type mappings with the Unity container.</summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>There is no need to register concrete types such as controllers or API controllers (unless you want to 
        /// change the defaults), as Unity allows resolving a concrete type even if it was not previously registered.</remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            container.RegisterType<IUnitOfWork, UnitOfWork>(new HierarchicalLifetimeManager(), new InjectionConstructor("KarellenConnectionString"));
            container.RegisterType<IIdentityMessageService, EmailIdentityServico>();
            container.RegisterType<IUserStore<UsuarioIdentity, int>, UsuarioIdentityStore>(new TransientLifetimeManager());
            container.RegisterType<IRoleStore<GrupoIdentity, int>, GrupoIdentityStore>(new TransientLifetimeManager());
            container.RegisterType<IQueryableRoleStore<GrupoIdentity, int>, GrupoIdentityStore>(new TransientLifetimeManager());
            container.RegisterTypes(
                AllClasses.FromLoadedAssemblies(),
                WithMappings.FromMatchingInterface,
                WithName.Default,
                WithLifetime.Transient);
        }
    }
}
