using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InternProj.Domain;
using InternProj.Extern.Dtos;
using InternProj.WebApi.Extern.Dtos.CityHall;
using InternProj.WebApi.Extern.Dtos.Iban;

namespace InternProj.Extern.Mappings
{
    public class EServiceMappingProfile :Profile
    {
        public EServiceMappingProfile()
        {
            CreateMap<CreateElectronicServiceDto, ElectronicService>();
            CreateMap<ElectronicService, ElectronicServiceDto>();


            CreateMap<CreateCityHallDto, CityHall>();
            CreateMap<CityHall, CityHallDto>();

            CreateMap<CreateAddressContactCityHallDto, AddressContactCityHall>();
            
            CreateMap<AddressContactCityHall, AddressContactCityHallDto>();

            CreateMap<Iban, BankAccountDto>().ForMember(dto => dto.CityHall, iban => iban.MapFrom(src => src.CityHall.Name))
                                      .ForMember(dto => dto.ElectronicService, iban => iban.MapFrom(src => src.ElectronicService.Name));
        }
    }
}
