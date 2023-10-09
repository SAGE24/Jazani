using Jazani.Application.Cores.Dtos;

namespace Jazani.Application.Generals.Dtos.Measureunits;
public class MeasureunitDto : CoreDto
{
    public int? Measureunitid { get; set; }
    public string Name { get; set; }
    public string Symbol { get; set; }
    public string? Description { get; set; }
    public string? Formulaconversion { get; set; }
}
