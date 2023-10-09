using AutoMapper;
using Jazani.Application.Cores.Exceptions;
using Jazani.Application.Mc.Dtos.Investments;
using Jazani.Domain.Mc.Models;
using Jazani.Domain.Mc.Repositories;
using Microsoft.Extensions.Logging;

namespace Jazani.Application.Mc.Services.Implementations;
public class InvestmentService : IInvestmentService
{
    private readonly IInvestmentRepository _investmentRepository;
    private readonly IMapper _mapper;
    private readonly ILogger<InvestmentService> _logger;

    public InvestmentService(
        IInvestmentRepository investmentRepository, 
        IMapper mapper,
        ILogger<InvestmentService> logger)
    {
        _investmentRepository = investmentRepository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<InvestmentDto> CreateAsync(InvestmentSaveDto investmentSave)
    {
        Investment record = _mapper.Map<Investment>(investmentSave);
        record.RegistrationDate = DateTime.Now;
        record.State = true;

        Investment newRecord = await _investmentRepository.SaveAsync(record);

        return _mapper.Map<InvestmentDto>(newRecord);
    }

    public async Task<InvestmentDto> DisabledAsync(int id)
    {
        Investment record = await SearchRecord(id);
        record.State = false;

        Investment modifiedRecord = await _investmentRepository.SaveAsync(record);

        return _mapper.Map<InvestmentDto>(modifiedRecord);
    }

    public async Task<InvestmentDto> EditAsync(int id, InvestmentSaveDto investmentSave)
    {
        Investment record = await SearchRecord(id);

        _mapper.Map<InvestmentSaveDto, Investment>(investmentSave, record);

        Investment recordModify = await _investmentRepository.SaveAsync(record);

        return _mapper.Map<InvestmentDto>(recordModify);
    }

    public async Task<IReadOnlyList<InvestmentDto>> FindAllAsync()
    {
        return _mapper.Map<IReadOnlyList<InvestmentDto>>(await _investmentRepository.FindAllAsync());
    }

    public async Task<InvestmentDto> FindByIdAsync(int id)
    {
        return _mapper.Map<InvestmentDto>(await SearchRecord(id));
    }

    private async Task<Investment> SearchRecord(int id)
    {
        Investment investment = await _investmentRepository.FindByIdAsync(id);
        return (investment is null) ? throw RecordNotFound(id) : investment;
    }

    private NotFoundCoreException RecordNotFound(int id)
    {
        _logger.LogWarning(message: $"Tipo de mineral no econtrado para el id: {id}");
        return new NotFoundCoreException($"Tipo de mineral no econtrado para el id: {id}");
    }
}
