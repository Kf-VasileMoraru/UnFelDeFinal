using InternProj.Domain;
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
        public int Id { get; set; }
        public string Name { get; set; }
        public string BanckAccount { get; set; }

        public List<AddressContactCityHallDto> AddressCityHall { get; set; }
    }
}
