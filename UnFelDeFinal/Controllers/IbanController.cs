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
using InternProj.WebApi.Extern.Dtos.Iban;

namespace InternProj.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IbanController : ControllerBase
    {

        private readonly IbanService ibanService;
        private readonly IMapper mapper;

        public IbanController(IbanService ibanService, IMapper mapper)
        {
            this.ibanService = ibanService;
            this.mapper = mapper;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var iban = ibanService.GetIbanById(id);
            if (iban == null)
                return NotFound();

            var result = mapper.Map<IbanDto>(iban);
            return Ok(result);
        }

        [HttpGet]
        public IActionResult Get([FromQuery] FilterOptions filterOptions)
        {
            var iban = ibanService.GetIban(filterOptions);

            var result = iban.Select(x => mapper.Map<IbanDto>(iban));

            return Ok(result);
        }

    }
}
