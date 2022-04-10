using MediatR;
using SodaCompany.Application.Commands.EmployeeType;
using SodaCompany.Core.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace SodaCompany.Application.Handlers.CommandHandlers.EmployeeTypes
{
    public class DeleteEmployeeTypeHandler : IRequestHandler<DeleteEmployeeTypeCommand, Unit>
    {
        private readonly IEmployeeTypeRepository _employeeTypeRepository;

        public DeleteEmployeeTypeHandler(IEmployeeTypeRepository employeeTypeRepository)
        {
            _employeeTypeRepository = employeeTypeRepository;
        }
        public async Task<Unit> Handle(DeleteEmployeeTypeCommand request, CancellationToken cancellationToken)
        {
            var product = await _employeeTypeRepository.GetByIdAsync(request.Id);
            if (product is null)
                return Unit.Value;
            await _employeeTypeRepository.DeleteAsync(product);
            return Unit.Value;
        }
    }
}
