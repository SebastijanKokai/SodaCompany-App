using AutoMapper;
using SodaCompany.Application.Commands.ProductionOrders;
using SodaCompany.Application.Dtos;
using SodaCompany.Application.Responses.ProductionOrders;
using SodaCompany.Core.Entities;
using System;
using System.Collections.Generic;

namespace SodaCompany.Application.Mappers
{
    public class ProductionOrderMapperProfile : Profile
    {
        public ProductionOrderMapperProfile()
        {
            CreateMap<InsertOrderProductCommand, ProductionOrderProduct>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.NewGuid()))
                .ForMember(dest => dest.ProductionOrderId, opt => opt.MapFrom(src => src.OrderId));
            CreateMap<ProductionOrder, ProductionOrderResponse>()
                .ForMember(dest => dest.OrderedProducts, opt => opt.MapFrom(src => ProductionOrderMapper.Mapper.Map<ICollection<OrderItem>>(src.ProductionOrderProduct)));
            CreateMap<InsertProductionOrderCommand, ProductionOrder>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.NewGuid()));
            CreateMap<OrderProductDto, ProductionOrderProduct>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.NewGuid()));
            CreateMap<ProductionOrderProduct, OrderItem>()
                .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity));
        }
    }
}
