using MediatR;
using SodaCompany.Application.Commands.EmployeeType;
using SodaCompany.Application.Mappers;
using SodaCompany.Core.Entities;
using SodaCompany.Core.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace SodaCompany.Application.Handlers.CommandHandlers.EmployeeTypes
{
    public class InsertEmployeeTypeHandler : IRequestHandler<InsertEmployeeTypeCommand, Unit>
    {
        private readonly IEmployeeTypeRepository _employeeTypesRepository;

        public InsertEmployeeTypeHandler(IEmployeeTypeRepository employeeTypeRepository)
        {
            _employeeTypesRepository = employeeTypeRepository;
        }
        public async Task<Unit> Handle(InsertEmployeeTypeCommand request, CancellationToken cancellationToken)
        {
            var newProduct = EmployeeTypeMapper.Mapper.Map<EmployeeType>(request);
            await _employeeTypesRepository.AddAsync(newProduct);
            return Unit.Value;
        }
    }
}
