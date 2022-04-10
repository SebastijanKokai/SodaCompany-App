using MediatR;
using System;

namespace SodaCompany.Application.Commands.EmployeeType
{
    public class UpdateEmployeeTypeCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
        public string Type { get; set; }
    }
}
