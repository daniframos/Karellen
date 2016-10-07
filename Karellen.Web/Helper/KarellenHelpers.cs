using Karellen.Data.Entidade;
using Karellen.Negocio.Util.Extensao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace Karellen.Web.Helper
{
    public static class KarellenHelper
    {
        public static MvcHtmlString OcorrenciasFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, object htmlAttributes)
        {
            var ocorrencias = Enum.GetValues(typeof(TipoOcorrencia))
                    .Cast<TipoOcorrencia>()
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
    }
}