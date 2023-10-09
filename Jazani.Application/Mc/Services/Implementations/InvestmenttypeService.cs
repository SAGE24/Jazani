using AutoMapper;
using Jazani.Application.Cores.Exceptions;
using Jazani.Application.Mc.Dtos.Investmenttypes;
using Jazani.Domain.Mc.Models;
using Jazani.Domain.Mc.Repositories;
using Microsoft.Extensions.Logging;

namespace Jazani.Application.Mc.Services.Implementations;
public class InvestmenttypeService : IInvestmenttypeService
{
    private readonly IInvestmenttypeRepository _investmenttypeRepository;
    private readonly IMapper _mapper;
    private readonly ILogger<InvestmenttypeService> _logger;

    public InvestmenttypeService(
        IInvestmenttypeRepository investmenttypeRepository, 
        IMapper mapper, 
        ILogger<InvestmenttypeService> logger)
    {
        _investmenttypeRepository = investmenttypeRepository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<InvestmenttypeDto> CreateAsync(InvestmenttypeSaveDto investmenttypeSave)
    {
        Investmenttype record = _mapper.Map<Investmenttype>(investmenttypeSave);
        record.RegistrationDate = DateTime.Now;
        record.State = true;

        Investmenttype newRecord = await _investmenttypeRepository.SaveAsync(record);

        return _mapper.Map<InvestmenttypeDto>(newRecord);
    }

    public async Task<InvestmenttypeDto> DisabledAsync(int id)
    {
        Investmenttype record = await SearchRecord(id);
        record.State = false;

        Investmenttype modifiedRecord = await _investmenttypeRepository.SaveAsync(record);

        return _mapper.Map<InvestmenttypeDto>(modifiedRecord);
    }

    public async Task<InvestmenttypeDto> EditAsync(int id, InvestmenttypeSaveDto investmenttypeSave)
    {
        Investmenttype record = await SearchRecord(id);

        _mapper.Map<InvestmenttypeSaveDto,  Investmenttype>(investmenttypeSave, record);

        Investmenttype modifiedRecord = await _investmenttypeRepository.SaveAsync(record);

        return _mapper.Map<InvestmenttypeDto>(record);
    }

    public async Task<IReadOnlyList<InvestmenttypeDto>> FindAllAsync()
    {
        return _mapper.Map<IReadOnlyList<InvestmenttypeDto>>(await _investmenttypeRepository.FindAllAsync());
    }

    public async Task<InvestmenttypeDto> FindByIdAsync(int id)
    {
        return _mapper.Map<InvestmenttypeDto>(await SearchRecord(id));
    }

    private async Task<Investmenttype> SearchRecord(int id)
    {
        Investmenttype record = await _investmenttypeRepository.FindByIdAsync(id);
        return record is null ? throw MineralTypeNotFound(id) : record;
    }

    private NotFoundCoreException MineralTypeNotFound(int id)
    {
        _logger.LogWarning(message: $"Tipo de Investmenttype no econtrado para el id: {id}");
        return new NotFoundCoreException($"Tipo de Investmenttype no econtrado para el id: {id}");
    }
}
