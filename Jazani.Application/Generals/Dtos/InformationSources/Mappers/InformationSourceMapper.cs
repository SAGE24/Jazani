using AutoMapper;
using Jazani.Domain.Generals.Models;

namespace Jazani.Application.Generals.Dtos.InformationSources.Mappers;
public class InformationSourceMapper : Profile
{
    public InformationSourceMapper()
    {
        CreateMap<InformationSource, InformationSourceDto>();

        CreateMap<InformationSourceType, InformationSourceTypeSimpleDto>();

        CreateMap<InformationSource, InformationSourceSaveDto>().ReverseMap();
    }
}
