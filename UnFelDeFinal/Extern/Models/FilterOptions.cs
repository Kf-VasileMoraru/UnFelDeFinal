using Microsoft.Data.SqlClient;
using Newtonsoft.Json;

namespace InternProj.Models
{
    public class FilterOptions
    {
        public string SearchTerm { get; set; }

        public SortOrder Order { get; set; }
    }
}
