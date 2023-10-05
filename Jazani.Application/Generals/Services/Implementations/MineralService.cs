using AutoMapper;
using Jazani.Application.Generals.Dtos.Minerals;
using Jazani.Domain.Generals.Models;
using Jazani.Domain.Generals.Repositories;

namespace Jazani.Application.Generals.Services.Implementations;
public class MineralService : IMineralService
{
    private readonly IMineralRepository _mineralRepository;
    private readonly IMapper _mapper;

    public MineralService(IMineralRepository mineralRepository, IMapper mapper)
    {
        _mineralRepository = mineralRepository;
        _mapper = mapper;
    }

    public async Task<MineralDto> CreateAsync(MineralSaveDto mineralSave)
    {
        Mineral record = _mapper.Map<Mineral>(mineralSave);
        record.RegistrationDate = DateTime.Now;
        record.State = true;

        Mineral newRecord = await _mineralRepository.SaveAsync(record);

        return _mapper.Map<MineralDto>(newRecord);
    }

    public async Task<MineralDto> DisabledAsync(int id)
    {
        Mineral? record = await SearchRecord(id);
        record.State = false;

        Mineral modifiedRecord = await _mineralRepository.SaveAsync(record);

        return _mapper.Map<MineralDto>(modifiedRecord);
    }

    public async Task<MineralDto> EditAsync(int id, MineralSaveDto mineralSave)
    {
        Mineral? record = await SearchRecord(id);

        _mapper.Map<MineralSaveDto, Mineral>(mineralSave, record);

        Mineral recordModify = await _mineralRepository.SaveAsync(record);

        return _mapper.Map<MineralDto>(recordModify);
    }

    public async Task<IReadOnlyList<MineralDto>> FindAllAsync()
    {
        return _mapper.Map<IReadOnlyList<MineralDto>>(await _mineralRepository.FindAllAsync());
    }

    public async Task<MineralDto?> FindByIdAsync(int id)
    {
        return _mapper.Map<MineralDto?>(await SearchRecord(id));
    }

    private async Task<Mineral?> SearchRecord(int id) { 
        return await _mineralRepository.FindByIdAsync(id);
    }
}
