using Jazani.Application.Cores.Dtos;

namespace Jazani.Application.Admins.Dtos.Users;
public class UserDto: CoreDto
{
    public string Name { get; set; } = default;
    public string? LastName { get; set; }
    public string? Email { get; set; } = default;
    public int RoleId { get; set; }
}
