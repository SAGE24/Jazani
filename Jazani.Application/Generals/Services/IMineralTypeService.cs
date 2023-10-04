using Jazani.Application.Generals.Dtos.MineralTypes;

namespace Jazani.Application.Generals.Services;
public interface IMineralTypeService
{
    Task<IReadOnlyList<MineralTypeDto>> FindAllAsync();

    Task<MineralTypeDto?> FindByIdAsync(int id);

    Task<MineralTypeDto> CreateAsync(MineralTypeSaveDto mineralTypeSave);

    Task<MineralTypeDto> EditAsync(int id, MineralTypeSaveDto mineralTypeSave);

    Task<MineralTypeDto> DisabledAsync(int id);
}
