using System.Collections.Generic;
using UnFelDeFinal.Domain;
using UnFelDeFinal.Extern.Dtos;
using UnFelDeFinal.Models;

namespace UnFelDeFinal.Services
{
    public interface IEServiceService
    {
        Eservice AddNewEservice(CreateEserviceDto createEserviceDto);
        IList<Eservice> GetEservice(FilterOptions filterOptions);
        Eservice GetEserviceById(int id);
    }
}