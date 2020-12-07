using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternProj.WebApi.Extern.Dtos.Roles
{
    public class ToggleUserCityHallAdminRole
    {
        public string UserEmail { get; set; }
        public bool Add { get; set; }

    }
}
