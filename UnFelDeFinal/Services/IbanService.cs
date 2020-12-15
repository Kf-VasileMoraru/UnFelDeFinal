using AutoMapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InternProj.Domain;
using InternProj.WebApi.Exceptions;
using InternProj.Extern.Dtos;
using InternProj.Models;
using InternProj.WebApi.Services;
using InternProj.Db.Repositories.Interfaces;
using InternProj.Db.Repositories.Implementation;

namespace InternProj.WebApi.Services
{
    public class IbanService
    {
        private readonly IbanRepository ibanRepository;
        private readonly IMapper mapper;

        public IbanService(IbanRepository ibanRepository, IMapper mapper)
        {
            this.ibanRepository = ibanRepository;
            this.mapper = mapper;
        }

        public Iban GetIbanById(int id)
        {
            return ibanRepository.GetIbanByIdWithCityHallAndElectronicService(id);
        }

        public IList<Iban> GetIban(FilterOptions filterOptions)
        {
            IQueryable<Iban> iban;

            if (!string.IsNullOrWhiteSpace(filterOptions.SearchTerm))
            {
                iban = ibanRepository.FindWithFilter(filterOptions.SearchTerm);
            }
            else
            {
                iban = ibanRepository.GetAll();
            }

            return iban.ToList();
        }
    }
}
