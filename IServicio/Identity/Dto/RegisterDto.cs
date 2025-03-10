namespace IServicio.Identity.Dto
{
    public class RegisterDto
    {
        public string Email { get; set; }
        public string Nombre { get; set; }
        public string Celular { get; set; }
        public string Password { get; set; }
    }

    public class AssignRoleDto : RegisterDto
    {
        public string Role { get; set; }
    }

}
