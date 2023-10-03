using AutoMapper;
using Jazani.Domain.Generals.Models;

namespace Jazani.Application.Generals.Dtos.InformationSourceTypes.Mappers;
public class InformationSourceTypeSaveMapper : Profile
{
    public InformationSourceTypeSaveMapper() {
        CreateMap<InformationSourceType, InformationSourceTypeSaveDto>().ReverseMap();
    }
}
