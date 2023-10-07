using Jazani.Domain.Mc.Models;

namespace Jazani.Domain.Generals.Models;
public class Periodtype
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Time { get; set; }
    public string? Description { get; set; }
    public DateTime RegistrationDate { get; set; }
    public bool State { get; set; }

    public virtual ICollection<Investment>? Investments { get; set; }
}
