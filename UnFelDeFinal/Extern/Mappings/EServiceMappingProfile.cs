using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnFelDeFinal.Domain;
using UnFelDeFinal.Extern.Dtos;

namespace UnFelDeFinal.Extern.Mappings
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
