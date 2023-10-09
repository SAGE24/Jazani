using Jazani.Api.Exeptions;
using Jazani.Application.Mc.Dtos.Investmenttypes;
using Jazani.Application.Mc.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Jazani.Api.Controllers.Mc;

[Route("api/[controller]")]
//[ApiController]
public class InvestmenttypeController : ControllerBase
{
    private readonly IInvestmenttypeService _investmenttypeservice;

    public InvestmenttypeController(IInvestmenttypeService investmenttypeservice)
    {
        _investmenttypeservice = investmenttypeservice;
    }

    [HttpGet]
    public async Task<IEnumerable<InvestmenttypeDto>> Get()
    {
        return await _investmenttypeservice.FindAllAsync();
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(InvestmenttypeDto))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorModel))]
    public async Task<Results<NotFound, Ok<InvestmenttypeDto>>> Get(int id)
    {
        return TypedResults.Ok(await _investmenttypeservice.FindByIdAsync(id));
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(InvestmenttypeDto))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorModel))]
    public async Task<Results<BadRequest, Ok<InvestmenttypeDto>>> Post([FromBody] InvestmenttypeSaveDto investmenttypeSave)
    {
        return TypedResults.Ok(await _investmenttypeservice.CreateAsync(investmenttypeSave));
    }

    [HttpPut("{id}")]
    public async Task<InvestmenttypeDto> Put(int id, [FromBody] InvestmenttypeSaveDto investmenttypeSave)
    {
        return await _investmenttypeservice.EditAsync(id, investmenttypeSave);
    }

    [HttpDelete("{id}")]
    public async Task<InvestmenttypeDto> Disabled(int id)
    {
        return await _investmenttypeservice.DisabledAsync(id);
    }
}
