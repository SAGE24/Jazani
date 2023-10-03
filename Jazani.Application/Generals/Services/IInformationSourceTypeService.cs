using Jazani.Application.Generals.Dtos.InformationSourceTypes;

namespace Jazani.Application.Generals.Services;
public interface IInformationSourceTypeService
{
    Task<IReadOnlyList<InformationSourceTypeDto>> FindAllAsync();

    Task<InformationSourceTypeDto?> FindByIdAsync(int id);

    Task<InformationSourceTypeDto> CreateAsync(InformationSourceTypeSaveDto officeSave);

    Task<InformationSourceTypeDto> EditAsync(int id, InformationSourceTypeSaveDto officeSave);

    Task<InformationSourceTypeDto> DisabledAsync(int id);
}
