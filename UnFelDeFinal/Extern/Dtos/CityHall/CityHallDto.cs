using InternProj.WebApi.Extern.Dtos.CityHall;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternProj.Extern.Dtos
{
    public class CityHallDto
    {
        public string Name { get; set; }
        public decimal BanckAccount { get; set; }

        public List<AddressContactCityHallDto> AddressContactCityHall { get; set; }
    }
}
