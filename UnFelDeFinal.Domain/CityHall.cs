using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.ComponentModel;

namespace InternProj.Domain
{
    public class CityHall : BaseEntity
    {

        [StringLength(450, MinimumLength = 5,
        ErrorMessage = "CityHall Name should be minimum 5 characters and a maximum of 50 characters")]
        [DataType(DataType.Text)]
        [Required]
        public string Name { get; set; }

        // [MaxLength(20)]
        [Column(TypeName = "varchar(20)")]
        public string BanckAccount { get; set; }
       
        [DefaultValue(false)]
        public bool IsDeleted { get; set; }


        //navigation property
        public virtual ICollection<BillingDetails> BillingDetails { get; set; }
        public virtual ICollection<Iban> Iban { get; set; }
        public virtual ICollection<AddressContactCityHall> AddressCityHall { get; set; }
    }
}

