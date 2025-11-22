using Dominio.Entidades;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace IServicio.JwToken
{
    public class JwTokenGenerator : IJwTokenGenerator //Generador de Token
    {
        private readonly JwtOptions _jwtOptions; // usamos 'JwtOptions' para configurar nuestro Token en su generacion
        public JwTokenGenerator(IOptions<JwtOptions> jwtOptions) // se usa IOptions<> para acceder a las opciones de JwtOptions
        {
            _jwtOptions = jwtOptions.Value;
        }
        public string GenerateToken(Usuario applicationUser, IEnumerable<string> roles) //generamos el token basado en ApplicationUser
        {
            var tokenHandler = new JwtSecurityTokenHandler(); // usamos 'tokenHandler' para generar el token

            var key = Encoding.ASCII.GetBytes(_jwtOptions.Secret); //generamos el key Secret

            var claimsList = new List<Claim> // JWT esta compuesto por multiples 'claims' que le asignamos los valores del usuario
            {
                new Claim(JwtRegisteredClaimNames.Email, applicationUser.Email),
                new Claim(JwtRegisteredClaimNames.Sub, applicationUser.Id),
                new Claim(JwtRegisteredClaimNames.Name, applicationUser.UserName)
            };

            // se agrega el claim tipo 'role' a la lista de claims
            claimsList.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));

            var tokenDescriptor = new SecurityTokenDescriptor // describe configuracions de el token
            {
                Audience = _jwtOptions.Audience, // agregamos Audience de nuestro 'JwtOptions'
                Issuer = _jwtOptions.Issuer, // Issuer similar arriba
                Subject = new ClaimsIdentity(claimsList), // Agregamos los claims que definimos en 'claimsList' y se almacenan en 'Subject'
                Expires = DateTime.UtcNow.AddDays(7), // expiracion del jwt
                // SigningCredentials usa en 'SymmetricSecurityKey' el 'Key' secret y el algoritmo 'SecurityAlgorithms' del tipo 'HmacSha256Signature' que es el mas comun usado
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor); // generamos el token
            return tokenHandler.WriteToken(token); // escribe el token necesario y lo retorna
        }
    }
}
