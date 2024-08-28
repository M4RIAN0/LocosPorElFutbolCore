namespace IServicio.Identity.Dto
{
    public class RegistrationRequestDto
    {
        public string Email { get; set; }
        public string Nombre { get; set; }
        public string Celular { get; set; }
        public string Password { get; set; }
        public string? Role { get; set; }
    }
}
