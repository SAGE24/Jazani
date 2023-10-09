using Jazani.Api.Exeptions;
using Jazani.Application.Mc.Dtos.Investments;
using Jazani.Application.Mc.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Jazani.Api.Controllers.Mc;

[Route("api/v1/[controller]")]
//[ApiController]
public class InvestmentController : ControllerBase
{
    private readonly IInvestmentService _investmentService;

    public InvestmentController(IInvestmentService investmentService)
    {
        _investmentService = investmentService;
    }

    [HttpGet]
    public async Task<IEnumerable<InvestmentDto>> Get()
    {
        return await _investmentService.FindAllAsync();
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(InvestmentDto))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorModel))]
    public async Task<Results<NotFound, Ok<InvestmentDto>>> Get(int id)
    {
        return TypedResults.Ok(await _investmentService.FindByIdAsync(id));
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(InvestmentDto))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorModel))]
    public async Task<Results<BadRequest, Ok<InvestmentDto>>> Post([FromBody] InvestmentSaveDto mineralTypeSave)
    {
        return TypedResults.Ok(await _investmentService.CreateAsync(mineralTypeSave));
    }

    [HttpPut("{id}")]
    public async Task<InvestmentDto> Put(int id, [FromBody] InvestmentSaveDto mineralTypeSave)
    {
        return await _investmentService.EditAsync(id, mineralTypeSave);
    }

    [HttpDelete("{id}")]
    public async Task<InvestmentDto> Disabled(int id)
    {
        return await _investmentService.DisabledAsync(id);
    }
}
