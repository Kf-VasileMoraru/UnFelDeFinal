using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternProj.WebApi.Extern.Dtos.CityHall
{
    public class AddressContactCityHallDto
    {
        public string City { get; set; }
        public string StreetHouseNumber { get; set; }
        public string PostalCode { get; set; }
        public string Phone0 { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public string Email0 { get; set; }
        public string Email1 { get; set; }
        public string Email2 { get; set; }
        public string Web0 { get; set; }
        public string Web1 { get; set; }
        public string Web2 { get; set; }
    }
}
