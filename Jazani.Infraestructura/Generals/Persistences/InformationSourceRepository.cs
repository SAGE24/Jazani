using Jazani.Domain.Generals.Models;
using Jazani.Domain.Generals.Repositories;
using Jazani.Infraestructure.Cores.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Jazani.Infraestructure.Generals.Persistences;
public class InformationSourceRepository : IInformationSourceRepository
{
    private readonly ApplicationDbContext _dbContext;

    public InformationSourceRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IReadOnlyList<InformationSource>> FindAllAsync()
    {
        return await _dbContext.InformationSources.ToListAsync();
    }

    public async Task<InformationSource?> FindByIdAsync(int id)
    {
        return await _dbContext.InformationSources.FirstOrDefaultAsync(item => item.Id == id);
    }

    public async Task<InformationSource> SaveAsync(InformationSource informationSource)
    {
        EntityState state = _dbContext.Entry(informationSource).State;

        _ = state switch
        {
            EntityState.Detached => _dbContext.InformationSources.Add(informationSource),
            EntityState.Modified => _dbContext.InformationSources.Update(informationSource)
        };

        await _dbContext.SaveChangesAsync();

        return informationSource;
    }
}
