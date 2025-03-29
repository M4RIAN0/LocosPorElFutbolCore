using System.ComponentModel.DataAnnotations;

namespace LXF.Web.Models.ViewModels
{
    public class LoginRequestViewModel
    {
        [Required]
        public string NombreUsuario { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
