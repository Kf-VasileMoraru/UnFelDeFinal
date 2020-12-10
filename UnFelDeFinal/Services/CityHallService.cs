using AutoMapper;
using InternProj.Db.Repositories.Interfaces;
using InternProj.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternProj.WebApi.Services
{
    public class CityHallService
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
    }
}
