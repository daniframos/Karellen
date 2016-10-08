using Karellen.Negocio.Mensagem;
using System.ComponentModel.DataAnnotations;

namespace Karellen.Web.Models.Conta
{
    public class SenhaVM
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = @"Senha")]
        public string Senha { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = @"Confirme a senha")]
        [Compare("Senha", ErrorMessageResourceType = typeof(Mensagem), ErrorMessageResourceName = "MN012")]
        public string SenhaConfirmada { get; set; }
    }
}