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
        private readonly IRepository<ElectronicService> eseviceRepository;
        private readonly IMapper mapper;

        public EServiceService(IRepository<ElectronicService> eseviceRepository, IMapper mapper)
        {
            this.eseviceRepository = eseviceRepository;
            this.mapper = mapper;
        }

        public ElectronicService GetEserviceById(int id)
        {
            return eseviceRepository.Find(id);
        }

        public IList<ElectronicService> GetEservice(FilterOptions filterOptions)
        {
            IQueryable<ElectronicService> eservices;

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

        public ElectronicService AddNewEservice(CreateEserviceDto createEserviceDto)
        {
            if (CheckIfTrezorExist(createEserviceDto.TreasureAccount))
                return null;


            var eservice = mapper.Map<ElectronicService>(createEserviceDto);

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
