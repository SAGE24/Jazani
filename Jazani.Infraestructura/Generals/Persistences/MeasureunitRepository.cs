using Jazani.Domain.Generals.Models;
using Jazani.Domain.Generals.Repositories;
using Jazani.Infraestructure.Cores.Contexts;
using Jazani.Infraestructure.Cores.Persistences;

namespace Jazani.Infraestructure.Generals.Persistences;
public class MeasureunitRepository : CrudRepository<Measureunit, int>, IMeasureunitRepository
{
    public MeasureunitRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}
