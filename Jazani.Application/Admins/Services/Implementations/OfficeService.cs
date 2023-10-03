using Jazani.Application.Admins.Dtos.Offices;
using Jazani.Domain.Admins.Models;
using Jazani.Domain.Admins.Repositories;
using AutoMapper;

namespace Jazani.Application.Admins.Services.Implementations;
public class OfficeService : IOfficeService
{
    private readonly IOfficeRepository _officeRepository;
    private readonly IMapper _mapper;

    public OfficeService(IOfficeRepository officeRepository, IMapper mapper) { 
        _officeRepository = officeRepository;
        _mapper = mapper;
    }

    public async Task<OfficeDTO> CreateAsync(OfficeSaveDto officeSave)
    {
        Office office = _mapper.Map<Office>(officeSave);
        Office officeSaved = await _officeRepository.SaveAsync(office);
        officeSaved.RegistrationDate = DateTime.Now;
        officeSaved.State = true;

        return _mapper.Map<OfficeDTO>(officeSaved);
    }

    public async Task<OfficeDTO> DisabledAsync(int id)
    {
        Office office = await _officeRepository.FindByIdAsync(id);
        office.State = false;

        Office officeSaved = await _officeRepository.SaveAsync(office);

        return _mapper.Map<OfficeDTO>(officeSaved);
    }

    public async Task<OfficeDTO> EditAsync(int id, OfficeSaveDto officeSave)
    {
        Office office = await _officeRepository.FindByIdAsync(id);

        _mapper.Map<OfficeSaveDto, Office>(officeSave, office);
        
        Office officeSaved = await _officeRepository.SaveAsync(office);

        return _mapper.Map<OfficeDTO>(officeSaved);
    }

    public async Task<IReadOnlyList<OfficeDTO>> FindAllAsync()
    {
        IReadOnlyList<Office> offices = await _officeRepository.FindAllAsync();
        return _mapper.Map<IReadOnlyList<OfficeDTO>>(offices);
    }

    public async Task<OfficeDTO?> FindByIdAsync(int id)
    {
        Office? office = await _officeRepository.FindByIdAsync(id);
        return _mapper.Map<OfficeDTO?>(office);
    }
}
