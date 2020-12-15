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
        private readonly ICityHallService cityHallService;
        private readonly IMapper mapper;

        public CityHallController(ICityHallService cityHallService, IMapper mapper)
        {
            this.cityHallService = cityHallService;
            this.mapper = mapper;
        }

        [HttpGet("{id}")]
        public IActionResult GetCityHallById(int id)
        {
            var cityHall = cityHallService.GetCityHallById(id);
            if (cityHall == null)
            {
                return NotFound();
            }

            var result = mapper.Map<CityHallDto>(cityHall);

            return Ok(result);
        }

        [HttpGet("getAllCityHall")]
        public IActionResult Get([FromQuery] FilterOptions filterOptions)
        {
            var cityHalls = cityHallService.GetAllCityHall();
            var result = cityHalls.Select(cityHalls => mapper.Map<CityHallDto>(cityHalls));

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCityHallById(int id)
        {
            cityHallService.DeleteCityHallById(id);

            return NoContent();
        }


        [HttpPost]
        public IActionResult Post([FromBody] CreateCityHallDto dto)
        {
            var cityHall = cityHallService.AddNewCityHall(dto);

            if (cityHall == null)
            {
                return NotFound("CityHall with such name already exists");
            }

            var result = mapper.Map<CityHallDto>(cityHall);

            return CreatedAtAction(nameof(Get), new { id = cityHall.Id }, result);
        }

        [HttpPut("{id}")]
        [ApiExceptionFilter]
        public IActionResult Put(int id, [FromBody] CreateCityHallDto dto)
        {
            var eService = cityHallService.UpdateCityhall(id, dto);

            if (eService == null)
            {
                return NotFound("Did not found such CityHall Service");
            }

            return NoContent();
        }


    }
}
