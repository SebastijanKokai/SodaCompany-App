using SodaCompany.Core.Entities;

namespace SodaCompany.Application.Services.Interfaces
{
    public interface IBearerTokenService
    {
        public string GenerateJWT(Employee credentials);
        public string GetUsernameFromToken(string token);
        public string GetEmployeeTypeFromToken(string token);
    }
}
