using Jazani.Application.Admins.Dtos.Users;
using Jazani.Application.Admins.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Jazani.Api.Controllers.Admins;

[Route("api/[controller]")]
//[ApiController]
public class UserController : ControllerBase
{
    readonly IUserService _userService;

    public UserController(IUserService userService) {
        _userService = userService;
    }

    [HttpPost]
    public async Task<Results<BadRequest, CreatedAtRoute<UserDto>>> Post([FromBody] UserSaveDto userSaveDto) {
        return TypedResults.CreatedAtRoute(await _userService.CreateAsync(userSaveDto));
    }
}
