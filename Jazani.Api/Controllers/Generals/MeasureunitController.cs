using Jazani.Api.Exeptions;
using Jazani.Application.Generals.Dtos.Measureunits;
using Jazani.Application.Generals.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Jazani.Api.Controllers.Generals;

[Route("api/[controller]")]
//[ApiController]
public class MeasureunitController : ControllerBase
{
    private readonly IMeasureunitService _measureunitService;

    public MeasureunitController(IMeasureunitService measureunitService)
    {
        _measureunitService = measureunitService;
    }

    [HttpGet]
    public async Task<IEnumerable<MeasureunitDto>> Get()
    {
        return await _measureunitService.FindAllAsync();
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MeasureunitDto))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorModel))]
    public async Task<Results<NotFound, Ok<MeasureunitDto>>> Get(int id)
    {
        return TypedResults.Ok(await _measureunitService.FindByIdAsync(id));
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(MeasureunitDto))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorModel))]
    public async Task<Results<BadRequest, Ok<MeasureunitDto>>> Post([FromBody] MeasureunitSaveDto measureunitSave)
    {
        return TypedResults.Ok(await _measureunitService.CreateAsync(measureunitSave));
    }

    [HttpPut("{id}")]
    public async Task<MeasureunitDto> Put(int id, [FromBody] MeasureunitSaveDto measureunitSave)
    {
        return await _measureunitService.EditAsync(id, measureunitSave);
    }

    [HttpDelete("{id}")]
    public async Task<MeasureunitDto> Disabled(int id)
    {
        return await _measureunitService.DisabledAsync(id);
    }
}
