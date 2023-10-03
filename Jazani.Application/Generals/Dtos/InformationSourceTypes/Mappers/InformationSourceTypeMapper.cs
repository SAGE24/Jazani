using AutoMapper;
using Jazani.Domain.Generals.Models;

namespace Jazani.Application.Generals.Dtos.InformationSourceTypes.Mappers;
public class InformationSourceTypeMapper : Profile
{
    public InformationSourceTypeMapper() {
        CreateMap<InformationSourceType, InformationSourceTypeDto>();
    }
}
