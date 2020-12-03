using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternProj.Domain
{
    public class AddressPerson : BaseEntity
    {
        public string City { get; set; }
        public string Street { get; set; }
        public string HouseNumber { get; set; }
        public string PostalColde { get; set; }
        public int? ElectronicServicePaymentInfoId { get; set; }


        //navigation property

        public virtual ElectronicServicePaymentInfo ElectronicServicePaymentInfo { get; set; }
    }
}