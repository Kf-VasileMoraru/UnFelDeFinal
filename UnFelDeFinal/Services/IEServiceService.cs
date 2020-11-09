using System.Collections.Generic;
using UnFelDeFinal.Domain;
using UnFelDeFinal.Extern.Dtos;
using UnFelDeFinal.Models;

namespace UnFelDeFinal.Services
{
    public interface IEServiceService
    {
        ElectronicService AddNewEservice(CreateEserviceDto createEserviceDto);
        IList<ElectronicService> GetEservice(FilterOptions filterOptions);
        ElectronicService GetEserviceById(int id);
    }
}