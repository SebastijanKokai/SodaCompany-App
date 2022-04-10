using MediatR;
using SodaCompany.Application.Queries.Base;
using SodaCompany.Application.Responses.Products;
using SodaCompany.Application.Responses.Wrappers;
using System.Collections.Generic;

namespace SodaCompany.Application.Queries.Products
{
    public class GetProductsQuery : BasePagedQuery, IRequest<PagedResponse<IReadOnlyList<ProductResponse>>>
    {
    }
}
