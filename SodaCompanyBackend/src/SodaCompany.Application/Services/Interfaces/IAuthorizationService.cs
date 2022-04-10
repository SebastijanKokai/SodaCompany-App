using SodaCompany.Application.Dtos;

namespace SodaCompany.Application.Services.Interfaces
{
    public interface IAuthorizationService
    {
        public string AuthorizeEmployee(EmployeeLoginDto credentials);
    }
}
