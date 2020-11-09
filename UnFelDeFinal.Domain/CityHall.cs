using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnFelDeFinal.Domain
{
    public class CityHall : BaseEntity
    {

        [StringLength(50, MinimumLength = 5,
        ErrorMessage = "CityHall Name should be minimum 3 characters and a maximum of 50 characters")]
        [DataType(DataType.Text)]
        [Required]
        public string Name { get; set; }

        // [MaxLength(20)]
        [Column(TypeName = "varchar(20)")]
        public string BanckAccount { get; set; }

        public int? AddressCityHallId1 { get; set; }
        public int? AddressCityHallId2 { get; set; }

        //navigation property
        public virtual ICollection<BillingDetails> BillingDetails { get; set; }
        public virtual ICollection<Iban> Iban { get; set; }
        public virtual AddressCityHall AddressCityHall { get; set; }
        public virtual ICollection<ContactCityHall> ContactCityHall { get; set; }
    }
}
