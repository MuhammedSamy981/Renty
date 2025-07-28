using Renty.Domain.Entities;

namespace Renty.Domain.Interfaces{
public interface ICitiesRepository:IGenericRepository<City>
{
   Task<List<City>> GetAllByCountryIdAsync(int id);
}

}