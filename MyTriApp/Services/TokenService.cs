using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MyTriApp.Data.Entities;
using MyTriApp.Secrets;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MyTriApp.Services.Interfaces
{
    public class TokenService : ITokenService
    {
        private readonly SecretsProvider _secretsProvider;

        public TokenService(SecretsProvider secretsProvider)
        {
            _secretsProvider = secretsProvider;
        }

        public async Task<string> GetUserToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(await _secretsProvider.GetSecretAsync("JWT-Key"));

            var claims = new List<Claim>
            {
                new("jti", Guid.NewGuid().ToString()),
                new("sub", user.Email),
                new("email", user.Email),
                new("userid", user.ExternalId.ToString()),
                new("isadmin", user.IsAdmin.ToString()!, ClaimValueTypes.Boolean)
            };

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddHours(1),
                Issuer = await _secretsProvider.GetSecretAsync("JWT-Issuer"),
                Audience = await _secretsProvider.GetSecretAsync("JWT-Audience"),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            var jwt = tokenHandler.WriteToken(token);

            return jwt;
        }
    }
}
