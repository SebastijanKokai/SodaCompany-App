using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SodaCompany.Application.Services.Interfaces;
using SodaCompany.Common.Options;
using SodaCompany.Core.Entities;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace SodaCompany.Application.Services
{
    public class BearerTokenService : IBearerTokenService
    {
        public BearerTokenService(IOptions<JWTOptions> JWTconfiguration)
        {
            _JWTOptions = JWTconfiguration.Value;
        }

        private const string EmployeeUsernameClaim = "Username";
        private const string EmployeeTypeClaim = "Type";
        private readonly JWTOptions _JWTOptions;
        public string GetUsernameFromToken(string token)
        {
            return new JwtSecurityToken(token).Claims.FirstOrDefault(c => c.Type == EmployeeUsernameClaim).Value;
        }
        public string GetEmployeeTypeFromToken(string token)
        {
            return new JwtSecurityToken(token).Claims.FirstOrDefault(c => c.Type == EmployeeTypeClaim).Value;
        }

        public string GenerateJWT(Employee credentials)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_JWTOptions.Key));
            var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[] {
                new Claim(EmployeeUsernameClaim,credentials.Username),
                new Claim(EmployeeTypeClaim,credentials.EmployeeType.Id.ToString())
            };

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials: signingCredentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
