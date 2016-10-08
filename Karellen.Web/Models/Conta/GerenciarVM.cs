using Karellen.Negocio.Mensagem;
using System.ComponentModel.DataAnnotations;

namespace Karellen.Web.Models.Conta
{
    public class GerenciarVM
    {
        [Required]
        [Display(Name = @"Nome")]
        public string Nome { get; set; }
        [Required]
        [Display(Name = @"Sobrenome")]
        public string Sobrenome { get; set; }
        [Required]
        [EmailAddress(ErrorMessageResourceType = typeof(Mensagem), ErrorMessageResourceName = "MN010")]
        [Display(Name = @"Email")]
        public string Email { get; set; }
        public string Cidade { get; set; }
    }
}