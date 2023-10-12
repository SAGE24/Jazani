using AutoFixture;
using AutoMapper;
using Jazani.Application.Mc.Dtos.Miningconcessions;
using Jazani.Application.Mc.Dtos.Miningconcessions.Profiles;
using Jazani.Application.Mc.Services;
using Jazani.Application.Mc.Services.Implementations;
using Jazani.Domain.Mc.Models;
using Jazani.Domain.Mc.Repositories;
using Microsoft.Extensions.Logging;
using Moq;

namespace Jazani.UnitTest.Application.Mc.Services;
public class MiningconcessionServiceTest
{
    readonly Mock<IMiningconcessionRepository> _mockIMiningconcessionRepository;
    readonly IMapper _mapper;
    readonly Mock<ILogger<MiningconcessionService>> _logger;
    readonly Fixture _fixture;

    public MiningconcessionServiceTest() {
        _mockIMiningconcessionRepository = new();

        MapperConfiguration mapperConfiguration = new(c => {
            c.AddProfile<MiningconcessionProfile>();
        });

        _mapper = mapperConfiguration.CreateMapper();
        _logger = new();
        _fixture = new();

        _fixture.Behaviors.Add(new OmitOnRecursionBehavior());
    }

    [Fact]
    public async void ReturnMiningconcessionDtoFindById()
    {
        //Arrange
        Miningconcession miningconcession = _fixture.Create<Miningconcession>();

        _mockIMiningconcessionRepository
            .Setup(r => r.FindByIdAsync(It.IsAny<int>()))
            .ReturnsAsync(miningconcession);

        //Act
        IMiningconcessionService miningconcessionService = new MiningconcessionService(_mockIMiningconcessionRepository.Object, _mapper, _logger.Object);
        MiningconcessionDto miningconcessionDto = await miningconcessionService.FindByIdAsync(miningconcession.Id);

        //Assert
        Assert.Equal(miningconcessionDto.Id, miningconcession.Id);
    }

    [Fact]
    public async void ReturnMiningconcessionDtoFindAllAsync()
    {
        //Arrange
        IReadOnlyList<Miningconcession> miningconcessions = _fixture.CreateMany<Miningconcession>(5).ToList();

        _mockIMiningconcessionRepository
            .Setup(r => r.FindAllAsync())
            .ReturnsAsync(miningconcessions);

        //Act
        IMiningconcessionService miningconcessionService = new MiningconcessionService(_mockIMiningconcessionRepository.Object, _mapper, _logger.Object);
        IReadOnlyList<MiningconcessionDto> miningconcessionDtos = await miningconcessionService.FindAllAsync();

        //Assert
        Assert.NotNull(miningconcessionDtos);
        Assert.Equal(miningconcessions.Count, miningconcessionDtos.Count);
    }

    [Fact]
    public async void ReturnMiningconcessionDtoCreateAsync()
    {
        //Arrage
        Miningconcession miningconcession = new()
        {
            Id = 4,
            Name = "prueba",
            Description = "prueba unitaria",
            RegistrationDate = DateTime.Now,
            State = true
        };

        _mockIMiningconcessionRepository
            .Setup(f => f.SaveAsync(It.IsAny<Miningconcession>()))
            .ReturnsAsync(miningconcession);

        MiningconcessionSaveDto miningconcessionSaveDto = new()
        {
            Name = miningconcession.Name,
            Description = miningconcession.Description,
        };

        //Act
        IMiningconcessionService miningconcessionService = new MiningconcessionService(_mockIMiningconcessionRepository.Object, _mapper, _logger.Object);
        MiningconcessionDto miningconcessionDto = await miningconcessionService.CreateAsync(miningconcessionSaveDto);

        //Asssert
        Assert.NotNull(miningconcessionDto);
        Assert.Equal(miningconcessionDto.Name, miningconcession.Name);
    }

    [Fact]
    public async void ReturnMiningconcessionDtoEditAsync()
    {
        //Arrage
        int id = 4;
        Miningconcession miningconcession = new()
        {
            Id = id,
            Name = "prueba",
            Description = "prueba unitaria",
            RegistrationDate = DateTime.Now,
            State = true
        };

        _mockIMiningconcessionRepository.Setup(f => f.FindByIdAsync(It.IsAny<int>()))
            .ReturnsAsync(miningconcession);
        _mockIMiningconcessionRepository.Setup(f => f.SaveAsync(It.IsAny<Miningconcession>()))
            .ReturnsAsync(miningconcession);

        MiningconcessionSaveDto miningconcessionSaveDto = new()
        {
            Name = miningconcession.Name,
            Description = miningconcession.Description,
        };

        //Act
        IMiningconcessionService miningconcessionService = new MiningconcessionService(_mockIMiningconcessionRepository.Object, _mapper, _logger.Object);
        MiningconcessionDto miningconcessionDto = await miningconcessionService.EditAsync(id, miningconcessionSaveDto);

        //Assert
        Assert.NotNull(miningconcessionDto);
        Assert.Equal(miningconcessionDto.Id, miningconcession.Id);
    }

    [Fact]
    public async void ReturnMiningconcessionDisabledAsync()
    {
        //Arrage
        int id = 4;
        Miningconcession miningconcession = new()
        {
            Id = id,
            Name = "prueba",
            Description = "prueba unitaria",
            RegistrationDate = DateTime.Now,
            State = true
        };

        _mockIMiningconcessionRepository.Setup(f => f.FindByIdAsync(It.IsAny<int>()))
            .ReturnsAsync(miningconcession);
        _mockIMiningconcessionRepository.Setup(f => f.SaveAsync(It.IsAny<Miningconcession>()))
            .ReturnsAsync(miningconcession);

        MiningconcessionSaveDto miningconcessionSaveDto = new()
        {
            Name = miningconcession.Name,
            Description = miningconcession.Description,
        };

        //Act
        IMiningconcessionService miningconcessionService = new MiningconcessionService(_mockIMiningconcessionRepository.Object, _mapper, _logger.Object);
        MiningconcessionDto miningconcessionDto = await miningconcessionService.DisabledAsync(id);

        //Assert
        Assert.NotNull(miningconcessionDto);
        Assert.Equal(miningconcessionDto.Id, miningconcession.Id);
        Assert.False(miningconcessionDto.State);
    }
}
