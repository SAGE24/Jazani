using Jazani.Domain.Admins.Models;
using Jazani.Domain.Admins.Repositories;
using Jazani.Infraestructure.Cores.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Jazani.Infraestructure.Admins.Persistences;
public class OfficeRepository : IOfficeRepository
{
    private readonly ApplicationDbContext _dbContext;

    public OfficeRepository(ApplicationDbContext dbContext) { 
        _dbContext = dbContext;
    }

    public async Task<IReadOnlyList<Office>> FindAllAsync()
    {
        return await _dbContext.Offices.ToListAsync();
    }

    public async Task<Office?> FindByIdAsync(int id)
    {
        return await _dbContext.Offices.Where(d => d.Id == id).FirstOrDefaultAsync();
    }

    public async Task<Office> SaveAsync(Office office)
    {
        EntityState state = _dbContext.Entry(office).State;

        _ = state switch { 
            EntityState.Detached => _dbContext.Offices.Add(office),
            EntityState.Modified => _dbContext.Offices.Update(office)
        };

        
        await _dbContext.SaveChangesAsync();

        return office;
    }
}
