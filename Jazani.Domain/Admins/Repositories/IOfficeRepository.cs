using Jazani.Domain.Admins.Models;
using Jazani.Domain.Cores.Repositories;

namespace Jazani.Domain.Admins.Repositories;
public interface IOfficeRepository : ICrudRepository<Office, int>
{
    //Task<IReadOnlyList<Office>> FindAllAsync();

    //Task<Office?> FindByIdAsync(int id);

    //Task<Office> SaveAsync(Office office);
}
