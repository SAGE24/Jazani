using Jazani.Domain.Cores.Models;
using Jazani.Domain.Mc.Models;

namespace Jazani.Domain.Generals.Models;
public class Periodtype : CoreModel<int>
{
    public string Name { get; set; }
    public int Time { get; set; }
    public string? Description { get; set; }

    public virtual ICollection<Investment>? Investments { get; set; }
}
