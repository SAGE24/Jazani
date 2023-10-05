using Jazani.Domain.Generals.Models;
using Jazani.Domain.Generals.Repositories;
using Jazani.Infraestructure.Cores.Contexts;
using Jazani.Infraestructure.Cores.Persistences;
using Microsoft.EntityFrameworkCore;

namespace Jazani.Infraestructure.Generals.Persistences;
public class InformationSourceRepository : CrudRepository<InformationSource, int>, IInformationSourceRepository
{
    private readonly ApplicationDbContext _dbContext;

    public InformationSourceRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public override async Task<IReadOnlyList<InformationSource>> FindAllAsync()
    {
        return await _dbContext.Set<InformationSource>()
            .Include(t => t.InformationSourceType)
            .AsNoTracking()
            .ToListAsync();
    }

    public override async Task<InformationSource?> FindByIdAsync(int id)
    {
        return await _dbContext.Set<InformationSource>()
            .Include(t => t.InformationSourceType)
            .FirstOrDefaultAsync(t => t.Id == id);
    }
}
