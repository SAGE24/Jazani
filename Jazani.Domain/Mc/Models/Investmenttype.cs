namespace Jazani.Domain.Mc.Models;
public class Investmenttype
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public DateTime RegistrationDate { get; set; }
    public bool State { get; set; }

    public virtual ICollection<Investment>? Investments { get; set; }
}
