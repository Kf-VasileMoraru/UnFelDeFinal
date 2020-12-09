using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternProj.Domain
{
    public enum PayerType
    {
        Pers_Fizica = 0,
        Pers_Juridica = 1,
    }

    public class ElectronicServicePaymentInfo : BaseEntity
    {
        
        public string PayerName { get; set; }
        public string Idnx { get; set; }
        public PayerType PayerType { get; set; }
        public decimal Amount { get; set; }
        public DateTime DataTime { get; set; }
        public string Comment { get; set; }

        public int? AddressPersonId { get; set; }

        //navigation property
        public virtual ICollection<BillingDetails> BillingDetails { get; set; }
        public virtual AddressPerson AddressPerson { get; set; }
    }
}
