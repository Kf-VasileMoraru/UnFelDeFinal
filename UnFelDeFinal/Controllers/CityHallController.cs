using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using InternProj.WebApi.Exceptions;
using InternProj.Extern.Dtos;
using InternProj.Models;
using InternProj.WebApi.Services;

namespace InternProj.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityHallController : ControllerBase
    {
        private readonly  CityHallService cityHallService;
        private readonly IMapper mapper;

        public CityHallController(CityHallService cityHallService, IMapper mapper)
        {
            this.cityHallService = cityHallService;
            this.mapper = mapper;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var cityHall = cityHallService.GetCityHallById(id);
            if (cityHall == null)
                return NotFound();

            //var result = mapper.Map<ElectronicServiceDto>(eService);
            return Ok(cityHall);
        }


    }
}
