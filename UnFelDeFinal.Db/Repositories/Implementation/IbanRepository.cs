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


        public Iban GetIbanById(int ibanId)
        {
            var iban = _dbSet.AsNoTracking()
                        .Include(x => x.ElectronicService)
                        .Include(x => x.CityHall)
                        .Where(x => x.IsDeleted == false)
                        .FirstOrDefault(x => x.Id == ibanId);

            return iban;
        }

        public IList<Iban> GetIbansOfCityHall(int searchTerm)
        {
            var listIban = _dbSet.Where(x => x.CityHallId == searchTerm)
                .Include(x => x.ElectronicService)
                .Include(x => x.CityHall)
                .Where(x => x.IsDeleted == false);

            return listIban.ToList();
        }

        public new void Delete(Iban entity)
        {
            entity.IsDeleted = true;
            Update(entity);
        }
    }
}




