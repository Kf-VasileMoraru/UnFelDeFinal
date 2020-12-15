using InternProj.Domain;
using InternProj.Extern.Dtos;
using System.Collections.Generic;

namespace InternProj.WebApi.Services
{
    public interface ICityHallService
    {
        CityHall AddNewCityHall(CreateCityHallDto dto);
        bool DeleteCityHallById(int id);
        IList<CityHall> GetAllCityHall();
        CityHall GetCityHallById(int id);
        CityHall UpdateCityhall(int id, CreateCityHallDto dto);
    }
}