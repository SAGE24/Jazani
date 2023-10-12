using Moq;
using AutoFixture;
using AutoMapper;
using Jazani.Application.Generals.Dtos.MineralTypes;
using Jazani.Application.Generals.Services;
using Jazani.Application.Generals.Services.Implementations;
using Jazani.Domain.Generals.Models;
using Jazani.Domain.Generals.Repositories;
using Jazani.Application.Generals.Dtos.MineralTypes.Profiles;
using Microsoft.Extensions.Logging;
using Jazani.Core.Paginations;

namespace Jazani.UniTest.Application.Generals.Services;
public class MineralTypeServiceTest
{
    readonly Mock<IMineralTypeRepository> _mockIMineralTypeRepository;
    readonly IMapper _mapper;
    readonly Mock<ILogger<MineralTypeService>> _logger;
    readonly Fixture _fixture;

    public MineralTypeServiceTest() { 
        _mockIMineralTypeRepository = new();

        MapperConfiguration mapperConfiguration = new(c => {
            c.AddProfile<MineralTypeProfile>();
        });

        _mapper = mapperConfiguration.CreateMapper();
        _logger = new();
        _fixture = new();

        _fixture.Behaviors.Add(new OmitOnRecursionBehavior());
    }

    /*
     * Task<IReadOnlyList<MineralDto>> FindAllAsync();
     * Task<MineralDto> FindByIdAsync(int id);
     * Task<MineralDto> CreateAsync(MineralSaveDto mineralSave);
     * Task<MineralDto> EditAsync(int id, MineralSaveDto mineralSave);
     * Task<MineralDto> DisabledAsync(int id);
     * 
     * A = Arrange - inicializar objetos
     * A = Act - procesar
     * A = Assert - comparar resultados
     * 
     */

    [Fact]
    public async void ReturnMineralDtoFindById()
    {
        //Arrange
        //Fixture fixture = new();
        //fixture.Behaviors.Add(new OmitOnRecursionBehavior());
        MineralType mineralType = _fixture.Create<MineralType>();

        //Mock<ILogger<MineralTypeService>> logger = new();
        //Mock<IMineralTypeRepository> mockIMineralTypeRepository = new();

        _mockIMineralTypeRepository
            .Setup(r => r.FindByIdAsync(It.IsAny<int>()))
            .ReturnsAsync(mineralType);

        //MapperConfiguration mapperConfiguration = new(c => { 
        //    c.AddProfile<MineralTypeProfile>();
        //});

        //IMapper mapper = mapperConfiguration.CreateMapper();

        //Act
        IMineralTypeService mineralTypeService = new MineralTypeService(_mockIMineralTypeRepository.Object, _mapper, _logger.Object);

        MineralTypeDto mineralTypeDto = await mineralTypeService.FindByIdAsync(mineralType.Id);

        //Assert
        Assert.Equal(mineralType.Name, mineralTypeDto.Name);
    }

    [Fact]
    public async void ReturnMineralTypeFindAllAsync() {
        //Arrange
        IReadOnlyList<MineralType> mineralTypes = _fixture.CreateMany<MineralType>(5).ToList();

        _mockIMineralTypeRepository
            .Setup(r => r.FindAllAsync())
            .ReturnsAsync(mineralTypes);

        //Act
        IMineralTypeService mineralTypeService = new MineralTypeService(_mockIMineralTypeRepository.Object, _mapper, _logger.Object);

        IReadOnlyList<MineralTypeDto> mineralTypeDtos = await mineralTypeService.FindAllAsync();

        //Assert
        Assert.Equal(5, mineralTypeDtos.Count);
        Assert.Equal(mineralTypes.Count, mineralTypeDtos.Count);
    }

    [Fact]
    public async void ReturnMinerlTypeCreateAsync() {
        //Arrage
        MineralType mineralType = new() { 
            Id = 1,
            Name = "Metalico",
            Description = "",
            Slug = "M",
            RegistrationDate = DateTime.UtcNow,
            State = true
        };

        _mockIMineralTypeRepository
            .Setup(r => r.SaveAsync(It.IsAny<MineralType>()))
            .ReturnsAsync(mineralType);

        MineralTypeSaveDto mineralTypeSaveDto = new()
        {
            Name = mineralType.Name,
            Description = mineralType.Description,
            Slug = mineralType.Slug
        };

        //Act
        IMineralTypeService mineralTypeService = new MineralTypeService(_mockIMineralTypeRepository.Object, _mapper, _logger.Object);

        MineralTypeDto mineralTypeDto = await mineralTypeService.CreateAsync(mineralTypeSaveDto);

        //Assert
        Assert.Equal(mineralType.Name, mineralTypeDto.Name);
    }

    [Fact]
    public async void ReturnMinerlTypeEditAsync()
    {
        //Arrage
        int id = 1;
        MineralType mineralType = new()
        {
            Id = id,
            Name = "Metalico",
            Description = "",
            Slug = "M",
            RegistrationDate = DateTime.UtcNow,
            State = true
        };

        _mockIMineralTypeRepository
            .Setup(r => r.SaveAsync(It.IsAny<MineralType>()))
            .ReturnsAsync(mineralType);
        _mockIMineralTypeRepository
            .Setup(r => r.FindByIdAsync(It.IsAny<int>()))
            .ReturnsAsync(mineralType);

        MineralTypeSaveDto mineralTypeSaveDto = new()
        {
            Name = mineralType.Name,
            Description = mineralType.Description,
            Slug = mineralType.Slug
        };

        //Act
        IMineralTypeService mineralTypeService = new MineralTypeService(_mockIMineralTypeRepository.Object, _mapper, _logger.Object);

        MineralTypeDto mineralTypeDto = await mineralTypeService.EditAsync(id, mineralTypeSaveDto);

        //Assert
        Assert.Equal(mineralType.Id, mineralTypeDto.Id);
    }

    [Fact]
    public async void ReturnMinerlTypeDisabledAsync()
    {
        //Arrage
        int id = 1;
        MineralType mineralType = new()
        {
            Id = id,
            Name = "Metalico",
            Description = "",
            Slug = "M",
            RegistrationDate = DateTime.UtcNow,
            State = true
        };

        _mockIMineralTypeRepository
            .Setup(r => r.SaveAsync(It.IsAny<MineralType>()))
            .ReturnsAsync(mineralType);
        _mockIMineralTypeRepository
            .Setup(r => r.FindByIdAsync(It.IsAny<int>()))
            .ReturnsAsync(mineralType);

        MineralTypeSaveDto mineralTypeSaveDto = new()
        {
            Name = mineralType.Name,
            Description = mineralType.Description,
            Slug = mineralType.Slug
        };

        //Act
        IMineralTypeService mineralTypeService = new MineralTypeService(_mockIMineralTypeRepository.Object, _mapper, _logger.Object);

        MineralTypeDto mineralTypeDto = await mineralTypeService.DisabledAsync(id);

        //Assert
        Assert.Equal(mineralType.Id, mineralTypeDto.Id);
        Assert.False(mineralTypeDto.State);
    }

    [Fact]
    public async void ReturnMineralTypePaginatedSearch() {
        //Arrage
        RequestPagination<MineralType> request = _fixture.Create<RequestPagination<MineralType>>();
        IReadOnlyList<MineralType> mineralTypes = _fixture.CreateMany<MineralType>(5).ToList();

        ResponsePagination<MineralType> response = new() { 
            Data = mineralTypes,
            PerPage = 5,
            Total = mineralTypes.Count,
            To = 1,
            From = 1,
            CurrentPage = 1
        };

        RequestPagination<MineralTypeFilterDto> requestPagination = new() {
            Filter = null,
            Page = 1,
            PerPage = 5
        };

        _mockIMineralTypeRepository
            .Setup(r => r.PaginatedSearch(It.IsAny<RequestPagination<MineralType>>()))
            .ReturnsAsync(response);

        //Act
        IMineralTypeService mineralTypeService = new MineralTypeService(_mockIMineralTypeRepository.Object, _mapper, _logger.Object);

        ResponsePagination<MineralTypeDto> responsePagination = await mineralTypeService.PaginatedSearch(requestPagination);

        //Assert
        Assert.NotNull(responsePagination);
        Assert.Equal(response.Data.Count, responsePagination.Data.Count);
    }
}
