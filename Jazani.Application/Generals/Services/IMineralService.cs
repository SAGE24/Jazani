using Jazani.Application.Generals.Dtos.Minerals;

namespace Jazani.Application.Generals.Services;
public interface IMineralService
{
    Task<IReadOnlyList<MineralDto>> FindAllAsync();

    Task<MineralDto?> FindByIdAsync(int id);

    Task<MineralDto> CreateAsync(MineralSaveDto mineralSave);

    Task<MineralDto> EditAsync(int id, MineralSaveDto mineralSave);

    Task<MineralDto> DisabledAsync(int id);
}
