using Karellen.Negocio.Mensagem;
using System.ComponentModel.DataAnnotations;

namespace Karellen.Web.Models.Conta
{
    public class LoginVM
    {
        [Required]
        [EmailAddress(ErrorMessageResourceType = typeof(Mensagem), ErrorMessageResourceName = "MN010")]
        [Display(Name = @"Email")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = @"Senha")]
        public string Senha { get; set; }

        [Display(Name = @"Lembrar")]
        public bool Lembrar { get; set; }
    }
}