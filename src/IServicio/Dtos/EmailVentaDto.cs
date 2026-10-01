using IServicio.Email;
using System.ComponentModel.DataAnnotations;

namespace IServicio.Dtos
{
    public class EmailVentaDto
    {
        [Required]
        public Message Message { get; set; }
    }
}
