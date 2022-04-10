using System;

namespace SodaCompany.Application.Dtos
{
    public class OrderProductDto
    {
        public decimal Quantity { get; set; }
        public Guid? ProductId { get; set; }
    }
}
