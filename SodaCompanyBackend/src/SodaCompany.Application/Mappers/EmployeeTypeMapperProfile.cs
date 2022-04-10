using AutoMapper;
using SodaCompany.Application.Commands.EmployeeType;
using SodaCompany.Application.Responses.EmployeeTypes;
using SodaCompany.Core.Entities;
using System;

namespace SodaCompany.Application.Mappers
{
    public class EmployeeTypeMapperProfile : Profile
    {
        public EmployeeTypeMapperProfile()
        {
            CreateMap<EmployeeType, EmployeeTypeResponse>();
            CreateMap<UpdateEmployeeTypeCommand, EmployeeType>();
            CreateMap<InsertEmployeeTypeCommand, EmployeeType>()
                .ForMember(m => m.Id, src => src.MapFrom(m => Guid.NewGuid()));
        }
    }
}
