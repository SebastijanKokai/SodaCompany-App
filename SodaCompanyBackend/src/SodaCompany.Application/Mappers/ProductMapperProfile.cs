using AutoMapper;
using SodaCompany.Application.Commands.Products;
using SodaCompany.Application.Responses.Products;
using SodaCompany.Core.Entities;
using System;

namespace SodaCompany.Application.Mappers
{
    public class ProductMapperProfile : Profile
    {
        public ProductMapperProfile()
        {
            CreateMap<Product, ProductResponse>();
            CreateMap<WorkProcedure, WorkProcedureItem>();
            CreateMap<WorkProcedurePart, PartProduct>();
            CreateMap<UpdateProductCommand, Product>();
            CreateMap<InsertProductCommand, Product>()
                .ForMember(m => m.Id, src => src.MapFrom(m => Guid.NewGuid()));
        }
    }
}
