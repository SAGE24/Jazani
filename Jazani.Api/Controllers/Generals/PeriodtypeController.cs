using Jazani.Api.Exeptions;
using Jazani.Application.Generals.Dtos.Periodtypes;
using Jazani.Application.Generals.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Jazani.Api.Controllers.Generals;

[Route("api/[controller]")]
//[ApiController]
public class PeriodtypeController : ControllerBase
{
    private readonly IPeriodtypeService _periodtypeService;

    public PeriodtypeController(IPeriodtypeService periodtypeService)
    {
        _periodtypeService = periodtypeService;
    }

    [HttpGet]
    public async Task<IEnumerable<PeriodtypeDto>> Get()
    {
        return await _periodtypeService.FindAllAsync();
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PeriodtypeDto))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorModel))]
    public async Task<Results<NotFound, Ok<PeriodtypeDto>>> Get(int id)
    {
        return TypedResults.Ok(await _periodtypeService.FindByIdAsync(id));
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(PeriodtypeDto))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorModel))]
    public async Task<Results<BadRequest, Ok<PeriodtypeDto>>> Post([FromBody] PeriodtypeSaveDto periodtypeSave)
    {
        return TypedResults.Ok(await _periodtypeService.CreateAsync(periodtypeSave));
    }

    [HttpPut("{id}")]
    public async Task<PeriodtypeDto> Put(int id, [FromBody] PeriodtypeSaveDto periodtypeSave)
    {
        return await _periodtypeService.EditAsync(id, periodtypeSave);
    }

    [HttpDelete("{id}")]
    public async Task<PeriodtypeDto> Disabled(int id)
    {
        return await _periodtypeService.DisabledAsync(id);
    }
}
