namespace Jazani.Application.Generals.Dtos.Minerals;
public class MineralDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public MineralTypeSimpleDto Mineraltype { get; set; }
    public string? Description { get; set; }
    public string? Symbol { get; set; }
    public DateTime RegistrationDate { get; set; }
    public bool State { get; set; }
}
