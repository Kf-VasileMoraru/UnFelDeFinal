using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnFelDeFinal.Domain;
using UnFelDeFinal.Models;

namespace UnFelDeFinal.Services
{
    public class EServiceService : IEServiceService
    {
        private readonly IRepository<Eservice> eseviceRepository;

        public EServiceService(IRepository<Eservice> eseviceRepository)
        {
            this.eseviceRepository = eseviceRepository;
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
    }
}
