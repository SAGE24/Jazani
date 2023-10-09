using AutoMapper;
using Jazani.Domain.Generals.Models;

namespace Jazani.Application.Generals.Dtos.Measureunits.Profiles;
public class MeasureunitProfile : Profile
{
    public MeasureunitProfile() {
        CreateMap<Measureunit, MeasureunitDto>();
        CreateMap<Measureunit, MeasureunitSaveDto>().ReverseMap();
    }
}
