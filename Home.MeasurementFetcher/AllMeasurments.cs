using Home.WebApi.Database.Models;

namespace Home.MeasurementFetcher
{
    public sealed class AllMeasurments
    {
        public ElectricityMeasurement? ElectricityMeasurement { get; set; }
        public MeteoMeasurement? MeteoMeasurement { get; set; }
    }
}
