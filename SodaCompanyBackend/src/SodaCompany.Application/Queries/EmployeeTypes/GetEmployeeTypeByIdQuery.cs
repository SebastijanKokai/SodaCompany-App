using MediatR;
using SodaCompany.Application.Responses.EmployeeTypes;
using System;

namespace SodaCompany.Application.Queries.EmployeeTypes
{
    public class GetEmployeeTypeByIdQuery : IRequest<EmployeeTypeResponse>
    {
        public Guid Id { get; set; }
    }
}
