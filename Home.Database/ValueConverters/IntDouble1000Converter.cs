using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Home.WebApi.Database.ValueConverters
{
    internal sealed class IntDouble1000Converter : ValueConverter<double, int>
    {
        public IntDouble1000Converter()
            :base(
                 v => (int)Math.Round(v * 1000),
                 v => v / 1000.0
            )
        {
        }
    }
}
