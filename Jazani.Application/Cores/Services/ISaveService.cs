namespace Jazani.Application.Cores.Services;
public interface ISaveService<TDto, TSaveDto, ID>
{
    Task<TDto> CreateAsync(TSaveDto mineralSave);

    Task<TDto> EditAsync(ID id, TSaveDto mineralSave);
}
