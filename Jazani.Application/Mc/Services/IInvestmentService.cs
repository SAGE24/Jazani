using Jazani.Application.Mc.Dtos.Investments;

namespace Jazani.Application.Mc.Services;
public interface IInvestmentService
{
    Task<IReadOnlyList<InvestmentDto>> FindAllAsync();

    Task<InvestmentDto> FindByIdAsync(int id);

    Task<InvestmentDto> CreateAsync(InvestmentSaveDto investmentSave);

    Task<InvestmentDto> EditAsync(int id, InvestmentSaveDto investmentSave);

    Task<InvestmentDto> DisabledAsync(int id);
}
