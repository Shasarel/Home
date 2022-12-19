using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Home.Database.ValueConverters
{
    internal sealed class DateTimeOffsetTimestampConverter : ValueConverter<DateTimeOffset, long> 
    {
        public DateTimeOffsetTimestampConverter() 
            : base(
                  v => v.ToUnixTimeSeconds(),
                  v => DateTimeOffset.FromUnixTimeSeconds(v))
        {
        }
    }
}
