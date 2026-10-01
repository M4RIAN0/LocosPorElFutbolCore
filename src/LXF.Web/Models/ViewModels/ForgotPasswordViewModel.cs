using IServicio.Email;
using System.ComponentModel.DataAnnotations;

namespace LXF.Web.Models.ViewModels
{
    public class ForgotPasswordViewModel
    {
        [Required(ErrorMessage = "El Email es Obligatorio.")]
        public string Email { get; set; }
        public Message? Message { get; set; }
    }
}
