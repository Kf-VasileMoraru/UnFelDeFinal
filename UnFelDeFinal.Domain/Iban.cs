using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnFelDeFinal.Domain
{
    public class Iban
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? ServiceId { get; set; }
        public int? CityHallId { get; set; }

        //navigation property
        public virtual ICollection<ServiceList> ServiceLists { get; set; }

        public virtual Eservice Service { get; set; }
        public virtual CityHall CityHall { get; set; }
    }
}
