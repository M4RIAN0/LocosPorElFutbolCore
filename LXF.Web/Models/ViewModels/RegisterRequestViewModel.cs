using System.ComponentModel.DataAnnotations;

namespace LXF.Web.Models.ViewModels
{
    public class RegisterRequestViewModel
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Celular { get; set; }
        [Required]
        public string Password { get; set; }
        public string? Role { get; set; }
    }
}
