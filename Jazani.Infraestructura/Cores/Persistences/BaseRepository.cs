using Jazani.Domain.Cores.Models;
using Jazani.Domain.Cores.Repositories;
using Jazani.Infraestructure.Cores.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Jazani.Infraestructure.Cores.Persistences;
public abstract class BaseRepository<T, ID> : IBaseRepository<T, ID> where T : CoreModel<ID>
{
    private readonly ApplicationDbContext _dbContext;
    private readonly DbSet<T> _dbset;

    public BaseRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
        _dbset = _dbContext.Set<T>();
    }

    public virtual async Task<T> DisabledByIdAsync(ID id)
    {
        T entity = await _dbset.FindAsync(id) ?? throw new Exception($"No se econtro informacion para el id: {id}");
        entity.State = false;        

        _dbset.Update(entity);
        await _dbContext.SaveChangesAsync();

        return entity;
    }

    public async Task<IReadOnlyList<T>> FindAllAsync()
    {
        return await _dbset.Where(d => d.State).ToListAsync();
    }

    public Task<T?> FindByIdAsync(ID id)
    {
        throw new NotImplementedException();
    }

    public Task<T> SaveAsync(T entity)
    {
        throw new NotImplementedException();
    }
}
