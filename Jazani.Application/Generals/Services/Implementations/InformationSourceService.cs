using AutoMapper;
using Jazani.Application.Generals.Dtos.InformationSources;
using Jazani.Domain.Generals.Models;
using Jazani.Domain.Generals.Repositories;

namespace Jazani.Application.Generals.Services.Implementations;
public class InformationSourceService : IInformationSourceService
{
    private readonly IInformationSourceRepository _informationSourceRepository;
    private readonly IMapper _mapper;

    public InformationSourceService(IInformationSourceRepository informationSourceRepository, IMapper mapper)
    {
        _informationSourceRepository = informationSourceRepository;
        _mapper = mapper;
    }

    public async Task<InformationSourceDto> CreateAsync(InformationSourceSaveDto informationSource)
    {
        InformationSource record = _mapper.Map<InformationSource>(informationSource);
        record.RegistrationDate = DateTime.Now;
        record.State = true;

        InformationSource newRecord = await _informationSourceRepository.SaveAsync(record);        

        return _mapper.Map<InformationSourceDto>(newRecord);
    }

    public async Task<InformationSourceDto> DisabledAsync(int id)
    {
        InformationSource? record = await SearchRecord(id);
        record.State = false;

        InformationSource modifiedRecord = await _informationSourceRepository.SaveAsync(record);

        return _mapper.Map<InformationSourceDto>(modifiedRecord);
    }

    public async Task<InformationSourceDto> EditAsync(int id, InformationSourceSaveDto informationSourceSave)
    {
        InformationSource? record = await SearchRecord(id);

        _mapper.Map<InformationSourceSaveDto, InformationSource>(informationSourceSave, record);

        InformationSource? modifiedRecord = await _informationSourceRepository.SaveAsync(record);

        return _mapper.Map<InformationSourceDto>(modifiedRecord);
    }

    public async Task<IReadOnlyList<InformationSourceDto>> FindAllAsync()
    {
        return  _mapper.Map<IReadOnlyList<InformationSourceDto>>(await _informationSourceRepository.FindAllAsync());
    }

    public async Task<InformationSourceDto?> FindByIdAsync(int id)
    {
        return _mapper.Map<InformationSourceDto>(await SearchRecord(id));
    }

    private async Task<InformationSource?> SearchRecord(int id) {
        return await _informationSourceRepository.FindByIdAsync(id);
    }
}
