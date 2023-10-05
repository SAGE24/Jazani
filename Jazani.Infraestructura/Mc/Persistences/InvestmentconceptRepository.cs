using Jazani.Domain.Mc.Models;
using Jazani.Domain.Mc.Repositories;
using Jazani.Infraestructure.Cores.Contexts;
using Jazani.Infraestructure.Cores.Persistences;

namespace Jazani.Infraestructure.Mc.Persistences;
public class InvestmentconceptRepository : CrudRepository<Investmentconcept, int>, IInvestmentconceptRepository
{
    public InvestmentconceptRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}
