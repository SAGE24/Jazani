using Jazani.Domain.Generals.Models;
using Jazani.Domain.Generals.Repositories;
using Jazani.Infraestructure.Cores.Contexts;
using Jazani.Infraestructure.Cores.Persistences;

namespace Jazani.Infraestructure.Generals.Persistences;
public class InformationSourceTypeRepository : CrudRepository<InformationSourceType, int>, IInformationSourceTypeRepository
{
    //private readonly ApplicationDbContext _dbContext;

    //public InformationSourceTypeRepository(ApplicationDbContext dbContext)
    //{
    //    _dbContext = dbContext;
    //}

    //public async Task<IReadOnlyList<InformationSourceType>> FindAllAsync()
    //{
    //    return await _dbContext.InformationSourceTypes.ToListAsync();
    //}

    //public async Task<InformationSourceType?> FindByIdAsync(int id)
    //{
    //    return await _dbContext.InformationSourceTypes.FirstOrDefaultAsync(item => item.Id == id);
    //}

    //public async Task<InformationSourceType> SaveAsync(InformationSourceType informationSourceType)
    //{
    //    EntityState state = _dbContext.Entry(informationSourceType).State;

    //    _ = state switch
    //    {
    //        EntityState.Detached => _dbContext.InformationSourceTypes.Add(informationSourceType),
    //        EntityState.Modified => _dbContext.InformationSourceTypes.Update(informationSourceType)
    //    };


    //    await _dbContext.SaveChangesAsync();

    //    return informationSourceType;
    //}
    public InformationSourceTypeRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}
