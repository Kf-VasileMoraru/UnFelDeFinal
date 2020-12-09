
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternProj.Domain
{
    public class ApplicationUser : IdentityUser
    {
        public string City { get; set; }
        public string StreetHouseNumber { get; set; }
        public string PostalColde { get; set; }

        //navigation property
        public virtual ICollection<BillingDetails> BillingDetails { get; set; }
    }
}
