using Home.Database.Models;
using System.Text.Json.Serialization;

namespace Home.MeasurementFetcher.Dtos
{
    public sealed class IoTChiefMeteoResponseDto : IIoTChiefResponseDataDto<MeteoMeasurement>
    {
        [JsonPropertyName("meteo_data")]
        public MeteoDataDto? MeteoData { get; set; }

        [JsonPropertyName("has_data")]
        public bool HasData { get; set; }

        public MeteoMeasurement ConvertToEntity() => 
            HasData && MeteoData != null ? MeteoData.ConvertToEntity() : new MeteoMeasurement();
    }
}
