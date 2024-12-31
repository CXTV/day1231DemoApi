using Demo.Application.Common.Interfaces.Authentication;
using Demo.Application.Common.Interfaces.Services;
using Demo.Domain.Entities;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

//生成JWT令牌
namespace Demo.Infrastructure.Authentication
{
    public class JwtTokenGenerator : IJwtTokenGenerator
    {
        private readonly IDateTimeProvider _dateTimeProvider;

        private readonly JwtSettings _jwtSettings;


        public JwtTokenGenerator(IDateTimeProvider _dateTimeProvider, IOptions<JwtSettings> jwtOptions)
        {
            this._dateTimeProvider = _dateTimeProvider;
            this._jwtSettings = jwtOptions.Value;
        }

        public string GenerateToken(User user)
        {
            //var key = "your-very-long-secret-key-that-is-at-least-32-characters-long";
            var key = _jwtSettings.Secret;
            var signingCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key)), SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.GivenName,user.FirstName),
                new Claim(JwtRegisteredClaimNames.FamilyName,user.LastName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var securityToken = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                expires: _dateTimeProvider.UtcNow.AddMinutes(_jwtSettings.ExpiryInMinutes),
                claims:claims,
                signingCredentials: signingCredentials);

            return new JwtSecurityTokenHandler().WriteToken(securityToken);
        }
    }
}
