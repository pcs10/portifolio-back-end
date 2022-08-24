using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using login_autenticacao.Models;
using Microsoft.IdentityModel.Tokens;

namespace login_autenticacao.Services
{
    public static class TokenService
    {
        public static string GenerateToken(Usuario user)
        {
            var tokenHandler = new JwtSecurityTokenHandler(); // cara que vai gerar o token de fato
            var key = Encoding.ASCII.GetBytes(Settings.Secret); //chave definida na classe secret
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Username.ToString()),
                    new Claim(ClaimTypes.Role, user.Role.ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);

        }
    }
}
