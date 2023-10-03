using AutoMapper;
using Jazani.Application.Generals.Dtos.InformationSourceTypes;
using Jazani.Domain.Generals.Models;
using Jazani.Domain.Generals.Repositories;

namespace Jazani.Application.Generals.Services.Implementations;
public class InformationSourceTypeService : IInformationSourceTypeService
{    
    private readonly IInformationSourceTypeRepository _informationSourceType;
    private readonly IMapper _mapper;

    public InformationSourceTypeService(IInformationSourceTypeRepository informationSourceType, IMapper mapper)
    {
        _informationSourceType = informationSourceType;
        _mapper = mapper;
    }

    public async Task<InformationSourceTypeDto> CreateAsync(InformationSourceTypeSaveDto informationSourceTypeSave)
    {
        InformationSourceType record = _mapper.Map<InformationSourceType>(informationSourceTypeSave);
        record.RegistrationDate = DateTime.Now;
        record.State = true;

        InformationSourceType newRecord = await _informationSourceType.SaveAsync(record);

        return _mapper.Map<InformationSourceTypeDto>(newRecord);
    }

    public async Task<InformationSourceTypeDto> DisabledAsync(int id)
    {
        InformationSourceType? record = await SearchRecord(id);
        record.State = false;

        InformationSourceType modifiedRecord = await _informationSourceType.SaveAsync(record);

        return _mapper.Map<InformationSourceTypeDto>(modifiedRecord);
    }

    public async Task<InformationSourceTypeDto> EditAsync(int id, InformationSourceTypeSaveDto informationSourceTypeSave)
    {
        InformationSourceType? record = await SearchRecord(id);

        _mapper.Map<InformationSourceTypeSaveDto, InformationSourceType>(informationSourceTypeSave, record);

        InformationSourceType? modifiedRecord = await _informationSourceType.SaveAsync(record);

        return _mapper.Map<InformationSourceTypeDto>(modifiedRecord);
    }

    public async Task<IReadOnlyList<InformationSourceTypeDto>> FindAllAsync()
    {
        return _mapper.Map<IReadOnlyList<InformationSourceTypeDto>>(await _informationSourceType.FindAllAsync());
    }

    public async Task<InformationSourceTypeDto?> FindByIdAsync(int id)
    {
        return _mapper.Map<InformationSourceTypeDto>(await SearchRecord(id));
    }

    private async Task<InformationSourceType?> SearchRecord(int id) {
        return await _informationSourceType.FindByIdAsync(id);
    }
}
