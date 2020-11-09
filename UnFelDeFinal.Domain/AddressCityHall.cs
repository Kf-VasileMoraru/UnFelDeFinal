
using System.Collections.Generic;

namespace UnFelDeFinal.Domain
{
    public class AddressCityHall : BaseEntity
    {
        public string City { get; set; }
        public string Street { get; set; }
        public string HouseNumber { get; set; }
        public string PostalColde { get; set; }

        //navigation property
        public virtual ICollection<CityHall> CityHall { get; set; }
    }
}
