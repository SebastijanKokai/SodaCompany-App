using MediatR;
using SodaCompany.Application.Responses.Products;
using System;

namespace SodaCompany.Application.Queries.Products
{
    public class GetProductByIdQuery : IRequest<ProductResponse>
    {
        public Guid Id { get; set; }
    }
}
