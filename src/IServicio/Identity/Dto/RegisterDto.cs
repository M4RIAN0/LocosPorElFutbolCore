namespace IServicio.Identity.Dto
{
    public class RegisterDto
    {
        public string Email { get; set; }
        public string NombreCompleto { get; set; }
        public string Celular { get; set; }
        public string Password { get; set; }

        // Persona
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Dni { get; set; }
        public string Direccion { get; set; }
        public string Sexo { get; set; }
        public string FechaNacimiento { get; set; }

    }

    public class AssignRoleDto : RegisterDto
    {
        public string Role { get; set; }
    }

}
