using MediatR;
using SodaCompany.Application.Mappers;
using SodaCompany.Application.Queries.EmployeeTypes;
using SodaCompany.Application.Responses.EmployeeTypes;
using SodaCompany.Core.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace SodaCompany.Application.Handlers.QueryHandlers.EmployeeTypes
{
    public class GetEmployeeTypeByIdHandler : IRequestHandler<GetEmployeeTypeByIdQuery, EmployeeTypeResponse>
    {
        private readonly IEmployeeTypeRepository _employeeTypesRepository;

        public GetEmployeeTypeByIdHandler(IEmployeeTypeRepository employeeTypesRepository)
        {
            _employeeTypesRepository = employeeTypesRepository;
        }

        public async Task<EmployeeTypeResponse> Handle(GetEmployeeTypeByIdQuery request, CancellationToken cancellationToken)
        {
            return EmployeeTypeMapper.Mapper.Map<EmployeeTypeResponse>(await _employeeTypesRepository.GetByIdAsync(request.Id));
        }
    }
}
