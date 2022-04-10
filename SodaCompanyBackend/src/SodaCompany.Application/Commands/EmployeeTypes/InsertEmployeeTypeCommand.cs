using MediatR;

namespace SodaCompany.Application.Commands.EmployeeType
{
    public class InsertEmployeeTypeCommand : IRequest<Unit>
    {
        public string Type { get; set; }
    }
}
