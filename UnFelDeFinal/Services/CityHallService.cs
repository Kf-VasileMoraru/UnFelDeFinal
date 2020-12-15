using AutoMapper;
using InternProj.Db.Repositories.Interfaces;
using InternProj.Domain;
using InternProj.Extern.Dtos;
using InternProj.WebApi.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternProj.WebApi.Services
{
    public class CityHallService : ICityHallService
    {
        private readonly ICityHallRepository cityHallRepository;
        private readonly IMapper mapper;

        public CityHallService(ICityHallRepository cityHallRepository, IMapper mapper)
        {
            this.cityHallRepository = cityHallRepository;
            this.mapper = mapper;
        }


        public CityHall GetCityHallById(int id)
        {
            CityHall cityHall = cityHallRepository.GetCityHallIdWithAdressCityHall(id);

            return cityHall;
        }

        public IList<CityHall> GetAllCityHall()
        {
            IQueryable<CityHall> cityHall;

            cityHall = cityHallRepository.GetAllCityHall();

            return cityHall.ToList();
        }

        public bool DeleteCityHallById(int id)
        {
            var cityHall = cityHallRepository.GetCityHallIdWithAdressCityHall(id);


            if (cityHall == null)
            {
                return false;
            }

            cityHallRepository.Delete(cityHall);
            cityHallRepository.Update(cityHall);
            cityHallRepository.Save();
            return true;
        }

        public CityHall AddNewCityHall(CreateCityHallDto dto)
        {
            if (CheckIfCityHallExist(dto.Name))
                return null;

            var cityHall = mapper.Map<CityHall>(dto);

            cityHallRepository.Add(cityHall);
            cityHallRepository.Save();

            return cityHall;
        }


        public CityHall UpdateCityhall(int id, CreateCityHallDto dto)
        {
            var cityHall = cityHallRepository.Find(id);
            if (cityHall == null)
                throw new NotFoundException("City Hall not found!");

            cityHall = mapper.Map<CityHall>(dto);

            cityHall.Id = id;

            cityHallRepository.Update(cityHall);
            cityHallRepository.Save();
            return cityHall;
        }


        private bool CheckIfCityHallExist(string name)
        {
            return cityHallRepository.Find(x => x.Name == name) != null;
        }

    }
}