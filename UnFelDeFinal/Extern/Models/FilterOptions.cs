using Microsoft.Data.SqlClient;
using Newtonsoft.Json;

namespace UnFelDeFinal.Models
{
    public class FilterOptions
    {
        public string SearchTerm { get; set; }

        public SortOrder Order { get; set; }
    }
}
