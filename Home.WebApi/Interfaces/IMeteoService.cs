using Home.WebApi.Dtos.Meteo;

namespace Home.WebApi.Interfaces
{
    public interface IMeteoService
    {
        Task<MeteoDto> GetCurrentData();
        MeteoChartDataDto GetMeteoChartData(DateTimeOffset from, DateTimeOffset to);
    }
}
