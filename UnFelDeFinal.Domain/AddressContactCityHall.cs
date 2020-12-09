
using System.Collections.Generic;

namespace InternProj.Domain
{
    public class AddressContactCityHall : BaseEntity
    {
        public string City { get; set; }
        public string StreetHouseNumber { get; set; }
        public string PostalColde { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public string Phone3 { get; set; }
        public string Email1 { get; set; }
        public string Email2 { get; set; }
        public string Email3 { get; set; }
        public string Web1 { get; set; }
        public string Web2 { get; set; }
        public string Web3 { get; set; }

        public int? CityHallId { get; set; }

        //navigation property
        public virtual CityHall CityHall { get; set; }
    }
}
