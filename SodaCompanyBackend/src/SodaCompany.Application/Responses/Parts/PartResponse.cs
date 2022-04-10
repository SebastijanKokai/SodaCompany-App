using System;

namespace SodaCompany.Application.Responses.Parts
{
    public class PartResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
