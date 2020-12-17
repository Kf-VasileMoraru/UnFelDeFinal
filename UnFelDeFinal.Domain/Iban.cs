using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternProj.Domain
{
    public class Iban : BaseEntity
    {
        public string Name { get; set; }
        public int? ElectronicServiceId { get; set; }
        public int? CityHallId { get; set; }
        
        [DefaultValue(false)]
        public bool IsDeleted { get; set; }

        //navigation property
        public virtual ICollection<BillingDetails> BillingDetails { get; set; }

        public virtual ElectronicService ElectronicService { get; set; }
        public virtual CityHall CityHall { get; set; }
    }
}
