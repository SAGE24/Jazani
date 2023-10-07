using AutoMapper;
using Jazani.Application.Cores.Exceptions;
using Jazani.Application.Generals.Dtos.PersonTypes;
using Jazani.Domain.Generals.Models;
using Jazani.Domain.Generals.Repositories;

namespace Jazani.Application.Generals.Services.Implementations;
public class PersonTypeService : IPersonTypeService
{
    private readonly IPersonTypeRepository _personTypeRepository;
    private readonly IMapper _mapper;

    public PersonTypeService(IPersonTypeRepository personTypeRepository, IMapper mapper)
    {
        _personTypeRepository = personTypeRepository;
        _mapper = mapper;
    }

    public async Task<IReadOnlyList<PersonTypeDto>> FindAllAsync()
    {
        IReadOnlyList<PersonType> records = await _personTypeRepository.FindAllAsync();

        return _mapper.Map<IReadOnlyList<PersonTypeDto>>(records);
    }

    public async Task<PersonTypeDto> FindByIdAsync(int id)
    {
        var record = await _personTypeRepository.FindByIdAsync(id);

        return (record is null) ? throw MineralTypeNotFound(id) : _mapper.Map<PersonTypeDto>(record);
    }

    private NotFoundCoreException MineralTypeNotFound(int id)
    {
        //_logger.LogWarning(message: $"Tipo de mineral no econtrado para el id: {id}");
        return new NotFoundCoreException($"Tipo de mineral no econtrado para el id: {id}");
    }
}
