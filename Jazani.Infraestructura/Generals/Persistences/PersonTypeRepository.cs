using Jazani.Domain.Generals.Models;
using Jazani.Domain.Generals.Repositories;
using Jazani.Infraestructure.Cores.Contexts;
using Jazani.Infraestructure.Cores.Persistences;

namespace Jazani.Infraestructure.Generals.Persistences;
public class PersonTypeRepository : CrudRepository<PersonType, int>, IPersonTypeRepository
{
    public PersonTypeRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}
