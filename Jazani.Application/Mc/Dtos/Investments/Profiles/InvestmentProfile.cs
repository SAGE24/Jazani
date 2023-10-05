using AutoMapper;
using Jazani.Domain.Mc.Models;

namespace Jazani.Application.Mc.Dtos.Investments.Profiles;
public class InvestmentProfile : Profile
{
    public InvestmentProfile() {
        CreateMap<Investment, InvestmentDto>();

        CreateMap<Investmentconcept, InvestmentConceptSimpleDto>();

        CreateMap<Investment, InvestmentSaveDto>().ReverseMap();
    }
}
