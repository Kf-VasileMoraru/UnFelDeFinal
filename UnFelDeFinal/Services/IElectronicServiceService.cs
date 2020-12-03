using System.Collections.Generic;
using InternProj.Domain;
using InternProj.Extern.Dtos;
using InternProj.Models;

namespace InternProj.Services
{
    public interface IElectronicServiceService
    {
        ElectronicService AddNewEservice(CreateElectronicServiceDto dto);
        IList<ElectronicService> GetEservice(FilterOptions filterOptions);
        ElectronicService GetEserviceById(int id);
        bool RemoveElectronicServiceById(int id);
        ElectronicService UpdateElectronicServiceDetails(int id, CreateElectronicServiceDto dto);
    }
}