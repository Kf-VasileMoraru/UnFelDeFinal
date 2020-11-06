using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnFelDeFinal.Domain
{
    public class ServiceList : BaseEntity
    {
        public bool IsPayed { get; set; }
        public DateTime? IsPayedDataTime { get; set; }
        public int? ServiceId { get; set; }
        public int? CityHallId { get; set; }
        public int? PayerInfoId { get; set; }
        public int IbanId { get; set; }

        //navigation property
        public virtual PayerInfo PayerInfo { get; set; }
        public virtual Eservice Service { get; set; }
        public virtual CityHall CityHall { get; set; }
        public virtual Iban Iban { get; set; }
    }
}
