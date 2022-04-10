using MediatR;
using System;

namespace SodaCompany.Application.Commands.Products
{
    public class DeleteProductCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}
