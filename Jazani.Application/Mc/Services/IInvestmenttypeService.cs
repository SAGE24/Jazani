using Jazani.Application.Cores.Services;
using Jazani.Application.Mc.Dtos.Investmenttypes;

namespace Jazani.Application.Mc.Services;
public interface IInvestmenttypeService : ICrudService<InvestmenttypeDto, InvestmenttypeSaveDto, int>
{
}
