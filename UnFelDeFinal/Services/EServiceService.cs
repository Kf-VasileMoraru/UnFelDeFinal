using AutoMapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnFelDeFinal.Domain;
using UnFelDeFinal.Extern.Dtos;
using UnFelDeFinal.Models;

namespace UnFelDeFinal.Services
{
    public class EServiceService : IEServiceService
    {
        private readonly IRepository<Eservice> eseviceRepository;
        private readonly IMapper mapper;

        public EServiceService(IRepository<Eservice> eseviceRepository, IMapper mapper)
        {
            this.eseviceRepository = eseviceRepository;
            this.mapper = mapper;
        }

        public Eservice GetEserviceById(int id)
        {
            return eseviceRepository.Find(id);
        }

        public IList<Eservice> GetEservice(FilterOptions filterOptions)
        {
            IQueryable<Eservice> eservices;

            if (!string.IsNullOrWhiteSpace(filterOptions.SearchTerm))
            {
                eservices = eseviceRepository.FindAll(e => e.Name.Contains(filterOptions.SearchTerm));
            }
            else
            {
                eservices = eseviceRepository.GetAll();
            }

            switch (filterOptions.Order)
            {
                case SortOrder.Ascending:
                    eservices = eservices.OrderBy(e => e.Name);
                    break;
                case SortOrder.Descending:
                    eservices = eservices.OrderByDescending(e => e.Name);
                    break;
            }

            return eservices.ToList();
        }

        public Eservice AddNewEservice(CreateEserviceDto createEserviceDto)
        {
            if (CheckIfTrezorExist(createEserviceDto.TreasureAccount))
                return null;


            var eservice = mapper.Map<Eservice>(createEserviceDto);

            //var employee = new Employee
            //{
            //    Idnp = createEmployeeDto.Idnp,
            //    Name = createEmployeeDto.Name,
            //    Position = createEmployeeDto.Position,
            //    Salary = createEmployeeDto.Salary
            //};

            eseviceRepository.Add(eservice);
            eseviceRepository.Save();
            return eservice;
        }


        private bool CheckIfTrezorExist(string trez)
        {
            return eseviceRepository.Find(x => x.TreasureAccount == trez) != null;
        }
    }
}
