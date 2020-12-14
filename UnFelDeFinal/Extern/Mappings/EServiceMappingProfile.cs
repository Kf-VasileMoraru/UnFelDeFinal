using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InternProj.Domain;
using InternProj.Extern.Dtos;
using InternProj.WebApi.Extern.Dtos.CityHall;

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



        }
    }
}
