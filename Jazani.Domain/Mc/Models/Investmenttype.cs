using Jazani.Domain.Cores.Models;

namespace Jazani.Domain.Mc.Models;
public class Investmenttype : CoreModel<int>
{
    public string Name { get; set; }
    public string? Description { get; set; }

    public virtual ICollection<Investment>? Investments { get; set; }
}
