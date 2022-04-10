using MediatR;
using SodaCompany.Application.Mappers;
using SodaCompany.Application.Queries.EmployeeTypes;
using SodaCompany.Application.Responses.EmployeeTypes;
using SodaCompany.Application.Responses.Wrappers;
using SodaCompany.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SodaCompany.Application.Handlers.QueryHandlers.EmployeeTypes
{
    public class GetEmployeeTypesHandler : IRequestHandler<GetEmployeeTypesQuery, PagedResponse<IReadOnlyList<EmployeeTypeResponse>>>
    {
        private readonly IEmployeeTypeRepository _employeeTypesRepository;

        public GetEmployeeTypesHandler(IEmployeeTypeRepository employeeTypesRepository)
        {
            _employeeTypesRepository = employeeTypesRepository;
        }
        public async Task<PagedResponse<IReadOnlyList<EmployeeTypeResponse>>> Handle(GetEmployeeTypesQuery request, CancellationToken cancellationToken)
        {
            var totalRecord = await _employeeTypesRepository.GetNumberOfRecord();

            if (request.RecordsPerPage < 1)
                request.RecordsPerPage = 10;

            if (request.PageNumber < 1)
            {

                request.PageNumber = 1;
                request.RecordsPerPage = totalRecord;
            }

            var numberOfPages = Convert.ToInt32(Math.Ceiling((double)totalRecord / (double)request.RecordsPerPage));

            if (numberOfPages < request.PageNumber)
                request.PageNumber = numberOfPages;

            var data = EmployeeTypeMapper.Mapper.Map<IReadOnlyList<EmployeeTypeResponse>>(await _employeeTypesRepository.GetEntitiesPaged(request.RecordsPerPage, request.PageNumber));

            var response = new PagedResponse<IReadOnlyList<EmployeeTypeResponse>>(data, request.PageNumber, request.RecordsPerPage, totalRecord);
            return response;
        }
    }
}
