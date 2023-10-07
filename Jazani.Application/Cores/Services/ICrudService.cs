namespace Jazani.Application.Cores.Services;
public interface ICrudService<TDto, TSaveDto, ID> : 
    IQueryService<TDto, ID>,
    ISaveService<TDto, TSaveDto, ID>,
    IDisabledService<TDto, ID>
{
    //Task<IReadOnlyList<TDto>> FindAllAsync();

    //Task<TDto> FindByIdAsync(ID id);

    //Task<TDto> CreateAsync(TSaveDto mineralSave);

    //Task<TDto> EditAsync(ID id, TSaveDto mineralSave);

    //Task<TDto> DisabledAsync(ID id);
}
