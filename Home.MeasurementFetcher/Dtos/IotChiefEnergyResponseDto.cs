using Home.Database.Models;
using System.Text.Json.Serialization;

namespace Home.MeasurementFetcher.Dtos
{
    public sealed class IotChiefEnergyResponseDto : IIoTChiefResponseDataDto<ElectricityMeasurement>
    {
        [JsonPropertyName("energy_data")]
        public EnergyDataDto? EnergyData { get; set; }

        [JsonPropertyName("has_data")]
        public bool HasData { get; set; }

        public ElectricityMeasurement ConvertToEntity() => 
            HasData && EnergyData != null? EnergyData.ConvertToEntity() : new ElectricityMeasurement();
    }
}
