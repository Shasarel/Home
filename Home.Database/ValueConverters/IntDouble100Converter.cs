using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Home.WebApi.Database.ValueConverters
{
    public class IntDouble100Converter : ValueConverter<double, int>
    {
        public IntDouble100Converter()
            :base(
                 v => (int)Math.Round(v * 100),
                 v => v / 100.0)
        {
        }
    }
}
