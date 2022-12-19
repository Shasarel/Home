using Home.Database.Models;

namespace Home.MeasurementFetcher
{
    public sealed class AllMeasurments
    {
        public ElectricityMeasurement ElectricityMeasurement { get; set; }
        public MeteoMeasurement MeteoMeasurement { get; set; }

        public AllMeasurments(ElectricityMeasurement electricityMeasurement, MeteoMeasurement meteoMeasurement)
        {
            ElectricityMeasurement = electricityMeasurement;
            MeteoMeasurement = meteoMeasurement;
        }
    }
}
