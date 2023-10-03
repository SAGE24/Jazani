using AutoMapper;
using Jazani.Domain.Generals.Models;

namespace Jazani.Application.Generals.Dtos.InformationSources.Mappers;
public class InformationSourceSaveMapper : Profile
{
    public InformationSourceSaveMapper() {
        CreateMap < InformationSource, InformationSourceSaveDto>().ReverseMap();
    }
}
