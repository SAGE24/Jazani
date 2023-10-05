using Jazani.Application.Generals.Dtos.Minerals;
using Jazani.Application.Generals.Services;
using Microsoft.AspNetCore.Mvc;

namespace Jazani.Api.Controllers.Generals;

[Route("api/[controller]")]
[ApiController]
public class MineralController : ControllerBase
{
    private readonly IMineralService _mineralService;

    public MineralController(IMineralService mineralService)
    {
        _mineralService = mineralService;
    }

    [HttpGet]
    public async Task<IEnumerable<MineralDto>> Get()
    {
        return await _mineralService.FindAllAsync();
    }

    [HttpGet("{id}")]
    public async Task<MineralDto?> Get(int id)
    {
        return await _mineralService.FindByIdAsync(id);
    }

    [HttpPost]
    public async Task<MineralDto> Post([FromBody] MineralSaveDto mineralTypeSave)
    {
        return await _mineralService.CreateAsync(mineralTypeSave);
    }

    [HttpPut("{id}")]
    public async Task<MineralDto> Put(int id, [FromBody] MineralSaveDto mineralTypeSave)
    {
        return await _mineralService.EditAsync(id, mineralTypeSave);
    }

    [HttpDelete("{id}")]
    public async Task<MineralDto> Disabled(int id)
    {
        return await _mineralService.DisabledAsync(id);
    }
}
