using AutoMapper;
using Jazani.Domain.Mc.Models;

namespace Jazani.Application.Mc.Dtos.Investmenttypes.Profiles;
public class InvestmenttypeProfile : Profile
{
    public InvestmenttypeProfile() { 
        CreateMap<Investmenttype, InvestmenttypeDto>();
        CreateMap<Investmenttype, InvestmenttypeSaveDto>().ReverseMap();
    }
}
