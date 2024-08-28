namespace Dominio.Entidades
{
    using Microsoft.AspNetCore.Identity;

    public partial class Usuario: IdentityUser
    {
        public string Nombre { get; set; }
    }
}
