using Home.Configuration;
using Home.WebApi.Database.Models;
using System.Text.Json.Serialization;

namespace Home.MeasurementFetcher.Dtos
{
    public sealed class MeteoDataDto
    {
        [JsonPropertyName("sitemp")]
        public double Temperature { get; set; }

        [JsonPropertyName("bmppress")]
        public double Pressure { get; set; }

        [JsonPropertyName("pms3")]
        public int DustPM10 { get; set; }

        [JsonPropertyName("pms4")]
        public int DustPM25 { get; set; }

        [JsonPropertyName("pms5")]
        public int DustPM100 { get; set; }

        [JsonPropertyName("cold")]
        public bool Cold { get; set; }

        [JsonPropertyName("bmpcon")]
        public bool BmpCon { get; set; }

        [JsonPropertyName("pmscon")]
        public bool PmsCon { get; set; }

        [JsonPropertyName("sicon")]
        public bool SiCon { get; set; }

        public MeteoMeasurement ConvertToEntity() => new()
        {
            Temperature = Temperature,
            Pressure = CalculateRelativePressure(),
            DustPM10 = DustPM10,
            DustPM25 = DustPM25,
            DustPM100 = DustPM100,
            IsDataCorrect = CheckDeviceCondition(),
        };

        private bool CheckDeviceCondition() =>
            !Cold &&
            BmpCon &&
            PmsCon &&
            SiCon;

        private double CalculateRelativePressure()
        {
            var f1 = 0.0065 * HomeConfig.Default.Altitude;
            var f2 = 1.0 - f1 / (f1 + Temperature + 273.15);
            var f3 = Math.Pow(f2, -5.257);
            return Math.Round(Pressure * f3, 1);
        }
    }
}
