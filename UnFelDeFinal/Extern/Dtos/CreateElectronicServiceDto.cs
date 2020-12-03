using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternProj.Extern.Dtos
{
    public class CreateElectronicServiceDto
    {
        [StringLength(450, MinimumLength = 5, ErrorMessage = "Name min 5 to max 450 char")]
        [Required]
        public string Name { get; set; }
        
        [Required]
        [Range(1, 10000, ErrorMessage = "Suma min 1 to 1000 lei")]
        public decimal Amount { get; set; }

        [StringLength(15, MinimumLength = 5, ErrorMessage = "Name min 5 to max 15 char")]
        public string TreasureAccount { get; set; }
    }
}
