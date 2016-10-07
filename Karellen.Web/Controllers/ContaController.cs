using Karellen.Negocio.Mensagem;
using Karellen.Negocio.Mensagem.Enum;
using Karellen.Negocio.Util.Extensao;
using Karellen.Web.Identity.Manager;
using Karellen.Web.Identity.Modelo;
using Karellen.Web.Models.Conta;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Karellen.Web.Controllers
{
    [Authorize]
    public class ContaController : BaseController
    {
        private readonly UsuarioIdentityManager _userManager;

        public ContaController(UsuarioIdentityManager userManager)
        {
            _userManager = userManager;
        }

        [AllowAnonymous]
        public ActionResult Login(EnumMensagem? mensagem, string returnUrl)
        {
            if (mensagem != null)
                ViewBag.Mensagem = mensagem.GetDescricao();

            ViewBag.ReturnUrl = returnUrl;
            return View("login");
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginVM model, string returnUrl)
        {
            if (!ModelState.IsValid) return View(model);
            if (User.Identity.IsAuthenticated) return RedirectToAction("index", "app");

            var usuarioIdentity = await _userManager.FindByEmailAsync(model.Email);
            if (usuarioIdentity != null)
                usuarioIdentity = await _userManager.FindAsync(usuarioIdentity.UserName, model.Senha);
            if (usuarioIdentity != null)
            {
                await SignInAsync(usuarioIdentity, model.Lembrar);
                return RedirectToLocal(returnUrl);
            }

            ModelState.AddModelError("", Mensagem.MN005);

            return View(model);
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Registrar(EnumMensagem? mensagem)
        {
            if (mensagem != null)
                ViewBag.Mensagem = mensagem.GetDescricao();

            return View("Registrar");
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Registrar(RegistrarVM model)
        {
            if (ModelState.IsValid)
            {
                var usuario = new UsuarioIdentity()
                {
                    Email = model.Email,
                    Nome = model.Nome,
                    Sobrenome = model.SobreNome,
                    UserName = GerarUserNameUsuario(model.Nome, model.SobreNome)
                };
                var u = await _userManager.FindByEmailAsync(usuario.Email);
                if (u != null)
                {
                    ModelState.AddModelError("email", Mensagem.MN018);
                    return View("Registrar");
                }
                var result = await _userManager.CreateAsync(usuario, model.Senha);
                if (!result.Succeeded)
                {
                    ModelState.AddModelError("", result.Errors.Aggregate((a, b) => a + Environment.NewLine + b));
                    return View("registrar");
                }

                var mensagem = GerarMensagemEmail(usuario.Nome);
                await _userManager.SendEmailAsync(usuario.Id, Mensagem.MN015, mensagem);

                return RedirectToAction("Login", "Conta", new { mensagem = EnumMensagem.ContaCriada });
            }

            return View("Registrar");
        }

        private string GerarMensagemEmail(string nomeRemetente)
        {
            var arquivo = System.IO.File
                                   .ReadAllText(HttpContext.Server.MapPath("~/App_Data/email.html"));
            var mensagem = arquivo.Replace("{NOME}", nomeRemetente);
            mensagem = mensagem.Replace("{MENSAGEM}", Mensagem.MN016);
            mensagem = mensagem.Replace("{URL}", Url.Action("Login", "Conta", new { }, Request.Url.Scheme));

            return mensagem;
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult ExternalLogin(string provider, string returnUrl)
        {

            ControllerContext.HttpContext.Session.RemoveAll();

            // Request a redirect to the external login provider
            return new ChallengeResult(provider, Url.Action("ExternalLoginCallback", "Conta", new { ReturnUrl = returnUrl }));
        }

        [AllowAnonymous]
        public async Task<ActionResult> ExternalLoginCallback(string returnUrl)
        {
            var loginInfo = await AuthenticationManager.GetExternalLoginInfoAsync();
            if (loginInfo?.Email == null)
            {
                ModelState.AddModelError("email", EnumMensagem.Erro.GetDescricao());
                return View("Registrar");
            }

            var user = await _userManager.FindAsync(loginInfo.Login);
            if (user != null)
            {
                await SignInAsync(user, isPersistent: false);
                return RedirectToLocal(returnUrl);
            }

            var userIdentity = GerarIdentidadeUsuario(loginInfo);

            user = _userManager.FindByEmail(loginInfo.Email);
            if (user != null)
            {
                ModelState.AddModelError("email", Mensagem.MN010);
                return View("Registrar");
            }
            // Criar a conta
            var result = await _userManager.CreateAsync(userIdentity);
            if (!result.Succeeded)
            {
                ModelState.AddModelError("email", EnumMensagem.Erro.GetDescricao());
            }
                
            // Adicionar login
            result = await _userManager.AddLoginAsync(userIdentity.Id, loginInfo.Login);
            if (result.Succeeded)
            {
                await SignInAsync(userIdentity, isPersistent: false);
                return RedirectToLocal(returnUrl);
            }
            return View("Registrar");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            AuthenticationManager.SignOut();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult Gerenciar(EnumMensagem? mensagem)
        {
            if (mensagem != null)
                ViewBag.Mensagem = mensagem.GetDescricao();

            return View("gerenciar");
        }

        [HttpPost]
        public ActionResult Gerenciar()
        {
            return RedirectToAction("gerenciar", new {mensagem = EnumMensagem.Alterado });
        }

        [HttpGet]
        public ActionResult Ocorrencias()
        {
            return View("ocorrencias");
        }


        #region Helpers
        // Used for XSRF protection when adding external logins
        private const string XsrfKey = "XsrfId";

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        private async Task SignInAsync(UsuarioIdentity user, bool isPersistent)
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ExternalCookie);
            var identity = await _userManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
            AuthenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = isPersistent }, identity);
        }

        private bool HasPassword()
        {
            var user = _userManager.FindById(Convert.ToInt32(User.Identity.GetUserId()));
            if (user != null)
            {
                return user.PasswordHash != null;
            }
            return false;
        }



        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
                return Redirect(returnUrl);
            else
                return RedirectToAction("index", "app");
        }

        private class ChallengeResult : HttpUnauthorizedResult
        {
            public ChallengeResult(string provider, string redirectUri) : this(provider, redirectUri, null)
            {
            }

            public ChallengeResult(string provider, string redirectUri, string userId)
            {
                LoginProvider = provider;
                RedirectUri = redirectUri;
                UserId = userId;
            }

            public string LoginProvider { get; set; }
            public string RedirectUri { get; set; }
            public string UserId { get; set; }

            public override void ExecuteResult(ControllerContext context)
            {
                var properties = new AuthenticationProperties() { RedirectUri = RedirectUri };
                if (UserId != null)
                {
                    properties.Dictionary[XsrfKey] = UserId;
                }
                context.HttpContext.GetOwinContext().Authentication.Challenge(properties, LoginProvider);
            }
        }

        private static UsuarioIdentity GerarIdentidadeUsuario(ExternalLoginInfo info)
        {
            var user = new UsuarioIdentity();
            if (info.Login.LoginProvider == "Facebook")
            {
                GetNomeUsuarioFacebook(info, user);
            }
            else if (info.Login.LoginProvider == "Google")
            {
                GetNomeUsuarioGoogle(info, user);
            }

            user.Email = info.Email;
            user.UserName = GerarUserNameUsuario(user.Nome, user.Sobrenome);
            return user;
        }

        private static string GerarUserNameUsuario(string primeiroNome, string segundoNome)
        {
            if (string.IsNullOrEmpty(primeiroNome))
                throw new ArgumentNullException(nameof(primeiroNome));

            if (string.IsNullOrEmpty(segundoNome))
                throw new ArgumentNullException(nameof(segundoNome));

            var userName = string.Format("{0}{1}", GerarPrefixo(primeiroNome),
                                                      GerarSufixo(segundoNome));

            return userName;
        }

        private static string GerarSufixo(string segundoNome)
        {
            char[] ESPACOEMBRACO = new char[0];
            return segundoNome.Trim()
                              .Split(ESPACOEMBRACO)
                              .First()
                              .Substring(0, 1)
                              .ToUpperInvariant() + DateTime.Now.Ticks;
        }

        private static string GerarPrefixo(string primeiroNome)
        {
            char[] ESPACOEMBRACO = new char[0];
            return primeiroNome.Trim()
                                .Split(ESPACOEMBRACO)
                                .First()
                                .Substring(0, 1)
                                .ToUpperInvariant();
        }

        private static void GetNomeUsuarioGoogle(ExternalLoginInfo info, UsuarioIdentity user)
        {
            var claims = info.ExternalIdentity.Claims;
            user.Nome = claims.FirstOrDefault(c => c.Type.Contains("givenname")).Value;
            user.Sobrenome = claims.FirstOrDefault(c => c.Type.Contains("surname")).Value;
        }

        private static void GetNomeUsuarioFacebook(ExternalLoginInfo info, UsuarioIdentity user)
        {
            var nomeCompleto = info.ExternalIdentity.Name;
            var nomeDivido = nomeCompleto.Split(' ');
            user.Nome = nomeDivido[0];
            user.Sobrenome = nomeDivido[nomeDivido.Length - 1];
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && _userManager != null)
            {
                _userManager.Dispose();
            }
            base.Dispose(disposing);
        }
        #endregion
    }
}