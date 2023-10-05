using Jazani.Application.Mc.Dtos.Investments;
using Jazani.Application.Mc.Services;
using Microsoft.AspNetCore.Mvc;

namespace Jazani.Api.Controllers.Mc;

[Route("api/v1/[controller]")]
[ApiController]
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
    public async Task<InvestmentDto?> Get(int id)
    {
        return await _investmentService.FindByIdAsync(id);
    }

    [HttpPost]
    public async Task<InvestmentDto> Post([FromBody] InvestmentSaveDto mineralTypeSave)
    {
        return await _investmentService.CreateAsync(mineralTypeSave);
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
