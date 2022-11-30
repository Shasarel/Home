using System.Text.Json.Serialization;

namespace Home.MeasurementFetcher.Dtos
{
    public sealed class InverterDataDto
    {
        [JsonPropertyName("power")]
        public int Power { get; set; }

        [JsonPropertyName("total_energy")]
        public double Energy { get; set; }
    }
}
