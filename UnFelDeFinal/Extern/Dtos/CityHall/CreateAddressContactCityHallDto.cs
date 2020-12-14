using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternProj.WebApi.Extern.Dtos.CityHall
{
    public class CreateAddressContactCityHallDto
    {
        [Required]
        public string City { get; set; }
        [Required]
        public string StreetHouseNumber { get; set; }
        [Required]
        public string PostalCode { get; set; }
        [Required]
        public string Phone0 { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        [Required]
        public string Email0 { get; set; }
        public string Email1 { get; set; }
        public string Email2 { get; set; }
        public string Web0 { get; set; }
        public string Web1 { get; set; }
        public string Web2 { get; set; }
    }
}
