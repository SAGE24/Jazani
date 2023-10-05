using Jazani.Application.Generals.Dtos.MineralTypes;
using Jazani.Application.Generals.Services;
using Microsoft.AspNetCore.Mvc;

namespace Jazani.Api.Controllers.Generals;

[Route("api/[controller]")]
[ApiController]
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
    public async Task<MineralTypeDto?> Get(int id)
    {
        return await _mineralTypeService.FindByIdAsync(id);
    }

    [HttpPost]
    public async Task<MineralTypeDto> Post([FromBody] MineralTypeSaveDto mineralTypeSave)
    {
        return await _mineralTypeService.CreateAsync(mineralTypeSave);
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
}
