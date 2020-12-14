using InternProj.Db.Repositories.Interfaces;
using InternProj.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternProj.Db.Repositories.Implementation
{
    public class CityHallRepository : Repository<CityHall>, ICityHallRepository
    {

        public CityHallRepository(EServicesDbContext dbContext) : base(dbContext)
        {

        }


        public CityHall GetCityHallIdWithAdressCityHall(int cityHallId)
        {
            var cityHall = _dbSet.AsNoTracking()
                        .Include(x => x.AddressCityHall)
                        .Where(x=>x.IsDeleted==false)
                        .FirstOrDefault(x => x.Id == cityHallId);

            return cityHall;
        }

        public IQueryable<CityHall> GetAllCityHall()
        {
            var cityHalls = _dbSet.AsNoTracking()
                        .Include(x => x.AddressCityHall)
                        .Where(x => x.IsDeleted == false);

            return cityHalls;
        }

        public new void Delete(CityHall entity)
        {
            entity.IsDeleted = true;
        }



    }
}
