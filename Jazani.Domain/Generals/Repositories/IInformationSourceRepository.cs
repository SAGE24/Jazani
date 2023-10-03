using Jazani.Domain.Generals.Models;

namespace Jazani.Domain.Generals.Repositories;
public interface IInformationSourceRepository
{
    Task<IReadOnlyList<InformationSource>> FindAllAsync();

    Task<InformationSource?> FindByIdAsync(int id);

    Task<InformationSource> SaveAsync(InformationSource informationSource);
}
