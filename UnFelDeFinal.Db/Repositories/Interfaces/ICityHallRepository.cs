using InternProj.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternProj.Db.Repositories.Interfaces
{
    public interface ICityHallRepository : IRepository<CityHall>
    {
        CityHall GetCityHallIdWithAdressCityHall(int cityHallId);
        IQueryable<CityHall> GetAllCityHall();
    }
}
