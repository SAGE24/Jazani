using Jazani.Api.Exeptions;
using Jazani.Application.Generals.Dtos.PersonTypes;
using Jazani.Application.Generals.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Jazani.Api.Controllers.Generals;

[Route("api/[controller]")]
//[ApiController]
public class PersonTypeController : ControllerBase
{
    private readonly IPersonTypeService _personTypeService;

    public PersonTypeController(IPersonTypeService personTypeService)
    {
        _personTypeService = personTypeService;
    }

    [HttpGet]
    public async Task<IEnumerable<PersonTypeDto>> Get()
    {
        return await _personTypeService.FindAllAsync();
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PersonTypeDto))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorModel))]
    public async Task<Results<NotFound, Ok<PersonTypeDto>>> Get(int id)
    {
        return TypedResults.Ok(await _personTypeService.FindByIdAsync(id));
    }
}

