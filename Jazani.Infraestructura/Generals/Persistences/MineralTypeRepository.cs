using Jazani.Domain.Generals.Models;
using Jazani.Domain.Generals.Repositories;
using Jazani.Infraestructure.Cores.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Jazani.Infraestructure.Generals.Persistences;
public class MineralTypeRepository : IMineralTypeRepository
{
    private readonly ApplicationDbContext _dbContext;

    public MineralTypeRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IReadOnlyList<MineralType>> FindAllAsync()
    {
        return await _dbContext.MineralTypes.ToListAsync();
    }

    public async Task<MineralType?> FindByIdAsync(int id)
    {
        return await _dbContext.MineralTypes.FirstOrDefaultAsync(item => item.Id == id);
    }

    public async Task<MineralType> SaveAsync(MineralType mineralType)
    {
        EntityState state = _dbContext.Entry(mineralType).State;

        _ = state switch
        {
            EntityState.Detached => _dbContext.MineralTypes.Add(mineralType),
            EntityState.Modified => _dbContext.MineralTypes.Update(mineralType)
        };

        await _dbContext.SaveChangesAsync();

        return mineralType;
    }
}
