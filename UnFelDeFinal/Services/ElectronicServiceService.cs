﻿using AutoMapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnFelDeFinal.Domain;
using UnFelDeFinal.Exceptions;
using UnFelDeFinal.Extern.Dtos;
using UnFelDeFinal.Models;

namespace UnFelDeFinal.Services
{
    public class ElectronicServiceService : IElectronicServiceService
    {
        private readonly IRepository<ElectronicService> eseviceRepository;
        private readonly IMapper mapper;

        public ElectronicServiceService(IRepository<ElectronicService> eseviceRepository, IMapper mapper)
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

        public ElectronicService AddNewEservice(CreateElectronicServiceDto dto)
        {
            if (CheckIfTrezorExist(dto.TreasureAccount))
                return null;


            var eservice = mapper.Map<ElectronicService>(dto);

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

        public ElectronicService UpdateElectronicServiceDetails(int id, CreateElectronicServiceDto dto)
        {
            var eservice = eseviceRepository.Find(id);
            if (eservice == null)
                throw new NotFoundException("Electornic Service not found!");

            //eservice = mapper.Map<ElectronicService>(dto);
            eservice.Amount = dto.Amount;
            // eservice.TreasureAccount = dto.TreasureAccount; 
            // TODO: Do this later 2
            eservice.Name = dto.Name;

            eseviceRepository.Update(eservice);
            eseviceRepository.Save();
            return eservice;
        }

        public bool RemoveElectronicServiceById(int id)
        {
            var eservice = eseviceRepository.Find(id);
            if (eservice != null)
            {
                eseviceRepository.Delete(eservice);
                eseviceRepository.Save();
                return true;
            }
            else return false;
        }


        private bool CheckIfTrezorExist(string trez)
        {
            return eseviceRepository.Find(x => x.TreasureAccount == trez) != null;
        }
    }
}