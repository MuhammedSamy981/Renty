using Renty.Domain.Entities;

namespace Renty.Domain.Interfaces{
public interface IAreasRepository:IGenericRepository<Area>
{
   Task<List<Area>> GetAllByCityIdAsync(int id);
   Task<List<Area>> GetAllByCityNameAsync(string name);
}
}