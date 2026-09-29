using IServicio.Email;

namespace IServicio.Identity.Dto
{
    public class ForgotPasswordDto
    {
        public string Email { get; set; }
        public Message Message { get; set; }
    }
}
