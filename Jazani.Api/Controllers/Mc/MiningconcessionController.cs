using Jazani.Api.Exeptions;
using Jazani.Application.Mc.Dtos.Miningconcessions;
using Jazani.Application.Mc.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Jazani.Api.Controllers.Mc;

[Route("api/[controller]")]
//[ApiController]
public class MiningconcessionController : ControllerBase
{
    private readonly IMiningconcessionService _miningconcessionService;

    public MiningconcessionController(IMiningconcessionService miningconcessionService)
    {
        _miningconcessionService = miningconcessionService;
    }

    [HttpGet]
    public async Task<IEnumerable<MiningconcessionDto>> Get()
    {
        return await _miningconcessionService.FindAllAsync();
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MiningconcessionDto))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorModel))]
    public async Task<Results<NotFound, Ok<MiningconcessionDto>>> Get(int id)
    {
        return TypedResults.Ok(await _miningconcessionService.FindByIdAsync(id));
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(MiningconcessionDto))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorModel))]
    public async Task<Results<BadRequest, Ok<MiningconcessionDto>>> Post([FromBody] MiningconcessionSaveDto miningconcessionSave)
    {
        return TypedResults.Ok(await _miningconcessionService.CreateAsync(miningconcessionSave));
    }

    [HttpPut("{id}")]
    public async Task<MiningconcessionDto> Put(int id, [FromBody] MiningconcessionSaveDto miningconcessionSave)
    {
        return await _miningconcessionService.EditAsync(id, miningconcessionSave);
    }

    [HttpDelete("{id}")]
    public async Task<MiningconcessionDto> Disabled(int id)
    {
        return await _miningconcessionService.DisabledAsync(id);
    }
}
