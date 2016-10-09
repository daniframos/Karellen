using Karellen.Negocio.Mensagem;
using System.ComponentModel.DataAnnotations;

namespace Karellen.Web.Models.Conta
{
    public class SenhaVM
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = @"Senha Atual")]
        public string SenhaAntiga { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = @"Nova Senha")]
        public string NovaSenha { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = @"Confirme a nova senha")]
        [Compare("NovaSenha", ErrorMessageResourceType = typeof(Mensagem), ErrorMessageResourceName = "MN012")]
        public string SenhaConfirmada { get; set; }
    }
}