using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Home.WebApi.Database.ValueConverters
{
    internal sealed class DateTimeOffsetDateIntConverter : ValueConverter<DateTimeOffset, int> 
    {
        public DateTimeOffsetDateIntConverter()
            : base(
               v => 766645 - (int)(new DateTime(2100, 01, 01) - v).TotalDays,
               v =>
               new DateTimeOffset(
                   new DateTime(2100, 01, 01).AddDays(v - 766645)))
        {
        }
        /* public DateTimeOffsetDateIntConverter()
             : base(
                   v => Convert.ToInt32($"{v.Year}{v.Month}{v.Day}"),
                   v => 
                   new DateTimeOffset(
                       new DateTime(
                           Convert.ToInt32(v.ToString().Substring(0, 4)),
                           Convert.ToInt32(v.ToString().Substring(4, 2)),
                           Convert.ToInt32(v.ToString().Substring(6, 2)))))
         {
         }*/
    }
}
