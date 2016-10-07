using AutoMapper;
using Karellen.Data.Entidade;
using Karellen.Data.Interface.UnitOfWork;
using Karellen.Web.Identity.Modelo;
using Microsoft.AspNet.Identity;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Karellen.Web.Identity.Store
{
    public class GrupoIdentityStore : IQueryableRoleStore<GrupoIdentity, int>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GrupoIdentityStore(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Dispose()
        {
            _unitOfWork.Dispose();
        }

        public Task CreateAsync(GrupoIdentity grupo)
        {
            if (grupo == null)
                throw new ArgumentNullException(nameof(grupo));

            var g = Mapper.Map<GrupoIdentity, Grupo>(grupo);

            _unitOfWork.RepositorioGrupo.Adicionar(g);
            return _unitOfWork.SaveChangesAsync();
        }

        public Task UpdateAsync(GrupoIdentity grupo)
        {
            if (grupo == null)
                throw new ArgumentNullException(nameof(grupo));

            var g = Mapper.Map<GrupoIdentity, Grupo>(grupo);

            _unitOfWork.RepositorioGrupo.Atualizar(g);
            return _unitOfWork.SaveChangesAsync();
        }

        public Task DeleteAsync(GrupoIdentity grupo)
        {
            if (grupo == null)
                throw new ArgumentNullException(nameof(grupo));

            var g = Mapper.Map<GrupoIdentity, Grupo>(grupo);

            _unitOfWork.RepositorioGrupo.Remover(g);
            return _unitOfWork.SaveChangesAsync();
        }

        public Task<GrupoIdentity> FindByIdAsync(int roleId)
        {
            var grupo = _unitOfWork.RepositorioGrupo.BuscarPorId(roleId);
            return Task.FromResult(Mapper.Map<Grupo, GrupoIdentity>(grupo));
        }

        public Task<GrupoIdentity> FindByNameAsync(string roleName)
        {
            var grupo = _unitOfWork.RepositorioGrupo.BuscarPorNome(roleName);
            return Task.FromResult(Mapper.Map<Grupo, GrupoIdentity>(grupo));
        }

        public IQueryable<GrupoIdentity> Roles
        {
            get
            {
                return _unitOfWork.RepositorioGrupo
                    .BuscarTodos()
                    .Select(x =>
                    {
                        var g = Mapper.Map<Grupo, GrupoIdentity>(x);
                        return g;
                    })
                    .AsQueryable();
            }
        }
    }
}