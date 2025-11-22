using Dominio.Entidades;
using System.Collections.Generic;

namespace IServicio.JwToken
{
    public interface IJwTokenGenerator
    {
        string GenerateToken(Usuario applicationUser, IEnumerable<string> roles);
    }
}
