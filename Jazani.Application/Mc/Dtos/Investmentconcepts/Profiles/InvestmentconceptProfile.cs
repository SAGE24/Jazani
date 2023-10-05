using AutoMapper;
using Jazani.Domain.Mc.Models;

namespace Jazani.Application.Mc.Dtos.Investmentconcepts.Profiles;
public class InvestmentconceptProfile : Profile
{
    public InvestmentconceptProfile() {
        CreateMap<Investmentconcept, InvestmentconceptDto>();
        CreateMap<Investmentconcept, InvestmentconceptSaveDto>().ReverseMap();
    }
}
