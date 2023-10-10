using Jazani.Application.Cores.Services;
using Jazani.Application.Mc.Dtos.Investments;

namespace Jazani.Application.Mc.Services;
public interface IInvestmentService : ICrudService<InvestmentDto, InvestmentSaveDto, int>, IPaginatedService<InvestmentDto, InvestmentFilterDto>
{
    //Task<IReadOnlyList<InvestmentDto>> FindAllAsync();

    //Task<InvestmentDto> FindByIdAsync(int id);

    //Task<InvestmentDto> CreateAsync(InvestmentSaveDto investmentSave);

    //Task<InvestmentDto> EditAsync(int id, InvestmentSaveDto investmentSave);

    //Task<InvestmentDto> DisabledAsync(int id);
}
