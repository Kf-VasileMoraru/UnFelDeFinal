using InternProj.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternProj.Db.Repositories.Implementation
{


        public class IbanRepository : Repository<Iban> //, ICityHallRepository
        {
        public IbanRepository(EServicesDbContext dbContext) : base(dbContext)
        {

        }


        public Iban GetIbanByIdWithCityHallAndElectronicService(int ibanId)
        {
            var iban = _dbSet.AsNoTracking()
                        .Include(x => x.ElectronicService)
                        .Include(x => x.CityHall)
                        .FirstOrDefault(x => x.Id == ibanId);

            return iban;
        }

        public IQueryable<Iban> FindWithFilter(string searchTerm)
        {
            var listIban = _dbSet.Where(x => x.CityHallId == Int32.Parse(searchTerm))
                .Include(x => x.ElectronicService)
                .Include(x => x.CityHall);



            return listIban;
        }
    }
}




