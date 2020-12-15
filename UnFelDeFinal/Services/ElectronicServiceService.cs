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

namespace InternProj.WebApi.Services
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
            IList<ElectronicService> eservices;

            if (!string.IsNullOrWhiteSpace(filterOptions.SearchTerm))
            {
                eservices = eseviceRepository.FindAll(e => e.Name.Contains(filterOptions.SearchTerm));
            }
            else
            {
                eservices = eseviceRepository.GetAll();
            }

            return eservices;
        }

        public ElectronicService AddNewEservice(CreateElectronicServiceDto dto)
        {
            if (CheckIfTrezorExist(dto.TreasureAccount))
                return null;


            var eservice = mapper.Map<ElectronicService>(dto);

            eseviceRepository.Add(eservice);
            return eservice;
        }

        public ElectronicService UpdateElectronicService(int id, CreateElectronicServiceDto dto)
        {
            var eservice = eseviceRepository.Find(id);
            if (eservice == null)
            { 
                throw new NotFoundException("Electornic Service not found!"); 
            }

            eservice = mapper.Map<ElectronicService>(dto);
            eservice.Id = id;

            eseviceRepository.Update(eservice);
            return eservice;
        }

        public bool RemoveElectronicServiceById(int id)
        {
            var eservice = eseviceRepository.Find(id);

            if (eservice == null)
            {
                return false;
            }

            eseviceRepository.Delete(eservice);
            return true;
        }


        private bool CheckIfTrezorExist(string trez)
        {
            return eseviceRepository.Find(x => x.TreasureAccount == trez) != null;
        }
    }
}
