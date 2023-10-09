using AutoMapper;
using Jazani.Application.Cores.Exceptions;
using Jazani.Application.Generals.Dtos.Periodtypes;
using Jazani.Domain.Generals.Models;
using Jazani.Domain.Generals.Repositories;
using Microsoft.Extensions.Logging;

namespace Jazani.Application.Generals.Services.Implementations;
public class PeriodtypeService : IPeriodtypeService
{
    private readonly IPeriodtypeRepository _periodtypeRepository;
    private readonly IMapper _mapper;
    private readonly ILogger<PeriodtypeService> _logger;

    public PeriodtypeService(
        IPeriodtypeRepository periodtypeRepository, 
        IMapper mapper, 
        ILogger<PeriodtypeService> logger)
    {
        _periodtypeRepository = periodtypeRepository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<PeriodtypeDto> CreateAsync(PeriodtypeSaveDto saveDto)
    {
        Periodtype record = _mapper.Map<Periodtype>(saveDto);
        record.RegistrationDate = DateTime.Now;
        record.State = true;

        Periodtype newRecord = await _periodtypeRepository.SaveAsync(record);

        return _mapper.Map<PeriodtypeDto>(newRecord);
    }

    public async Task<PeriodtypeDto> DisabledAsync(int id)
    {
        Periodtype record = await SearchRecord(id);
        record.State = false;

        Periodtype modifiedRecord = await _periodtypeRepository.SaveAsync(record);

        return _mapper.Map<PeriodtypeDto>(modifiedRecord);
    }

    public async Task<PeriodtypeDto> EditAsync(int id, PeriodtypeSaveDto saveDto)
    {
        Periodtype record = await SearchRecord(id);

        _mapper.Map(saveDto, record);

        Periodtype modifiedRecord = await _periodtypeRepository.SaveAsync(record);

        return _mapper.Map<PeriodtypeDto>(modifiedRecord);
    }

    public async Task<IReadOnlyList<PeriodtypeDto>> FindAllAsync()
    {
        return _mapper.Map<IReadOnlyList<PeriodtypeDto>>(await _periodtypeRepository.FindAllAsync());
    }

    public async Task<PeriodtypeDto> FindByIdAsync(int id)
    {
        return _mapper.Map<PeriodtypeDto>(await SearchRecord(id));
    }

    private async Task<Periodtype> SearchRecord(int id)
    {
        Periodtype record = await _periodtypeRepository.FindByIdAsync(id);
        return record is null ? throw RecordNotFound(id) : record;
    }

    private NotFoundCoreException RecordNotFound(int id)
    {
        _logger.LogWarning(message: $"Periodtype no econtrado para el id: {id}");
        return new NotFoundCoreException($"Periodtype no econtrado para el id: {id}");
    }
}
