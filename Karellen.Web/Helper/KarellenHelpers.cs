using Karellen.Data.Entidade;
using Karellen.Negocio.Util.Extensao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using Karellen.Web.Identity.Manager;
using Microsoft.AspNet.Identity;
using Microsoft.Practices.Unity;

namespace Karellen.Web.Helper
{
    public static class KarellenHelper
    {
        public static MvcHtmlString OcorrenciasFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, object htmlAttributes)
        {
            var ocorrencias = Enum.GetValues(typeof(EnumTipoOcorrencia))
                    .Cast<EnumTipoOcorrencia>()
                    .Select(l => new SelectListItem
                    {
                        Value = ((int)l).ToString(),
                        Text = l.GetDescricao()
                    }).ToList();


            return htmlHelper.ListBoxFor(expression, ocorrencias, htmlAttributes);
        }

        public static MvcHtmlString OcorrenciaAnonimaFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, bool usuarioAutenticado, string usuarioNome)
        {
            var opcoes = new List<string> {"Anônima", usuarioNome};

            var sb = new StringBuilder();
            foreach (var opcao in opcoes)
            {
                if (opcao == usuarioNome && string.IsNullOrEmpty(usuarioNome))
                    break;

                sb.Append(htmlHelper.RadioButton("OcorrenciaAnonima", opcao == "Anônima"));
                sb.Append(htmlHelper.Label(opcao));
                sb.Append("&nbsp");
            }

            return new MvcHtmlString(sb.ToString());
        }

        public static MvcHtmlString ImagemUsuario<TModel>(this HtmlHelper<TModel> htmlHelper, int usuarioId)
        {
            var container = UnityConfig.GetConfiguredContainer() as UnityContainer;
            var manager = container.Resolve<UsuarioIdentityManager>();
            var logins = manager.GetLogins(usuarioId);
            string userKey = string.Empty;
            if (logins != null)
            {
                var u = logins.FirstOrDefault(l => l.LoginProvider == "Facebook");
                userKey = u == null ? string.Empty : u.ProviderKey;
            }

            var tag = new TagBuilder("img");
            tag.AddCssClass("profile");
            tag.MergeAttribute("src", "http://graph.facebook.com/"+ userKey + "/picture?type=normal");

            return new MvcHtmlString(tag.ToString());
        }
    }
}