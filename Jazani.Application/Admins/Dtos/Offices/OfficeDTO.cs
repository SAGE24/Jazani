namespace Jazani.Application.Admins.Dtos.Offices;
public class OfficeDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public DateTime RegistrationDate { get; set; }
    public bool State { get; set; }
}
