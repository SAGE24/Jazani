using Jazani.Application.Admins.Dtos.Offices;
using Jazani.Application.Admins.Services;
using Microsoft.AspNetCore.Mvc;

namespace Jazani.Api.Controllers.Admins;

[Route("api/[controller]")]
[ApiController]
public class OfficeController : ControllerBase
{
    private readonly IOfficeService _officeService;

    public OfficeController(IOfficeService officeService) {
        _officeService = officeService;
    }

    [HttpGet]
    public async Task<IEnumerable<OfficeDTO>> Get() {
        return await _officeService.FindAllAsync();
    }

    [HttpGet("{id}")]
    public async Task<OfficeDTO?> Get(int id) {
        return await _officeService.FindByIdAsync(id);
    }

    [HttpPost]
    public async Task<OfficeDTO> Post(OfficeSaveDto officeSave) {
        return await _officeService.CreateAsync(officeSave);
    }

    [HttpPut]
    public async Task<OfficeDTO> Put(int id, OfficeSaveDto officeSave)
    {
        return await _officeService.EditAsync(id, officeSave);
    }

    [HttpDelete("{id}")]
    public async Task<OfficeDTO> Disabled(int id) { 
        return await _officeService.DisabledAsync(id);
    }
}
