using Jazani.Domain.Generals.Models;
using Jazani.Domain.Generals.Repositories;
using Jazani.Infraestructure.Cores.Contexts;
using Jazani.Infraestructure.Cores.Persistences;

namespace Jazani.Infraestructure.Generals.Persistences;
public class PeriodtypeRepository : CrudRepository<Periodtype, int>, IPeriodtypeRepository
{
    public PeriodtypeRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}
