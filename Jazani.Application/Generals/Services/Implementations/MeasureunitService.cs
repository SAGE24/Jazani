using AutoMapper;
using Jazani.Application.Cores.Exceptions;
using Jazani.Application.Generals.Dtos.Measureunits;
using Jazani.Domain.Generals.Models;
using Jazani.Domain.Generals.Repositories;
using Microsoft.Extensions.Logging;

namespace Jazani.Application.Generals.Services.Implementations;
public class MeasureunitService : IMeasureunitService
{
    private readonly IMeasureunitRepository _measureunitRepository;
    private readonly IMapper _mapper;
    private readonly ILogger<MeasureunitService> _logger;

    public MeasureunitService(
        IMeasureunitRepository measureunitRepository, 
        IMapper mapper, 
        ILogger<MeasureunitService> logger)
    {
        _measureunitRepository = measureunitRepository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<MeasureunitDto> CreateAsync(MeasureunitSaveDto saveDto)
    {
        Measureunit record = _mapper.Map<Measureunit>(saveDto);
        record.RegistrationDate = DateTime.Now;
        record.State = true;

        Measureunit newRecord = await _measureunitRepository.SaveAsync(record);

        return _mapper.Map<MeasureunitDto>(newRecord);
    }

    public async Task<MeasureunitDto> DisabledAsync(int id)
    {
        Measureunit record = await SearchRecord(id);
        record.State = false;

        Measureunit modifiedRecord = await _measureunitRepository.SaveAsync(record);

        return _mapper.Map<MeasureunitDto>(modifiedRecord);
    }

    public async Task<MeasureunitDto> EditAsync(int id, MeasureunitSaveDto saveDto)
    {
        Measureunit record = await SearchRecord(id);

        _mapper.Map(saveDto, record);

        Measureunit modifiedRecord = await _measureunitRepository.SaveAsync(record);

        return _mapper.Map<MeasureunitDto>(modifiedRecord);
    }

    public async Task<IReadOnlyList<MeasureunitDto>> FindAllAsync()
    {
        return _mapper.Map<IReadOnlyList<MeasureunitDto>>(await _measureunitRepository.FindAllAsync());
    }

    public async Task<MeasureunitDto> FindByIdAsync(int id)
    {
        return _mapper.Map<MeasureunitDto>(await SearchRecord(id));
    }

    private async Task<Measureunit> SearchRecord(int id)
    {
        Measureunit record = await _measureunitRepository.FindByIdAsync(id);
        return record is null ? throw RecordNotFound(id) : record;
    }

    private NotFoundCoreException RecordNotFound(int id)
    {
        _logger.LogWarning(message: $"Measureunit no econtrado para el id: {id}");
        return new NotFoundCoreException($"Measureunit no econtrado para el id: {id}");
    }
}
