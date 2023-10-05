using AutoMapper;
using Jazani.Application.Mc.Dtos.Investments;
using Jazani.Domain.Mc.Models;
using Jazani.Domain.Mc.Repositories;

namespace Jazani.Application.Mc.Services.Implementations;
public class InvestmentService : IInvestmentService
{
    private readonly IInvestmentRepository _investmentRepository;
    private readonly IMapper _mapper;

    public InvestmentService(IInvestmentRepository investmentRepository, IMapper mapper)
    {
        _investmentRepository = investmentRepository;
        _mapper = mapper;
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
        Investment? record = await SearchRecord(id);
        record.State = false;

        Investment modifiedRecord = await _investmentRepository.SaveAsync(record);

        return _mapper.Map<InvestmentDto>(modifiedRecord);
    }

    public async Task<InvestmentDto> EditAsync(int id, InvestmentSaveDto investmentSave)
    {
        Investment? record = await SearchRecord(id);

        _mapper.Map<InvestmentSaveDto, Investment>(investmentSave, record);

        Investment recordModify = await _investmentRepository.SaveAsync(record);

        return _mapper.Map<InvestmentDto>(recordModify);
    }

    public async Task<IReadOnlyList<InvestmentDto>> FindAllAsync()
    {
        return _mapper.Map<IReadOnlyList<InvestmentDto>>(await _investmentRepository.FindAllAsync());
    }

    public async Task<InvestmentDto?> FindByIdAsync(int id)
    {
        return _mapper.Map<InvestmentDto>(await SearchRecord(id));
    }

    private async Task<Investment?> SearchRecord(int id)
    {
        return await _investmentRepository.FindByIdAsync(id);
    }
}
