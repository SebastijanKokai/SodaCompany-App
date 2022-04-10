using MediatR;
using System;

namespace SodaCompany.Application.Commands.Products
{
    public class UpdateProductCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid? ProductModelId { get; set; }
    }
}
