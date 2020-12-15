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
    public class BankAccountController : ControllerBase
    {

        private readonly BankAccountService ibanService;
        private readonly IMapper mapper;

        public BankAccountController(BankAccountService ibanService, IMapper mapper)
        {
            this.ibanService = ibanService;
            this.mapper = mapper;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var bankAccount = ibanService.GetBankAccountById(id);
            if (bankAccount == null)
            {
                return NotFound();
            }

            var result = mapper.Map<BankAccountDto>(bankAccount);
            return Ok(result);
        }

        [HttpGet]
        public IActionResult Get([FromQuery] FilterOptions filterOptions)
        {
            var bankAccounts = ibanService.GetBankAccountsOfCityHall(filterOptions);
            if (bankAccounts == null)
            {
                return NotFound();
            }

            //var result = iban.Select(x => mapper.Map<IbanDto>(iban));

            return Ok(bankAccounts);
        }

    }
}
