using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternProj.WebApi.Extern.Dtos.CursValutar
{
    public class ExchangeRateDto
    {
        public string Currency { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
    }
}
