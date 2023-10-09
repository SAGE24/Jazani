using Jazani.Domain.Cores.Models;
using Jazani.Domain.Mc.Models;

namespace Jazani.Domain.Generals.Models;
public class Measureunit : CoreModel<int>
{
    public int? Measureunitid { get; set; }
    public string Name { get; set; }
    public string Symbol { get; set; }
    public string? Description { get; set; }
    public string? Formulaconversion { get; set; }

    public virtual ICollection<Investment>? Investments { get; set; }
}
