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
    public class BankAccountService
    {
        private readonly IbanRepository ibanRepository;
        private readonly IMapper mapper;

        public BankAccountService(IbanRepository ibanRepository, IMapper mapper)
        {
            this.ibanRepository = ibanRepository;
            this.mapper = mapper;
        }

        public Iban GetBankAccountById(int id)
        {
            return ibanRepository.GetIbanByIdWithCityHallAndElectronicService(id);
        }

        public IList<Iban> GetBankAccountsOfCityHall(FilterOptions filterOptions)
        {
            IList<Iban> ibans;
            int searchTerm;

            if (!string.IsNullOrWhiteSpace(filterOptions.SearchTerm))
            {
                bool success = Int32.TryParse(filterOptions.SearchTerm, out searchTerm);

                if (success)
                {
                    ibans = ibanRepository.GetIbansOfCityHall(searchTerm);
                    return ibans;
                }

                return null;
            }
            else
            {
                ibans = ibanRepository.GetAll();
            }

            return ibans;
        }
    }
}
