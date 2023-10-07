using AutoMapper;
using FluentValidation.Internal;
using Jazani.Application.Cores.Exceptions;
using Jazani.Application.Generals.Dtos.MineralTypes;
using Jazani.Core.Paginations;
using Jazani.Domain.Generals.Models;
using Jazani.Domain.Generals.Repositories;
using Microsoft.Extensions.Logging;

namespace Jazani.Application.Generals.Services.Implementations;
public class MineralTypeService : IMineralTypeService
{
    private readonly IMineralTypeRepository _mineralTypeRepository;
    private readonly IMapper _mapper;
    private readonly ILogger<MineralTypeService> _logger;

    public MineralTypeService(IMineralTypeRepository mineralTypeRepository, IMapper mapper, ILogger<MineralTypeService> logger)
    {
        _mineralTypeRepository = mineralTypeRepository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<MineralTypeDto> CreateAsync(MineralTypeSaveDto mineralTypeSave)
    {
        MineralType record = _mapper.Map<MineralType>(mineralTypeSave);
        record.RegistrationDate = DateTime.Now;
        record.State = true;

        MineralType newRecord = await _mineralTypeRepository.SaveAsync(record);

        return _mapper.Map<MineralTypeDto>(newRecord);
    }

    public async Task<MineralTypeDto> DisabledAsync(int id)
    {
        MineralType? record = await SearchRecord(id);
        record.State = false;

        MineralType modifiedRecord = await _mineralTypeRepository.SaveAsync(record);

        return _mapper.Map<MineralTypeDto>(modifiedRecord);
    }

    public async Task<MineralTypeDto> EditAsync(int id, MineralTypeSaveDto mineralTypeSave)
    {
        MineralType? record = await SearchRecord(id);

        _mapper.Map<MineralTypeSaveDto, MineralType>(mineralTypeSave, record);

        MineralType? modifiedRecord = await _mineralTypeRepository.SaveAsync(record);

        return _mapper.Map<MineralTypeDto>(modifiedRecord);
    }

    public async Task<IReadOnlyList<MineralTypeDto>> FindAllAsync()
    {
        return _mapper.Map<IReadOnlyList<MineralTypeDto>>(await _mineralTypeRepository.FindAllAsync());
    }

    public async Task<MineralTypeDto?> FindByIdAsync(int id)
    {
        var record = await SearchRecord(id);

        if (record is null) MineralTypeNotFound(id);

        _logger.LogInformation($"Tipo de mineral {record.Name}");

        return _mapper.Map<MineralTypeDto>(record);
    }

    private async Task<MineralType?> SearchRecord(int id)
    {
        MineralType? record = await _mineralTypeRepository.FindByIdAsync(id);
        return record is null ? throw MineralTypeNotFound(id) : record;
    }

    private NotFoundCoreException MineralTypeNotFound(int id) {
        _logger.LogWarning(message: $"Tipo de mineral no econtrado para el id: {id}");
        return new NotFoundCoreException($"Tipo de mineral no econtrado para el id: {id}");
    }

    public async Task<ResponsePagination<MineralTypeDto>> PaginatedSearch(RequestPagination<MineralTypeFilterDto> request)
    {
        var entity = _mapper.Map<RequestPagination<MineralType>>(request);
        var response = await _mineralTypeRepository.PaginatedSearch(entity);

        return _mapper.Map<ResponsePagination<MineralTypeDto>>(response);
    }
}
