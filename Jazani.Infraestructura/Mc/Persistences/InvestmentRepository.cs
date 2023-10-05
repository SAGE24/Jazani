using Jazani.Domain.Mc.Models;
using Jazani.Domain.Mc.Repositories;
using Jazani.Infraestructure.Cores.Contexts;
using Jazani.Infraestructure.Cores.Persistences;
using Microsoft.EntityFrameworkCore;

namespace Jazani.Infraestructure.Mc.Persistences;
public class InvestmentRepository : CrudRepository<Investment, int>, IInvestmentRepository
{
    private readonly ApplicationDbContext _dbContext;

    public InvestmentRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public override async Task<IReadOnlyList<Investment>> FindAllAsync()
    {
        return await _dbContext.Set<Investment>()
            .Include(t => t.Investmentconcept)
            .AsNoTracking()
            .ToListAsync();
    }

    public override async Task<Investment?> FindByIdAsync(int id)
    {
        return await _dbContext.Set<Investment>()
            .Include(t => t.Investmentconcept)
            .FirstOrDefaultAsync(t => t.Id == id);
    }
}
