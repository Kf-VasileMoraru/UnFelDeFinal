using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternProj.Domain
{
    public class ContactPerson : BaseEntity
    {
        public string ContactData { get; set; }
        public int? ContactTypeId0 { get; set; }
        public int? ContactTypeId1 { get; set; }
        public int? ElectronicServicePaymentInfoId { get; set; }



        //navigation property
        public virtual ContactType ContactType { get; set; }
        public virtual ElectronicServicePaymentInfo ElectronicServicePaymentInfo { get; set; }
    }
}
