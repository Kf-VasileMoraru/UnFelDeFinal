using InternProj.WebApi.Extern.Dtos.CityHall;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternProj.Extern.Dtos
{
    public class CreateCityHallDto
    {
        [StringLength(450, MinimumLength = 5, ErrorMessage = "Name min 5 to max 450 char")]
        [Required]
        public string Name { get; set; }
        
        [Required]
        public string BanckAccount { get; set; }
        
        [Required]
        public List<CreateAddressContactCityHallDto> AddressCityHall { get; set; }
    }
}
