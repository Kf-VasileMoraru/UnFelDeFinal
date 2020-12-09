using InternProj.Domain;
using InternProj.Extern.Dtos;
using InternProj.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternProj.WebApi.Services
{
    public interface ICityHall
    {
        CityHall AddNewCityHall(CreateCityHallDto dto);
        IList<CityHall> GetCityHall(FilterOptions filterOptions);
        CityHall GetCityHallById(int id);
        bool RemoveCityHallById(int id);
        CityHall UpdateCityHallDetails(int id, CreateCityHallDto dto);
    }
}
