using Jazani.Core.Securities.Entities;

namespace Jazani.Application.Admins.Dtos.Users
{
    public class UserSecurityDto : UserDto
    {
        public SecurityEntity Security { get; set; }
    }
}
