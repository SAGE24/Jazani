namespace Jazani.Domain.Generals.Models;
public class InformationSourceType
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public DateTimeOffset RegistrationDate { get; set; }
    public bool State { get; set; }

    public virtual ICollection<InformationSource> InformationSources { get; set; }
}
