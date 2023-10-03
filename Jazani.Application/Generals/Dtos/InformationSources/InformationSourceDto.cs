namespace Jazani.Application.Generals.Dtos.InformationSources;
public class InformationSourceDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public int? InformationSourceid { get; set; }
    public int? InformationSourceTypeId { get; set; }
    public string? Initials { get; set; }
    public DateTimeOffset RegistrationDate { get; set; }
    public bool State { get; set; }
}
