using Autofac.Core.Registration;
using Jazani.Core.Paginations;
using Jazani.Domain.Cores.Paginations;
using Jazani.Domain.Mc.Models;
using Jazani.Domain.Mc.Repositories;
using Jazani.Infraestructure.Cores.Contexts;
using Jazani.Infraestructure.Cores.Persistences;
using Microsoft.EntityFrameworkCore;

namespace Jazani.Infraestructure.Mc.Persistences;
public class InvestmentRepository : CrudRepository<Investment, int>, IInvestmentRepository
{
    private readonly ApplicationDbContext _dbContext;
    private readonly IPaginator<Investment> _paginator;

    public InvestmentRepository(ApplicationDbContext dbContext, IPaginator<Investment> paginator) : base(dbContext)
    {
        _dbContext = dbContext;
        _paginator = paginator;
    }

    public override async Task<IReadOnlyList<Investment>> FindAllAsync()
    {
        return await _dbContext.Set<Investment>()
            .Include(t => t.Investmentconcept)
            .Include(t => t.Holder)
            .Include(t => t.Investmenttype)
            .Include(t => t.Miningconcession)
            .Include(t => t.Measureunit)
            .Include(t => t.Periodtype)
            .AsNoTracking()
            .ToListAsync();
    }

    public override async Task<Investment> FindByIdAsync(int id)
    {
        return await _dbContext.Set<Investment>()
            .Include(t => t.Investmentconcept)
            .Include(t => t.Holder)
            .Include(t => t.Investmenttype)
            .Include(t => t.Miningconcession)
            .Include(t => t.Measureunit)
            .Include(t => t.Periodtype)
            .FirstOrDefaultAsync(t => t.Id == id);
    }

    public async Task<ResponsePagination<Investment>> PaginatedSearch(RequestPagination<Investment> request)
    {
        var filter = request.Filter;
        var query = _dbContext.Set<Investment>().AsQueryable();

        if (filter is not null) {
            query = query.Where(x =>
            ((filter.Year == null || filter.Year == 0) || x.Year == filter.Year) &&
            (string.IsNullOrWhiteSpace(filter.Description) || x.Description.ToUpper().Contains(filter.Description.ToUpper())) &&
            ((filter.State == null) || x.State == filter.State)
            );
        }
        query = query.OrderByDescending(x => x.Id);

        return await _paginator.Paginate(query, request);
    }

    public override async Task<Investment> SaveAsync(Investment entity)
    {
        EntityState state = _dbContext.Entry(entity).State;

        _ = state switch
        {
            EntityState.Detached => _dbContext.Set<Investment>().Add(entity),
            EntityState.Modified => _dbContext.Set<Investment>().Update(entity),
            EntityState.Unchanged => throw new NotImplementedException(),
            EntityState.Deleted => throw new NotImplementedException(),
            EntityState.Added => throw new NotImplementedException(),
            _ => throw new NotImplementedException()
        };

        await _dbContext.SaveChangesAsync();

        return await FindByIdAsync(entity.Id);
    }
}
