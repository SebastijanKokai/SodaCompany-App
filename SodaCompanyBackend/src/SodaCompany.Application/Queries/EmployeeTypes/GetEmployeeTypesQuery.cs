using MediatR;
using SodaCompany.Application.Queries.Base;
using SodaCompany.Application.Responses.EmployeeTypes;
using SodaCompany.Application.Responses.Wrappers;
using System.Collections.Generic;

namespace SodaCompany.Application.Queries.EmployeeTypes
{
    public class GetEmployeeTypesQuery : BasePagedQuery, IRequest<PagedResponse<IReadOnlyList<EmployeeTypeResponse>>>
    {
    }
}
