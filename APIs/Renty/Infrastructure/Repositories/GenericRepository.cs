
using Microsoft.EntityFrameworkCore;
using Renty.Domain.Interfaces;
using Renty.Infrastructure.Data;

namespace Renty.Infrastructure.Repositories
{

public class GenericRepository<TEntity> : IGenericRepository<TEntity>
where TEntity : class
{
    private readonly ApplicationDbContext _context;

    public GenericRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<TEntity>> GetAllAsync()
    {
        return await  _context.Set<TEntity>().AsNoTracking().ToListAsync();
    }


    public async Task<TEntity?> GetByIdAsync(int? id)
    {
        return await  _context.Set<TEntity>().FindAsync(id);
    }

    public async Task AddAsync(TEntity entity)
    {
       await _context.Set<TEntity>().AddAsync(entity);
    }

    public async Task AddRangeAsync(List<TEntity> entities)
    {
       await _context.Set<TEntity>().AddRangeAsync(entities);
    }

    public Task UpdateAsync(TEntity entity)
    {
        _context.Set<TEntity>().Update(entity);
        return Task.CompletedTask;
    }

   public Task UpdateRangeAsync(List<TEntity> entities)
    {
        _context.Set<TEntity>().UpdateRange(entities);
        return Task.CompletedTask;
    }

    public  async Task DeleteAsync(int id)
    {
        var entity =  await _context.Set<TEntity>().FindAsync(id);
        if (entity != null)
        {
             _context.Set<TEntity>().Remove(entity);
        }
    }


    }
}