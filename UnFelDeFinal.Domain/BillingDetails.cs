using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnFelDeFinal.Domain
{
    public class BillingDetails : BaseEntity
    {
        public bool IsPayed { get; set; }
        public DateTime? IsPayedDataTime { get; set; }
        public int? ElectronicServiceId { get; set; }
        public int? CityHallId { get; set; }
        public int? ElectronicServicePaymentInfoId { get; set; }
        public int IbanId { get; set; }

        //navigation property
        public virtual ElectronicServicePaymentInfo ElectronicServicePaymentInfo { get; set; }
        public virtual ElectronicService ElectronicService { get; set; }
        public virtual CityHall CityHall { get; set; }
        public virtual Iban Iban { get; set; }
    }
}
