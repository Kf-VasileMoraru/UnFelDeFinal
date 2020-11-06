using System.Collections.Generic;
using UnFelDeFinal.Domain;
using UnFelDeFinal.Models;

namespace UnFelDeFinal.Services
{
    public interface IEServiceService
    {
        IList<Eservice> GetEservice(FilterOptions filterOptions);
        Eservice GetEserviceById(int id);
    }
}