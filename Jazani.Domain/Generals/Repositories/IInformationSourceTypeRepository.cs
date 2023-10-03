using Jazani.Domain.Generals.Models;

namespace Jazani.Domain.Generals.Repositories;
public interface IInformationSourceTypeRepository
{
    Task<IReadOnlyList<InformationSourceType>> FindAllAsync();

    Task<InformationSourceType?> FindByIdAsync(int id);

    Task<InformationSourceType> SaveAsync(InformationSourceType informationSourceType);
}
