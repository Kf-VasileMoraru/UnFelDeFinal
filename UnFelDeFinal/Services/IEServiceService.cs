using System.Collections.Generic;
using UnFelDeFinal.Domain;
using UnFelDeFinal.Extern.Dtos;
using UnFelDeFinal.Models;

namespace UnFelDeFinal.Services
{
    public interface IEServiceService
    {
        ElectronicService AddNewEservice(CreateElectronicServiceDto dto);
        IList<ElectronicService> GetEservice(FilterOptions filterOptions);
        ElectronicService GetEserviceById(int id);
        bool RemoveElectronicServiceById(int id);
        ElectronicService UpdateElectronicServiceDetails(int id, CreateElectronicServiceDto dto);
    }
}