using IServicio.Email;
using System.ComponentModel.DataAnnotations;

namespace LXF.Web.Models.ViewModels
{

    public class EmailVentaViewModel
    {
        [Required]
        public Message Message { get; set; }

    }
}