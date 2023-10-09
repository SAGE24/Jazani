using Jazani.Api.Exeptions;
using Jazani.Application.Mc.Dtos.Investmentconcepts;
using Jazani.Application.Mc.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Jazani.Api.Controllers.Mc;

[Route("api/v1/[controller]")]
//[ApiController]
public class InvestmentconceptController : ControllerBase
{
    private readonly IInvestmentconceptService _investmentconceptService;

    public InvestmentconceptController(IInvestmentconceptService investmentconceptService)
    {
        _investmentconceptService = investmentconceptService;
    }

    [HttpGet]
    public async Task<IEnumerable<InvestmentconceptDto>> Get()
    {
        return await _investmentconceptService.FindAllAsync();
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(InvestmentconceptDto))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorModel))]
    public async Task<Results<NotFound, Ok<InvestmentconceptDto>>> Get(int id)
    {
        return TypedResults.Ok(await _investmentconceptService.FindByIdAsync(id));
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(InvestmentconceptDto))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorModel))]
    public async Task<Results<BadRequest, Ok<InvestmentconceptDto>>> Post([FromBody] InvestmentconceptSaveDto mineralTypeSave)
    {
        return TypedResults.Ok(await _investmentconceptService.CreateAsync(mineralTypeSave));
    }

    [HttpPut("{id}")]
    public async Task<InvestmentconceptDto> Put(int id, [FromBody] InvestmentconceptSaveDto mineralTypeSave)
    {
        return await _investmentconceptService.EditAsync(id, mineralTypeSave);
    }

    [HttpDelete("{id}")]
    public async Task<InvestmentconceptDto> Disabled(int id)
    {
        return await _investmentconceptService.DisabledAsync(id);
    }
}
