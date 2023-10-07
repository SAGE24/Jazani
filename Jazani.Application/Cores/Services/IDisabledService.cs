namespace Jazani.Application.Cores.Services;
public interface IDisabledService<TDto, ID>
{
    Task<TDto> DisabledAsync(ID id);
}
