using AutoFixture;
using AutoMapper;
using Jazani.Application.Mc.Dtos.Investments;
using Jazani.Application.Mc.Dtos.Investments.Profiles;
using Jazani.Application.Mc.Services;
using Jazani.Application.Mc.Services.Implementations;
using Jazani.Domain.Mc.Models;
using Jazani.Domain.Mc.Repositories;
using Microsoft.Extensions.Logging;
using Moq;

namespace Jazani.UnitTest.Application.Mc.Services;
public class InvestmentServiceTest
{
    readonly Mock<IInvestmentRepository> _mockIInvestmentRepository;
    readonly IMapper _mapper;
    readonly Mock<ILogger<InvestmentService>> _logger;
    readonly Fixture _fixture;

    public InvestmentServiceTest() {
        _mockIInvestmentRepository = new();

        MapperConfiguration mapperConfiguration = new(c => {
            c.AddProfile<InvestmentProfile>();
        });

        _mapper = mapperConfiguration.CreateMapper();
        _logger = new();
        _fixture = new();

        _fixture.Behaviors.Add(new OmitOnRecursionBehavior());
    }

    [Fact]
    public async void ReturnInvestmentDtoFindById()
    {
        //Arrange
        Investment investment = _fixture.Create<Investment>();

        _mockIInvestmentRepository
            .Setup(r => r.FindByIdAsync(It.IsAny<int>()))
            .ReturnsAsync(investment);

        //Act
        IInvestmentService investmentService = new InvestmentService(_mockIInvestmentRepository.Object, _mapper, _logger.Object);

        InvestmentDto investmentDto = await investmentService.FindByIdAsync(investment.Id);

        //Assert
        Assert.Equal(investment.Id, investmentDto.Id);
    }

    [Fact]
    public async void ReturnInvestmentDtoFindAllAsync()
    {
        //Arrange
        IReadOnlyList<Investment> investments = _fixture.CreateMany<Investment>(5).ToList();

        _mockIInvestmentRepository
            .Setup(r => r.FindAllAsync())
            .ReturnsAsync(investments);

        //Act
        IInvestmentService mineralTypeService = new InvestmentService(_mockIInvestmentRepository.Object, _mapper, _logger.Object);

        IReadOnlyList<InvestmentDto> investmentDtos = await mineralTypeService.FindAllAsync();

        //Assert
        Assert.NotNull(investmentDtos);
        Assert.Equal(investments.Count, investmentDtos.Count);
    }
}
