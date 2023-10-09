using Jazani.Application.Cores.Dtos;

namespace Jazani.Application.Generals.Dtos.Periodtypes;
public class PeriodtypeDto : CoreDto
{
    public string Name { get; set; }
    public int Time { get; set; }
    public string? Description { get; set; }
}
