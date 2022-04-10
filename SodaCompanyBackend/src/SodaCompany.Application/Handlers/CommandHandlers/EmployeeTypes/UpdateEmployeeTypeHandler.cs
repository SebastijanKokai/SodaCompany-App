using MediatR;
using SodaCompany.Application.Commands.EmployeeType;
using SodaCompany.Core.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace SodaCompany.Application.Handlers.CommandHandlers.EmployeeTypes
{
    public class UpdateEmployeeTypeHandler : IRequestHandler<UpdateEmployeeTypeCommand, Unit>
    {
        private readonly IEmployeeTypeRepository _employeeTypeRepository;

        public UpdateEmployeeTypeHandler(IEmployeeTypeRepository employeeTypeRepository)
        {
            _employeeTypeRepository = employeeTypeRepository;
        }
        public async Task<Unit> Handle(UpdateEmployeeTypeCommand request, CancellationToken cancellationToken)
        {
            var oldProduct = await _employeeTypeRepository.GetByIdAsync(request.Id);
            if (oldProduct is null)
                return Unit.Value;
            oldProduct.Id = request.Id;
            oldProduct.Type = request.Type;
            await _employeeTypeRepository.UpdateAsync(oldProduct);
            return Unit.Value;
        }
    }
}
