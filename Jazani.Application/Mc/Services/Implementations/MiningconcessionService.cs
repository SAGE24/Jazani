using AutoMapper;
using Jazani.Application.Cores.Exceptions;
using Jazani.Application.Mc.Dtos.Miningconcessions;
using Jazani.Domain.Mc.Models;
using Jazani.Domain.Mc.Repositories;
using Microsoft.Extensions.Logging;

namespace Jazani.Application.Mc.Services.Implementations;
public class MiningconcessionService : IMiningconcessionService
{
    private readonly IMiningconcessionRepository _miningconcessionRepository;
    private readonly IMapper _mapper;
    private readonly ILogger<MiningconcessionService> _logger;

    public MiningconcessionService(IMiningconcessionRepository miningconcessionRepository, IMapper mapper, ILogger<MiningconcessionService> logger)
    {
        _miningconcessionRepository = miningconcessionRepository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<MiningconcessionDto> CreateAsync(MiningconcessionSaveDto saveDto)
    {
        Miningconcession record = _mapper.Map<Miningconcession>(saveDto);
        record.RegistrationDate = DateTime.Now;
        record.State = true;

        Miningconcession newRecord = await _miningconcessionRepository.SaveAsync(record);

        return _mapper.Map<MiningconcessionDto>(newRecord);
    }

    public async Task<MiningconcessionDto> DisabledAsync(int id)
    {
        Miningconcession record = await SearchRecord(id);
        record.State = false;

        Miningconcession modifiedRecord = await _miningconcessionRepository.SaveAsync(record);

        return _mapper.Map<MiningconcessionDto>(modifiedRecord);
    }

    public async Task<MiningconcessionDto> EditAsync(int id, MiningconcessionSaveDto saveDto)
    {
        Miningconcession record = await SearchRecord(id);

        _mapper.Map(saveDto, record);

        Miningconcession modifiedRecord = await _miningconcessionRepository.SaveAsync(record);

        return _mapper.Map<MiningconcessionDto>(modifiedRecord);
    }

    public async Task<IReadOnlyList<MiningconcessionDto>> FindAllAsync()
    {
        return _mapper.Map<IReadOnlyList<MiningconcessionDto>>(await _miningconcessionRepository.FindAllAsync());
    }

    public async Task<MiningconcessionDto> FindByIdAsync(int id)
    {
        return _mapper.Map<MiningconcessionDto>(await SearchRecord(id));
    }

    private async Task<Miningconcession> SearchRecord(int id)
    {
        Miningconcession record = await _miningconcessionRepository.FindByIdAsync(id);
        return record is null ? throw MineralTypeNotFound(id) : record;
    }

    private NotFoundCoreException MineralTypeNotFound(int id)
    {
        _logger.LogWarning(message: $"Miningconcession no econtrado para el id: {id}");
        return new NotFoundCoreException($"Miningconcession no econtrado para el id: {id}");
    }
}
