using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnFelDeFinal.Domain
{
    public enum PayerType
    {
        Pers_Fizica = 0,
        Pers_Juridica = 1,
    }

    public class PayerInfo
    {
        public int Id { get; set; }
        public string PayerName { get; set; }
        public string Idnx { get; set; }
        public PayerType PayerType { get; set; }
        public float Amount { get; set; }
        public DateTime DataTime { get; set; }
        public string Comment { get; set; }

        //navigation property
        public virtual ICollection<ServiceList> ServiceLists { get; set; }
    }
}
