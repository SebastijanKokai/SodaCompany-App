using AutoMapper;
using SodaCompany.Application.Commands.ProductionPlans;
using SodaCompany.Application.Dtos;
using SodaCompany.Application.Responses.ProductionPlans;
using SodaCompany.Core.Entities;
using System;
using System.Linq;

namespace SodaCompany.Application.Mappers
{
    public class ProductionPlanMapperProfile : Profile
    {
        public ProductionPlanMapperProfile()
        {
            CreateMap<InsertProductionPlanCommand, ProductionPlan>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.NewGuid()));
            CreateMap<ProductionPlanWorkProcedureDto, ProductionPlanWorkProcedure>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.NewGuid()));
            CreateMap<ProductionPlanWorkProcedureDto, ProductionPlanWorkProcedure>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.NewGuid()));
            CreateMap<InsertProductionPlanWorkProcedureCommand, ProductionPlanWorkProcedure>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.NewGuid()));
            CreateMap<ProductionPlan, ProductionPlanResponse>()
                .ForMember(dest => dest.TotalProductionCost, opt => opt.MapFrom(src => src.ProductionPlanWorkProcedure.Sum(wp => wp.Quantity * (wp.WorkProcedure.ProductionPrice + wp.WorkProcedure.WorkProcedurePart.Sum(part => part.Quantity * part.Part.Price)))));
            CreateMap<ProductionPlanWorkProcedure, ProductionPlanItem>();
            CreateMap<WorkProcedurePart, ProductPart>();
        }
    }
}
