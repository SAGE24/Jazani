using AutoFixture;
using AutoMapper;
using Jazani.Application.Mc.Dtos.Investments;
using Jazani.Application.Mc.Dtos.Investmenttypes;
using Jazani.Application.Mc.Dtos.Investmenttypes.Profiles;
using Jazani.Application.Mc.Services;
using Jazani.Application.Mc.Services.Implementations;
using Jazani.Domain.Mc.Models;
using Jazani.Domain.Mc.Repositories;
using Microsoft.Extensions.Logging;
using Moq;

namespace Jazani.UnitTest.Application.Mc.Services;
public class InvestmenttypeServiceTest
{
    readonly Mock<IInvestmenttypeRepository> _mockIInvestmenttypeRepository;
    readonly IMapper _mapper;
    readonly Mock<ILogger<InvestmenttypeService>> _logger;
    readonly Fixture _fixture;

    public InvestmenttypeServiceTest() {
        _mockIInvestmenttypeRepository = new();

        MapperConfiguration mapperConfiguration = new(c => {
            c.AddProfile<InvestmenttypeProfile>();
        });

        _mapper = mapperConfiguration.CreateMapper();
        _logger = new();
        _fixture = new();

        _fixture.Behaviors.Add(new OmitOnRecursionBehavior());
    }

    [Fact]
    public async void ReturnInvestmentTypeDtoFindById()
    {
        //Arrange
        Investmenttype investmentType = _fixture.Create<Investmenttype>();

        _mockIInvestmenttypeRepository
            .Setup(r => r.FindByIdAsync(It.IsAny<int>()))
            .ReturnsAsync(investmentType);

        //Act
        IInvestmenttypeService investmentTypeService = new InvestmenttypeService(_mockIInvestmenttypeRepository.Object, _mapper, _logger.Object);
        InvestmenttypeDto investmentTypeDto = await investmentTypeService.FindByIdAsync(investmentType.Id);

        //Assert
        Assert.Equal(investmentType.Id, investmentTypeDto.Id);
    }

    [Fact]
    public async void ReturnInvestmentTypeDtoFindAllAsync()
    {
        //Arrange
        IReadOnlyList<Investmenttype> investmenttypes = _fixture.CreateMany<Investmenttype>(5).ToList();

        _mockIInvestmenttypeRepository
            .Setup(r => r.FindAllAsync())
            .ReturnsAsync(investmenttypes);

        //Act
        IInvestmenttypeService investmentTypeService = new InvestmenttypeService(_mockIInvestmenttypeRepository.Object, _mapper, _logger.Object);
        IReadOnlyList<InvestmenttypeDto> investmentDtos = await investmentTypeService.FindAllAsync();

        //Assert
        Assert.NotNull(investmentDtos);
        Assert.Equal(investmenttypes.Count, investmentDtos.Count);
    }

    [Fact]
    public async void ReturnInvestmentTypeDtoCreateAsync()
    {
        //Arrage
        Investmenttype investmentType = new()
        {
            Id = 4,
            Name = "prueba",
            Description = "prueba unitaria",
            RegistrationDate = DateTime.Now,
            State = true
        };

        _mockIInvestmenttypeRepository
            .Setup(f => f.SaveAsync(It.IsAny<Investmenttype>()))
            .ReturnsAsync(investmentType);

        InvestmenttypeSaveDto investmentTypeSaveDto = new()
        {
            Name = investmentType.Name,
            Description = investmentType.Description,
        };

        //Act
        IInvestmenttypeService investmentTypeService = new InvestmenttypeService(_mockIInvestmenttypeRepository.Object, _mapper, _logger.Object);
        InvestmenttypeDto investmentTypeDto = await investmentTypeService.CreateAsync(investmentTypeSaveDto);

        //Asssert
        Assert.NotNull(investmentTypeDto);
        Assert.Equal(investmentTypeDto.Name, investmentType.Name);
    }

    [Fact]
    public async void ReturnInvestmentTypeDtoEditAsync()
    {
        //Arrage
        int id = 4;
        Investmenttype investmentType = new()
        {
            Id = id,
            Name = "prueba",
            Description = "prueba unitaria",
            RegistrationDate = DateTime.Now,
            State = true
        };

        _mockIInvestmenttypeRepository.Setup(f => f.FindByIdAsync(It.IsAny<int>()))
            .ReturnsAsync(investmentType);
        _mockIInvestmenttypeRepository.Setup(f => f.SaveAsync(It.IsAny<Investmenttype>()))
            .ReturnsAsync(investmentType);

        InvestmenttypeSaveDto investmentTypeSaveDto = new()
        {
            Name = investmentType.Name,
            Description = investmentType.Description,
        };

        //Act
        IInvestmenttypeService investmentTypeService = new InvestmenttypeService(_mockIInvestmenttypeRepository.Object, _mapper, _logger.Object);
        InvestmenttypeDto investmenttypeDto = await investmentTypeService.EditAsync(id, investmentTypeSaveDto);

        //Assert
        Assert.NotNull(investmenttypeDto);
        Assert.Equal(investmenttypeDto.Id, investmentType.Id);
    }

    [Fact]
    public async void ReturnInvestmentTypeDtoDisabledAsync()
    {
        //Arrage
        int id = 4;
        Investmenttype investmentType = new()
        {
            Id = id,
            Name = "prueba",
            Description = "prueba unitaria",
            RegistrationDate = DateTime.Now,
            State = true
        };

        _mockIInvestmenttypeRepository.Setup(f => f.FindByIdAsync(It.IsAny<int>()))
            .ReturnsAsync(investmentType);
        _mockIInvestmenttypeRepository.Setup(f => f.SaveAsync(It.IsAny<Investmenttype>()))
            .ReturnsAsync(investmentType);

        InvestmenttypeSaveDto investmentTypeSaveDto = new()
        {
            Name = investmentType.Name,
            Description = investmentType.Description,
        };

        //Act
        IInvestmenttypeService investmentTypeService = new InvestmenttypeService(_mockIInvestmenttypeRepository.Object, _mapper, _logger.Object);
        InvestmenttypeDto investmentTypeDto = await investmentTypeService.DisabledAsync(id);

        //Assert
        Assert.NotNull(investmentTypeDto);
        Assert.Equal(investmentTypeDto.Id, investmentType.Id);
        Assert.False(investmentTypeDto.State);
    }
}
