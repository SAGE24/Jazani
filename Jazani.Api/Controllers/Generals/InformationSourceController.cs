using Jazani.Application.Generals.Dtos.InformationSources;
using Jazani.Application.Generals.Services;
using Microsoft.AspNetCore.Mvc;

namespace Jazani.Api.Controllers.Generals;

[Route("api/v1/[controller]")]
[ApiController]
public class InformationSourceController : ControllerBase
{
    private readonly IInformationSourceService _informationSourceService;

    public InformationSourceController(IInformationSourceService informationSourceService)
    {
        _informationSourceService = informationSourceService;
    }

    [HttpGet]
    public async Task<IEnumerable<InformationSourceDto>> Get()
    {
        return await _informationSourceService.FindAllAsync();
    }

    [HttpGet("{id}")]
    public async Task<InformationSourceDto?> Get(int id)
    {
        return await _informationSourceService.FindByIdAsync(id);
    }

    [HttpPost]
    public async Task<InformationSourceDto> Post(InformationSourceSaveDto officeSave)
    {
        return await _informationSourceService.CreateAsync(officeSave);
    }

    [HttpPut]
    public async Task<InformationSourceDto> Put(int id, InformationSourceSaveDto officeSave)
    {
        return await _informationSourceService.EditAsync(id, officeSave);
    }

    [HttpDelete("{id}")]
    public async Task<InformationSourceDto> Disabled(int id)
    {
        return await _informationSourceService.DisabledAsync(id);
    }
}
