using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UnFelDeFinal.Extern.Dtos;
using UnFelDeFinal.Models;
using UnFelDeFinal.Services;

namespace UnFelDeFinal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EserviceController : ControllerBase
    {
        private readonly IEServiceService eServiceService;
        private readonly IMapper mapper;

        public EserviceController(IEServiceService eServiceService, IMapper mapper )
        {
            this.eServiceService = eServiceService;
            this.mapper = mapper;
        }


        // GET: api/<ValuesController>
        [HttpGet]
        public IActionResult Get([FromQuery] FilterOptions filterOptions)
        {
            var eService = eServiceService.GetEservice(filterOptions);
            var result = eService.Select(e => mapper.Map<EserviceDto>(e));

            return Ok(result);
        }


        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var employee = eServiceService.GetEserviceById(id);
            if (employee == null)
                return NotFound();

            var result = mapper.Map<EserviceDto>(employee);
            return Ok(result);
        }


        // POST api/<EmployeesController>
        [HttpPost]
        public IActionResult Post([FromBody] CreateEserviceDto dto)
        {
            var employee = eServiceService.AddNewEservice(dto);

            if (employee == null)
                return BadRequest("Service with such Trez already exists");

            var result = mapper.Map<EserviceDto>(employee);

            return CreatedAtAction(nameof(Get), new { id = employee.Id }, result);
        }


    }
}
