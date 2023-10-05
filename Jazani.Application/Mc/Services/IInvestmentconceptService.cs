using Jazani.Application.Mc.Dtos.Investmentconcepts;

namespace Jazani.Application.Mc.Services;
public interface IInvestmentconceptService
{
    Task<IReadOnlyList<InvestmentconceptDto>> FindAllAsync();

    Task<InvestmentconceptDto?> FindByIdAsync(int id);

    Task<InvestmentconceptDto> CreateAsync(InvestmentconceptSaveDto investmentconceptSave);

    Task<InvestmentconceptDto> EditAsync(int id, InvestmentconceptSaveDto investmentconceptSave);

    Task<InvestmentconceptDto> DisabledAsync(int id);
}
