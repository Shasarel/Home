using Home.Configuration;
using Home.Database.Models;
using Home.MeasurementFetcher.Dtos;
using System.Net.Http.Json;

namespace Home.MeasurementFetcher
{
    public static class MeasurementFetcher
    {
        public static async Task<AllMeasurments> GetAllMeasurements()
        {
            var electricityMeasurementTask = GetElectricityMeasurement();
            var meteoMeasurementTask = GetMeteoMeasurement();

            return new AllMeasurments(await electricityMeasurementTask, await meteoMeasurementTask);
        }

        public static async Task<ElectricityMeasurement> GetElectricityMeasurement() =>
            await GetMeasurement<ElectricityMeasurement, IotChiefEnergyResponseDto>(HomeConfig.Default.IoTChiefUrl);

        public static async Task<MeteoMeasurement> GetMeteoMeasurement() =>
            await GetMeasurement<MeteoMeasurement, IoTChiefMeteoResponseDto>(HomeConfig.Default.MeteoUrl);

        internal static async Task<TEntity> GetMeasurement<TEntity, TDto>(string? requestUri) 
            where TEntity : new()
            where TDto : IIoTChiefResponseDataDto<TEntity>
        {
            using var client = new HttpClient();
            var result = await client.GetFromJsonAsync<TDto>(requestUri);

            if (result == null)
                return new TEntity();

            return result.ConvertToEntity();
        }
    }
}