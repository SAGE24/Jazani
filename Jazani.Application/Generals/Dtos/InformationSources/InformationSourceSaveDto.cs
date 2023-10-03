namespace Jazani.Application.Generals.Dtos.InformationSources;
public class InformationSourceSaveDto
{
    public string Name { get; set; }
    public string? Description { get; set; }
    public int? InformationSourceid { get; set; }
    public int? InformationSourceTypeId { get; set; }
    public string? Initials { get; set; }
}
