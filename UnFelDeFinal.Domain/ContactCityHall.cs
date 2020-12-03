using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternProj.Domain
{
    public class ContactCityHall : BaseEntity
    {
        public string ContactData { get; set; }
        public int? CityHallId { get; set; }
        public int? ContactTypeId0 { get; set; }
        public int? ContactTypeId1 { get; set; }
        public int? ContactTypeId2 { get; set; }
        public int? ContactTypeId3 { get; set; }
        public int? ContactTypeId4 { get; set; }
        public int? ContactTypeId5 { get; set; }

        //navigation property
        public virtual ContactType ContactType { get; set; }
        public virtual CityHall CityHall { get; set; }

    }
}
