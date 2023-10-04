using Jazani.Domain.Generals.Repositories;
using AutoMapper;
using Jazani.Application.Generals.Dtos.MineralTypes;
using Jazani.Domain.Generals.Models;

namespace Jazani.Application.Generals.Services.Implementations;
public class MineralTypeService : IMineralTypeService
{
    private readonly IMineralTypeRepository _mineralTypeRepository;
    private readonly IMapper _mapper;

    public MineralTypeService(IMineralTypeRepository mineralTypeRepository, IMapper mapper)
    {
        _mineralTypeRepository = mineralTypeRepository;
        _mapper = mapper;
    }

    public async Task<MineralTypeDto> CreateAsync(MineralTypeSaveDto mineralTypeSave)
    {
        MineralType record = _mapper.Map<MineralType>(mineralTypeSave);
        record.RegistrationDate = DateTime.Now;
        record.State = true;

        MineralType newRecord = await _mineralTypeRepository.SaveAsync(record);

        return _mapper.Map<MineralTypeDto>(newRecord);
    }

    public async Task<MineralTypeDto> DisabledAsync(int id)
    {
        MineralType? record = await SearchRecord(id);
        record.State = false;

        MineralType modifiedRecord = await _mineralTypeRepository.SaveAsync(record);

        return _mapper.Map<MineralTypeDto>(modifiedRecord);
    }

    public async Task<MineralTypeDto> EditAsync(int id, MineralTypeSaveDto mineralTypeSave)
    {
        MineralType? record = await SearchRecord(id);

        _mapper.Map<MineralTypeSaveDto, MineralType>(mineralTypeSave, record);

        MineralType? modifiedRecord = await _mineralTypeRepository.SaveAsync(record);

        return _mapper.Map<MineralTypeDto>(modifiedRecord);
    }

    public async Task<IReadOnlyList<MineralTypeDto>> FindAllAsync()
    {
        return _mapper.Map<IReadOnlyList<MineralTypeDto>>(await _mineralTypeRepository.FindAllAsync());
    }

    public async Task<MineralTypeDto?> FindByIdAsync(int id)
    {
        return _mapper.Map<MineralTypeDto>(await SearchRecord(id));
    }

    private async Task<MineralType?> SearchRecord(int id)
    {
        return await _mineralTypeRepository.FindByIdAsync(id);
    }
}
