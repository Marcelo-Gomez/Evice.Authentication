using Evice.Authentication.Domain.AggregatesModel.LoginAggregate;
using Evice.Authentication.Infrastructure.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Evice.Authentication.Infrastructure.Services
{
    public class JwtService : IJwtService
    {
        private readonly JwtSecurityTokenHandler _jwtSecurityTokenHandler;
        private readonly string _jwtSecret;

        public JwtService(JwtSecurityTokenHandler jwtSecurityTokenHandler, IConfiguration configuration)
        {
            this._jwtSecurityTokenHandler = jwtSecurityTokenHandler ?? throw new ArgumentNullException(nameof(jwtSecurityTokenHandler));
            this._jwtSecret = configuration["Jwt:Secret"] ?? throw new ArgumentNullException(nameof(configuration));
        }

        public string GenerateEncodedToken(UserInfoToken userInfoToken, int expirationInSeconds)
        {
            var currentDateUtc = DateTime.UtcNow;
            var securityTokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub, userInfoToken.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(ClaimTypes.Role, userInfoToken.IsAdmin ? "Admin" : "Employee"),
                    new Claim("Id", userInfoToken.Id.ToString()),
                    new Claim("Name", userInfoToken.Name),
                    new Claim("Email", userInfoToken.Email),
                    new Claim("CompanyName", userInfoToken.CompanyName)
                }),
                IssuedAt = currentDateUtc,
                NotBefore = currentDateUtc,
                Expires = currentDateUtc.AddSeconds(expirationInSeconds),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(this._jwtSecret)), SecurityAlgorithms.HmacSha256Signature)
            };

            var securityToken = this._jwtSecurityTokenHandler.CreateToken(securityTokenDescriptor);

            return this._jwtSecurityTokenHandler.WriteToken(securityToken);
        }
    }
}