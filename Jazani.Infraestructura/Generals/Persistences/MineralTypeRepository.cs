using Jazani.Core.Paginations;
using Jazani.Domain.Cores.Paginations;
using Jazani.Domain.Generals.Models;
using Jazani.Domain.Generals.Repositories;
using Jazani.Infraestructure.Cores.Contexts;
using Jazani.Infraestructure.Cores.Persistences;

namespace Jazani.Infraestructure.Generals.Persistences;
public class MineralTypeRepository : CrudRepository<MineralType, int>, IMineralTypeRepository
{
    private readonly ApplicationDbContext _dbContext;
    private readonly IPaginator<MineralType> _paginator;

    //public MineralTypeRepository(ApplicationDbContext dbContext)
    //{
    //    _dbContext = dbContext;
    //}

    //public async Task<IReadOnlyList<MineralType>> FindAllAsync()
    //{
    //    return await _dbContext.MineralTypes.ToListAsync();
    //}

    //public async Task<MineralType?> FindByIdAsync(int id)
    //{
    //    return await _dbContext.MineralTypes.FirstOrDefaultAsync(item => item.Id == id);
    //}

    //public async Task<MineralType> SaveAsync(MineralType mineralType)
    //{
    //    EntityState state = _dbContext.Entry(mineralType).State;

    //    _ = state switch
    //    {
    //        EntityState.Detached => _dbContext.MineralTypes.Add(mineralType),
    //        EntityState.Modified => _dbContext.MineralTypes.Update(mineralType)
    //    };

    //    await _dbContext.SaveChangesAsync();

    //    return mineralType;
    //}
    public MineralTypeRepository(ApplicationDbContext dbContext, IPaginator<MineralType> paginator) : base(dbContext)
    {
        _dbContext = dbContext;
        _paginator = paginator;
    }

    public async Task<ResponsePagination<MineralType>> PaginatedSearch(RequestPagination<MineralType> request)
    {
        var filter = request.Filter;
        var query = _dbContext.Set<MineralType>().AsQueryable();
        
        if (filter is not null) {
            query = query.Where(x => 
            (string.IsNullOrWhiteSpace(filter.Name) || x.Name.ToUpper().Contains(filter.Name.ToUpper()))
            && (string.IsNullOrWhiteSpace(filter.Description) || x.Description.ToUpper().Contains(filter.Description.ToUpper()))
            );
        }

        query = query.OrderByDescending(x => x.Id);

        return await _paginator.Paginate(query, request);
    }
}
