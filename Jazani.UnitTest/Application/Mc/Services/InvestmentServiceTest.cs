using AutoFixture;
using AutoMapper;
using Jazani.Application.Mc.Dtos.Investments;
using Jazani.Application.Mc.Dtos.Investments.Profiles;
using Jazani.Application.Mc.Services;
using Jazani.Application.Mc.Services.Implementations;
using Jazani.Core.Paginations;
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

    [Fact]
    public async void ReturnInvestmentDtoCreateAsync() {
        //Arrage
        Investment investment = new() { 
            Id = 31,
            Amountinvestd = 100,
            Year = 2023,
            Description = "Registro creado por Sage, modificado",
            Miningconcessionid = 15,
            Investmenttypeid = 1,
            Currencytypeid = 0,
            Periodtypeid = 1,
            Measureunitid = 1,
            RegistrationDate = DateTime.Now,
            State = true,
            Monthname = "Octubre",
            Monthid = 10,
            Accreditationcode = "",
            Accountantcode = "",
            Holderid = 3,
            Declaredtypeid = 0,
            Documentid = 34146,
            Investmentconceptid = 9,
            Module = true,
            Frecuency = 0,
            Isdac = 0,
            Metrictons = "",
            Declarationdate = DateTime.Now
        };

        _mockIInvestmentRepository
            .Setup(f => f.SaveAsync(It.IsAny<Investment>()))
            .ReturnsAsync(investment);

        InvestmentSaveDto investmentSaveDto = new() { 
            Amountinvestd = investment.Amountinvestd,
            Year = investment.Year,
            Description = investment.Description,
            Miningconcessionid = investment.Miningconcessionid,
            Investmenttypeid = investment.Investmenttypeid,
            Currencytypeid= investment.Currencytypeid,
            Periodtypeid = investment.Periodtypeid,
            Measureunitid = investment.Measureunitid,
            Monthname = investment.Monthname,
            Monthid = investment.Monthid,
            Accreditationcode = investment.Accreditationcode,
            Holderid = investment.Holderid,
            Declaredtypeid  = investment.Declaredtypeid,
            Documentid = investment.Documentid,
            Investmentconceptid = investment.Investmentconceptid,
            Module = investment.Module,
            Frecuency = investment.Frecuency,
            Isdac = investment.Isdac,
            Metrictons = investment.Metrictons,
            Declarationdate = investment.Declarationdate,
        };

        //Act
        IInvestmentService investmentService = new InvestmentService(_mockIInvestmentRepository.Object, _mapper, _logger.Object);
        InvestmentDto investmentDto = await investmentService.CreateAsync(investmentSaveDto);
        
        //Asssert
        Assert.NotNull(investmentDto);
        Assert.Equal(investmentDto.Description, investment.Description);
    }

    [Fact]
    public async void ReturnInvestmentDtoEditAsync() {
        //Arrage
        int id = 31;
        Investment investment = new()
        {
            Id = id,
            Amountinvestd = 100,
            Year = 2023,
            Description = "Registro creado por Sage, modificado",
            Miningconcessionid = 15,
            Investmenttypeid = 1,
            Currencytypeid = 0,
            Periodtypeid = 1,
            Measureunitid = 1,
            RegistrationDate = DateTime.Now,
            State = true,
            Monthname = "Octubre",
            Monthid = 10,
            Accreditationcode = "",
            Accountantcode = "",
            Holderid = 3,
            Declaredtypeid = 0,
            Documentid = 34146,
            Investmentconceptid = 9,
            Module = true,
            Frecuency = 0,
            Isdac = 0,
            Metrictons = "",
            Declarationdate = DateTime.Now
        };

        _mockIInvestmentRepository.Setup(f => f.FindByIdAsync(It.IsAny<int>()))
            .ReturnsAsync(investment);
        _mockIInvestmentRepository.Setup(f => f.SaveAsync(It.IsAny<Investment>()))
            .ReturnsAsync(investment);

        InvestmentSaveDto investmentSaveDto = new()
        {
            Amountinvestd = investment.Amountinvestd,
            Year = investment.Year,
            Description = investment.Description,
            Miningconcessionid = investment.Miningconcessionid,
            Investmenttypeid = investment.Investmenttypeid,
            Currencytypeid = investment.Currencytypeid,
            Periodtypeid = investment.Periodtypeid,
            Measureunitid = investment.Measureunitid,
            Monthname = investment.Monthname,
            Monthid = investment.Monthid,
            Accreditationcode = investment.Accreditationcode,
            Holderid = investment.Holderid,
            Declaredtypeid = investment.Declaredtypeid,
            Documentid = investment.Documentid,
            Investmentconceptid = investment.Investmentconceptid,
            Module = investment.Module,
            Frecuency = investment.Frecuency,
            Isdac = investment.Isdac,
            Metrictons = investment.Metrictons,
            Declarationdate = investment.Declarationdate,
        };

        //Act
        IInvestmentService investmentService = new InvestmentService(_mockIInvestmentRepository.Object, _mapper, _logger.Object);
        InvestmentDto investmentDto = await investmentService.EditAsync(id, investmentSaveDto);

        //Assert
        Assert.NotNull(investmentDto);
        Assert.Equal(investmentDto.Id, investment.Id);
    }

    [Fact]
    public async void ReturnInvestmentDtoDisabledAsync()
    {
        //Arrage
        int id = 31;
        Investment investment = new()
        {
            Id = id,
            Amountinvestd = 100,
            Year = 2023,
            Description = "Registro creado por Sage, modificado",
            Miningconcessionid = 15,
            Investmenttypeid = 1,
            Currencytypeid = 0,
            Periodtypeid = 1,
            Measureunitid = 1,
            RegistrationDate = DateTime.Now,
            State = true,
            Monthname = "Octubre",
            Monthid = 10,
            Accreditationcode = "",
            Accountantcode = "",
            Holderid = 3,
            Declaredtypeid = 0,
            Documentid = 34146,
            Investmentconceptid = 9,
            Module = true,
            Frecuency = 0,
            Isdac = 0,
            Metrictons = "",
            Declarationdate = DateTime.Now
        };

        _mockIInvestmentRepository.Setup(f => f.FindByIdAsync(It.IsAny<int>()))
            .ReturnsAsync(investment);
        _mockIInvestmentRepository.Setup(f => f.SaveAsync(It.IsAny<Investment>()))
            .ReturnsAsync(investment);

        InvestmentSaveDto investmentSaveDto = new()
        {
            Amountinvestd = investment.Amountinvestd,
            Year = investment.Year,
            Description = investment.Description,
            Miningconcessionid = investment.Miningconcessionid,
            Investmenttypeid = investment.Investmenttypeid,
            Currencytypeid = investment.Currencytypeid,
            Periodtypeid = investment.Periodtypeid,
            Measureunitid = investment.Measureunitid,
            Monthname = investment.Monthname,
            Monthid = investment.Monthid,
            Accreditationcode = investment.Accreditationcode,
            Holderid = investment.Holderid,
            Declaredtypeid = investment.Declaredtypeid,
            Documentid = investment.Documentid,
            Investmentconceptid = investment.Investmentconceptid,
            Module = investment.Module,
            Frecuency = investment.Frecuency,
            Isdac = investment.Isdac,
            Metrictons = investment.Metrictons,
            Declarationdate = investment.Declarationdate,
        };

        //Act
        IInvestmentService investmentService = new InvestmentService(_mockIInvestmentRepository.Object, _mapper, _logger.Object);
        InvestmentDto investmentDto = await investmentService.DisabledAsync(id);
        
        //Assert
        Assert.NotNull(investmentDto);
        Assert.Equal(investmentDto.Id, investment.Id);
        Assert.False(investment.State);
    }

    [Fact]
    public async void ReturnMineralTypePaginatedSearch()
    {
        //Arrage
        RequestPagination<Investment> request = _fixture.Create<RequestPagination<Investment>>();
        IReadOnlyList<Investment> investments = _fixture.CreateMany<Investment>(5).ToList();

        ResponsePagination<Investment> response = new()
        {
            Data = investments,
            PerPage = 5,
            Total = investments.Count,
            To = 1,
            From = 1,
            CurrentPage = 1
        };

        RequestPagination<InvestmentFilterDto> requestPagination = new()
        {
            Filter = null,
            Page = 1,
            PerPage = 5
        };

        _mockIInvestmentRepository
            .Setup(r => r.PaginatedSearch(It.IsAny<RequestPagination<Investment>>()))
            .ReturnsAsync(response);

        //Act
        IInvestmentService investmentService = new InvestmentService(_mockIInvestmentRepository.Object, _mapper, _logger.Object);
        ResponsePagination<InvestmentDto> responsePagination = await investmentService.PaginatedSearch(requestPagination);

        //Assert
        Assert.NotNull(responsePagination);
        Assert.Equal(response.Data.Count, responsePagination.Data.Count);
    }
}
