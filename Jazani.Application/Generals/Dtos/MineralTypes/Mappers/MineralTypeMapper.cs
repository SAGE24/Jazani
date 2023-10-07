using AutoMapper;
using Jazani.Core.Paginations;
using Jazani.Domain.Generals.Models;

namespace Jazani.Application.Generals.Dtos.MineralTypes.Mappers;
public class MineralTypeMapper : IMappingAction<RequestPagination<MineralType>, RequestPagination<MineralTypeDto>>
{
    public void Process(RequestPagination<MineralType> source, RequestPagination<MineralTypeDto> destination, ResolutionContext context)
    {
        throw new NotImplementedException();
    }
}
