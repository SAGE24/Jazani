using Jazani.Api.Exeptions;
using Jazani.Application.Admins.Dtos.Users;
using Jazani.Application.Admins.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Jazani.Api.Controllers.Admins;

[Route("api/[controller]")]
//[ApiController]
public class AuthController : ControllerBase
{
    readonly IUserService _userService;

    public AuthController(IUserService userService) { 
        _userService = userService;
    }

    [HttpPost("Login")]
    [AllowAnonymous]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserSecurityDto))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorValidationModel))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorModel))]
    public async Task<Results<BadRequest, Ok<UserSecurityDto>>> Post([FromBody] UserAuthDto userAuthDto) {
        return TypedResults.Ok(await _userService.LoginAsync(userAuthDto));
    }
}
