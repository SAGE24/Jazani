using AutoMapper;
using Jazani.Domain.Generals.Models;
using Jazani.Domain.Mc.Models;
using Jazani.Domain.Soc.Models;

namespace Jazani.Application.Mc.Dtos.Investments.Profiles;
public class InvestmentProfile : Profile
{
    public InvestmentProfile() {
        CreateMap<Investment, InvestmentDto>();

        CreateMap<Investmentconcept, InvestmentConceptSimpleDto>();
        CreateMap<Holder, InvestmentHolderSimpleDto>();
        CreateMap<Investmenttype, InvestmentInvestmentTypeSimpleDto>();
        CreateMap<Miningconcession, InvestmentMiningconcessionSimpleDto>();
        CreateMap<Measureunit, InvestmentMeasureunitSimpleDto>();
        CreateMap<Periodtype, InvestmentPeriodtypeSimpleDto>();

        CreateMap<Investment, InvestmentSaveDto>().ReverseMap();
    }
}
