using Karellen.Negocio.Mensagem;
using System.ComponentModel.DataAnnotations;

namespace Karellen.Web.Models.Conta
{
    public class RegistrarVM
    {
        [Required]
        [Display(Name = @"Nome")]
        public string Nome { get; set; }

        [Required]
        [Display(Name = @"Sobrenome")]
        public string SobreNome { get; set; }

        [Required]
        [EmailAddress(ErrorMessageResourceType = typeof(Mensagem), ErrorMessageResourceName = "MN010")]
        [Display(Name = @"Email")]
        public string Email { get; set; }

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