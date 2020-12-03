using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InternProj.Domain;
using InternProj.Extern.Dtos;

namespace InternProj.Extern.Mappings
{
    public class EServiceMappingProfile :Profile
    {
        public EServiceMappingProfile()
        {
            CreateMap<ElectronicService, ElectronicServiceDto>();
            CreateMap<CreateElectronicServiceDto, ElectronicService>();
        }
    }
}
