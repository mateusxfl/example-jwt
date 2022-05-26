using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ApiAuth.Models;
using Microsoft.IdentityModel.Tokens;

namespace ApiAuth.Services
{
    public static class TokenService
    {
        public static string GenerateToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            // Transformamos nossa Secret num array de bytes.
            var key = Encoding.ASCII.GetBytes(Settings.Secret);

            // Tudo que o nosso token tem, tudo que precisa para funcionar.
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                // Claims: afirmações referentes aos roles do usuário.
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, user.Username),
                    new Claim(ClaimTypes.Role, user.Role)
                }),

                // Caso o token expire, é necessário o processo de refresh Token.
                Expires = DateTime.UtcNow.AddHours(2),

                // Credenciais usadas para encripitar e desencriptar o Token.
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)

            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}