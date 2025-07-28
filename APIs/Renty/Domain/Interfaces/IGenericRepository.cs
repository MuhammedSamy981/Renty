namespace Renty.Domain.Interfaces{
public interface IGenericRepository<TEntity>
where TEntity:class
{
    Task<List<TEntity>> GetAllAsync();
    Task<TEntity?> GetByIdAsync(int? id);
    Task AddAsync(TEntity entity);
    Task AddRangeAsync(List<TEntity> entities);
    Task UpdateAsync(TEntity entity);
    Task UpdateRangeAsync(List<TEntity> entities);
    Task DeleteAsync(int id);

          //  Task<IEnumerable<Product>> GetAllProductsAsync();  

}
}