using Home.MeasurementFetcher.Dtos;
using Home.WebApi.Database.Models;
using System.Text.Json.Serialization;

namespace Home.MeasurementFetcher.Dtos
{
    public sealed class EnergyDataDto
    {
        [JsonPropertyName("flara_data")]
        public InverterDataDto? FlaraData { get; set; }

        [JsonPropertyName("deye_data")]
        public InverterDataDto? DeyeData { get; set; }

        [JsonPropertyName("power_import")]
        public int PowerImport { get; set; }

        [JsonPropertyName("power_export")]
        public int PowerExport { get; set; }

        [JsonPropertyName("energy_import")]
        public double EnergyImport { get; set; }

        [JsonPropertyName("energy_export")]
        public double EnergyExport { get; set; }

        public ElectricityMeasurement ConvertToEntity() => new ()
        {
            EnergyProduction = FlaraData!.Energy,
            EnergyProductionDeye = DeyeData!.Energy,
            EnergyImport = EnergyImport,
            EnergyExport = EnergyExport,
            PowerProduction = FlaraData.Power,
            PowerProductionDeye = DeyeData.Power,
            PowerImport = PowerImport,
            PowerExport = PowerExport,
            Correct = true,
        };
}
}
