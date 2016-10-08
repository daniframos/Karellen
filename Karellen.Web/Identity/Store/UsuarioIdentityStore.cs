using AutoMapper;
using Karellen.Data.Entidade;
using Karellen.Data.Interface.UnitOfWork;
using Karellen.Negocio.Mensagem;
using Karellen.Web.Identity.Modelo;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Karellen.Web.Identity.Store
{
    public class UsuarioIdentityStore : IUserLoginStore<UsuarioIdentity, int>,
                                IUserRoleStore<UsuarioIdentity, int>,
                                IUserPasswordStore<UsuarioIdentity, int>,
                                IUserEmailStore<UsuarioIdentity, int>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UsuarioIdentityStore(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task AddLoginAsync(UsuarioIdentity identityUsuario, UserLoginInfo login)
        {
            if (identityUsuario == null)
                throw new ArgumentNullException(nameof(identityUsuario));
            if (login == null)
                throw new ArgumentNullException(nameof(login));

            var usuario = _unitOfWork.RepositorioUsuario.BuscarPorId(identityUsuario.Id);
            if (usuario == null)
                throw new ArgumentException(Mensagem.MN011, nameof(identityUsuario));

            var l = new LoginExterno
            {
                LoginProvedor = login.LoginProvider,
                KeyProvedor = login.ProviderKey,
                UsuarioId = usuario.Id
            };
            usuario.Logins.Add(l);

            _unitOfWork.RepositorioUsuario.Atualizar(usuario);
            return _unitOfWork.SaveChangesAsync();
        }

        public Task AddToRoleAsync(UsuarioIdentity identityUsuario, string grupoNome)
        {
            if (identityUsuario == null)
                throw new ArgumentNullException(nameof(identityUsuario));
            if (string.IsNullOrWhiteSpace(grupoNome))
                throw new ArgumentNullException(nameof(grupoNome));

            var usuario = _unitOfWork.RepositorioUsuario.BuscarPorId(identityUsuario.Id);
            if (usuario == null)
                throw new ArgumentException(Mensagem.MN011, nameof(identityUsuario));

            var grupo = _unitOfWork.RepositorioGrupo.BuscarPorNome(grupoNome);
            if (grupo == null)
                throw new ArgumentException(Mensagem.MN011, nameof(grupo));

            usuario.Grupos.Add(grupo);
            _unitOfWork.RepositorioUsuario.Atualizar(usuario);

            return _unitOfWork.SaveChangesAsync();
        }

        public async Task CreateAsync(UsuarioIdentity usuarioIdentity)
        {
            if (usuarioIdentity == null)
                throw new ArgumentNullException(nameof(usuarioIdentity));

            var usuario = Mapper.Map<UsuarioIdentity, Usuario>(usuarioIdentity);

            _unitOfWork.RepositorioUsuario.Adicionar(usuario);
            await _unitOfWork.SaveChangesAsync();
            usuarioIdentity.Id = usuario.Id;
        }

        public Task DeleteAsync(UsuarioIdentity identityUsuario)
        {
            if (identityUsuario == null)
                throw new ArgumentNullException(nameof(identityUsuario));

            var usuario = Mapper.Map<UsuarioIdentity, Usuario>(identityUsuario);

            _unitOfWork.RepositorioUsuario.Atualizar(usuario);
            return _unitOfWork.SaveChangesAsync();
        }

        public void Dispose()
        {
            _unitOfWork.Dispose();
        }

        public Task<UsuarioIdentity> FindAsync(UserLoginInfo userLogin)
        {
            if (userLogin == null)
                throw new ArgumentNullException("login");

            var identityUsuario = default(UsuarioIdentity);

            var login = _unitOfWork.RepositorioLoginExterno.BuscarProviderKey(userLogin.LoginProvider, userLogin.ProviderKey);
            if (login != null)
                identityUsuario = Mapper.Map<Usuario, UsuarioIdentity>(login.Usuario);

            return Task.FromResult(identityUsuario);
        }

        public Task<UsuarioIdentity> FindByIdAsync(int userId)
        {
            var usuario = _unitOfWork.RepositorioUsuario.BuscarPorId(userId);
            var identityUsuario = Mapper.Map<Usuario, UsuarioIdentity>(usuario);
            return Task.FromResult(identityUsuario);
        }

        public Task<UsuarioIdentity> FindByNameAsync(string userName)
        {
            var usuario = _unitOfWork.RepositorioUsuario.BuscarPorUserName(userName);
            var identityUsuario = Mapper.Map<Usuario, UsuarioIdentity>(usuario);
            return Task.FromResult(identityUsuario);
        }

        public Task<IList<UserLoginInfo>> GetLoginsAsync(UsuarioIdentity identityUsuario)
        {
            if (identityUsuario == null)
                throw new ArgumentNullException(nameof(identityUsuario));

            var usuario = _unitOfWork.RepositorioUsuario.BuscarPorId(identityUsuario.Id);
            if (usuario == null)
                throw new ArgumentException(Mensagem.MN011, nameof(identityUsuario));

            return Task.FromResult<IList<UserLoginInfo>>(usuario.Logins.Select(x => new UserLoginInfo(x.LoginProvedor, x.KeyProvedor)).ToList());
        }

        public Task<string> GetPasswordHashAsync(UsuarioIdentity user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));
            return Task.FromResult(user.PasswordHash);
        }

        public Task<IList<string>> GetRolesAsync(UsuarioIdentity user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            var u = _unitOfWork.RepositorioUsuario.BuscarPorId(user.Id);
            if (u == null)
                throw new ArgumentException(Mensagem.MN011, nameof(user));

            return Task.FromResult<IList<string>>(u.Grupos.Select(x => x.Nome).ToList());
        }

        public Task<bool> HasPasswordAsync(UsuarioIdentity user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));
            return Task.FromResult(!string.IsNullOrWhiteSpace(user.PasswordHash));
        }

        public Task<bool> IsInRoleAsync(UsuarioIdentity user, string roleName)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));
            if (string.IsNullOrWhiteSpace(roleName))
                throw new ArgumentNullException(nameof(roleName));

            var u = _unitOfWork.RepositorioUsuario.BuscarPorId(user.Id);
            if (u == null)
                throw new ArgumentException(Mensagem.MN011, nameof(user));

            return Task.FromResult(u.Grupos.Any(x => x.Nome == roleName));
        }

        public Task RemoveFromRoleAsync(UsuarioIdentity user, string roleName)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));
            if (string.IsNullOrWhiteSpace(roleName))
                throw new ArgumentNullException(nameof(roleName));

            var u = _unitOfWork.RepositorioUsuario.BuscarPorId(user.Id);
            if (u == null)
                throw new ArgumentException(Mensagem.MN011, nameof(u));

            var r = u.Grupos.FirstOrDefault(x => x.Nome == roleName);
            u.Grupos.Remove(r);

            _unitOfWork.RepositorioUsuario.Atualizar(u);
            return _unitOfWork.SaveChangesAsync();
        }

        public Task RemoveLoginAsync(UsuarioIdentity user, UserLoginInfo login)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));
            if (login == null)
                throw new ArgumentNullException(nameof(login));

            var u = _unitOfWork.RepositorioUsuario.BuscarPorId(user.Id);
            if (u == null)
                throw new ArgumentException(Mensagem.MN011, nameof(user));

            var l = u.Logins.FirstOrDefault(x => x.LoginProvedor == login.LoginProvider && x.KeyProvedor == login.ProviderKey);
            u.Logins.Remove(l);

            _unitOfWork.RepositorioUsuario.Atualizar(u);
            return _unitOfWork.SaveChangesAsync();
        }

        public Task SetPasswordHashAsync(UsuarioIdentity user, string passwordHash)
        {
            user.PasswordHash = passwordHash;
            return Task.FromResult(0);
        }

        public Task UpdateAsync(UsuarioIdentity user)
        {
            if (user == null)
                throw new ArgumentException(nameof(user));

            var u = _unitOfWork.RepositorioUsuario.BuscarPorId(user.Id);
            if (u == null)
                throw new ArgumentException(Mensagem.MN011, nameof(user));

            popularUsuario(u, user);

            _unitOfWork.RepositorioUsuario.Atualizar(u);
            return _unitOfWork.SaveChangesAsync();
        }

        private void popularUsuario(Usuario user, UsuarioIdentity identityUser)
        {
            user.Id = identityUser.Id;
            user.Cidade = identityUser.Cidade;
            user.Nome = identityUser.Nome;
            user.UserName = identityUser.UserName;
            user.SenhaHash = identityUser.PasswordHash;
            user.Email = identityUser.Email;
            user.SobreNome = identityUser.Sobrenome;
        }

        public Task SetEmailAsync(UsuarioIdentity user, string email)
        {
            user.Email = email;
            return Task.FromResult(0);
        }

        public Task<string> GetEmailAsync(UsuarioIdentity user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));
            return Task.FromResult(user.Email);
        }

        public Task<bool> GetEmailConfirmedAsync(UsuarioIdentity user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));
            return Task.FromResult(true);
        }

        public Task SetEmailConfirmedAsync(UsuarioIdentity user, bool confirmed)
        {
            return Task.FromResult(0);
        }

        public Task<UsuarioIdentity> FindByEmailAsync(string email)
        {
            var usuario = _unitOfWork.RepositorioUsuario.BuscarPorEmail(email);
            var identityUsuario = Mapper.Map<Usuario, UsuarioIdentity>(usuario);
            return Task.FromResult(identityUsuario);
        }
    }
}