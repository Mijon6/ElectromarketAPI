using AutoMapper;
using ElectromarketAPI.Entities;
using ElectromarketAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectromarketAPI
{
    public class ElectromarketMappingProfile : Profile
    {
        public ElectromarketMappingProfile()
        {
            CreateMap<Electromarket, ElectromarketDto>()
                .ForMember(m => m.City, c => c.MapFrom(s => s.Address.City))
                .ForMember(m => m.Street, c => c.MapFrom(s => s.Address.Street))
                .ForMember(m => m.PostalCode, c => c.MapFrom(s => s.Address.PostalCode));

            CreateMap<Stuff, StuffDto>();

            CreateMap<CreateElectromarketDto, Electromarket>()
                .ForMember(r => r.Address, c => c.MapFrom(dto => new Address() { City = dto.City, PostalCode = dto.PostalCode, Street = dto.Street }));
        }
    }
}
