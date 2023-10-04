using Jazani.Domain.Generals.Models;

namespace Jazani.Domain.Generals.Repositories;
public interface IMineralTypeRepository
{
    Task<IReadOnlyList<MineralType>> FindAllAsync();

    Task<MineralType?> FindByIdAsync(int id);

    Task<MineralType> SaveAsync(MineralType informationSource);
}
