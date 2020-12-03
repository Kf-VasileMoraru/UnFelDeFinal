using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternProj.Domain
{
    public class ContactType : BaseEntity
    {
        public string Type { get; set; }

        //navigation property
        public virtual ICollection<ContactPerson> ContactPerson { get; set; }
        public virtual ICollection<ContactCityHall> ContactCityHall { get; set; }
    }
}
