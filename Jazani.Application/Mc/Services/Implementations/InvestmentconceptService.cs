using AutoMapper;
using Jazani.Application.Cores.Exceptions;
using Jazani.Application.Mc.Dtos.Investmentconcepts;
using Jazani.Domain.Mc.Models;
using Jazani.Domain.Mc.Repositories;
using Microsoft.Extensions.Logging;

namespace Jazani.Application.Mc.Services.Implementations;
public class InvestmentconceptService : IInvestmentconceptService
{
    private readonly IInvestmentconceptRepository _investmentconceptRepository;
    private readonly IMapper _mapper;
    private readonly ILogger<InvestmentconceptService> _logger;

    public InvestmentconceptService(
        IInvestmentconceptRepository investmentconceptRepository, 
        IMapper mapper, 
        ILogger<InvestmentconceptService> logger
        )
    {
        _investmentconceptRepository = investmentconceptRepository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<InvestmentconceptDto> CreateAsync(InvestmentconceptSaveDto investmentconceptSave)
    {
        Investmentconcept record = _mapper.Map<Investmentconcept>(investmentconceptSave);
        record.RegistrationDate = DateTime.Now;
        record.State = true;

        Investmentconcept newRecord = await _investmentconceptRepository.SaveAsync(record);

        return _mapper.Map<InvestmentconceptDto>(newRecord);
    }

    public async Task<InvestmentconceptDto> DisabledAsync(int id)
    {
        Investmentconcept record = await SearchRecord(id);
        record.State = false;

        Investmentconcept modifiedRecord = await _investmentconceptRepository.SaveAsync(record);

        return _mapper.Map<InvestmentconceptDto>(modifiedRecord);
    }

    public async Task<InvestmentconceptDto> EditAsync(int id, InvestmentconceptSaveDto investmentconceptSave)
    {
        Investmentconcept record = await SearchRecord(id);

        _mapper.Map<InvestmentconceptSaveDto, Investmentconcept>(investmentconceptSave, record);

        Investmentconcept recordModify = await _investmentconceptRepository.SaveAsync(record);

        return _mapper.Map<InvestmentconceptDto>(recordModify);
    }

    public async Task<IReadOnlyList<InvestmentconceptDto>> FindAllAsync()
    {
        return _mapper.Map<IReadOnlyList<InvestmentconceptDto>>(await _investmentconceptRepository.FindAllAsync());
    }

    public async Task<InvestmentconceptDto> FindByIdAsync(int id)
    {
        return _mapper.Map<InvestmentconceptDto>(await SearchRecord(id));
    }

    private async Task<Investmentconcept> SearchRecord(int id)
    {
        Investmentconcept record = await _investmentconceptRepository.FindByIdAsync(id);
        return (record is null) ? throw RecordNotFound(id) : record;
    }

    private NotFoundCoreException RecordNotFound(int id)
    {
        _logger.LogWarning(message: $"Tipo de mineral no econtrado para el id: {id}");
        return new NotFoundCoreException($"Tipo de mineral no econtrado para el id: {id}");
    }
}
