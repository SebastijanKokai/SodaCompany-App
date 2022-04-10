using SodaCompany.Application.Dtos;
using SodaCompany.Application.Services.Interfaces;
using SodaCompany.Common.Exceptions;
using SodaCompany.Core.Repositories;

namespace SodaCompany.Application.Services
{
    public class AuthorizationService : IAuthorizationService
    {
        private readonly IBearerTokenService _bearerTokenService;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IHashingService _hashingService;

        public AuthorizationService(IBearerTokenService bearerTokenService, IEmployeeRepository employeeRepository, IHashingService hashingService)
        {
            _bearerTokenService = bearerTokenService;
            _employeeRepository = employeeRepository;
            _hashingService = hashingService;
        }
        public string AuthorizeEmployee(EmployeeLoginDto credentials)
        {
            var employee = _employeeRepository.GetEmployeeByUsername(credentials.Username);
            if (employee is null)
                throw new UnAuthorizedException("User is not found");
            var hash = _hashingService.ComputeHash($"{credentials.Password}{employee.Salt}");
            if (!_hashingService.CompareHash(hash, employee.Password))
                throw new UnAuthorizedException("Wrong credentials");
            return _bearerTokenService.GenerateJWT(employee);

        }
    }
}
