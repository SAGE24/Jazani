using Jazani.Application.Admins.Dtos.Offices;

namespace Jazani.Application.Admins.Services;
public interface IOfficeService
{
    Task<IReadOnlyList<OfficeDTO>> FindAllAsync();
    
    Task<OfficeDTO?> FindByIdAsync(int id);

    Task<OfficeDTO> CreateAsync(OfficeSaveDto officeSave);

    Task<OfficeDTO> EditAsync(int id, OfficeSaveDto officeSave);

    Task<OfficeDTO> DisabledAsync(int id);
}
