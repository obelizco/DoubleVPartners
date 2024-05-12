using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Back.Personas.Dominio.Dtos;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Back.Personas.CasosDeUso.Service
{
    public class JwtService
    {
        private string secrect;
       
        public JwtService(IConfiguration configuration)
        {
            secrect = configuration["jwt:secret"];
        }

        public string GenerateToken(UsuarioDto user)
        {
             
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(secrect);
            var claims = new Claim[] {
             new Claim("uid", user.IdUsuario.ToString()),
             new Claim("user", user.NombreUsuario),

             //new Claim("IdUsuario", user.IdUsuario.ToString()),
             //new Claim("Email", user.Email),
             //new Claim("lastName", user.Apellido1.ToString()),

        };

            var signingCredentials = new SigningCredentials(
                new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(secrect)
                    ),
                 SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                "api:prueba",
                "https://doublevpartners.com/",
                claims,
                null,
                DateTime.UtcNow.AddDays(7),
                signingCredentials
                );

            var tokenValue = new JwtSecurityTokenHandler()
                .WriteToken(token);

            return tokenValue;

        }
    }
}
