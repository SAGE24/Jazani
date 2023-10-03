using Jazani.Application.Generals.Dtos.InformationSourceTypes;
using Jazani.Application.Generals.Services;
using Microsoft.AspNetCore.Mvc;

namespace Jazani.Api.Controllers.Generals;

[Route("api/v1/[controller]")]
[ApiController]
public class InformationSourceTypeController : ControllerBase
{
    private readonly IInformationSourceTypeService _informationSourceTypeService;

    public InformationSourceTypeController(IInformationSourceTypeService informationSourceTypeService)
    {
        _informationSourceTypeService = informationSourceTypeService;
    }

    [HttpGet]
    public async Task<IEnumerable<InformationSourceTypeDto>> Get()
    {
        return await _informationSourceTypeService.FindAllAsync();
    }

    [HttpGet("{id}")]
    public async Task<InformationSourceTypeDto?> Get(int id)
    {
        return await _informationSourceTypeService.FindByIdAsync(id);
    }

    [HttpPost]
    public async Task<InformationSourceTypeDto> Post(InformationSourceTypeSaveDto officeSave)
    {
        return await _informationSourceTypeService.CreateAsync(officeSave);
    }

    [HttpPut]
    public async Task<InformationSourceTypeDto> Put(int id, InformationSourceTypeSaveDto officeSave)
    {
        return await _informationSourceTypeService.EditAsync(id, officeSave);
    }

    [HttpDelete("{id}")]
    public async Task<InformationSourceTypeDto> Disabled(int id)
    {
        return await _informationSourceTypeService.DisabledAsync(id);
    }
}
