using AutoMapper;
using Jazani.Domain.Mc.Models;

namespace Jazani.Application.Mc.Dtos.Miningconcessions.Profiles;
public class MiningconcessionProfile : Profile
{
    public MiningconcessionProfile() {
        CreateMap<Miningconcession, MiningconcessionDto>();
        CreateMap<Miningconcession, MiningconcessionSaveDto>().ReverseMap();
    }
}
