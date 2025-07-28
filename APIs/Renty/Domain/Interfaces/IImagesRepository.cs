using Renty.Domain.Entities;

namespace Renty.Domain.Interfaces{
public interface IImagesRepository:IGenericRepository<Image>
{
     Task<List<Image>> GetAllByProductIdAsync(int? id);
}
}