using Jazani.Application.Generals.Dtos.InformationSources;

namespace Jazani.Application.Generals.Services;
public interface IInformationSourceService
{
    Task<IReadOnlyList<InformationSourceDto>> FindAllAsync();

    Task<InformationSourceDto?> FindByIdAsync(int id);

    Task<InformationSourceDto> CreateAsync(InformationSourceSaveDto informationSource);

    Task<InformationSourceDto> EditAsync(int id, InformationSourceSaveDto informationSourceSave);

    Task<InformationSourceDto> DisabledAsync(int id);
}
