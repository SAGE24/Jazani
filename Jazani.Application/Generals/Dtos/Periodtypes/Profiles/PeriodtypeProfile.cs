using AutoMapper;
using Jazani.Domain.Generals.Models;

namespace Jazani.Application.Generals.Dtos.Periodtypes.Profiles;
public class PeriodtypeProfile : Profile
{
    public PeriodtypeProfile() {
        CreateMap<Periodtype, PeriodtypeDto>();
        CreateMap<Periodtype, PeriodtypeSaveDto>().ReverseMap();
    }
}
