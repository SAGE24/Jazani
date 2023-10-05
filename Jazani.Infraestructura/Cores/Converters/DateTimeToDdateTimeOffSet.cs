using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Jazani.Infraestructure.Cores.Converters;
public class DateTimeToDdateTimeOffSet : ValueConverter<DateTime, DateTimeOffset>
{
    public DateTimeToDdateTimeOffSet() : base(
        datetime => DateTimeOffset.UtcNow,
        dateTimeOffSet => dateTimeOffSet.DateTime
        ) 
    { }
}
