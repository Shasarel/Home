using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Home.WebApi.Database.ValueConverters
{
    public class DateTimeOffsetTimestampConverter : ValueConverter<DateTimeOffset, long> 
    {
        public DateTimeOffsetTimestampConverter() 
            : base(
                  v => v.ToUnixTimeSeconds(),
                  v => DateTimeOffset.FromUnixTimeSeconds(v))
        {
        }
    }
}
