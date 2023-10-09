using Jazani.Application.Cores.Services;
using Jazani.Application.Mc.Dtos.Miningconcessions;

namespace Jazani.Application.Mc.Services;
public interface IMiningconcessionService : ICrudService<MiningconcessionDto, MiningconcessionSaveDto, int>
{
}
