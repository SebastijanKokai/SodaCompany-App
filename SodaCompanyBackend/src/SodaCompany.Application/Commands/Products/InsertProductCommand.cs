using MediatR;
using System;

namespace SodaCompany.Application.Commands.Products
{
    public class InsertProductCommand : IRequest<Unit>
    {
        public string Name { get; set; }
        public Guid? ProductModelId { get; set; }
        public Guid? WorkProcedureId { get; set; }
    }
}
