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
            var x = _dbSet.AsNoTracking()
                       
                       .FirstOrDefault(x => x.Id == cityHallId);

           
            var y = new CityHall
           {
               Id = x.Id,
               Name = x.Name,
               BanckAccount = x.BanckAccount,
               AddressCityHall = x.AddressCityHall

            };




            return y;
        }
    }
}
