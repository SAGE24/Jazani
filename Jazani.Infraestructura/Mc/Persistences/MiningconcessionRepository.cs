using Jazani.Domain.Mc.Models;
using Jazani.Domain.Mc.Repositories;
using Jazani.Infraestructure.Cores.Contexts;
using Jazani.Infraestructure.Cores.Persistences;

namespace Jazani.Infraestructure.Mc.Persistences;
public class MiningconcessionRepository : CrudRepository<Miningconcession, int>, IMiningconcessionRepository
{
    public MiningconcessionRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}
