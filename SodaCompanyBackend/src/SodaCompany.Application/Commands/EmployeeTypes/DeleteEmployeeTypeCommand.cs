using MediatR;
using System;

namespace SodaCompany.Application.Commands.EmployeeType
{
    public class DeleteEmployeeTypeCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}
