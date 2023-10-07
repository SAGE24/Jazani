using Jazani.Api.Exeptions;
using Jazani.Application.Generals.Dtos.MineralTypes;
using Jazani.Application.Generals.Services;
using Jazani.Core.Paginations;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Jazani.Api.Controllers.Generals;

[Route("api/[controller]")]
//[ApiController]
public class MineralTypeController : ControllerBase
{
    private readonly IMineralTypeService _mineralTypeService;

    public MineralTypeController(IMineralTypeService mineralTypeService)
    {
        _mineralTypeService = mineralTypeService;
    }

    [HttpGet]
    public async Task<IEnumerable<MineralTypeDto>> Get()
    {
        return await _mineralTypeService.FindAllAsync();
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MineralTypeDto))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorModel))]
    public async Task<Results<NotFound, Ok<MineralTypeDto>>> Get(int id)
    {        
        return TypedResults.Ok(await _mineralTypeService.FindByIdAsync(id));
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(MineralTypeDto))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorResponse))]
    public async Task<Results<BadRequest, CreatedAtRoute<MineralTypeDto>>> Post([FromBody] MineralTypeSaveDto mineralTypeSave)
    {
        //if (!ModelState.IsValid)
        //{
        //    return Results.BadRequest(ModelState.Where(m => m.Value.Errors.Count > 0).ToArray());
        //}
        //return (IResult)await _mineralTypeService.CreateAsync(mineralTypeSave);
        return TypedResults.CreatedAtRoute(await _mineralTypeService.CreateAsync(mineralTypeSave));
    }

    [HttpPut("{id}")]
    public async Task<MineralTypeDto> Put(int id, [FromBody] MineralTypeSaveDto mineralTypeSave)
    {
        return await _mineralTypeService.EditAsync(id, mineralTypeSave);
    }

    [HttpDelete("{id}")]
    public async Task<MineralTypeDto> Disabled(int id)
    {
        return await _mineralTypeService.DisabledAsync(id);
    }

    [HttpGet("PaginatedSearch")]
    public async Task<ResponsePagination<MineralTypeDto>> PaginatedSearch([FromQuery] RequestPagination<MineralTypeFilterDto> request) {
        return await _mineralTypeService.PaginatedSearch(request);
    }
}
