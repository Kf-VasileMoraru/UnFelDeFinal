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
using System.Xml.Linq;
using InternProj.WebApi.Extern.Dtos.CursValutar;

namespace InternProj.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExternalService : ControllerBase
    {
        private readonly IMapper mapper;

        public ExternalService( IMapper mapper)
        {
            this.mapper = mapper;
        }


        [HttpGet("exchangeRate")]
        [ApiExceptionFilter]
        public IActionResult Get()
        {
            var currencies = new List<string> { "EUR", "USD", "RUB", "RON", "UAH" };
            var curentData = DateTime.Today.ToString("dd.MM.yyyy");

            XDocument doc = null;

            try
            {
                doc = XDocument.Load($"https://www.bnm.md/ro/official_exchange_rates?get_xml=1&date={curentData}");
            }
            catch (Exception e)
            {
                throw new NotFoundException("BNM server not answer");
            }
                

            var result = doc.Descendants("Valute").Select(x =>
               new ExchangeRateDto
               {
                   Currency = x.Element("CharCode").Value.ToString(),
                   Name = x.Element("Name").Value.ToString(),
                   Value = x.Element("Value").Value.ToString()
               }).Where(x => currencies.Contains(x.Currency)).ToList();


            return Ok(result);
        }

    };
}
