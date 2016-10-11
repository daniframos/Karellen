using Karellen.Negocio.Mensagem;
using Karellen.Web.Identity.Manager;
using Microsoft.Practices.Unity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Karellen.Web.Models.Conta
{
    public class GerenciarVM: IValidatableObject
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

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var container = UnityConfig.GetConfiguredContainer() as UnityContainer;
            var manager = container.Resolve<UsuarioIdentityManager>();
            var task = manager.FindByEmailAsync(this.Email);
            task.Wait();
            var u = task.Result;
            if (u != null)
            {
                yield return new ValidationResult(Mensagem.MN018);
            }
        }
    }
}