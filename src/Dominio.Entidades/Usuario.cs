namespace Dominio.Entidades
{
    using Microsoft.AspNetCore.Identity;

    public class Usuario: IdentityUser
    {
        public string Nombre { get; set; }
    }
}
